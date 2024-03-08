
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
namespace csa_contract_default {
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
	///Contributi Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttax 		=> Tables["csa_contracttax"];

	///<summary>
	///Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contract 		=> Tables["csa_contract"];

	///<summary>
	///Matricole CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractregistry 		=> Tables["csa_contractregistry"];

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

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin1 		=> Tables["fin1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account1 		=> Tables["account1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb1 		=> Tables["upb1"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractview 		=> Tables["csa_contractview"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractexpense 		=> Tables["csa_contractexpense"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttaxexpense 		=> Tables["csa_contracttaxexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview1 		=> Tables["expenseview1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview2 		=> Tables["expenseview2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview3 		=> Tables["expenseview3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttaxexpenseview 		=> Tables["csa_contracttaxexpenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttaxview 		=> Tables["csa_contracttaxview"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexp 		=> Tables["epexp"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractepexp 		=> Tables["csa_contractepexp"];

	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttaxepexp 		=> Tables["csa_contracttaxepexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview2 		=> Tables["epexpview2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview 		=> Tables["epexpview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview1 		=> Tables["epexpview1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fase_epexp 		=> Tables["fase_epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contract_partition 		=> Tables["csa_contract_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview4 		=> Tables["expenseview4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview3 		=> Tables["epexpview3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin2 		=> Tables["fin2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account2 		=> Tables["account2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb2 		=> Tables["upb2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contracttax_partition 		=> Tables["csa_contracttax_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

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
	tcsa_contracttax.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_contracttax.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	tcsa_contracttax.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_contracttax.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tcsa_contracttax.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tcsa_contracttax.Columns.Add( new DataColumn("idepexp", typeof(int)));
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
	tcsa_contract.Columns.Add( new DataColumn("active", typeof(string)));
	tcsa_contract.Columns.Add( new DataColumn("idsor_siope_main", typeof(int)));
	tcsa_contract.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_contract.Columns.Add( new DataColumn("idepexp_main", typeof(int)));
	Tables.Add(tcsa_contract);
	tcsa_contract.PrimaryKey =  new DataColumn[]{tcsa_contract.Columns["idcsa_contract"], tcsa_contract.Columns["ayear"]};


	//////////////////// CSA_CONTRACTREGISTRY /////////////////////////////////
	var tcsa_contractregistry= new DataTable("csa_contractregistry");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	C= new DataColumn("idcsa_registry", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	C= new DataColumn("extmatricula", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractregistry.Columns.Add(C);
	tcsa_contractregistry.Columns.Add( new DataColumn("idreg", typeof(int)));
	tcsa_contractregistry.Columns.Add( new DataColumn("!title", typeof(string)));
	tcsa_contractregistry.Columns.Add( new DataColumn("!cf", typeof(string)));
	Tables.Add(tcsa_contractregistry);
	tcsa_contractregistry.PrimaryKey =  new DataColumn[]{tcsa_contractregistry.Columns["idcsa_contract"], tcsa_contractregistry.Columns["idcsa_registry"], tcsa_contractregistry.Columns["ayear"]};


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
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// FIN1 /////////////////////////////////
	var tfin1= new DataTable("fin1");
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin1.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin1.Columns.Add(C);
	Tables.Add(tfin1);
	tfin1.PrimaryKey =  new DataColumn[]{tfin1.Columns["idfin"]};


	//////////////////// ACCOUNT1 /////////////////////////////////
	var taccount1= new DataTable("account1");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	Tables.Add(taccount1);
	taccount1.PrimaryKey =  new DataColumn[]{taccount1.Columns["idacc"]};


	//////////////////// UPB1 /////////////////////////////////
	var tupb1= new DataTable("upb1");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb1.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb1.Columns.Add(C);
	Tables.Add(tupb1);
	tupb1.PrimaryKey =  new DataColumn[]{tupb1.Columns["idupb"]};


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


	//////////////////// CSA_CONTRACTVIEW /////////////////////////////////
	var tcsa_contractview= new DataTable("csa_contractview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	C= new DataColumn("ycontract", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	C= new DataColumn("ncontract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	tcsa_contractview.Columns.Add( new DataColumn("idcsa_contractkind", typeof(int)));
	tcsa_contractview.Columns.Add( new DataColumn("csa_contractkindcode", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("csa_contractkind", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	tcsa_contractview.Columns.Add( new DataColumn("description", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("upb", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("idupb_contractkind", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("codeupb_contractkind", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("upb_contractkind", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("idacc_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("codeacc_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("account_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("idfin_main", typeof(int)));
	tcsa_contractview.Columns.Add( new DataColumn("codefin_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("fin_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("idexp_main", typeof(int)));
	tcsa_contractview.Columns.Add( new DataColumn("nphase_main", typeof(byte)));
	tcsa_contractview.Columns.Add( new DataColumn("phase_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("ymov_main", typeof(short)));
	tcsa_contractview.Columns.Add( new DataColumn("nmov_main", typeof(int)));
	C= new DataColumn("flagkeepalive", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	tcsa_contractview.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractview.Columns.Add(C);
	tcsa_contractview.Columns.Add( new DataColumn("idsor_siope_main", typeof(int)));
	tcsa_contractview.Columns.Add( new DataColumn("sortcode_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("sorting_main", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_contractview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	tcsa_contractview.Columns.Add( new DataColumn("idepexp_main", typeof(int)));
	Tables.Add(tcsa_contractview);
	tcsa_contractview.PrimaryKey =  new DataColumn[]{tcsa_contractview.Columns["ayear"], tcsa_contractview.Columns["idcsa_contract"]};


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


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


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
	tcsa_contracttaxexpense.Columns.Add( new DataColumn("!phase", typeof(string)));
	tcsa_contracttaxexpense.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tcsa_contracttaxexpense.Columns.Add( new DataColumn("!nmov", typeof(int)));
	Tables.Add(tcsa_contracttaxexpense);
	tcsa_contracttaxexpense.PrimaryKey =  new DataColumn[]{tcsa_contracttaxexpense.Columns["ndetail"], tcsa_contracttaxexpense.Columns["ayear"], tcsa_contracttaxexpense.Columns["idcsa_contracttax"], tcsa_contracttaxexpense.Columns["idcsa_contract"]};


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

	//////////////////// EXPENSEVIEW2 /////////////////////////////////
	var texpenseview2= new DataTable("expenseview2");
	C= new DataColumn("idexp", typeof(int));
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
	Tables.Add(texpenseview2);
	texpenseview2.PrimaryKey =  new DataColumn[]{texpenseview2.Columns["idexp"]};


	//////////////////// EXPENSEVIEW3 /////////////////////////////////
	var texpenseview3= new DataTable("expenseview3");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview3.Columns.Add(C);
	Tables.Add(texpenseview3);
	texpenseview3.PrimaryKey =  new DataColumn[]{texpenseview3.Columns["idexp"]};


	//////////////////// CSA_CONTRACTTAXEXPENSEVIEW /////////////////////////////////
	var tcsa_contracttaxexpenseview= new DataTable("csa_contracttaxexpenseview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("quota", typeof(decimal));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxexpenseview.Columns.Add(C);
	tcsa_contracttaxexpenseview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contracttaxexpenseview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tcsa_contracttaxexpenseview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tcsa_contracttaxexpenseview.Columns.Add( new DataColumn("phase", typeof(string)));
	Tables.Add(tcsa_contracttaxexpenseview);
	tcsa_contracttaxexpenseview.PrimaryKey =  new DataColumn[]{tcsa_contracttaxexpenseview.Columns["ayear"], tcsa_contracttaxexpenseview.Columns["idcsa_contract"], tcsa_contracttaxexpenseview.Columns["idcsa_contracttax"], tcsa_contracttaxexpenseview.Columns["ndetail"]};


	//////////////////// CSA_CONTRACTTAXVIEW /////////////////////////////////
	var tcsa_contracttaxview= new DataTable("csa_contracttaxview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(int));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	tcsa_contracttaxview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("idacc", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contracttaxview.Columns.Add(C);
	tcsa_contracttaxview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("nphase", typeof(byte)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("sortcode_siope", typeof(string)));
	tcsa_contracttaxview.Columns.Add( new DataColumn("idepexp", typeof(int)));
	Tables.Add(tcsa_contracttaxview);
	tcsa_contracttaxview.PrimaryKey =  new DataColumn[]{tcsa_contracttaxview.Columns["ayear"], tcsa_contracttaxview.Columns["idcsa_contract"], tcsa_contracttaxview.Columns["idcsa_contracttax"]};


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
	tepexpview2.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview2.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview2.Columns.Add(C);
	Tables.Add(tepexpview2);
	tepexpview2.PrimaryKey =  new DataColumn[]{tepexpview2.Columns["idepexp"]};


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
	tepexpview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available5", typeof(decimal)));
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
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
	tepexpview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	Tables.Add(tepexpview);
	tepexpview.PrimaryKey =  new DataColumn[]{tepexpview.Columns["idepexp"]};


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
	tepexpview1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tepexpview1);
	tepexpview1.PrimaryKey =  new DataColumn[]{tepexpview1.Columns["idepexp"]};


	//////////////////// FASE_EPEXP /////////////////////////////////
	var tfase_epexp= new DataTable("fase_epexp");
	C= new DataColumn("nphase", typeof(int));
	C.AllowDBNull=false;
	tfase_epexp.Columns.Add(C);
	tfase_epexp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(tfase_epexp);
	tfase_epexp.PrimaryKey =  new DataColumn[]{tfase_epexp.Columns["nphase"]};


	//////////////////// CSA_CONTRACT_PARTITION /////////////////////////////////
	var tcsa_contract_partition= new DataTable("csa_contract_partition");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contract_partition.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contract_partition.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contract_partition.Columns.Add(C);
	tcsa_contract_partition.Columns.Add( new DataColumn("quota", typeof(double)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contract_partition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contract_partition.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contract_partition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contract_partition.Columns.Add(C);
	tcsa_contract_partition.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_contract_partition.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contract_partition.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_contract_partition.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!phasemovfin", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!ymov", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!nmov", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!phaseimpbudg", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!yepexp", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!nepexp", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!codeacc", typeof(string)));
	tcsa_contract_partition.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	Tables.Add(tcsa_contract_partition);
	tcsa_contract_partition.PrimaryKey =  new DataColumn[]{tcsa_contract_partition.Columns["idcsa_contract"], tcsa_contract_partition.Columns["ayear"], tcsa_contract_partition.Columns["ndetail"]};


	//////////////////// EXPENSEVIEW4 /////////////////////////////////
	var texpenseview4= new DataTable("expenseview4");
	C= new DataColumn("idexp", typeof(int));
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
	Tables.Add(texpenseview4);
	texpenseview4.PrimaryKey =  new DataColumn[]{texpenseview4.Columns["idexp"]};


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
	tepexpview3.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepexpview3.Columns.Add( new DataColumn("available5", typeof(decimal)));
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
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
	tepexpview3.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview3.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview3.Columns.Add(C);
	Tables.Add(tepexpview3);
	tepexpview3.PrimaryKey =  new DataColumn[]{tepexpview3.Columns["idepexp"]};


	//////////////////// FIN2 /////////////////////////////////
	var tfin2= new DataTable("fin2");
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin2.Columns.Add(C);
	Tables.Add(tfin2);
	tfin2.PrimaryKey =  new DataColumn[]{tfin2.Columns["idfin"]};


	//////////////////// ACCOUNT2 /////////////////////////////////
	var taccount2= new DataTable("account2");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount2.Columns.Add(C);
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
	Tables.Add(tupb2);
	tupb2.PrimaryKey =  new DataColumn[]{tupb2.Columns["idupb"]};


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


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting2.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting2.Columns.Add( new DataColumn("email", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


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
	var cPar = new []{epexpview2.Columns["idepexp"]};
	var cChild = new []{csa_contracttaxepexp.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview_csa_contracttaxepexp",cPar,cChild,false));

	cPar = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	cChild = new []{csa_contracttaxepexp.Columns["idcsa_contract"], csa_contracttaxepexp.Columns["idcsa_contracttax"], csa_contracttaxepexp.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contracttaxepexp_csa_contracttax",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_contractepexp.Columns["idcsa_contract"], csa_contractepexp.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contractepexp",cPar,cChild,false));

	cPar = new []{epexpview1.Columns["idepexp"]};
	cChild = new []{csa_contractepexp.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview1_csa_contractepexp",cPar,cChild,false));

	cPar = new []{expenseview2.Columns["idexp"]};
	cChild = new []{csa_contracttaxexpense.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expenseview2_csa_contracttaxexpense",cPar,cChild,false));

	cPar = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	cChild = new []{csa_contracttaxexpense.Columns["idcsa_contract"], csa_contracttaxexpense.Columns["idcsa_contracttax"], csa_contracttaxexpense.Columns["ayear"]};
	Relations.Add(new DataRelation("FK_csa_contracttaxexpense_csa_contracttax",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_contractexpense.Columns["idcsa_contract"], csa_contractexpense.Columns["ayear"]};
	Relations.Add(new DataRelation("FK_csa_contract_csa_contractexpense",cPar,cChild,false));

	cPar = new []{expenseview1.Columns["idexp"]};
	cChild = new []{csa_contractexpense.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expenseview1_csa_contractexpense",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_contractregistry.Columns["idcsa_contract"], csa_contractregistry.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contractregistry",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{csa_contractregistry.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_csa_contractregistry",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{csa_contract.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("FK_underwriting_csa_contract",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{csa_contract.Columns["idsor_siope_main"]};
	Relations.Add(new DataRelation("FK_sorting_csa_contract",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{csa_contract.Columns["idfin_main"]};
	Relations.Add(new DataRelation("fin_csa_contract",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contract.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contract",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{csa_contract.Columns["idacc_main"]};
	Relations.Add(new DataRelation("account_csa_contract",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{csa_contract.Columns["idexp_main"]};
	Relations.Add(new DataRelation("expenseview_csa_contract",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_contract.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_contract",cPar,cChild,false));

	cPar = new []{epexp.Columns["idepexp"]};
	cChild = new []{csa_contract.Columns["idepexp_main"]};
	Relations.Add(new DataRelation("epexp_csa_contract",cPar,cChild,false));

	cPar = new []{epexpview.Columns["idepexp"]};
	cChild = new []{csa_contract.Columns["idepexp_main"]};
	Relations.Add(new DataRelation("epexpview_csa_contract",cPar,cChild,false));

	cPar = new []{expenseview3.Columns["idexp"]};
	cChild = new []{csa_contracttax.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expenseview3_csa_contracttax",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{csa_contracttax.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting1_csa_contracttax",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contracttax",cPar,cChild,false));

	cPar = new []{upb1.Columns["idupb"]};
	cChild = new []{csa_contracttax.Columns["idupb"]};
	Relations.Add(new DataRelation("upb1_csa_contracttax",cPar,cChild,false));

	cPar = new []{fin1.Columns["idfin"]};
	cChild = new []{csa_contracttax.Columns["idfin"]};
	Relations.Add(new DataRelation("fin1_csa_contracttax",cPar,cChild,false));

	cPar = new []{account1.Columns["idacc"]};
	cChild = new []{csa_contracttax.Columns["idacc"]};
	Relations.Add(new DataRelation("account1_csa_contracttax",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	cChild = new []{csa_contract_partition.Columns["idcsa_contract"], csa_contract_partition.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contract_partition",cPar,cChild,false));

	cPar = new []{expenseview4.Columns["idexp"]};
	cChild = new []{csa_contract_partition.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview4_csa_contract_partition",cPar,cChild,false));

	cPar = new []{epexpview3.Columns["idepexp"]};
	cChild = new []{csa_contract_partition.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview3_csa_contract_partition",cPar,cChild,false));

	cPar = new []{fin2.Columns["idfin"]};
	cChild = new []{csa_contract_partition.Columns["idfin"]};
	Relations.Add(new DataRelation("fin2_csa_contract_partition",cPar,cChild,false));

	cPar = new []{account2.Columns["idacc"]};
	cChild = new []{csa_contract_partition.Columns["idacc"]};
	Relations.Add(new DataRelation("account2_csa_contract_partition",cPar,cChild,false));

	cPar = new []{upb2.Columns["idupb"]};
	cChild = new []{csa_contract_partition.Columns["idupb"]};
	Relations.Add(new DataRelation("upb2_csa_contract_partition",cPar,cChild,false));

	cPar = new []{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	cChild = new []{csa_contracttax_partition.Columns["idcsa_contract"], csa_contracttax_partition.Columns["idcsa_contracttax"], csa_contracttax_partition.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contracttax_csa_contracttax_partition",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{csa_contract_partition.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting2_csa_contract_partition",cPar,cChild,false));

	#endregion

}
}
}
