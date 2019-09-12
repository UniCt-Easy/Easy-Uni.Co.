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
namespace csa_incomesetup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Configurazione Voci CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_incomesetup 		=> Tables["csa_incomesetup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finincomeclawback 		=> Tables["finincomeclawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finexpense 		=> Tables["finexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finincome 		=> Tables["finincome"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountdebit 		=> Tables["accountdebit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountente 		=> Tables["accountente"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountclawback 		=> Tables["accountclawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_revenue 		=> Tables["account_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountcreditente 		=> Tables["accountcreditente"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingincomeclawback 		=> Tables["sortingincomeclawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingincome 		=> Tables["sortingincome"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingexpense 		=> Tables["sortingexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finexpensecost 		=> Tables["finexpensecost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingexpensecost 		=> Tables["sortingexpensecost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_cost 		=> Tables["account_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_incomesetup1 		=> Tables["csa_incomesetup1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_incomesetupview 		=> Tables["csa_incomesetupview"];

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
	//////////////////// CSA_INCOMESETUP /////////////////////////////////
	var tcsa_incomesetup= new DataTable("csa_incomesetup");
	C= new DataColumn("idcsa_incomesetup", typeof(int));
	C.AllowDBNull=false;
	tcsa_incomesetup.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_incomesetup.Columns.Add(C);
	tcsa_incomesetup.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idfin_income", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idacc_debit", typeof(string)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idfin_expense", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idacc_expense", typeof(string)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idfin_incomeclawback", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idacc_internalcredit", typeof(string)));
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_incomesetup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_incomesetup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetup.Columns.Add(C);
	tcsa_incomesetup.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idacc_agency_credit", typeof(string)));
	tcsa_incomesetup.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idsor_siope_expense", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idsor_siope_income", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idsor_siope_incomeclawback", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idfin_cost", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idacc_cost", typeof(string)));
	tcsa_incomesetup.Columns.Add( new DataColumn("idsor_siope_cost", typeof(int)));
	tcsa_incomesetup.Columns.Add( new DataColumn("vocecsaunified", typeof(string)));
	Tables.Add(tcsa_incomesetup);
	tcsa_incomesetup.PrimaryKey =  new DataColumn[]{tcsa_incomesetup.Columns["idcsa_incomesetup"], tcsa_incomesetup.Columns["ayear"]};


	//////////////////// FININCOMECLAWBACK /////////////////////////////////
	var tfinincomeclawback= new DataTable("finincomeclawback");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	tfinincomeclawback.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	tfinincomeclawback.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	tfinincomeclawback.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinincomeclawback.Columns.Add(C);
	Tables.Add(tfinincomeclawback);
	tfinincomeclawback.PrimaryKey =  new DataColumn[]{tfinincomeclawback.Columns["idfin"]};


	//////////////////// FINEXPENSE /////////////////////////////////
	var tfinexpense= new DataTable("finexpense");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	tfinexpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	tfinexpense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	tfinexpense.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinexpense.Columns.Add(C);
	Tables.Add(tfinexpense);
	tfinexpense.PrimaryKey =  new DataColumn[]{tfinexpense.Columns["idfin"]};


	//////////////////// FININCOME /////////////////////////////////
	var tfinincome= new DataTable("finincome");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	tfinincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	tfinincome.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	tfinincome.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinincome.Columns.Add(C);
	Tables.Add(tfinincome);
	tfinincome.PrimaryKey =  new DataColumn[]{tfinincome.Columns["idfin"]};


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
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// ACCOUNTDEBIT /////////////////////////////////
	var taccountdebit= new DataTable("accountdebit");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	taccountdebit.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	taccountdebit.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	taccountdebit.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountdebit.Columns.Add(C);
	taccountdebit.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountdebit.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountdebit);
	taccountdebit.PrimaryKey =  new DataColumn[]{taccountdebit.Columns["idacc"]};


	//////////////////// ACCOUNTENTE /////////////////////////////////
	var taccountente= new DataTable("accountente");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	taccountente.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountente.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountente.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountente.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	taccountente.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	taccountente.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountente.Columns.Add(C);
	taccountente.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountente.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountente.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountente.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountente.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountente.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountente.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountente.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountente.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountente);
	taccountente.PrimaryKey =  new DataColumn[]{taccountente.Columns["idacc"]};


	//////////////////// ACCOUNTCLAWBACK /////////////////////////////////
	var taccountclawback= new DataTable("accountclawback");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	taccountclawback.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	taccountclawback.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	taccountclawback.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountclawback.Columns.Add(C);
	taccountclawback.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountclawback.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountclawback);
	taccountclawback.PrimaryKey =  new DataColumn[]{taccountclawback.Columns["idacc"]};


	//////////////////// ACCOUNT_REVENUE /////////////////////////////////
	var taccount_revenue= new DataTable("account_revenue");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_revenue);
	taccount_revenue.PrimaryKey =  new DataColumn[]{taccount_revenue.Columns["idacc"]};


	//////////////////// ACCOUNTCREDITENTE /////////////////////////////////
	var taccountcreditente= new DataTable("accountcreditente");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	taccountcreditente.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	taccountcreditente.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	taccountcreditente.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountcreditente.Columns.Add(C);
	taccountcreditente.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountcreditente.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountcreditente);
	taccountcreditente.PrimaryKey =  new DataColumn[]{taccountcreditente.Columns["idacc"]};


	//////////////////// SORTINGINCOMECLAWBACK /////////////////////////////////
	var tsortingincomeclawback= new DataTable("sortingincomeclawback");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsortingincomeclawback.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	tsortingincomeclawback.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	tsortingincomeclawback.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsortingincomeclawback.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsortingincomeclawback.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	tsortingincomeclawback.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	tsortingincomeclawback.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingincomeclawback.Columns.Add(C);
	tsortingincomeclawback.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingincomeclawback.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsortingincomeclawback);
	tsortingincomeclawback.PrimaryKey =  new DataColumn[]{tsortingincomeclawback.Columns["idsor"]};


	//////////////////// SORTINGINCOME /////////////////////////////////
	var tsortingincome= new DataTable("sortingincome");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	tsortingincome.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsortingincome.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsortingincome.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsortingincome.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsortingincome.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsortingincome.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsortingincome.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	tsortingincome.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	tsortingincome.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsortingincome.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsortingincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	tsortingincome.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	tsortingincome.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingincome.Columns.Add(C);
	tsortingincome.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingincome.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsortingincome);
	tsortingincome.PrimaryKey =  new DataColumn[]{tsortingincome.Columns["idsor"]};


	//////////////////// SORTINGEXPENSE /////////////////////////////////
	var tsortingexpense= new DataTable("sortingexpense");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	tsortingexpense.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsortingexpense.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsortingexpense.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsortingexpense.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsortingexpense.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsortingexpense.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsortingexpense.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	tsortingexpense.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	tsortingexpense.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsortingexpense.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsortingexpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	tsortingexpense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	tsortingexpense.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingexpense.Columns.Add(C);
	tsortingexpense.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingexpense.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsortingexpense);
	tsortingexpense.PrimaryKey =  new DataColumn[]{tsortingexpense.Columns["idsor"]};


	//////////////////// FINEXPENSECOST /////////////////////////////////
	var tfinexpensecost= new DataTable("finexpensecost");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	tfinexpensecost.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	tfinexpensecost.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	tfinexpensecost.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinexpensecost.Columns.Add(C);
	Tables.Add(tfinexpensecost);
	tfinexpensecost.PrimaryKey =  new DataColumn[]{tfinexpensecost.Columns["idfin"]};


	//////////////////// SORTINGEXPENSECOST /////////////////////////////////
	var tsortingexpensecost= new DataTable("sortingexpensecost");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	tsortingexpensecost.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsortingexpensecost.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	tsortingexpensecost.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	tsortingexpensecost.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsortingexpensecost.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsortingexpensecost.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	tsortingexpensecost.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	tsortingexpensecost.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingexpensecost.Columns.Add(C);
	tsortingexpensecost.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingexpensecost.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsortingexpensecost);
	tsortingexpensecost.PrimaryKey =  new DataColumn[]{tsortingexpensecost.Columns["idsor"]};


	//////////////////// ACCOUNT_COST /////////////////////////////////
	var taccount_cost= new DataTable("account_cost");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_cost);
	taccount_cost.PrimaryKey =  new DataColumn[]{taccount_cost.Columns["idacc"]};


	//////////////////// CSA_INCOMESETUP1 /////////////////////////////////
	var tcsa_incomesetup1= new DataTable("csa_incomesetup1");
	C= new DataColumn("idcsa_incomesetup", typeof(int));
	C.AllowDBNull=false;
	tcsa_incomesetup1.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_incomesetup1.Columns.Add(C);
	tcsa_incomesetup1.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idfin_income", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idacc_debit", typeof(string)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idfin_expense", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idacc_expense", typeof(string)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idfin_incomeclawback", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idacc_internalcredit", typeof(string)));
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetup1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_incomesetup1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetup1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_incomesetup1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetup1.Columns.Add(C);
	tcsa_incomesetup1.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idacc_agency_credit", typeof(string)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idsor_siope_expense", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idsor_siope_income", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idsor_siope_incomeclawback", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idfin_cost", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idacc_cost", typeof(string)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("idsor_siope_cost", typeof(int)));
	tcsa_incomesetup1.Columns.Add( new DataColumn("vocecsaunified", typeof(string)));
	Tables.Add(tcsa_incomesetup1);
	tcsa_incomesetup1.PrimaryKey =  new DataColumn[]{tcsa_incomesetup1.Columns["idcsa_incomesetup"], tcsa_incomesetup1.Columns["ayear"]};


	//////////////////// CSA_INCOMESETUPVIEW /////////////////////////////////
	var tcsa_incomesetupview= new DataTable("csa_incomesetupview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_incomesetupview.Columns.Add(C);
	C= new DataColumn("idcsa_incomesetup", typeof(int));
	C.AllowDBNull=false;
	tcsa_incomesetupview.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetupview.Columns.Add(C);
	tcsa_incomesetupview.Columns.Add( new DataColumn("vocecsaunified", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("upb", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idacc_debit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codeacc_debit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("account_debit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idacc_ente", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codeacc_ente", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("account_ente", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idacc_internalcredit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codeacc_internalcredit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("account_internalcredit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codeacc_revenue", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("account_revenue", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idacc_agency_credit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codeacc_agency_credit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("account_agency_credit", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idfin_income", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codefin_income", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("fin_income", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idsor_siope_income", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sortcode_income", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sorting_income", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idfin_expense", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codefin_expense", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("fin_expense", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idsor_siope_expense", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sortcode_expense", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sorting_expense", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idfin_incomeclawback", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codefin_clawback", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("fin_clawback", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idsor_siope_clawback", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sortcode_clawback", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sorting_clawback", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idfin_cost", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("codefin_cost", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("fin_cost", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("idsor_siope_cost", typeof(int)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sortcode_cost", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("sorting_cost", typeof(string)));
	tcsa_incomesetupview.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetupview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_incomesetupview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_incomesetupview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_incomesetupview.Columns.Add(C);
	Tables.Add(tcsa_incomesetupview);
	tcsa_incomesetupview.PrimaryKey =  new DataColumn[]{tcsa_incomesetupview.Columns["ayear"], tcsa_incomesetupview.Columns["idcsa_incomesetup"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortingexpense.Columns["idsor"]};
	var cChild = new []{csa_incomesetup.Columns["idsor_siope_expense"]};
	Relations.Add(new DataRelation("FK_sortingexpense_csa_incomesetup",cPar,cChild,false));

	cPar = new []{sortingincomeclawback.Columns["idsor"]};
	cChild = new []{csa_incomesetup.Columns["idsor_siope_incomeclawback"]};
	Relations.Add(new DataRelation("FK_sortingincomeclawback_csa_incomesetup",cPar,cChild,false));

	cPar = new []{sortingincome.Columns["idsor"]};
	cChild = new []{csa_incomesetup.Columns["idsor_siope_income"]};
	Relations.Add(new DataRelation("FK_sortingincome_csa_incomesetup",cPar,cChild,false));

	cPar = new []{accountente.Columns["idacc"]};
	cChild = new []{csa_incomesetup.Columns["idacc_expense"]};
	Relations.Add(new DataRelation("accountente_csa_incomesetup",cPar,cChild,false));

	cPar = new []{finincomeclawback.Columns["idfin"]};
	cChild = new []{csa_incomesetup.Columns["idfin_incomeclawback"]};
	Relations.Add(new DataRelation("finincomeint_csa_incomesetup",cPar,cChild,false));

	cPar = new []{finexpense.Columns["idfin"]};
	cChild = new []{csa_incomesetup.Columns["idfin_expense"]};
	Relations.Add(new DataRelation("finexpense_csa_incomesetup",cPar,cChild,false));

	cPar = new []{finincome.Columns["idfin"]};
	cChild = new []{csa_incomesetup.Columns["idfin_income"]};
	Relations.Add(new DataRelation("finincome_csa_incomesetup",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_incomesetup.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_incomesetup",cPar,cChild,false));

	cPar = new []{accountclawback.Columns["idacc"]};
	cChild = new []{csa_incomesetup.Columns["idacc_internalcredit"]};
	Relations.Add(new DataRelation("accountclawback_csa_incomesetup",cPar,cChild,false));

	cPar = new []{accountdebit.Columns["idacc"]};
	cChild = new []{csa_incomesetup.Columns["idacc_debit"]};
	Relations.Add(new DataRelation("accountdebit_csa_incomesetup",cPar,cChild,false));

	cPar = new []{account_revenue.Columns["idacc"]};
	cChild = new []{csa_incomesetup.Columns["idacc_revenue"]};
	Relations.Add(new DataRelation("account_revenue_csa_incomesetup",cPar,cChild,false));

	cPar = new []{accountcreditente.Columns["idacc"]};
	cChild = new []{csa_incomesetup.Columns["idacc_agency_credit"]};
	Relations.Add(new DataRelation("accountcreditente_csa_incomesetup",cPar,cChild,false));

	cPar = new []{finexpensecost.Columns["idfin"]};
	cChild = new []{csa_incomesetup.Columns["idfin_cost"]};
	Relations.Add(new DataRelation("finexpensecost_csa_incomesetup",cPar,cChild,false));

	cPar = new []{sortingexpensecost.Columns["idsor"]};
	cChild = new []{csa_incomesetup.Columns["idsor_siope_cost"]};
	Relations.Add(new DataRelation("sortingexpensecost_csa_incomesetup",cPar,cChild,false));

	cPar = new []{account_cost.Columns["idacc"]};
	cChild = new []{csa_incomesetup.Columns["idacc_cost"]};
	Relations.Add(new DataRelation("account_cost_csa_incomesetup",cPar,cChild,false));

	cPar = new []{csa_incomesetup1.Columns["vocecsa"], csa_incomesetup1.Columns["ayear"]};
	cChild = new []{csa_incomesetup.Columns["vocecsaunified"], csa_incomesetup.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_incomesetup1_csa_incomesetup",cPar,cChild,false));

	#endregion

}
}
}
