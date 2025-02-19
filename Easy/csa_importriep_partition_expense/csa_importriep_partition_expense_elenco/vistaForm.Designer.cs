
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
namespace csa_importriep_partition_expense_elenco {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partition_expense 		=> Tables["csa_importriep_partition_expense"];

	///<summary>
	///Importazione Riepiloghi CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep 		=> Tables["csa_importriep"];

	///<summary>
	///Importazione CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_import 		=> Tables["csa_import"];

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
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_movkind 		=> Tables["csa_movkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_main 		=> Tables["registry_main"];

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
	texpenseview.PrimaryKey =  new DataColumn[]{texpenseview.Columns["idexp"], texpenseview.Columns["ayear"]};


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
	tcsa_importriep.Columns.Add( new DataColumn("competency", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("idepexp", typeof(int)));
	Tables.Add(tcsa_importriep);
	tcsa_importriep.PrimaryKey =  new DataColumn[]{tcsa_importriep.Columns["idcsa_import"], tcsa_importriep.Columns["idriep"]};


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
	tcsa_import.Columns.Add( new DataColumn("ybill_netti", typeof(short)));
	tcsa_import.Columns.Add( new DataColumn("nbill_netti", typeof(int)));
	tcsa_import.Columns.Add( new DataColumn("ybill_versamenti", typeof(short)));
	tcsa_import.Columns.Add( new DataColumn("nbill_versamenti", typeof(int)));
	Tables.Add(tcsa_import);
	tcsa_import.PrimaryKey =  new DataColumn[]{tcsa_import.Columns["idcsa_import"]};


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
	tregistry.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// CSA_MOVKIND /////////////////////////////////
	var tcsa_movkind= new DataTable("csa_movkind");
	C= new DataColumn("movkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_movkind.Columns.Add(C);
	tcsa_movkind.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tcsa_movkind);
	tcsa_movkind.PrimaryKey =  new DataColumn[]{tcsa_movkind.Columns["movkind"]};


	//////////////////// REGISTRY_MAIN /////////////////////////////////
	var tregistry_main= new DataTable("registry_main");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	tregistry_main.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry_main.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	tregistry_main.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry_main.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry_main.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	tregistry_main.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry_main.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	tregistry_main.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry_main.Columns.Add(C);
	tregistry_main.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry_main.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry_main.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry_main.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	tregistry_main.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	Tables.Add(tregistry_main);
	tregistry_main.PrimaryKey =  new DataColumn[]{tregistry_main.Columns["idreg"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{expenseview.Columns["idexp"]};
	var cChild = new []{csa_importriep_partition_expense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview_csa_importriep_partition_expense",cPar,cChild,false));

	cPar = new []{csa_importriep.Columns["idcsa_import"], csa_importriep.Columns["idriep"]};
	cChild = new []{csa_importriep_partition_expense.Columns["idcsa_import"], csa_importriep_partition_expense.Columns["idriep"]};
	Relations.Add(new DataRelation("csa_importriep_csa_importriep_partition_expense",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importriep_partition_expense.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importriep_partition_expense",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_importriep.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_importriep",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{csa_importriep.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_csa_importriep",cPar,cChild,false));

	cPar = new []{csa_movkind.Columns["movkind"]};
	cChild = new []{csa_importriep_partition_expense.Columns["movkind"]};
	Relations.Add(new DataRelation("csa_movkind_csa_importriep_partition_expense",cPar,cChild,false));

	cPar = new []{registry_main.Columns["idreg"]};
	cChild = new []{expenseview.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_main_expenseview",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"], csa_contract.Columns["idcsa_contractkind"]};
	cChild = new []{csa_importriep.Columns["idcsa_contract"], csa_importriep.Columns["ayear"], csa_importriep.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contract_csa_importriep",cPar,cChild,false));

	#endregion

}
}
}
