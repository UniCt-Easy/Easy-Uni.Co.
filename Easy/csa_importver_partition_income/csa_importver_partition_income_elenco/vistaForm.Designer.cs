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
namespace csa_importver_partition_income_elenco {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partition_income 		=> Tables["csa_importver_partition_income"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

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
	///Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contract 		=> Tables["csa_contract"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_movkind 		=> Tables["csa_movkind"];

	///<summary>
	///Ente CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_agency 		=> Tables["csa_agency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_agency 		=> Tables["registry_agency"];

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
	EnforceConstraints = false;

	#region create DataTables
	DataColumn C;
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
	tcsa_importver_partition_income.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_partition_income.Columns.Add( new DataColumn("movkind", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partition_income.Columns.Add(C);
	Tables.Add(tcsa_importver_partition_income);
	tcsa_importver_partition_income.PrimaryKey =  new DataColumn[]{tcsa_importver_partition_income.Columns["idcsa_import"], tcsa_importver_partition_income.Columns["idver"], tcsa_importver_partition_income.Columns["ndetail"], tcsa_importver_partition_income.Columns["idinc"]};


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
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contractkind", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contract", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_agency", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idfin_income", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_debit", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idfin_expense", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_expense", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idfin_incomeclawback", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_internalcredit", typeof(string)));
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
	tcsa_importver.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("competency", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_agency_credit", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_income", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_expense", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_incomeclawback", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_cost", typeof(int)));
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


	//////////////////// CSA_AGENCY /////////////////////////////////
	var tcsa_agency= new DataTable("csa_agency");
	C= new DataColumn("idcsa_agency", typeof(int));
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
	tcsa_agency.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tcsa_agency);
	tcsa_agency.PrimaryKey =  new DataColumn[]{tcsa_agency.Columns["idcsa_agency"]};


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
	tregistry_agency.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry_agency.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	tregistry_agency.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	Tables.Add(tregistry_agency);
	tregistry_agency.PrimaryKey =  new DataColumn[]{tregistry_agency.Columns["idreg"]};


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
	var cPar = new []{incomeview.Columns["idinc"]};
	var cChild = new []{csa_importver_partition_income.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_csa_importver_partition_income",cPar,cChild,false));

	cPar = new []{csa_importver.Columns["idcsa_import"], csa_importver.Columns["idver"]};
	cChild = new []{csa_importver_partition_income.Columns["idcsa_import"], csa_importver_partition_income.Columns["idver"]};
	Relations.Add(new DataRelation("csa_importver_csa_importver_partition_income",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importver_partition_income.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importver_partition_income",cPar,cChild,false));

	cPar = new []{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"], csa_contract.Columns["idcsa_contractkind"]};
	cChild = new []{csa_importver.Columns["idcsa_contract"], csa_importver.Columns["ayear"], csa_importver.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contract_csa_importver",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{csa_importver.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_csa_importver",cPar,cChild,false));

	cPar = new []{csa_movkind.Columns["movkind"]};
	cChild = new []{csa_importver_partition_income.Columns["movkind"]};
	Relations.Add(new DataRelation("csa_movkind_csa_importver_partition_income",cPar,cChild,false));

	cPar = new []{csa_agency.Columns["idcsa_agency"]};
	cChild = new []{csa_importver.Columns["idcsa_agency"]};
	Relations.Add(new DataRelation("csa_agency_csa_importver",cPar,cChild,false));

	cPar = new []{registry_agency.Columns["idreg"]};
	cChild = new []{csa_importver.Columns["idreg_agency"]};
	Relations.Add(new DataRelation("registry_agency_csa_importver",cPar,cChild,false));

	cPar = new []{registry_main.Columns["idreg"]};
	cChild = new []{incomeview.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_main_incomeview",cPar,cChild,false));

	#endregion

}
}
}
