
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
namespace csa_contracttax_partition_elenco {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	///<summary>
	///Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contract 		=> Tables["csa_contract"];

	///<summary>
	///Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkind 		=> Tables["csa_contractkind"];

	///<summary>
	///Informazioni annuali su tipo contratto csa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkindyear 		=> Tables["csa_contractkindyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	///<summary>
	///Contributi Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttax 		=> Tables["csa_contracttax"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview 		=> Tables["epexpview"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttax_partition 		=> Tables["csa_contracttax_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fase_epexp 		=> Tables["fase_epexp"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttax_partitionview 		=> Tables["csa_contracttax_partitionview"];

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
	tcsa_contract.Columns.Add( new DataColumn("flagrecreate", typeof(string)));
	tcsa_contract.Columns.Add( new DataColumn("active", typeof(string)));
	tcsa_contract.Columns.Add( new DataColumn("idsor_siope_main", typeof(int)));
	tcsa_contract.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_contract.Columns.Add( new DataColumn("idepexp_main", typeof(int)));
	Tables.Add(tcsa_contract);
	tcsa_contract.PrimaryKey =  new DataColumn[]{tcsa_contract.Columns["idcsa_contract"], tcsa_contract.Columns["ayear"]};


	//////////////////// CSA_CONTRACTKIND /////////////////////////////////
	var tcsa_contractkind= new DataTable("csa_contractkind");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("flagcr", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	tcsa_contractkind.Columns.Add( new DataColumn("flagkeepalive", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	tcsa_contractkind.Columns.Add( new DataColumn("active", typeof(string)));
	tcsa_contractkind.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	Tables.Add(tcsa_contractkind);
	tcsa_contractkind.PrimaryKey =  new DataColumn[]{tcsa_contractkind.Columns["idcsa_contractkind"]};


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
	tcsa_contractkindyear.Columns.Add( new DataColumn("idsor_siope_main", typeof(int)));
	Tables.Add(tcsa_contractkindyear);
	tcsa_contractkindyear.PrimaryKey =  new DataColumn[]{tcsa_contractkindyear.Columns["idcsa_contractkind"], tcsa_contractkindyear.Columns["ayear"]};


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
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cf", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("p_iva", typeof(string)));
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
	texpenseview.Columns.Add( new DataColumn("idaccdebit", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeaccdebit", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cupcode", typeof(string)));
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
	tcsa_contracttax.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contracttax.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_contracttax.Columns.Add( new DataColumn("idepexp", typeof(int)));
	Tables.Add(tcsa_contracttax);
	tcsa_contracttax.PrimaryKey =  new DataColumn[]{tcsa_contracttax.Columns["idcsa_contract"], tcsa_contracttax.Columns["idcsa_contracttax"], tcsa_contracttax.Columns["ayear"]};


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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// EPEXPVIEW /////////////////////////////////
	var tepexpview= new DataTable("epexpview");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("amountwithsign", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("amountwithsign2", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("amountwithsign3", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("amountwithsign4", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("amountwithsign5", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("totamount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	C= new DataColumn("totcurramount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("available", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("available2", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("available3", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("available4", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("available5", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("costavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("totaldebit", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("parentyepexp", typeof(short)));
	tepexpview.Columns.Add( new DataColumn("parentnepexp", typeof(int)));
	C= new DataColumn("yliv1", typeof(short));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("nliv1", typeof(int));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexpview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("registry", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexpview.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("manager", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	C= new DataColumn("rateiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("debit", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("credit", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("cost", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("revenue", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("provision", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tepexpview);

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


	//////////////////// CSA_CONTRACTTAX_PARTITION /////////////////////////////////
	var tcsa_contracttax_partition= new DataTable("csa_contracttax_partition");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	tcsa_contracttax_partition.Columns.Add( new DataColumn("quota", typeof(double)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttax_partition.Columns.Add(C);
	tcsa_contracttax_partition.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_contracttax_partition.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contracttax_partition.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_contracttax_partition.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contracttax_partition.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contracttax_partition.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tcsa_contracttax_partition);
	tcsa_contracttax_partition.PrimaryKey =  new DataColumn[]{tcsa_contracttax_partition.Columns["idcsa_contract"], tcsa_contracttax_partition.Columns["idcsa_contracttax"], tcsa_contracttax_partition.Columns["ayear"], tcsa_contracttax_partition.Columns["ndetail"]};


	//////////////////// FASE_EPEXP /////////////////////////////////
	var tfase_epexp= new DataTable("fase_epexp");
	C= new DataColumn("nphase", typeof(int));
	C.AllowDBNull=false;
	tfase_epexp.Columns.Add(C);
	tfase_epexp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(tfase_epexp);
	tfase_epexp.PrimaryKey =  new DataColumn[]{tfase_epexp.Columns["nphase"]};


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
	tsorting.Columns.Add( new DataColumn("email", typeof(string)));
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// CSA_CONTRACTTAX_PARTITIONVIEW /////////////////////////////////
	var tcsa_contracttax_partitionview= new DataTable("csa_contracttax_partitionview");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("ycontract", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("ncontract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("csa_contractkind", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("flagcr", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("quota", typeof(double)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("paridexp", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttax_partitionview.Columns.Add(C);
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("yepexp", typeof(short)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("nepexp", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("nphaseepexp", typeof(short)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("upb", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("account", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("fin", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idsorkind", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("codesorkind", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("sortingkind", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("idsor", typeof(int)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("sortcode", typeof(string)));
	tcsa_contracttax_partitionview.Columns.Add( new DataColumn("sorting", typeof(string)));
	Tables.Add(tcsa_contracttax_partitionview);
	tcsa_contracttax_partitionview.PrimaryKey =  new DataColumn[]{tcsa_contracttax_partitionview.Columns["idcsa_contract"], tcsa_contracttax_partitionview.Columns["idcsa_contracttax"], tcsa_contracttax_partitionview.Columns["ayear"], tcsa_contracttax_partitionview.Columns["ndetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	var cChild = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contracttax",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("FK_csa_contractkindyear_csa_contractkind",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contract.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("FK_csa_contractkind_csa_contract",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_contracttax_partition.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_contracttax_partition",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{csa_contracttax_partition.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_csa_contracttax_partition",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{csa_contracttax_partition.Columns["idacc"]};
	Relations.Add(new DataRelation("account_csa_contracttax_partition",cPar,cChild,false));

	cPar = new []{epexpview.Columns["idepexp"]};
	cChild = new []{csa_contracttax_partition.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview_csa_contracttax_partition",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{csa_contracttax_partition.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview_csa_contracttax_partition",cPar,cChild,false));

	cPar = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	cChild = new []{csa_contracttax_partition.Columns["idcsa_contract"], csa_contracttax_partition.Columns["idcsa_contracttax"], csa_contracttax_partition.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contracttax_csa_contracttax_partition",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{csa_contracttax_partition.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_csa_contracttax_partition",cPar,cChild,false));

	#endregion

}
}
}
