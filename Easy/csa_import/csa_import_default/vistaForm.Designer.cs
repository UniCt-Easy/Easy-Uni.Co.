
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
namespace csa_import_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_import 		=> Tables["csa_import"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep 		=> Tables["csa_importriep"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver 		=> Tables["csa_importver"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry1 		=> Tables["registry1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_epexp 		=> Tables["csa_importver_epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_expense 		=> Tables["csa_importver_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_epexp 		=> Tables["csa_importriep_epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_expense 		=> Tables["csa_importriep_expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partition 		=> Tables["csa_importriep_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partition 		=> Tables["csa_importver_partition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importriep_partitionview 		=> Tables["csa_importriep_partitionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_importver_partitionview 		=> Tables["csa_importver_partitionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill_netti 		=> Tables["bill_netti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill_versamenti 		=> Tables["bill_versamenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_bill 		=> Tables["csa_bill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_sospesi 		=> Tables["registry_sospesi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill_ripartizione 		=> Tables["bill_ripartizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_import 		=> Tables["emisti_import"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_01 		=> Tables["emisti_rec_01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_10 		=> Tables["emisti_rec_10"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_02 		=> Tables["emisti_rec_02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_03 		=> Tables["emisti_rec_03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_04 		=> Tables["emisti_rec_04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_05 		=> Tables["emisti_rec_05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_06 		=> Tables["emisti_rec_06"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_07 		=> Tables["emisti_rec_07"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_08 		=> Tables["emisti_rec_08"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emisti_rec_09 		=> Tables["emisti_rec_09"];

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
	tcsa_import.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	tcsa_import.Columns.Add( new DataColumn("referencedate", typeof(DateTime)));
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
	tcsa_importriep.Columns.Add( new DataColumn("ayear", typeof(int)));
	tcsa_importriep.Columns.Add( new DataColumn("!fin", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("!upb", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("!account", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("!registry", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("idepexp", typeof(string)));
	tcsa_importriep.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tcsa_importriep);
	tcsa_importriep.PrimaryKey =  new DataColumn[]{tcsa_importriep.Columns["idcsa_import"], tcsa_importriep.Columns["idriep"]};


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
	tcsa_importver.Columns.Add( new DataColumn("ayear", typeof(int)));
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
	tcsa_importver.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idreg", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contracttax", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_contractkinddata", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idcsa_incomesetup", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver.Columns.Add(C);
	tcsa_importver.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idacc_agency_credit", typeof(string)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_income", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_expense", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_incomeclawback", typeof(int)));
	tcsa_importver.Columns.Add( new DataColumn("idsor_siope_cost", typeof(int)));
	Tables.Add(tcsa_importver);
	tcsa_importver.PrimaryKey =  new DataColumn[]{tcsa_importver.Columns["idcsa_import"], tcsa_importver.Columns["idver"]};


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


	//////////////////// REGISTRY1 /////////////////////////////////
	var tregistry1= new DataTable("registry1");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	tregistry1.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry1.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	tregistry1.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry1.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry1.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	tregistry1.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry1.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	tregistry1.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry1.Columns.Add(C);
	tregistry1.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry1.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry1.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry1.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistry1);
	tregistry1.PrimaryKey =  new DataColumn[]{tregistry1.Columns["idreg"]};


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
	texpenseview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(texpenseview);

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
	Tables.Add(tcsa_importver_expense);
	tcsa_importver_expense.PrimaryKey =  new DataColumn[]{tcsa_importver_expense.Columns["idcsa_import"], tcsa_importver_expense.Columns["idver"], tcsa_importver_expense.Columns["ndetail"]};


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
	Tables.Add(tcsa_importriep_epexp);
	tcsa_importriep_epexp.PrimaryKey =  new DataColumn[]{tcsa_importriep_epexp.Columns["idcsa_import"], tcsa_importriep_epexp.Columns["idriep"], tcsa_importriep_epexp.Columns["ndetail"]};


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
	Tables.Add(tcsa_importriep_expense);
	tcsa_importriep_expense.PrimaryKey =  new DataColumn[]{tcsa_importriep_expense.Columns["idcsa_import"], tcsa_importriep_expense.Columns["idriep"], tcsa_importriep_expense.Columns["ndetail"]};


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
	tcsa_importriep_partition.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importriep_partition.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tcsa_importriep_partition);
	tcsa_importriep_partition.PrimaryKey =  new DataColumn[]{tcsa_importriep_partition.Columns["idcsa_import"], tcsa_importriep_partition.Columns["idriep"], tcsa_importriep_partition.Columns["ndetail"]};


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
	tcsa_importver_partition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_partition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_partition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importver_partition.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tcsa_importver_partition);
	tcsa_importver_partition.PrimaryKey =  new DataColumn[]{tcsa_importver_partition.Columns["idcsa_import"], tcsa_importver_partition.Columns["idver"], tcsa_importver_partition.Columns["ndetail"]};


	//////////////////// CSA_IMPORTRIEP_PARTITIONVIEW /////////////////////////////////
	var tcsa_importriep_partitionview= new DataTable("csa_importriep_partitionview");
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("ayear", typeof(short)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("competency", typeof(int)));
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	C= new DataColumn("yimport", typeof(short));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	C= new DataColumn("nimport", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	C= new DataColumn("idriep", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idcsa_contract", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("ycontract", typeof(short)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("ncontract", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idcsa_contractkind", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("csa_contractkindcode", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("csa_contractkind", typeof(string)));
	C= new DataColumn("ruolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	C= new DataColumn("capitolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	C= new DataColumn("competenza", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("flagcr", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("matricola", typeof(string));
	C.AllowDBNull=false;
	tcsa_importriep_partitionview.Columns.Add(C);
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("paridexp", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("yepexp", typeof(short)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("nepexp", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("nphaseepexp", typeof(short)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("upb", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("account", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("fin", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idsorkind", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("codesorkind", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("sortingkind", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("idsor_siope", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("sortcode_siope", typeof(string)));
	tcsa_importriep_partitionview.Columns.Add( new DataColumn("sorting_siope", typeof(string)));
	Tables.Add(tcsa_importriep_partitionview);
	tcsa_importriep_partitionview.PrimaryKey =  new DataColumn[]{tcsa_importriep_partitionview.Columns["idcsa_import"], tcsa_importriep_partitionview.Columns["idriep"], tcsa_importriep_partitionview.Columns["ndetail"]};


	//////////////////// CSA_IMPORTVER_PARTITIONVIEW /////////////////////////////////
	var tcsa_importver_partitionview= new DataTable("csa_importver_partitionview");
	tcsa_importver_partitionview.Columns.Add( new DataColumn("ayear", typeof(short)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("competency", typeof(int)));
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("yimport", typeof(short));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("nimport", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("idver", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	tcsa_importver_partitionview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idcsa_contract", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("ycontract", typeof(short)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("ncontract", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idcsa_contractkind", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("csa_contractkindcode", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("csa_contractkind", typeof(string)));
	C= new DataColumn("ruolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("capitolocsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("competenza", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("matricola", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("ente", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_importver_partitionview.Columns.Add(C);
	tcsa_importver_partitionview.Columns.Add( new DataColumn("vocecsaunified", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("registry", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idcsa_agency", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("agency", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idreg_agency", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("registry_agency", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idcsa_agencypaymethod", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idcsa_contracttax", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idcsa_contractkinddata", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idcsa_incomesetup", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idacc_debit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codeacc_debit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("account_debit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idacc_expense", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codeacc_expense", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("account_expense", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idacc_internalcredit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codeacc_internalcredit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("account_internalcredit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codeacc_revenue", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("account_revenue", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idacc_agency_credit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codeacc_agency_credit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("account_agency_credit", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idfin_income", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codefin_income", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("fin_income", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idfin_expense", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codefin_expense", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("fin_expense", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idfin_incomeclawback", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codefin_incomeclawback", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("fin_incomeclawback", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idsor_siope_income", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sortcode_income", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sorting_income", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idsor_siope_expense", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sortcode_expense", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sorting_expense", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idsor_siope_incomeclawback", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sortcode_incomeclawback", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sorting_incomeclawback", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idsor_siope_cost", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sortcode_cost", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sorting_cost", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("paridexp", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("yepexp", typeof(short)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("nepexp", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("nphaseepexp", typeof(short)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("flagcr", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("flagclawback", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("upb", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idacc_cost", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codeacc_cost", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("account_cost", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("fin", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idsorkind", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("codesorkind", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sortingkind", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("idsor_siope", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sortcode_siope", typeof(string)));
	tcsa_importver_partitionview.Columns.Add( new DataColumn("sorting_siope", typeof(string)));
	Tables.Add(tcsa_importver_partitionview);
	tcsa_importver_partitionview.PrimaryKey =  new DataColumn[]{tcsa_importver_partitionview.Columns["idcsa_import"], tcsa_importver_partitionview.Columns["ndetail"], tcsa_importver_partitionview.Columns["idver"]};


	//////////////////// BILL_NETTI /////////////////////////////////
	var tbill_netti= new DataTable("bill_netti");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbill_netti.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbill_netti.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbill_netti.Columns.Add(C);
	tbill_netti.Columns.Add( new DataColumn("registry", typeof(string)));
	tbill_netti.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbill_netti.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbill_netti.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbill_netti.Columns.Add( new DataColumn("active", typeof(string)));
	tbill_netti.Columns.Add( new DataColumn("motive", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill_netti.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill_netti.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill_netti.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill_netti.Columns.Add(C);
	tbill_netti.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbill_netti.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbill_netti.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	tbill_netti.Columns.Add( new DataColumn("banknum", typeof(int)));
	tbill_netti.Columns.Add( new DataColumn("idbank", typeof(string)));
	Tables.Add(tbill_netti);
	tbill_netti.PrimaryKey =  new DataColumn[]{tbill_netti.Columns["ybill"], tbill_netti.Columns["nbill"], tbill_netti.Columns["billkind"]};


	//////////////////// BILL_VERSAMENTI /////////////////////////////////
	var tbill_versamenti= new DataTable("bill_versamenti");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbill_versamenti.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbill_versamenti.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbill_versamenti.Columns.Add(C);
	tbill_versamenti.Columns.Add( new DataColumn("registry", typeof(string)));
	tbill_versamenti.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbill_versamenti.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbill_versamenti.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbill_versamenti.Columns.Add( new DataColumn("active", typeof(string)));
	tbill_versamenti.Columns.Add( new DataColumn("motive", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill_versamenti.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill_versamenti.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill_versamenti.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill_versamenti.Columns.Add(C);
	tbill_versamenti.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbill_versamenti.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbill_versamenti.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	tbill_versamenti.Columns.Add( new DataColumn("banknum", typeof(int)));
	tbill_versamenti.Columns.Add( new DataColumn("idbank", typeof(string)));
	Tables.Add(tbill_versamenti);
	tbill_versamenti.PrimaryKey =  new DataColumn[]{tbill_versamenti.Columns["ybill"], tbill_versamenti.Columns["nbill"], tbill_versamenti.Columns["billkind"]};


	//////////////////// CSA_BILL /////////////////////////////////
	var tcsa_bill= new DataTable("csa_bill");
	C= new DataColumn("idcsa_import", typeof(int));
	C.AllowDBNull=false;
	tcsa_bill.Columns.Add(C);
	C= new DataColumn("idcsa_bill", typeof(int));
	C.AllowDBNull=false;
	tcsa_bill.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcsa_bill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tcsa_bill.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tcsa_bill.Columns.Add(C);
	tcsa_bill.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcsa_bill.Columns.Add( new DataColumn("lu", typeof(string)));
	tcsa_bill.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcsa_bill.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_bill.Columns.Add( new DataColumn("!registry", typeof(string)));
	tcsa_bill.Columns.Add( new DataColumn("!motive", typeof(string)));
	tcsa_bill.Columns.Add( new DataColumn("!datasospeso", typeof(string)));
	Tables.Add(tcsa_bill);
	tcsa_bill.PrimaryKey =  new DataColumn[]{tcsa_bill.Columns["idcsa_import"], tcsa_bill.Columns["idcsa_bill"]};


	//////////////////// REGISTRY_SOSPESI /////////////////////////////////
	var tregistry_sospesi= new DataTable("registry_sospesi");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	tregistry_sospesi.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry_sospesi.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	tregistry_sospesi.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry_sospesi.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry_sospesi.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	tregistry_sospesi.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry_sospesi.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	tregistry_sospesi.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry_sospesi.Columns.Add(C);
	tregistry_sospesi.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry_sospesi.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry_sospesi.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry_sospesi.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	tregistry_sospesi.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	Tables.Add(tregistry_sospesi);
	tregistry_sospesi.PrimaryKey =  new DataColumn[]{tregistry_sospesi.Columns["idreg"]};


	//////////////////// BILL_RIPARTIZIONE /////////////////////////////////
	var tbill_ripartizione= new DataTable("bill_ripartizione");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbill_ripartizione.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbill_ripartizione.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbill_ripartizione.Columns.Add(C);
	tbill_ripartizione.Columns.Add( new DataColumn("registry", typeof(string)));
	tbill_ripartizione.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbill_ripartizione.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbill_ripartizione.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbill_ripartizione.Columns.Add( new DataColumn("active", typeof(string)));
	tbill_ripartizione.Columns.Add( new DataColumn("motive", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill_ripartizione.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill_ripartizione.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill_ripartizione.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill_ripartizione.Columns.Add(C);
	tbill_ripartizione.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbill_ripartizione.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbill_ripartizione.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	tbill_ripartizione.Columns.Add( new DataColumn("banknum", typeof(int)));
	tbill_ripartizione.Columns.Add( new DataColumn("idbank", typeof(string)));
	Tables.Add(tbill_ripartizione);
	tbill_ripartizione.PrimaryKey =  new DataColumn[]{tbill_ripartizione.Columns["ybill"], tbill_ripartizione.Columns["nbill"], tbill_ripartizione.Columns["billkind"]};


	//////////////////// EMISTI_IMPORT /////////////////////////////////
	var temisti_import= new DataTable("emisti_import");
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("nimport", typeof(int));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	C= new DataColumn("yimport", typeof(short));
	C.AllowDBNull=false;
	temisti_import.Columns.Add(C);
	temisti_import.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	temisti_import.Columns.Add( new DataColumn("idcsa_import", typeof(int)));
	Tables.Add(temisti_import);
	temisti_import.PrimaryKey =  new DataColumn[]{temisti_import.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_01 /////////////////////////////////
	var temisti_rec_01= new DataTable("emisti_rec_01");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	temisti_rec_01.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	temisti_rec_01.Columns.Add( new DataColumn("dpt", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("codicefiscale", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("cognome1", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("nome1", typeof(string)));
	C= new DataColumn("modalpagamento", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("tiposervizio", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	temisti_rec_01.Columns.Add( new DataColumn("iban", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("cin", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("abi", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("cab", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("contocorrente", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("ufficioservizio", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("capitolospesa", typeof(int)));
	temisti_rec_01.Columns.Add( new DataColumn("capitolobilancio", typeof(int)));
	temisti_rec_01.Columns.Add( new DataColumn("qualifica", typeof(string)));
	C= new DataColumn("livello", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("classe", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("scatti", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("imponibilerataannocorrente", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("irpefrataannocorrente", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("irpefarretratiannocorrente", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("irpefarretratiannoprecedente", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("irpeftotalenetta", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("importoannuolordo", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("importomensilelordo", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("importomensilenetto", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("importonetto13ma", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("importoprev13ma", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("importoirpef13ma", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("detrazionibase", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("detrazioniconiuge", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("detrazionifigli", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("detrazionialtrifam", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	C= new DataColumn("totaledetrazioni", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	temisti_rec_01.Columns.Add( new DataColumn("codiceregimecontributivo", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("codregioneirap", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("codicecomuneaccon", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("codicecomunesaldo", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("irpefaccessorieac", typeof(int)));
	temisti_rec_01.Columns.Add( new DataColumn("irpefaccessorieap", typeof(int)));
	temisti_rec_01.Columns.Add( new DataColumn("regimecontributivocud", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("creditoirpef", typeof(int)));
	temisti_rec_01.Columns.Add( new DataColumn("aliquotamedia", typeof(int)));
	temisti_rec_01.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_01.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_01.Columns.Add( new DataColumn("lu", typeof(string)));
	temisti_rec_01.Columns.Add( new DataColumn("iscrizione", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_01.Columns.Add(C);
	temisti_rec_01.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_01);
	temisti_rec_01.PrimaryKey =  new DataColumn[]{temisti_rec_01.Columns["nrec"], temisti_rec_01.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_10 /////////////////////////////////
	var temisti_rec_10= new DataTable("emisti_rec_10");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	temisti_rec_10.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("emissione", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("imponibileritenutaacconto", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("imponibileritenutaaccontoiva", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("importoritenutaacconto", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("impcontrintegrcat", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("impcontrintegrinps", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("importoiva", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("perccontrintegrcat", typeof(decimal));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	C= new DataColumn("perccontrintegrinps", typeof(decimal));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	temisti_rec_10.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_10.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_10.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_10.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_10.Columns.Add(C);
	temisti_rec_10.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_10);
	temisti_rec_10.PrimaryKey =  new DataColumn[]{temisti_rec_10.Columns["nrec"], temisti_rec_10.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_02 /////////////////////////////////
	var temisti_rec_02= new DataTable("emisti_rec_02");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	temisti_rec_02.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	C= new DataColumn("codiceassegno", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	temisti_rec_02.Columns.Add( new DataColumn("sottocodiceassegno", typeof(string)));
	C= new DataColumn("importolordotabellare", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	C= new DataColumn("importolordorata", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	C= new DataColumn("importoriduzionept", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	C= new DataColumn("importoriduzionete", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	C= new DataColumn("importoritprev", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	temisti_rec_02.Columns.Add( new DataColumn("datascadassegno", typeof(string)));
	temisti_rec_02.Columns.Add( new DataColumn("flagimponfiscale", typeof(string)));
	temisti_rec_02.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_02.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_02.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_02.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_02.Columns.Add(C);
	temisti_rec_02.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_02);
	temisti_rec_02.PrimaryKey =  new DataColumn[]{temisti_rec_02.Columns["nrec"], temisti_rec_02.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_03 /////////////////////////////////
	var temisti_rec_03= new DataTable("emisti_rec_03");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	temisti_rec_03.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	C= new DataColumn("codiceassegno", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	temisti_rec_03.Columns.Add( new DataColumn("codritprevass", typeof(string)));
	C= new DataColumn("aliquotalavoratore", typeof(decimal));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	C= new DataColumn("percentualeapplicazione", typeof(decimal));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	C= new DataColumn("imponibile", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	C= new DataColumn("importoritenuta", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	C= new DataColumn("aliquotadatore", typeof(decimal));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	C= new DataColumn("importodatore", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	temisti_rec_03.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_03.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_03.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_03.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_03.Columns.Add(C);
	temisti_rec_03.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_03);
	temisti_rec_03.PrimaryKey =  new DataColumn[]{temisti_rec_03.Columns["nrec"], temisti_rec_03.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_04 /////////////////////////////////
	var temisti_rec_04= new DataTable("emisti_rec_04");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_04.Columns.Add(C);
	temisti_rec_04.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_04.Columns.Add(C);
	temisti_rec_04.Columns.Add( new DataColumn("codiceritenuta", typeof(string)));
	temisti_rec_04.Columns.Add( new DataColumn("tiporitenuta", typeof(string)));
	temisti_rec_04.Columns.Add( new DataColumn("importoritenuta", typeof(int)));
	C= new DataColumn("importoritnetto", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_04.Columns.Add(C);
	temisti_rec_04.Columns.Add( new DataColumn("codritoneremens", typeof(string)));
	C= new DataColumn("importooneremens", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_04.Columns.Add(C);
	temisti_rec_04.Columns.Add( new DataColumn("codrit1tantum", typeof(string)));
	C= new DataColumn("importorit1tantum", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_04.Columns.Add(C);
	temisti_rec_04.Columns.Add( new DataColumn("codcontratto", typeof(string)));
	temisti_rec_04.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_04.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_04.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_04.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_04.Columns.Add(C);
	temisti_rec_04.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	temisti_rec_04.Columns.Add( new DataColumn("flagriduzimpon", typeof(string)));
	temisti_rec_04.Columns.Add( new DataColumn("progressivodebito", typeof(int)));
	Tables.Add(temisti_rec_04);
	temisti_rec_04.PrimaryKey =  new DataColumn[]{temisti_rec_04.Columns["nrec"], temisti_rec_04.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_05 /////////////////////////////////
	var temisti_rec_05= new DataTable("emisti_rec_05");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_05.Columns.Add(C);
	temisti_rec_05.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_05.Columns.Add(C);
	temisti_rec_05.Columns.Add( new DataColumn("codiceritenutacategoria", typeof(string)));
	C= new DataColumn("codiceassegno", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_05.Columns.Add(C);
	C= new DataColumn("importoritenuta", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_05.Columns.Add(C);
	temisti_rec_05.Columns.Add( new DataColumn("datascadritcat", typeof(DateTime)));
	temisti_rec_05.Columns.Add( new DataColumn("tiporitcat", typeof(string)));
	C= new DataColumn("percapplritcat", typeof(decimal));
	C.AllowDBNull=false;
	temisti_rec_05.Columns.Add(C);
	C= new DataColumn("percritcat", typeof(decimal));
	C.AllowDBNull=false;
	temisti_rec_05.Columns.Add(C);
	temisti_rec_05.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_05.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_05.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_05.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_05.Columns.Add(C);
	temisti_rec_05.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_05);
	temisti_rec_05.PrimaryKey =  new DataColumn[]{temisti_rec_05.Columns["nrec"], temisti_rec_05.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_06 /////////////////////////////////
	var temisti_rec_06= new DataTable("emisti_rec_06");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	temisti_rec_06.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	C= new DataColumn("codiceassegno", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	temisti_rec_06.Columns.Add( new DataColumn("codicearretrato", typeof(string)));
	C= new DataColumn("datalotto", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	C= new DataColumn("numlotto", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	C= new DataColumn("annoriferimento", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	C= new DataColumn("importolordorata", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	C= new DataColumn("importoriduzionept", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	C= new DataColumn("importoriduzionete", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	C= new DataColumn("importoritenute", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	temisti_rec_06.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_06.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_06.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_06.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_06.Columns.Add(C);
	temisti_rec_06.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_06);
	temisti_rec_06.PrimaryKey =  new DataColumn[]{temisti_rec_06.Columns["nrec"], temisti_rec_06.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_07 /////////////////////////////////
	var temisti_rec_07= new DataTable("emisti_rec_07");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	temisti_rec_07.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	C= new DataColumn("codiceassegno", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	temisti_rec_07.Columns.Add( new DataColumn("codicearretrato", typeof(string)));
	C= new DataColumn("datalotto", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	C= new DataColumn("numlotto", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	C= new DataColumn("annoriferimento", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	temisti_rec_07.Columns.Add( new DataColumn("codritprevass", typeof(string)));
	C= new DataColumn("imponibile", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	C= new DataColumn("importoritlavoratore", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	C= new DataColumn("importoritdatore", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	temisti_rec_07.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_07.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_07.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_07.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_07.Columns.Add(C);
	temisti_rec_07.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_07);
	temisti_rec_07.PrimaryKey =  new DataColumn[]{temisti_rec_07.Columns["nrec"], temisti_rec_07.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_08 /////////////////////////////////
	var temisti_rec_08= new DataTable("emisti_rec_08");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	temisti_rec_08.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("idelenco", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("codente", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("capbilstato", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("numpg", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	temisti_rec_08.Columns.Add( new DataColumn("tipotass", typeof(string)));
	C= new DataColumn("annoriferimento", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	temisti_rec_08.Columns.Add( new DataColumn("compenso", typeof(string)));
	temisti_rec_08.Columns.Add( new DataColumn("sottocompenso", typeof(string)));
	C= new DataColumn("tipolcompenso", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("importo", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("inizio_comp", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("fine_comp", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("quantita", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("imp_unitario", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	C= new DataColumn("importoritenute", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	temisti_rec_08.Columns.Add( new DataColumn("ufficioresponsabilecomunicante", typeof(string)));
	temisti_rec_08.Columns.Add( new DataColumn("ufficioserviziocomunicante", typeof(string)));
	temisti_rec_08.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_08.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_08.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_08.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_08.Columns.Add(C);
	temisti_rec_08.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_08);
	temisti_rec_08.PrimaryKey =  new DataColumn[]{temisti_rec_08.Columns["nrec"], temisti_rec_08.Columns["idemisti_import"]};


	//////////////////// EMISTI_REC_09 /////////////////////////////////
	var temisti_rec_09= new DataTable("emisti_rec_09");
	C= new DataColumn("nrec", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	temisti_rec_09.Columns.Add( new DataColumn("rata", typeof(string)));
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	C= new DataColumn("idelenco", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	C= new DataColumn("capbilstato", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	C= new DataColumn("numpg", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	C= new DataColumn("annoriferimento", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	temisti_rec_09.Columns.Add( new DataColumn("compenso", typeof(string)));
	temisti_rec_09.Columns.Add( new DataColumn("sottocompenso", typeof(string)));
	C= new DataColumn("tipolcompenso", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	temisti_rec_09.Columns.Add( new DataColumn("codritprevass", typeof(string)));
	C= new DataColumn("imponibile", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	C= new DataColumn("importoritlavoratore", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	C= new DataColumn("importoritdatore", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	temisti_rec_09.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	temisti_rec_09.Columns.Add( new DataColumn("cu", typeof(string)));
	temisti_rec_09.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	temisti_rec_09.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idemisti_import", typeof(int));
	C.AllowDBNull=false;
	temisti_rec_09.Columns.Add(C);
	temisti_rec_09.Columns.Add( new DataColumn("progressivo_rec_01", typeof(int)));
	Tables.Add(temisti_rec_09);
	temisti_rec_09.PrimaryKey =  new DataColumn[]{temisti_rec_09.Columns["nrec"], temisti_rec_09.Columns["idemisti_import"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{csa_import.Columns["idcsa_import"]};
	var cChild = new []{csa_importriep_expense.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importriep_expense",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importriep_epexp.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importriep_epexp",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importver_expense.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importver_expense",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importver_epexp.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importver_epexp",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importriep.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importriep",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{csa_importriep.Columns["idacc"]};
	Relations.Add(new DataRelation("account_csa_importriep",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{csa_importriep.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_csa_importriep",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_importriep.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_importriep",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importver_partition.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importver_partition",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importriep_partition.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importriep_partition",cPar,cChild,false));

	cPar = new []{bill_netti.Columns["ybill"], bill_netti.Columns["nbill"]};
	cChild = new []{csa_import.Columns["ybill_netti"], csa_import.Columns["nbill_netti"]};
	Relations.Add(new DataRelation("bill_netti_csa_import",cPar,cChild,false));

	cPar = new []{bill_versamenti.Columns["ybill"], bill_versamenti.Columns["nbill"]};
	cChild = new []{csa_import.Columns["ybill_versamenti"], csa_import.Columns["nbill_versamenti"]};
	Relations.Add(new DataRelation("bill_versamenti_csa_import",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_bill.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_bill",cPar,cChild,false));

	cPar = new []{registry_sospesi.Columns["idreg"]};
	cChild = new []{csa_bill.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_sospesi_csa_bill",cPar,cChild,false));

	cPar = new []{bill_ripartizione.Columns["nbill"]};
	cChild = new []{csa_bill.Columns["nbill"]};
	Relations.Add(new DataRelation("bill_csa_bill",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_01.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_01",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_02.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_02",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_03.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_03",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_04.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_04",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_05.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_05",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_06.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_06",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_07.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_07",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_08.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_08",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_09.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_09",cPar,cChild,false));

	cPar = new []{emisti_import.Columns["idemisti_import"]};
	cChild = new []{emisti_rec_10.Columns["idemisti_import"]};
	Relations.Add(new DataRelation("emisti_import_emisti_rec_10",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{emisti_import.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_emisti_import",cPar,cChild,false));

	cPar = new []{csa_import.Columns["idcsa_import"]};
	cChild = new []{csa_importver.Columns["idcsa_import"]};
	Relations.Add(new DataRelation("csa_import_csa_importver",cPar,cChild,false));

	#endregion

}
}
}
