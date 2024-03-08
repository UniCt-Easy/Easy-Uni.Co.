
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
using System.Globalization;
using meta_account;
using meta_config;
using metadatalibrary;
namespace testParentChildRelated {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public accountTable account 		{get { return (accountTable )Tables["account"];}}
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public configTable config 		{get { return (configTable )Tables["config"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable account_accruedcost 		{get { return (MetaTable)Tables["account_accruedcost"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public dsmeta(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";
	SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	MetaTable T;
	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new accountTable();
	taccount.addBaseColumns("idacc","ayear","codeacc","ct","cu","flag","flagcompetency","flagloss","flagprofit","flagregistry","flagtransitory","flagupb","idaccountkind","idpatrimony","idplaccount","lt","lu","nlevel","paridacc","patrimony_sign","placcount_sign","printingorder","rtf","title","txt","idacc_special","flagenablebudgetprev","flagaccountusage","economicbudget_sign","idsor_economicbudget","idsor_investmentbudget","investmentbudget_sign");
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","automanagekind","balancekind","booking_on_invoice","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","csa_flaggroupby_expense","csa_flaggroupby_income","csa_flaglinktoexp","ct","cu","cudactivitycode","currpartitiontitle","default_idfinvarstatus","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","email","email_f24","expense_expiringdays","expensephase","fin_kind","finvar_warnmail","finvarofficial_default","flag_autodocnumbering","flag_paymentamount","flagautopayment","flagautoproceeds","flagbank_grouping","flagcredit","flagdirectcsaclawback","flagepexp","flagfruitful","flagivapaybyrow","flagivaregphase","flagpayment","flagpayment12","flagpcashautopayment","flagpcashautoproceeds","flagproceeds","flagrefund","flagrefund12","flagva3","foreignhours","iban_f24","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_invoicetoemit","idacc_invoicetoreceive","idacc_ivapayment","idacc_ivapayment12","idacc_ivarefund","idacc_ivarefund12","idacc_mainivapayment","idacc_mainivapayment_internal","idacc_mainivapayment_internal12","idacc_mainivapayment12","idacc_mainivarefund","idacc_mainivarefund_internal","idacc_mainivarefund_internal12","idacc_mainivarefund12","idacc_patrimony","idacc_pl","idacc_revenue_gross_csa","idacc_supplier","idacc_unabatable","idacc_unabatable_refund","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfin_store","idfinexpense","idfinexpensesurplus","idfinincome_gross_csa","idfinincomesurplus","idfinivapayment","idfinivapayment12","idfinivarefund","idfinivarefund12","idinpscenter","idivapayperiodicity","idivapayperiodicity_instit","idpaymethodabi","idpaymethodnoabi","idreg_csa","idregauto","idsiopeincome_csa","idsor1_stock","idsor2_stock","idsor3_stock","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","invoice_flagregister","itineration_directauth","lcard","linktoinvoice","lt","lu","mainflagivaregphase","mainflagpayment","mainflagpayment12","mainflagrefund","mainflagrefund12","mainidacc_unabatable","mainidacc_unabatable_refund","mainidfinivapayment","mainidfinivapayment12","mainidfinivarefund","mainidfinivarefund12","mainminpayment","mainminpayment12","mainminrefund","mainminrefund12","mainpaymentagency","mainpaymentagency12","mainrefundagency","mainrefundagency12","mainstartivabalance","mainstartivabalance12","minpayment","minpayment12","minrefund","minrefund12","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","paymentagency12","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","refundagency12","startivabalance","startivabalance12","taxvaliditykind","wageaddition_flagrestart","wageimportappname","epannualthreeshold","flagbalance_csa","flagiva_immediate_or_deferred","flagenabletransmission","idpccdebitstatus","flagpaymentsplit","flagsplitpayment","idacc_ivapaymentsplit","idacc_unabatable_split","idfinivapaymentsplit","paymentagencysplit","startivabalancesplit","agencynumber","femode","idacc_economic_result","idacc_previous_economic_result","idacc_bankpaydoc","idacc_bankprodoc","csa_flagtransmissionlinking","idaccmotive_forwarder","idivakind_forwarder","idaccmotive_grantdeferredcost","idaccmotive_grantrevenue");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// ACCOUNT_ACCRUEDCOST /////////////////////////////////
	T= new MetaTable("account_accruedcost");
	T.defineColumn("idacc", typeof(String),false);
	T.defineColumn("ayear", typeof(Int16),false);
	T.defineColumn("codeacc", typeof(String),false);
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("flag", typeof(Int32));
	T.defineColumn("flagcompetency", typeof(String));
	T.defineColumn("flagloss", typeof(String));
	T.defineColumn("flagprofit", typeof(String));
	T.defineColumn("flagregistry", typeof(String));
	T.defineColumn("flagtransitory", typeof(String));
	T.defineColumn("flagupb", typeof(String));
	T.defineColumn("idaccountkind", typeof(String));
	T.defineColumn("idpatrimony", typeof(String));
	T.defineColumn("idplaccount", typeof(String));
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("nlevel", typeof(String),false);
	T.defineColumn("paridacc", typeof(String));
	T.defineColumn("patrimony_sign", typeof(String));
	T.defineColumn("placcount_sign", typeof(String));
	T.defineColumn("printingorder", typeof(String),false);
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("title", typeof(String),false);
	T.defineColumn("txt", typeof(String));
	T.defineColumn("idacc_special", typeof(String));
	T.defineColumn("flagenablebudgetprev", typeof(String));
	T.defineColumn("flagaccountusage", typeof(Int32));
	T.defineColumn("economicbudget_sign", typeof(String));
	T.defineColumn("idsor_economicbudget", typeof(Int32));
	T.defineColumn("idsor_investmentbudget", typeof(Int32));
	T.defineColumn("investmentbudget_sign", typeof(String));
	Tables.Add(T);
	T.defineKey("idacc");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{account.Columns["idacc"]};
	CChild = new DataColumn[1]{config.Columns["idacc_pl"]};
	Relations.Add(new DataRelation("account_config",CPar,CChild,false));

	CPar = new DataColumn[1]{account_accruedcost.Columns["idacc"]};
	CChild = new DataColumn[1]{config.Columns["idacc_accruedcost"]};
	Relations.Add(new DataRelation("idacc_accruedcost_config",CPar,CChild,false));

	#endregion

}
}
}
