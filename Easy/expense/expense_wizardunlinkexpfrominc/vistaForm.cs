
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
namespace expense_wizardunlinkexpfrominc {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income 		=> Tables["income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin_income 		=> Tables["fin_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_income 		=> Tables["upb_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager_income 		=> Tables["manager_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselastview 		=> Tables["expenselastview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomelastview 		=> Tables["incomelastview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeyear 		=> Tables["incomeyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseyear 		=> Tables["expenseyear"];

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


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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
	tincome.Columns.Add( new DataColumn("idpayment", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("idman", typeof(int)));
	tincome.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincome.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(tincome);
	tincome.PrimaryKey =  new DataColumn[]{tincome.Columns["idinc"]};


	//////////////////// FIN_INCOME /////////////////////////////////
	var tfin_income= new DataTable("fin_income");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	tfin_income.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	tfin_income.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	tfin_income.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin_income.Columns.Add(C);
	Tables.Add(tfin_income);
	tfin_income.PrimaryKey =  new DataColumn[]{tfin_income.Columns["idfin"]};


	//////////////////// UPB_INCOME /////////////////////////////////
	var tupb_income= new DataTable("upb_income");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	tupb_income.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_income.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	tupb_income.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_income.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	tupb_income.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_income.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_income.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	tupb_income.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_income.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_income.Columns.Add(C);
	tupb_income.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_income.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_income.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	Tables.Add(tupb_income);
	tupb_income.PrimaryKey =  new DataColumn[]{tupb_income.Columns["idupb"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


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
	tincomeview.Columns.Add( new DataColumn("kpro", typeof(int)));
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
	C= new DataColumn("unpartitioned", typeof(decimal));
	C.ReadOnly=true;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("nproceedstransmission", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
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
	tincomeview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"]};


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
	texpenseview.Columns.Add( new DataColumn("formerymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("formernmov", typeof(int)));
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
	texpenseview.Columns.Add( new DataColumn("ypay", typeof(short)));
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
	texpenseview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeser", typeof(string)));
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
	texpenseview.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
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


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// MANAGER_INCOME /////////////////////////////////
	var tmanager_income= new DataTable("manager_income");
	tmanager_income.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager_income.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager_income.Columns.Add(C);
	tmanager_income.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager_income.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager_income.Columns.Add(C);
	tmanager_income.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager_income.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager_income.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager_income.Columns.Add(C);
	tmanager_income.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager_income.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager_income.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager_income.Columns.Add(C);
	Tables.Add(tmanager_income);
	tmanager_income.PrimaryKey =  new DataColumn[]{tmanager_income.Columns["idman"]};


	//////////////////// EXPENSELASTVIEW /////////////////////////////////
	var texpenselastview= new DataTable("expenselastview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenselastview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpenselastview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenselastview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("codeser", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselastview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenselastview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("txt", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenselastview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("extracode", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselastview.Columns.Add(C);
	texpenselastview.Columns.Add( new DataColumn("codetreasurer", typeof(string)));
	texpenselastview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	Tables.Add(texpenselastview);
	texpenselastview.PrimaryKey =  new DataColumn[]{texpenselastview.Columns["idexp"]};


	//////////////////// INCOMELASTVIEW /////////////////////////////////
	var tincomelastview= new DataTable("incomelastview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomelastview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomelastview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomelastview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	Tables.Add(tincomelastview);
	tincomelastview.PrimaryKey =  new DataColumn[]{tincomelastview.Columns["idinc"]};


	//////////////////// INCOMEYEAR /////////////////////////////////
	var tincomeyear= new DataTable("incomeyear");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	tincomeyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	tincomeyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	tincomeyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	Tables.Add(tincomeyear);
	tincomeyear.PrimaryKey =  new DataColumn[]{tincomeyear.Columns["ayear"], tincomeyear.Columns["idinc"]};


	//////////////////// EXPENSEYEAR /////////////////////////////////
	var texpenseyear= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	texpenseyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	texpenseyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	texpenseyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	Tables.Add(texpenseyear);
	texpenseyear.PrimaryKey =  new DataColumn[]{texpenseyear.Columns["ayear"], texpenseyear.Columns["idexp"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{upb.Columns["idupb"]};
	var cChild = new []{expenseyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_expenseyear",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{expenseyear.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_expenseyear",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseyear.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenseyear",cPar,cChild,false));

	cPar = new []{upb_income.Columns["idupb"]};
	cChild = new []{incomeyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_income_incomeyear",cPar,cChild,false));

	cPar = new []{fin_income.Columns["idfin"]};
	cChild = new []{incomeyear.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_income_incomeyear",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomeyear",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomelastview.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelastview",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenselastview.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselastview",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseview.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenseview",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomeview.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomeview",cPar,cChild,false));

	cPar = new []{incomephase.Columns["nphase"]};
	cChild = new []{income.Columns["nphase"]};
	Relations.Add(new DataRelation("incomephase_income",cPar,cChild,false));

	cPar = new []{manager_income.Columns["idman"]};
	cChild = new []{income.Columns["idman"]};
	Relations.Add(new DataRelation("manager_income_income",cPar,cChild,false));

	cPar = new []{expensephase.Columns["nphase"]};
	cChild = new []{expense.Columns["nphase"]};
	Relations.Add(new DataRelation("expensephase_expense",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{expense.Columns["idman"]};
	Relations.Add(new DataRelation("manager_expense",cPar,cChild,false));

	#endregion

}
}
}
