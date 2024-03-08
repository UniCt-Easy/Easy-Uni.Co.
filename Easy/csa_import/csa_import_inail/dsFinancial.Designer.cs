
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
namespace csa_import_inail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsFinancial"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsFinancial: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseyear 		=> Tables["expenseyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensetax 		=> Tables["expensetax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseclawback 		=> Tables["expenseclawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensesorted 		=> Tables["expensesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeyear 		=> Tables["incomeyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomesorted 		=> Tables["incomesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income 		=> Tables["income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselast 		=> Tables["expenselast"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomelast 		=> Tables["incomelast"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_import_expense 		=> Tables["csa_import_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_import_income 		=> Tables["csa_import_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwritingpayment 		=> Tables["underwritingpayment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwritingappropriation 		=> Tables["underwritingappropriation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwritingappropriationview 		=> Tables["underwritingappropriationview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partition_expense 		=> Tables["csa_importver_partition_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partition_income 		=> Tables["csa_importver_partition_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partition_expense 		=> Tables["csa_importriep_partition_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partition_income 		=> Tables["csa_importriep_partition_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensebill 		=> Tables["expensebill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomebill 		=> Tables["incomebill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensevar 		=> Tables["expensevar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomevar 		=> Tables["incomevar"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsFinancial(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsFinancial (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsFinancial";
	Prefix = "";
	Namespace = "http://tempuri.org/dsFinancial.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// EXPENSEYEAR /////////////////////////////////
	var texpenseyear= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	texpenseyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	texpenseyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	Tables.Add(texpenseyear);
	texpenseyear.PrimaryKey =  new DataColumn[]{texpenseyear.Columns["ayear"], texpenseyear.Columns["idexp"]};


	//////////////////// EXPENSETAX /////////////////////////////////
	var texpensetax= new DataTable("expensetax");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(int));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	texpensetax.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("competencydate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	texpensetax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("exemptionquota", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	texpensetax.Columns.Add( new DataColumn("ntaxpay", typeof(int)));
	texpensetax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("ytaxpay", typeof(short)));
	Tables.Add(texpensetax);
	texpensetax.PrimaryKey =  new DataColumn[]{texpensetax.Columns["taxcode"], texpensetax.Columns["idexp"], texpensetax.Columns["nbracket"]};


	//////////////////// EXPENSECLAWBACK /////////////////////////////////
	var texpenseclawback= new DataTable("expenseclawback");
	C= new DataColumn("idclawback", typeof(int));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	texpenseclawback.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	Tables.Add(texpenseclawback);
	texpenseclawback.PrimaryKey =  new DataColumn[]{texpenseclawback.Columns["idexp"], texpenseclawback.Columns["idclawback"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
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


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new DataTable("expensesorted");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("description", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	texpensesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	texpensesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpensesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("originalamount", typeof(decimal)));
	Tables.Add(texpensesorted);
	texpensesorted.PrimaryKey =  new DataColumn[]{texpensesorted.Columns["idexp"], texpensesorted.Columns["idsor"], texpensesorted.Columns["idsubclass"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// INCOMEYEAR /////////////////////////////////
	var tincomeyear= new DataTable("incomeyear");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	tincomeyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	tincomeyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	Tables.Add(tincomeyear);
	tincomeyear.PrimaryKey =  new DataColumn[]{tincomeyear.Columns["idinc"], tincomeyear.Columns["ayear"]};


	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new DataTable("incomesorted");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("description", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tincomesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	tincomesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tincomesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("originalamount", typeof(decimal)));
	Tables.Add(tincomesorted);
	tincomesorted.PrimaryKey =  new DataColumn[]{tincomesorted.Columns["idinc"], tincomesorted.Columns["idsor"], tincomesorted.Columns["idsubclass"]};


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
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// INCOME /////////////////////////////////
	var tincome= new DataTable("income");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("doc", typeof(string)));
	tincome.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tincome.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("idpayment", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	tincome.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincome.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(tincome);
	tincome.PrimaryKey =  new DataColumn[]{tincome.Columns["idinc"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("assetload_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("currpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredexpensephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredincomephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronicimport", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronictrasmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("expense_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("expensephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("foreignhours", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_customer", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_patrimony", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_pl", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_supplier", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_foot", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincomesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("importappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("income_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("incomephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("minpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("motivelen", typeof(short)));
	tconfig.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	tconfig.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	tconfig.Columns.Add( new DataColumn("payment_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


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
	texpenselast.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
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
	texpenselast.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(texpenselast);
	texpenselast.PrimaryKey =  new DataColumn[]{texpenselast.Columns["idexp"]};


	//////////////////// INCOMELAST /////////////////////////////////
	var tincomelast= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomelast.Columns.Add( new DataColumn("idacccredit", typeof(string)));
	Tables.Add(tincomelast);
	tincomelast.PrimaryKey =  new DataColumn[]{tincomelast.Columns["idinc"]};


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
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nphase", typeof(byte)));
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
	texpenseview.PrimaryKey =  new DataColumn[]{texpenseview.Columns["idexp"], texpenseview.Columns["ayear"]};


	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("nphase", typeof(byte)));
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
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"], tincomeview.Columns["ayear"]};


	//////////////////// CSA_IMPORT_EXPENSE /////////////////////////////////
	var tcsa_import_expense= new DataTable("csa_import_expense");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_import_expense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_import_expense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_import_expense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_import_expense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tcsa_import_expense.Columns.Add(C);
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_import_expense.Columns.Add(C);
	C= new DataColumn("movkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_import_expense.Columns.Add(C);
	Tables.Add(tcsa_import_expense);
	tcsa_import_expense.PrimaryKey =  new DataColumn[]{tcsa_import_expense.Columns["idexp"], tcsa_import_expense.Columns["idcsa_import"]};


	//////////////////// CSA_IMPORT_INCOME /////////////////////////////////
	var tcsa_import_income= new DataTable("csa_import_income");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_import_income.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_import_income.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_import_income.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_import_income.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcsa_import_income.Columns.Add(C);
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_import_income.Columns.Add(C);
	C= new DataColumn("movkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_import_income.Columns.Add(C);
	Tables.Add(tcsa_import_income);
	tcsa_import_income.PrimaryKey =  new DataColumn[]{tcsa_import_income.Columns["idinc"], tcsa_import_income.Columns["idcsa_import"]};


	//////////////////// UNDERWRITINGPAYMENT /////////////////////////////////
	var tunderwritingpayment= new DataTable("underwritingpayment");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	Tables.Add(tunderwritingpayment);
	tunderwritingpayment.PrimaryKey =  new DataColumn[]{tunderwritingpayment.Columns["idunderwriting"], tunderwritingpayment.Columns["idexp"]};


	//////////////////// UNDERWRITINGAPPROPRIATION /////////////////////////////////
	var tunderwritingappropriation= new DataTable("underwritingappropriation");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	Tables.Add(tunderwritingappropriation);
	tunderwritingappropriation.PrimaryKey =  new DataColumn[]{tunderwritingappropriation.Columns["idunderwriting"], tunderwritingappropriation.Columns["idexp"]};


	//////////////////// UNDERWRITINGAPPROPRIATIONVIEW /////////////////////////////////
	var tunderwritingappropriationview= new DataTable("underwritingappropriationview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("expensephase", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	tunderwritingappropriationview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("registry", typeof(string)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("idman", typeof(int)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("manager", typeof(string)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("doc", typeof(string)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	tunderwritingappropriationview.Columns.Add( new DataColumn("codeunderwriting", typeof(string)));
	C= new DataColumn("underwriting", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	tunderwritingappropriationview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("fin", typeof(string)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tunderwritingappropriationview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingappropriationview.Columns.Add(C);
	Tables.Add(tunderwritingappropriationview);
	tunderwritingappropriationview.PrimaryKey =  new DataColumn[]{tunderwritingappropriationview.Columns["idexp"], tunderwritingappropriationview.Columns["idunderwriting"]};


	//////////////////// CSA_IMPORTVER_PARTITION_EXPENSE /////////////////////////////////
	var tcsa_importver_partition_expense= new DataTable("csa_importver_partition_expense");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_expense.Columns.Add(C);
	C= new DataColumn("idver", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_expense.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_expense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_expense.Columns.Add(C);
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("movkind", typeof(int)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("originalamount", typeof(decimal)));
	Tables.Add(tcsa_importver_partition_expense);
	tcsa_importver_partition_expense.PrimaryKey =  new DataColumn[]{tcsa_importver_partition_expense.Columns["idcsa_import"], tcsa_importver_partition_expense.Columns["idver"], tcsa_importver_partition_expense.Columns["ndetail"], tcsa_importver_partition_expense.Columns["idexp"]};


	//////////////////// CSA_IMPORTVER_PARTITION_INCOME /////////////////////////////////
	var tcsa_importver_partition_income= new DataTable("csa_importver_partition_income");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_income.Columns.Add(C);
	C= new DataColumn("idver", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_income.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_income.Columns.Add(C);
	tcsa_importver_partition_income.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("movkind", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_income.Columns.Add(C);
	tcsa_importver_partition_income.Columns.Add( new DataColumn("originalamount", typeof(decimal)));
	Tables.Add(tcsa_importver_partition_income);
	tcsa_importver_partition_income.PrimaryKey =  new DataColumn[]{tcsa_importver_partition_income.Columns["idcsa_import"], tcsa_importver_partition_income.Columns["idver"], tcsa_importver_partition_income.Columns["ndetail"], tcsa_importver_partition_income.Columns["idinc"]};


	//////////////////// CSA_IMPORTRIEP_PARTITION_EXPENSE /////////////////////////////////
	var tcsa_importriep_partition_expense= new DataTable("csa_importriep_partition_expense");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_expense.Columns.Add(C);
	C= new DataColumn("idriep", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_expense.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_expense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_expense.Columns.Add(C);
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("movkind", typeof(int)));
	Tables.Add(tcsa_importriep_partition_expense);
	tcsa_importriep_partition_expense.PrimaryKey =  new DataColumn[]{tcsa_importriep_partition_expense.Columns["idcsa_import"], tcsa_importriep_partition_expense.Columns["idriep"], tcsa_importriep_partition_expense.Columns["ndetail"], tcsa_importriep_partition_expense.Columns["idexp"]};


	//////////////////// CSA_IMPORTRIEP_PARTITION_INCOME /////////////////////////////////
	var tcsa_importriep_partition_income= new DataTable("csa_importriep_partition_income");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_income.Columns.Add(C);
	C= new DataColumn("idriep", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_income.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_income.Columns.Add(C);
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("movkind", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_income.Columns.Add(C);
	Tables.Add(tcsa_importriep_partition_income);
	tcsa_importriep_partition_income.PrimaryKey =  new DataColumn[]{tcsa_importriep_partition_income.Columns["idcsa_import"], tcsa_importriep_partition_income.Columns["idriep"], tcsa_importriep_partition_income.Columns["ndetail"], tcsa_importriep_partition_income.Columns["idinc"]};


	//////////////////// EXPENSEBILL /////////////////////////////////
	var texpensebill= new DataTable("expensebill");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	Tables.Add(texpensebill);
	texpensebill.PrimaryKey =  new DataColumn[]{texpensebill.Columns["idexp"], texpensebill.Columns["ybill"], texpensebill.Columns["nbill"]};


	//////////////////// INCOMEBILL /////////////////////////////////
	var tincomebill= new DataTable("incomebill");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	Tables.Add(tincomebill);
	tincomebill.PrimaryKey =  new DataColumn[]{tincomebill.Columns["idinc"], tincomebill.Columns["ybill"], tincomebill.Columns["nbill"]};


	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new DataTable("expensevar");
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	texpensevar.Columns.Add( new DataColumn("yvar", typeof(short)));
	texpensevar.Columns.Add( new DataColumn("description", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensevar.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpensevar.Columns.Add( new DataColumn("cu", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("lu", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensevar.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("yinv", typeof(short)));
	texpensevar.Columns.Add( new DataColumn("ninv", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	Tables.Add(texpensevar);
	texpensevar.PrimaryKey =  new DataColumn[]{texpensevar.Columns["nvar"], texpensevar.Columns["idexp"]};


	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new DataTable("incomevar");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomevar.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("txt", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomevar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("ninv", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("yinv", typeof(short)));
	Tables.Add(tincomevar);
	tincomevar.PrimaryKey =  new DataColumn[]{tincomevar.Columns["idinc"], tincomevar.Columns["nvar"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{expense.Columns["idexp"]};
	var cChild = new []{expense.Columns["parentidexp"]};
	Relations.Add(new DataRelation("expenseexpense",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("income_income",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{underwritingappropriation.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_underwritingappropriation",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{underwritingpayment.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_underwritingpayment",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{csa_import_income.Columns["idinc"]};
	Relations.Add(new DataRelation("income_csa_import_income",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{csa_import_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_csa_import_expense",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselast",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{income.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_income",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{income.Columns["idpayment"]};
	Relations.Add(new DataRelation("expense_income",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{expense.Columns["idreg"]};
	Relations.Add(new DataRelation("registryexpense",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomesorted.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomesorted",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomeyear",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensesorted.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensesorted",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseclawback.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseclawback",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensetax.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensetax",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{expenseyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finexpenseyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{expenseyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbexpenseyear",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseyear.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseyear",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{csa_importver_partition_income.Columns["idinc"]};
	Relations.Add(new DataRelation("income_csa_importver_partition_income",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{csa_importriep_partition_income.Columns["idinc"]};
	Relations.Add(new DataRelation("income_csa_importriep_partition_income",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{csa_importver_partition_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_csa_importver_partition_expense",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{csa_importriep_partition_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_csa_importriep_partition_expense",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensebill.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expensebill",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomebill.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomebill",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensevar.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expensevar",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomevar.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomevar",cPar,cChild,false));

	#endregion

}
}
}
