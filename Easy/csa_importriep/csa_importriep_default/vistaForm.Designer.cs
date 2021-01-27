
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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace csa_importriep_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkind 		=> Tables["csa_contractkind"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Informazioni annuali su tipo contratto csa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkindyear 		=> Tables["csa_contractkindyear"];

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

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Importazione CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_import 		=> Tables["csa_import"];

	///<summary>
	///Importazione Riepiloghi CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep 		=> Tables["csa_importriep"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexp 		=> Tables["epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fase_epexp 		=> Tables["fase_epexp"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractepexp 		=> Tables["csa_contractepexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview1 		=> Tables["epexpview1"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractexpense 		=> Tables["csa_contractexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview1 		=> Tables["expenseview1"];

	///<summary>
	///Movimenti di spesa collegati ad un riepilogo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_expense 		=> Tables["csa_importriep_expense"];

	///<summary>
	///Impegni di budget collegati ad un riepilogo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_epexp 		=> Tables["csa_importriep_epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partition 		=> Tables["csa_importriep_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview3 		=> Tables["expenseview3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview3 		=> Tables["epexpview3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin2 		=> Tables["fin2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account2 		=> Tables["account2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb2 		=> Tables["upb2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partition_expense 		=> Tables["csa_importriep_partition_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partition_income 		=> Tables["csa_importriep_partition_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview4 		=> Tables["expenseview4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkindview 		=> Tables["csa_contractkindview"];

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


	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


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
	tcsa_contract.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
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


	//////////////////// CSA_IMPORTRIEP /////////////////////////////////
	var tcsa_importriep= new DataTable("csa_importriep");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	C= new DataColumn("idriep", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	C= new DataColumn("ruolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	C= new DataColumn("capitolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	C= new DataColumn("competenza", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	C= new DataColumn("matricola", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	C= new DataColumn("importo", typeof(decimal));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	tcsa_importriep.Columns.Add( new DataColumn("flagcr", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("idcsa_contractkind", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idcsa_contract", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep.Columns.Add(C);
	tcsa_importriep.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("ayear", typeof(short)));
	tcsa_importriep.Columns.Add( new DataColumn("competency", typeof(short)));
	tcsa_importriep.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idepexp", typeof(int)));
	Tables.Add(tcsa_importriep);
	tcsa_importriep.PrimaryKey =  new DataColumn[]{tcsa_importriep.Columns["idcsa_import"], tcsa_importriep.Columns["idriep"]};


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
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


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


	//////////////////// FASE_EPEXP /////////////////////////////////
	var tfase_epexp= new DataTable("fase_epexp");
	C= new DataColumn("nphase", typeof(int));
	C.AllowDBNull=false;
	tfase_epexp.Columns.Add(C);
	tfase_epexp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(tfase_epexp);
	tfase_epexp.PrimaryKey =  new DataColumn[]{tfase_epexp.Columns["nphase"]};


	//////////////////// CSA_CONTRACTEPEXP /////////////////////////////////
	var tcsa_contractepexp= new DataTable("csa_contractepexp");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	tcsa_contractepexp.Columns.Add( new DataColumn("quota", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	tcsa_contractepexp.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_contractepexp.Columns.Add( new DataColumn("!yepexp", typeof(short)));
	tcsa_contractepexp.Columns.Add( new DataColumn("!nepexp", typeof(int)));
	tcsa_contractepexp.Columns.Add( new DataColumn("!phase", typeof(string)));
	Tables.Add(tcsa_contractepexp);
	tcsa_contractepexp.PrimaryKey =  new DataColumn[]{tcsa_contractepexp.Columns["idcsa_contract"], tcsa_contractepexp.Columns["ayear"], tcsa_contractepexp.Columns["ndetail"]};


	//////////////////// EPEXPVIEW1 /////////////////////////////////
	var tepexpview1= new DataTable("epexpview1");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	tepexpview1.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("totamount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	tepexpview1.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	C= new DataColumn("totcurramount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	tepexpview1.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepexpview1.Columns.Add( new DataColumn("available5", typeof(decimal)));
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("totaldebit", typeof(decimal));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	tepexpview1.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("parentyepexp", typeof(short)));
	tepexpview1.Columns.Add( new DataColumn("parentnepexp", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexpview1.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview1.Columns.Add(C);
	tepexpview1.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("registry", typeof(string)));
	tepexpview1.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexpview1.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexpview1.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("manager", typeof(string)));
	tepexpview1.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tepexpview1.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	C= new DataColumn("rateiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("debit", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("credit", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("cost", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("revenue", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview1.Columns.Add(C);
	Tables.Add(tepexpview1);
	tepexpview1.PrimaryKey =  new DataColumn[]{tepexpview1.Columns["idepexp"]};


	//////////////////// CSA_CONTRACTEXPENSE /////////////////////////////////
	var tcsa_contractexpense= new DataTable("csa_contractexpense");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractexpense.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractexpense.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractexpense.Columns.Add(C);
	tcsa_contractexpense.Columns.Add( new DataColumn("quota", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractexpense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractexpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractexpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractexpense.Columns.Add(C);
	tcsa_contractexpense.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contractexpense.Columns.Add( new DataColumn("!ymov", typeof(short)));
	tcsa_contractexpense.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tcsa_contractexpense.Columns.Add( new DataColumn("!phase", typeof(string)));
	Tables.Add(tcsa_contractexpense);
	tcsa_contractexpense.PrimaryKey =  new DataColumn[]{tcsa_contractexpense.Columns["idcsa_contract"], tcsa_contractexpense.Columns["ayear"], tcsa_contractexpense.Columns["ndetail"]};


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
	texpenseview1.Columns.Add( new DataColumn("formerymov", typeof(short)));
	texpenseview1.Columns.Add( new DataColumn("formernmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview1.Columns.Add(C);
	texpenseview1.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("cf", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("p_iva", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("ypay", typeof(short)));
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
	texpenseview1.Columns.Add( new DataColumn("iban", typeof(string)));
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
	texpenseview1.Columns.Add( new DataColumn("codeser", typeof(string)));
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
	texpenseview1.Columns.Add( new DataColumn("clawbackref", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpenseview1.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	texpenseview1.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("codeaccdebit", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("cupcode", typeof(string)));
	texpenseview1.Columns.Add( new DataColumn("txt", typeof(string)));
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

	//////////////////// CSA_IMPORTRIEP_EXPENSE /////////////////////////////////
	var tcsa_importriep_expense= new DataTable("csa_importriep_expense");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_expense.Columns.Add(C);
	C= new DataColumn("idriep", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_expense.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_expense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_expense.Columns.Add(C);
	tcsa_importriep_expense.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importriep_expense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importriep_expense.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importriep_expense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importriep_expense.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importriep_expense.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_importriep_expense.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tcsa_importriep_expense.Columns.Add( new DataColumn("!nmov", typeof(int)));
	Tables.Add(tcsa_importriep_expense);
	tcsa_importriep_expense.PrimaryKey =  new DataColumn[]{tcsa_importriep_expense.Columns["idcsa_import"], tcsa_importriep_expense.Columns["idriep"], tcsa_importriep_expense.Columns["ndetail"]};


	//////////////////// CSA_IMPORTRIEP_EPEXP /////////////////////////////////
	var tcsa_importriep_epexp= new DataTable("csa_importriep_epexp");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_epexp.Columns.Add(C);
	C= new DataColumn("idriep", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_epexp.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_epexp.Columns.Add(C);
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_epexp.Columns.Add(C);
	tcsa_importriep_epexp.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importriep_epexp.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importriep_epexp.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importriep_epexp.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importriep_epexp.Columns.Add( new DataColumn("quota", typeof(decimal)));
	tcsa_importriep_epexp.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_importriep_epexp.Columns.Add( new DataColumn("!yepexp", typeof(int)));
	tcsa_importriep_epexp.Columns.Add( new DataColumn("!nepexp", typeof(int)));
	Tables.Add(tcsa_importriep_epexp);
	tcsa_importriep_epexp.PrimaryKey =  new DataColumn[]{tcsa_importriep_epexp.Columns["idcsa_import"], tcsa_importriep_epexp.Columns["idriep"], tcsa_importriep_epexp.Columns["ndetail"]};


	//////////////////// CSA_IMPORTRIEP_PARTITION /////////////////////////////////
	var tcsa_importriep_partition= new DataTable("csa_importriep_partition");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition.Columns.Add(C);
	C= new DataColumn("idriep", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition.Columns.Add(C);
	tcsa_importriep_partition.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!phasemovfin", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!ymov", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!nmov", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!phaseimpbudg", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!yepexp", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!nepexp", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!codeacc", typeof(string)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	Tables.Add(tcsa_importriep_partition);
	tcsa_importriep_partition.PrimaryKey =  new DataColumn[]{tcsa_importriep_partition.Columns["idcsa_import"], tcsa_importriep_partition.Columns["idriep"], tcsa_importriep_partition.Columns["ndetail"]};


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
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tcsa_importriep_partition_expense.Columns.Add( new DataColumn("!nmov", typeof(int)));
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
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tcsa_importriep_partition_income.Columns.Add( new DataColumn("!nmov", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partition_income.Columns.Add(C);
	Tables.Add(tcsa_importriep_partition_income);
	tcsa_importriep_partition_income.PrimaryKey =  new DataColumn[]{tcsa_importriep_partition_income.Columns["idcsa_import"], tcsa_importriep_partition_income.Columns["idriep"], tcsa_importriep_partition_income.Columns["ndetail"], tcsa_importriep_partition_income.Columns["idinc"]};


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


	//////////////////// CSA_CONTRACTKINDVIEW /////////////////////////////////
	var tcsa_contractkindview= new DataTable("csa_contractkindview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	tcsa_contractkindview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	tcsa_contractkindview.Columns.Add( new DataColumn("idacc_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("codeacc_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("account_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("idfin_main", typeof(int)));
	tcsa_contractkindview.Columns.Add( new DataColumn("codefin_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("fin_main", typeof(string)));
	C= new DataColumn("contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("flagcr", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	tcsa_contractkindview.Columns.Add( new DataColumn("flagkeepalive", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("active", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("idsor_siope_main", typeof(int)));
	tcsa_contractkindview.Columns.Add( new DataColumn("sortcode_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("sorting_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_contractkindview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	Tables.Add(tcsa_contractkindview);

	#endregion


	#region DataRelation creation
	var cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	var cChild = new []{csa_importriep.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("FK_csa_contractkind_csa_importriep",cPar,cChild,false));

	cPar = new []{epexpview1.Columns["idepexp"]};
	cChild = new []{csa_importriep_epexp.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview1_csa_contractepexp",cPar,cChild,false));

	cPar = new []{csa_importriep.Columns["idcsa_import"], csa_importriep.Columns["idriep"]};
	cChild = new []{csa_importriep_epexp.Columns["idcsa_import"], csa_importriep_epexp.Columns["idriep"]};
	Relations.Add(new DataRelation("csa_importriep_csa_importriep_epexp",cPar,cChild,false));

	cPar = new []{csa_importriep.Columns["idcsa_import"], csa_importriep.Columns["idriep"]};
	cChild = new []{csa_importriep_expense.Columns["idcsa_import"], csa_importriep_expense.Columns["idriep"]};
	Relations.Add(new DataRelation("csa_importriep_csa_importriep_expense",cPar,cChild,false));

	cPar = new []{expenseview1.Columns["idexp"]};
	cChild = new []{csa_importriep_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview1_csa_contractexpense",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_contractexpense.Columns["idcsa_contract"], csa_contractexpense.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contractexpense",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_contractepexp.Columns["idcsa_contract"], csa_contractepexp.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contractepexp",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{csa_importriep.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("FK_underwriting_csa_importriep",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{csa_importriep.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting_csa_importriep",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_importriep.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_importriep",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{csa_importriep.Columns["idacc"]};
	Relations.Add(new DataRelation("account_csa_importriep",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{csa_importriep.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_csa_importriep",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{csa_importriep.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_csa_importriep",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importriep.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importriep",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_importriep.Columns["idcsa_contract"], csa_importriep.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_importriep",cPar,cChild,false));

	cPar = new []{epexp.Columns["idepexp"]};
	cChild = new []{csa_importriep.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexp_csa_importriep",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{csa_importriep.Columns["idcsa_import"], csa_importriep.Columns["idriep"]};
	cChild = new []{csa_importriep_partition.Columns["idcsa_import"], csa_importriep_partition.Columns["idriep"]};
	Relations.Add(new DataRelation("csa_importriep_csa_importriep_partition",cPar,cChild,false));

	cPar = new []{expenseview3.Columns["idexp"]};
	cChild = new []{csa_importriep_partition.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview3_csa_importriep_partition",cPar,cChild,false));

	cPar = new []{epexpview3.Columns["idepexp"]};
	cChild = new []{csa_importriep_partition.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview3_csa_importriep_partition",cPar,cChild,false));

	cPar = new []{fin2.Columns["idfin"]};
	cChild = new []{csa_importriep_partition.Columns["idfin"]};
	Relations.Add(new DataRelation("fin2_csa_importriep_partition",cPar,cChild,false));

	cPar = new []{account2.Columns["idacc"]};
	cChild = new []{csa_importriep_partition.Columns["idacc"]};
	Relations.Add(new DataRelation("account2_csa_importriep_partition",cPar,cChild,false));

	cPar = new []{upb2.Columns["idupb"]};
	cChild = new []{csa_importriep_partition.Columns["idupb"]};
	Relations.Add(new DataRelation("upb2_csa_importriep_partition",cPar,cChild,false));

	cPar = new []{csa_importriep.Columns["idcsa_import"], csa_importriep.Columns["idriep"]};
	cChild = new []{csa_importriep_partition_expense.Columns["idcsa_import"], csa_importriep_partition_expense.Columns["idriep"]};
	Relations.Add(new DataRelation("csa_importriep_csa_importriep_partition_expense",cPar,cChild,false));

	cPar = new []{csa_importriep.Columns["idcsa_import"], csa_importriep.Columns["idriep"]};
	cChild = new []{csa_importriep_partition_income.Columns["idcsa_import"], csa_importriep_partition_income.Columns["idriep"]};
	Relations.Add(new DataRelation("csa_importriep_csa_importriep_partition_income",cPar,cChild,false));

	cPar = new []{expenseview4.Columns["idexp"]};
	cChild = new []{csa_importriep_partition_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview4_csa_importriep_partition_expense",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"]};
	cChild = new []{csa_importriep_partition_income.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_csa_importriep_partition_income",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{csa_importriep_partition.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting1_csa_importriep_partition",cPar,cChild,false));

	#endregion

}
}
}
