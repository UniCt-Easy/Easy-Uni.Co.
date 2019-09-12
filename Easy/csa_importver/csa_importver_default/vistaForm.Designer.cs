/*
    Easy
    Copyright (C) 2019 Universit‡ degli Studi di Catania (www.unict.it)

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
namespace csa_importver_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkind 		=> Tables["csa_contractkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fase_epexp 		=> Tables["fase_epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_debit 		=> Tables["account_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin_income 		=> Tables["fin_income"];

	///<summary>
	///Informazioni annuali su tipo contratto csa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkindyear 		=> Tables["csa_contractkindyear"];

	///<summary>
	///Contributi Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttax 		=> Tables["csa_contracttax"];

	///<summary>
	///Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contract 		=> Tables["csa_contract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin_expense 		=> Tables["fin_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_expense 		=> Tables["account_expense"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin_cost 		=> Tables["fin_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_cost 		=> Tables["account_cost"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Contributi Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkinddata 		=> Tables["csa_contractkinddata"];

	///<summary>
	///Importazione Versamenti CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver 		=> Tables["csa_importver"];

	///<summary>
	///Importazione CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_import 		=> Tables["csa_import"];

	///<summary>
	///Configurazione Voci CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_incomesetup 		=> Tables["csa_incomesetup"];

	///<summary>
	///Ente CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_agency 		=> Tables["csa_agency"];

	///<summary>
	///Modalit√† pagamento Ente CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_agencypaymethod 		=> Tables["csa_agencypaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_agency 		=> Tables["registry_agency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin_incomeclawback 		=> Tables["fin_incomeclawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_internalcredit 		=> Tables["account_internalcredit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_revenue 		=> Tables["account_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_agency_credit 		=> Tables["account_agency_credit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_cost 		=> Tables["sorting_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_incomeclawback 		=> Tables["sorting_incomeclawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_income 		=> Tables["sorting_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_expense 		=> Tables["sorting_expense"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttaxepexp 		=> Tables["csa_contracttaxepexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview2 		=> Tables["epexpview2"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexp 		=> Tables["epexp"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttaxexpense 		=> Tables["csa_contracttaxexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview2 		=> Tables["expenseview2"];

	///<summary>
	///Impegni di budget collegati ad un versamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_epexp 		=> Tables["csa_importver_epexp"];

	///<summary>
	///Movimenti di spesa collegati ad un versamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_expense 		=> Tables["csa_importver_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview1 		=> Tables["expenseview1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexp_ver 		=> Tables["epexp_ver"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview3 		=> Tables["expenseview3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview3 		=> Tables["epexpview3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin2 		=> Tables["fin2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account2 		=> Tables["account2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partition 		=> Tables["csa_importver_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb2 		=> Tables["upb2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partition_expense 		=> Tables["csa_importver_partition_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partition_income 		=> Tables["csa_importver_partition_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview4 		=> Tables["expenseview4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

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
	//////////////////// CSA_CONTRACTKIND /////////////////////////////////
	var tcsa_contractkind= new DataTable("csa_contractkind");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("flagcr", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	tcsa_contractkind.Columns.Add( new DataColumn("flagkeepalive", typeof(string)));
	tcsa_contractkind.Columns.Add( new DataColumn("active", typeof(string)));
	tcsa_contractkind.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	Tables.Add(tcsa_contractkind);
	tcsa_contractkind.PrimaryKey =  new DataColumn[]{tcsa_contractkind.Columns["idcsa_contractkind"]};


	//////////////////// FASE_EPEXP /////////////////////////////////
	var tfase_epexp= new DataTable("fase_epexp");
	C= new DataColumn("nphase", typeof(int));
	C.AllowDBNull=false;
	tfase_epexp.Columns.Add(C);
	tfase_epexp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(tfase_epexp);

	//////////////////// ACCOUNT_DEBIT /////////////////////////////////
	var taccount_debit= new DataTable("account_debit");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	taccount_debit.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	taccount_debit.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	taccount_debit.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_debit.Columns.Add(C);
	taccount_debit.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_debit.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_debit);
	taccount_debit.PrimaryKey =  new DataColumn[]{taccount_debit.Columns["idacc"]};


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


	//////////////////// CSA_CONTRACTKINDYEAR /////////////////////////////////
	var tcsa_contractkindyear= new DataTable("csa_contractkindyear");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	tcsa_contractkindyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractkindyear.Columns.Add( new DataColumn("idacc_main", typeof(string)));
	tcsa_contractkindyear.Columns.Add( new DataColumn("idfin_main", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	Tables.Add(tcsa_contractkindyear);
	tcsa_contractkindyear.PrimaryKey =  new DataColumn[]{tcsa_contractkindyear.Columns["idcsa_contractkind"], tcsa_contractkindyear.Columns["ayear"]};


	//////////////////// CSA_CONTRACTTAX /////////////////////////////////
	var tcsa_contracttax= new DataTable("csa_contracttax");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	tcsa_contracttax.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contracttax.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contracttax.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contracttax.Columns.Add( new DataColumn("idacc", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttax.Columns.Add(C);
	tcsa_contracttax.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tcsa_contracttax.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tcsa_contracttax.Columns.Add( new DataColumn("!codeacc", typeof(string)));
	Tables.Add(tcsa_contracttax);
	tcsa_contracttax.PrimaryKey =  new DataColumn[]{tcsa_contracttax.Columns["idcsa_contract"], tcsa_contracttax.Columns["idcsa_contracttax"], tcsa_contracttax.Columns["ayear"]};


	//////////////////// CSA_CONTRACT /////////////////////////////////
	var tcsa_contract= new DataTable("csa_contract");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("ycontract", typeof(short));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("ncontract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	tcsa_contract.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("flagkeepalive", typeof(string));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	tcsa_contract.Columns.Add( new DataColumn("flagrecreate", typeof(string)));
	tcsa_contract.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contract.Columns.Add( new DataColumn("idacc_main", typeof(string)));
	tcsa_contract.Columns.Add( new DataColumn("idexp_main", typeof(int)));
	tcsa_contract.Columns.Add( new DataColumn("idfin_main", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contract.Columns.Add(C);
	Tables.Add(tcsa_contract);
	tcsa_contract.PrimaryKey =  new DataColumn[]{tcsa_contract.Columns["idcsa_contract"], tcsa_contract.Columns["ayear"]};


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


	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// FIN_EXPENSE /////////////////////////////////
	var tfin_expense= new DataTable("fin_expense");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	tfin_expense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	tfin_expense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	tfin_expense.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin_expense.Columns.Add(C);
	Tables.Add(tfin_expense);
	tfin_expense.PrimaryKey =  new DataColumn[]{tfin_expense.Columns["idfin"]};


	//////////////////// ACCOUNT_EXPENSE /////////////////////////////////
	var taccount_expense= new DataTable("account_expense");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	taccount_expense.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	taccount_expense.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	taccount_expense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_expense.Columns.Add(C);
	taccount_expense.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_expense.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_expense);
	taccount_expense.PrimaryKey =  new DataColumn[]{taccount_expense.Columns["idacc"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// FIN_COST /////////////////////////////////
	var tfin_cost= new DataTable("fin_cost");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	tfin_cost.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	tfin_cost.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	tfin_cost.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin_cost.Columns.Add(C);
	Tables.Add(tfin_cost);
	tfin_cost.PrimaryKey =  new DataColumn[]{tfin_cost.Columns["idfin"]};


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


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// CSA_CONTRACTKINDDATA /////////////////////////////////
	var tcsa_contractkinddata= new DataTable("csa_contractkinddata");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("idcsa_contractkinddata", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	tcsa_contractkinddata.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("idacc", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	Tables.Add(tcsa_contractkinddata);
	tcsa_contractkinddata.PrimaryKey =  new DataColumn[]{tcsa_contractkinddata.Columns["idcsa_contractkind"], tcsa_contractkinddata.Columns["idcsa_contractkinddata"], tcsa_contractkinddata.Columns["ayear"]};


	//////////////////// CSA_IMPORTVER /////////////////////////////////
	var tcsa_importver= new DataTable("csa_importver");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("idver", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("ruolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("capitolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("competenza", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("matricola", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("ente", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("importo", typeof(decimal));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	tcsa_importver.Columns.Add( new DataColumn("flagcr", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("ayear", typeof(short)));
	tcsa_importver.Columns.Add( new DataColumn("competency", typeof(short)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contractkind", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contract", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_agency", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idfin_income", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_debit", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idfin_expense", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_expense", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idfin_incomeclawback", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_internalcredit", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idreg_agency", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_agencypaymethod", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idexp_cost", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idfin_cost", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_cost", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("flagclawback", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idreg", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contracttax", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contractkinddata", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_incomesetup", typeof(int)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	tcsa_importver.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_agency_credit", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_cost", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_expense", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_income", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_incomeclawback", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("vocecsaunified", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idepexp", typeof(int)));
	Tables.Add(tcsa_importver);
	tcsa_importver.PrimaryKey =  new DataColumn[]{tcsa_importver.Columns["idcsa_import"], tcsa_importver.Columns["idver"]};


	//////////////////// CSA_IMPORT /////////////////////////////////
	var tcsa_import= new DataTable("csa_import");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	C= new DataColumn("yimport", typeof(short));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	C= new DataColumn("nimport", typeof(int));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	tcsa_import.Columns.Add( new DataColumn("ybill_netti", typeof(short)));
	tcsa_import.Columns.Add( new DataColumn("nbill_netti", typeof(int)));
	tcsa_import.Columns.Add( new DataColumn("ybill_versamenti", typeof(short)));
	tcsa_import.Columns.Add( new DataColumn("nbill_versamenti", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_import.Columns.Add(C);
	Tables.Add(tcsa_import);
	tcsa_import.PrimaryKey =  new DataColumn[]{tcsa_import.Columns["idcsa_import"]};


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
	tcsa_incomesetup.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	Tables.Add(tcsa_incomesetup);
	tcsa_incomesetup.PrimaryKey =  new DataColumn[]{tcsa_incomesetup.Columns["idcsa_incomesetup"], tcsa_incomesetup.Columns["ayear"]};


	//////////////////// CSA_AGENCY /////////////////////////////////
	var tcsa_agency= new DataTable("csa_agency");
	C= new DataColumn("idcsa_agency", typeof(int));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("ente", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("isinternal", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	Tables.Add(tcsa_agency);
	tcsa_agency.PrimaryKey =  new DataColumn[]{tcsa_agency.Columns["idcsa_agency"]};


	//////////////////// CSA_AGENCYPAYMETHOD /////////////////////////////////
	var tcsa_agencypaymethod= new DataTable("csa_agencypaymethod");
	C= new DataColumn("idcsa_agency", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("idcsa_agencypaymethod", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	tcsa_agencypaymethod.Columns.Add( new DataColumn("idreg", typeof(int)));
	Tables.Add(tcsa_agencypaymethod);
	tcsa_agencypaymethod.PrimaryKey =  new DataColumn[]{tcsa_agencypaymethod.Columns["idcsa_agency"], tcsa_agencypaymethod.Columns["idcsa_agencypaymethod"]};


	//////////////////// REGISTRY_AGENCY /////////////////////////////////
	var tregistry_agency= new DataTable("registry_agency");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	tregistry_agency.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry_agency.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	tregistry_agency.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry_agency.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry_agency.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	tregistry_agency.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry_agency.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	tregistry_agency.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry_agency.Columns.Add(C);
	tregistry_agency.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry_agency.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry_agency.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistry_agency);
	tregistry_agency.PrimaryKey =  new DataColumn[]{tregistry_agency.Columns["idreg"]};


	//////////////////// FIN_INCOMECLAWBACK /////////////////////////////////
	var tfin_incomeclawback= new DataTable("fin_incomeclawback");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	tfin_incomeclawback.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	tfin_incomeclawback.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	tfin_incomeclawback.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin_incomeclawback.Columns.Add(C);
	Tables.Add(tfin_incomeclawback);
	tfin_incomeclawback.PrimaryKey =  new DataColumn[]{tfin_incomeclawback.Columns["idfin"]};


	//////////////////// ACCOUNT_INTERNALCREDIT /////////////////////////////////
	var taccount_internalcredit= new DataTable("account_internalcredit");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	taccount_internalcredit.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	taccount_internalcredit.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	taccount_internalcredit.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_internalcredit.Columns.Add(C);
	taccount_internalcredit.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_internalcredit.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_internalcredit);
	taccount_internalcredit.PrimaryKey =  new DataColumn[]{taccount_internalcredit.Columns["idacc"]};


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


	//////////////////// ACCOUNT_AGENCY_CREDIT /////////////////////////////////
	var taccount_agency_credit= new DataTable("account_agency_credit");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	taccount_agency_credit.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	taccount_agency_credit.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	taccount_agency_credit.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_agency_credit.Columns.Add(C);
	taccount_agency_credit.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_agency_credit.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_agency_credit);
	taccount_agency_credit.PrimaryKey =  new DataColumn[]{taccount_agency_credit.Columns["idacc"]};


	//////////////////// SORTING_COST /////////////////////////////////
	var tsorting_cost= new DataTable("sorting_cost");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	tsorting_cost.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_cost.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_cost.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_cost.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_cost.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_cost.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_cost.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	tsorting_cost.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	tsorting_cost.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_cost.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_cost.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	tsorting_cost.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	tsorting_cost.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_cost.Columns.Add(C);
	tsorting_cost.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_cost.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting_cost);
	tsorting_cost.PrimaryKey =  new DataColumn[]{tsorting_cost.Columns["idsor"]};


	//////////////////// SORTING_INCOMECLAWBACK /////////////////////////////////
	var tsorting_incomeclawback= new DataTable("sorting_incomeclawback");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	tsorting_incomeclawback.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	tsorting_incomeclawback.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	tsorting_incomeclawback.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	tsorting_incomeclawback.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_incomeclawback.Columns.Add(C);
	tsorting_incomeclawback.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_incomeclawback.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting_incomeclawback);
	tsorting_incomeclawback.PrimaryKey =  new DataColumn[]{tsorting_incomeclawback.Columns["idsor"]};


	//////////////////// SORTING_INCOME /////////////////////////////////
	var tsorting_income= new DataTable("sorting_income");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	tsorting_income.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_income.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_income.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_income.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_income.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_income.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_income.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	tsorting_income.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	tsorting_income.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_income.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_income.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	tsorting_income.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	tsorting_income.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_income.Columns.Add(C);
	tsorting_income.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_income.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting_income);
	tsorting_income.PrimaryKey =  new DataColumn[]{tsorting_income.Columns["idsor"]};


	//////////////////// SORTING_EXPENSE /////////////////////////////////
	var tsorting_expense= new DataTable("sorting_expense");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	tsorting_expense.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_expense.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_expense.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_expense.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_expense.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_expense.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_expense.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	tsorting_expense.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	tsorting_expense.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_expense.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_expense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	tsorting_expense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	tsorting_expense.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_expense.Columns.Add(C);
	tsorting_expense.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_expense.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting_expense);
	tsorting_expense.PrimaryKey =  new DataColumn[]{tsorting_expense.Columns["idsor"]};


	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("active", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("doc", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tunderwriting.Columns.Add( new DataColumn("codeunderwriting", typeof(string)));
	Tables.Add(tunderwriting);
	tunderwriting.PrimaryKey =  new DataColumn[]{tunderwriting.Columns["idunderwriting"]};


	//////////////////// CSA_CONTRACTTAXEPEXP /////////////////////////////////
	var tcsa_contracttaxepexp= new DataTable("csa_contracttaxepexp");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("quota", typeof(decimal));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxepexp.Columns.Add(C);
	tcsa_contracttaxepexp.Columns.Add( new DataColumn("!yepexp", typeof(short)));
	tcsa_contracttaxepexp.Columns.Add( new DataColumn("!nepexp", typeof(int)));
	tcsa_contracttaxepexp.Columns.Add( new DataColumn("!nphase", typeof(string)));
	Tables.Add(tcsa_contracttaxepexp);
	tcsa_contracttaxepexp.PrimaryKey =  new DataColumn[]{tcsa_contracttaxepexp.Columns["idcsa_contract"], tcsa_contracttaxepexp.Columns["idcsa_contracttax"], tcsa_contracttaxepexp.Columns["ayear"], tcsa_contracttaxepexp.Columns["ndetail"]};


	//////////////////// EPEXPVIEW2 /////////////////////////////////
	var tepexpview2= new DataTable("epexpview2");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	tepexpview2.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("totamount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	tepexpview2.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	C= new DataColumn("totcurramount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	tepexpview2.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepexpview2.Columns.Add( new DataColumn("available5", typeof(decimal)));
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("totaldebit", typeof(decimal));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	tepexpview2.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("parentyepexp", typeof(short)));
	tepexpview2.Columns.Add( new DataColumn("parentnepexp", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexpview2.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview2.Columns.Add(C);
	tepexpview2.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("registry", typeof(string)));
	tepexpview2.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexpview2.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexpview2.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("manager", typeof(string)));
	tepexpview2.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tepexpview2.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	C= new DataColumn("rateiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("debit", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("credit", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("cost", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("revenue", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	Tables.Add(tepexpview2);
	tepexpview2.PrimaryKey =  new DataColumn[]{tepexpview2.Columns["idepexp"]};


	//////////////////// EPEXP /////////////////////////////////
	var tepexp= new DataTable("epexp");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexp.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexp.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepexp.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	Tables.Add(tepexp);
	tepexp.PrimaryKey =  new DataColumn[]{tepexp.Columns["idepexp"]};


	//////////////////// CSA_CONTRACTTAXEXPENSE /////////////////////////////////
	var tcsa_contracttaxexpense= new DataTable("csa_contracttaxexpense");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("quota", typeof(decimal));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxexpense.Columns.Add(C);
	tcsa_contracttaxexpense.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contracttaxexpense.Columns.Add( new DataColumn("!ymov", typeof(short)));
	tcsa_contracttaxexpense.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tcsa_contracttaxexpense.Columns.Add( new DataColumn("!phase", typeof(string)));
	Tables.Add(tcsa_contracttaxexpense);
	tcsa_contracttaxexpense.PrimaryKey =  new DataColumn[]{tcsa_contracttaxexpense.Columns["idcsa_contract"], tcsa_contracttaxexpense.Columns["idcsa_contracttax"], tcsa_contracttaxexpense.Columns["ayear"], tcsa_contracttaxexpense.Columns["ndetail"]};


	//////////////////// EXPENSEVIEW2 /////////////////////////////////
	var texpenseview2= new DataTable("expenseview2");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	texpenseview2.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview2.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("formerymov", typeof(short)));
	texpenseview2.Columns.Add( new DataColumn("formernmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	texpenseview2.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("cf", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("p_iva", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpenseview2.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview2.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	texpenseview2.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview2.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview2.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview2.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview2.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("codeser", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview2.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview2.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview2.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview2.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview2.Columns.Add(C);
	texpenseview2.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview2.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	texpenseview2.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpenseview2.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	texpenseview2.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("codeaccdebit", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("cupcode", typeof(string)));
	texpenseview2.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview2.Columns.Add(C);
	Tables.Add(texpenseview2);

	//////////////////// CSA_IMPORTVER_EPEXP /////////////////////////////////
	var tcsa_importver_epexp= new DataTable("csa_importver_epexp");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_epexp.Columns.Add(C);
	C= new DataColumn("idver", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_epexp.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_epexp.Columns.Add(C);
	tcsa_importver_epexp.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("quota", typeof(decimal)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("!yepexp", typeof(short)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("!nepexp", typeof(int)));
	tcsa_importver_epexp.Columns.Add( new DataColumn("!phase", typeof(string)));
	Tables.Add(tcsa_importver_epexp);
	tcsa_importver_epexp.PrimaryKey =  new DataColumn[]{tcsa_importver_epexp.Columns["idcsa_import"], tcsa_importver_epexp.Columns["idver"], tcsa_importver_epexp.Columns["ndetail"]};


	//////////////////// CSA_IMPORTVER_EXPENSE /////////////////////////////////
	var tcsa_importver_expense= new DataTable("csa_importver_expense");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_expense.Columns.Add(C);
	C= new DataColumn("idver", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_expense.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_expense.Columns.Add(C);
	tcsa_importver_expense.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_importver_expense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_expense.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_expense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_expense.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_expense.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importver_expense.Columns.Add( new DataColumn("!ymov", typeof(short)));
	tcsa_importver_expense.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tcsa_importver_expense.Columns.Add( new DataColumn("!phase", typeof(string)));
	Tables.Add(tcsa_importver_expense);
	tcsa_importver_expense.PrimaryKey =  new DataColumn[]{tcsa_importver_expense.Columns["idcsa_import"], tcsa_importver_expense.Columns["idver"], tcsa_importver_expense.Columns["ndetail"]};


	//////////////////// EXPENSEVIEW1 /////////////////////////////////
	var texpenseview1= new DataTable("expenseview1");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	texpenseview1.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview1.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	texpenseview1.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("ypay", typeof(short));
	C.ReadOnly=true;
	texpenseview1.Columns.Add(C);
	texpenseview1.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview1.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	texpenseview1.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview1.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview1.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview1.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview1.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview1.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview1.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview1.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview1.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview1.Columns.Add(C);
	texpenseview1.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview1.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	texpenseview1.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("txt", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	Tables.Add(texpenseview1);
	texpenseview1.PrimaryKey =  new DataColumn[]{texpenseview1.Columns["idexp"]};


	//////////////////// EPEXP_VER /////////////////////////////////
	var tepexp_ver= new DataTable("epexp_ver");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	tepexp_ver.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("totamount", typeof(decimal));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	tepexp_ver.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	C= new DataColumn("totcurramount", typeof(decimal));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	tepexp_ver.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepexp_ver.Columns.Add( new DataColumn("available5", typeof(decimal)));
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("totaldebit", typeof(decimal));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	tepexp_ver.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexp_ver.Columns.Add( new DataColumn("parentyepexp", typeof(short)));
	tepexp_ver.Columns.Add( new DataColumn("parentnepexp", typeof(int)));
	tepexp_ver.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexp_ver.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp_ver.Columns.Add(C);
	tepexp_ver.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexp_ver.Columns.Add( new DataColumn("registry", typeof(string)));
	tepexp_ver.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexp_ver.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexp_ver.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexp_ver.Columns.Add( new DataColumn("manager", typeof(string)));
	tepexp_ver.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tepexp_ver.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	C= new DataColumn("rateiattivi", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("debit", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("credit", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("cost", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("revenue", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexp_ver.Columns.Add(C);
	Tables.Add(tepexp_ver);
	tepexp_ver.PrimaryKey =  new DataColumn[]{tepexp_ver.Columns["idepexp"]};


	//////////////////// EXPENSEVIEW3 /////////////////////////////////
	var texpenseview3= new DataTable("expenseview3");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	texpenseview3.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview3.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("formerymov", typeof(short)));
	texpenseview3.Columns.Add( new DataColumn("formernmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	texpenseview3.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("cf", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("p_iva", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpenseview3.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview3.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	texpenseview3.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview3.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview3.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview3.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview3.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("codeser", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview3.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview3.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview3.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview3.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview3.Columns.Add(C);
	texpenseview3.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview3.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	texpenseview3.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpenseview3.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	texpenseview3.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("codeaccdebit", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("cupcode", typeof(string)));
	texpenseview3.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	Tables.Add(texpenseview3);
	texpenseview3.PrimaryKey =  new DataColumn[]{texpenseview3.Columns["idexp"]};


	//////////////////// EPEXPVIEW3 /////////////////////////////////
	var tepexpview3= new DataTable("epexpview3");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("amountwithsign", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("amountwithsign2", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("amountwithsign3", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("amountwithsign4", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("amountwithsign5", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("totamount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	C= new DataColumn("totcurramount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("available", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("available2", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("available3", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("available4", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("available5", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("costavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("totaldebit", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("parentyepexp", typeof(short)));
	tepexpview3.Columns.Add( new DataColumn("parentnepexp", typeof(int)));
	C= new DataColumn("yliv1", typeof(short));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("nliv1", typeof(int));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexpview3.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("registry", typeof(string)));
	tepexpview3.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexpview3.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexpview3.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("manager", typeof(string)));
	tepexpview3.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tepexpview3.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	C= new DataColumn("rateiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("debit", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("credit", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("cost", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("revenue", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("provision", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tepexpview3.Columns.Add( new DataColumn("codemotive", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexpview3.Columns.Add(C);
	tepexpview3.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tepexpview3);
	tepexpview3.PrimaryKey =  new DataColumn[]{tepexpview3.Columns["idepexp"]};


	//////////////////// FIN2 /////////////////////////////////
	var tfin2= new DataTable("fin2");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	tfin2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	tfin2.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	tfin2.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	Tables.Add(tfin2);
	tfin2.PrimaryKey =  new DataColumn[]{tfin2.Columns["idfin"]};


	//////////////////// ACCOUNT2 /////////////////////////////////
	var taccount2= new DataTable("account2");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	taccount2.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount2.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount2.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount2.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	taccount2.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	taccount2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	taccount2.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount2.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount2.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount2.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount2.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount2.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount2.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount2.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount2.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount2);
	taccount2.PrimaryKey =  new DataColumn[]{taccount2.Columns["idacc"]};


	//////////////////// CSA_IMPORTVER_PARTITION /////////////////////////////////
	var tcsa_importver_partition= new DataTable("csa_importver_partition");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition.Columns.Add(C);
	C= new DataColumn("idver", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition.Columns.Add(C);
	tcsa_importver_partition.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_importver_partition.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importver_partition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_partition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_partition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!phasemovfin", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!ymov", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!nmov", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!phaseimpbudg", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!yepexp", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!nepexp", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!codeacc", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importver_partition.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	Tables.Add(tcsa_importver_partition);
	tcsa_importver_partition.PrimaryKey =  new DataColumn[]{tcsa_importver_partition.Columns["idcsa_import"], tcsa_importver_partition.Columns["idver"], tcsa_importver_partition.Columns["ndetail"]};


	//////////////////// UPB2 /////////////////////////////////
	var tupb2= new DataTable("upb2");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	tupb2.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb2.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb2.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb2.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb2.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb2.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb2.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb2.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	tupb2.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb2.Columns.Add(C);
	tupb2.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tupb2);
	tupb2.PrimaryKey =  new DataColumn[]{tupb2.Columns["idupb"]};


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
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tcsa_importver_partition_expense.Columns.Add( new DataColumn("movkind", typeof(int)));
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
	tcsa_importver_partition_income.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("!nmov", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_income.Columns.Add(C);
	Tables.Add(tcsa_importver_partition_income);
	tcsa_importver_partition_income.PrimaryKey =  new DataColumn[]{tcsa_importver_partition_income.Columns["idcsa_import"], tcsa_importver_partition_income.Columns["idver"], tcsa_importver_partition_income.Columns["ndetail"], tcsa_importver_partition_income.Columns["idinc"]};


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
	tincomeview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tincomeview.Columns.Add( new DataColumn("ypayment", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("descrpayment", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("kproceedstransmission", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("nproceedstransmission", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	tincomeview.Columns.Add( new DataColumn("idacccredit", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeacccredit", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("accountcredit", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("underwriting", typeof(string)));
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
	tincomeview.Columns.Add( new DataColumn("external_reference", typeof(string)));
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"]};


	//////////////////// EXPENSEVIEW4 /////////////////////////////////
	var texpenseview4= new DataTable("expenseview4");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	texpenseview4.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview4.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("formerymov", typeof(short)));
	texpenseview4.Columns.Add( new DataColumn("formernmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	texpenseview4.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("cf", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("p_iva", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpenseview4.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview4.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	texpenseview4.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview4.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview4.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview4.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview4.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("codeser", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview4.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview4.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview4.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview4.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview4.Columns.Add(C);
	texpenseview4.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview4.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	texpenseview4.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpenseview4.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	texpenseview4.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("codeaccdebit", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("cupcode", typeof(string)));
	texpenseview4.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview4.Columns.Add(C);
	Tables.Add(texpenseview4);
	texpenseview4.PrimaryKey =  new DataColumn[]{texpenseview4.Columns["idexp"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting1.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting1.Columns.Add( new DataColumn("email", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{expenseview1.Columns["idexp"]};
	var cChild = new []{csa_importver_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview1_csa_importver_expense",cPar,cChild,false));

	cPar = new []{csa_importver.Columns["idcsa_import"], csa_importver.Columns["idver"]};
	cChild = new []{csa_importver_expense.Columns["idcsa_import"], csa_importver_expense.Columns["idver"]};
	Relations.Add(new DataRelation("csa_importver_csa_importver_expense",cPar,cChild,false));

	cPar = new []{epexp_ver.Columns["idepexp"]};
	cChild = new []{csa_importver_epexp.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexp_ver_csa_importver_epexp",cPar,cChild,false));

	cPar = new []{csa_importver.Columns["idcsa_import"], csa_importver.Columns["idver"]};
	cChild = new []{csa_importver_epexp.Columns["idcsa_import"], csa_importver_epexp.Columns["idver"]};
	Relations.Add(new DataRelation("csa_importver_csa_importver_epexp",cPar,cChild,false));

	cPar = new []{expenseview2.Columns["idexp"]};
	cChild = new []{csa_contracttaxexpense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview2_csa_contracttaxexpense",cPar,cChild,false));

	cPar = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	cChild = new []{csa_contracttaxexpense.Columns["idcsa_contract"], csa_contracttaxexpense.Columns["idcsa_contracttax"], csa_contracttaxexpense.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contracttax_csa_contracttaxexpense",cPar,cChild,false));

	cPar = new []{epexpview2.Columns["idepexp"]};
	cChild = new []{csa_contracttaxepexp.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview2_csa_contracttaxepexp",cPar,cChild,false));

	cPar = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	cChild = new []{csa_contracttaxepexp.Columns["idcsa_contract"], csa_contracttaxepexp.Columns["idcsa_contracttax"], csa_contracttaxepexp.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contracttax_csa_contracttaxepexp",cPar,cChild,false));

	cPar = new []{csa_agency.Columns["idcsa_agency"]};
	cChild = new []{csa_agencypaymethod.Columns["idcsa_agency"]};
	Relations.Add(new DataRelation("csa_agency_csa_agencypaymethod",cPar,cChild,false));

	cPar = new []{epexp.Columns["idepexp"]};
	cChild = new []{csa_importver.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexp_csa_importver",cPar,cChild,false));

	cPar = new []{account_agency_credit.Columns["idacc"]};
	cChild = new []{csa_importver.Columns["idacc_agency_credit"]};
	Relations.Add(new DataRelation("account_agency_credit_csa_importver",cPar,cChild,false));

	cPar = new []{account_revenue.Columns["idacc"]};
	cChild = new []{csa_importver.Columns["idacc_revenue"]};
	Relations.Add(new DataRelation("account_revenue_csa_importver",cPar,cChild,false));

	cPar = new []{account_internalcredit.Columns["idacc"]};
	cChild = new []{csa_importver.Columns["idacc_internalcredit"]};
	Relations.Add(new DataRelation("account_internalcredit_csa_importver",cPar,cChild,false));

	cPar = new []{fin_incomeclawback.Columns["idfin"]};
	cChild = new []{csa_importver.Columns["idfin_incomeclawback"]};
	Relations.Add(new DataRelation("fin_incomeclawback_csa_importver",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{csa_importver.Columns["idexp_cost"]};
	Relations.Add(new DataRelation("expenseview_csa_importver",cPar,cChild,false));

	cPar = new []{account_expense.Columns["idacc"]};
	cChild = new []{csa_importver.Columns["idacc_expense"]};
	Relations.Add(new DataRelation("account_expense_csa_importver",cPar,cChild,false));

	cPar = new []{fin_expense.Columns["idfin"]};
	cChild = new []{csa_importver.Columns["idfin_expense"]};
	Relations.Add(new DataRelation("fin_expense_csa_importver",cPar,cChild,false));

	cPar = new []{fin_cost.Columns["idfin"]};
	cChild = new []{csa_importver.Columns["idfin_cost"]};
	Relations.Add(new DataRelation("fin_cost_csa_importver",cPar,cChild,false));

	cPar = new []{account_cost.Columns["idacc"]};
	cChild = new []{csa_importver.Columns["idacc_cost"]};
	Relations.Add(new DataRelation("account_cost_csa_importver",cPar,cChild,false));

	cPar = new []{csa_agencypaymethod.Columns["idcsa_agency"], csa_agencypaymethod.Columns["idcsa_agencypaymethod"]};
	cChild = new []{csa_importver.Columns["idcsa_agency"], csa_importver.Columns["idcsa_agencypaymethod"]};
	Relations.Add(new DataRelation("csa_agencypaymethod_csa_importver",cPar,cChild,false));

	cPar = new []{account_debit.Columns["idacc"]};
	cChild = new []{csa_importver.Columns["idacc_debit"]};
	Relations.Add(new DataRelation("account_debit_csa_importver",cPar,cChild,false));

	cPar = new []{fin_income.Columns["idfin"]};
	cChild = new []{csa_importver.Columns["idfin_income"]};
	Relations.Add(new DataRelation("fin_income_csa_importver",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_importver.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_importver",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{csa_importver.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_csa_importver",cPar,cChild,false));

	cPar = new []{csa_incomesetup.Columns["idcsa_incomesetup"], csa_incomesetup.Columns["ayear"]};
	cChild = new []{csa_importver.Columns["idcsa_incomesetup"], csa_importver.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_incomesetup_csa_importver",cPar,cChild,false));

	cPar = new []{csa_agency.Columns["idcsa_agency"]};
	cChild = new []{csa_importver.Columns["idcsa_agency"]};
	Relations.Add(new DataRelation("csa_agency_csa_importver",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_importver.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_importver",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_importver.Columns["idcsa_contract"], csa_importver.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_importver",cPar,cChild,false));

	cPar = new []{csa_contractkinddata.Columns["idcsa_contractkind"], csa_contractkinddata.Columns["idcsa_contractkinddata"], csa_contractkinddata.Columns["ayear"]};
	cChild = new []{csa_importver.Columns["idcsa_contractkind"], csa_importver.Columns["idcsa_contractkinddata"], csa_importver.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contractkinddata_csa_importver",cPar,cChild,false));

	cPar = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	cChild = new []{csa_importver.Columns["idcsa_contract"], csa_importver.Columns["idcsa_contracttax"], csa_importver.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contracttax_csa_importver",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importver.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importver",cPar,cChild,false));

	cPar = new []{registry_agency.Columns["idreg"]};
	cChild = new []{csa_importver.Columns["idreg_agency"]};
	Relations.Add(new DataRelation("registry_agency_csa_importver",cPar,cChild,false));

	cPar = new []{sorting_income.Columns["idsor"]};
	cChild = new []{csa_importver.Columns["idsor_siope_income"]};
	Relations.Add(new DataRelation("FK_sorting_income_csa_importver",cPar,cChild,false));

	cPar = new []{sorting_cost.Columns["idsor"]};
	cChild = new []{csa_importver.Columns["idsor_siope_cost"]};
	Relations.Add(new DataRelation("FK_sorting_cost_csa_importver",cPar,cChild,false));

	cPar = new []{sorting_incomeclawback.Columns["idsor"]};
	cChild = new []{csa_importver.Columns["idsor_siope_incomeclawback"]};
	Relations.Add(new DataRelation("FK_sorting_incomeclawback_csa_importver",cPar,cChild,false));

	cPar = new []{sorting_expense.Columns["idsor"]};
	cChild = new []{csa_importver.Columns["idsor_siope_expense"]};
	Relations.Add(new DataRelation("FK_sorting_expense_csa_importver",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{csa_importver.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("FK_underwriting_csa_importver",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{expenseview3.Columns["idexp"]};
	cChild = new []{csa_importver_partition.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview_csa_importver_partition",cPar,cChild,false));

	cPar = new []{account2.Columns["idacc"]};
	cChild = new []{csa_importver_partition.Columns["idacc"]};
	Relations.Add(new DataRelation("account_csa_importver_partition",cPar,cChild,false));

	cPar = new []{fin2.Columns["idfin"]};
	cChild = new []{csa_importver_partition.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_csa_importver_partition",cPar,cChild,false));

	cPar = new []{epexpview3.Columns["idepexp"]};
	cChild = new []{csa_importver_partition.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview_csa_importver_partition",cPar,cChild,false));

	cPar = new []{upb2.Columns["idupb"]};
	cChild = new []{csa_importver_partition.Columns["idupb"]};
	Relations.Add(new DataRelation("upb2_csa_importver_partition",cPar,cChild,false));

	cPar = new []{csa_importver.Columns["idcsa_import"], csa_importver.Columns["idver"]};
	cChild = new []{csa_importver_partition.Columns["idcsa_import"], csa_importver_partition.Columns["idver"]};
	Relations.Add(new DataRelation("csa_importver_csa_importver_partition",cPar,cChild,false));

	cPar = new []{csa_importver.Columns["idcsa_import"], csa_importver.Columns["idver"]};
	cChild = new []{csa_importver_partition_expense.Columns["idcsa_import"], csa_importver_partition_expense.Columns["idver"]};
	Relations.Add(new DataRelation("csa_importver_csa_importver_partition_expense",cPar,cChild,false));

	cPar = new []{csa_importver.Columns["idcsa_import"], csa_importver.Columns["idver"]};
	cChild = new []{csa_importver_partition_income.Columns["idcsa_import"], csa_importver_partition_income.Columns["idver"]};
	Relations.Add(new DataRelation("csa_importver_csa_importver_partition_income",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"]};
	cChild = new []{csa_importver_partition_income.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_csa_importver_partition_income",cPar,cChild,false));

	cPar = new []{expenseview4.Columns["idexp"]};
	cChild = new []{csa_importver_partition_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview4_csa_importver_partition_expense",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{csa_importver_partition.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting1_csa_importver_partition",cPar,cChild,false));

	#endregion

}
}
}
