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
using meta_config;
using meta_estimatedetail;
using meta_registry;
using meta_estimatekind;
using meta_estimate;
using meta_incomelast;
using meta_incomesorted;
using meta_income;
using meta_incomeyear;
using meta_upb;
using meta_fin;
using meta_incomevar;
using meta_flussocrediti;
using meta_flussocreditidetail;
using meta_invoice;
using meta_invoicedetail;
using meta_flussoincassi;
using meta_flussoincassidetail;
using meta_registryreference;
using meta_invoicekind;
using meta_ivaregister;
using meta_list;
using meta_ivaregisterkind;
using meta_webpayment;
using meta_ivakind;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace no_table_flussostudenti {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable no_table 		=> (MetaTable)Tables["no_table"];

	///<summary>
	///Informazioni ente contabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable license 		=> (MetaTable)Tables["license"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Dettaglio contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatedetailTable estimatedetail 		=> (estimatedetailTable)Tables["estimatedetail"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind 		=> (estimatekindTable)Tables["estimatekind"];

	///<summary>
	///Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimateTable estimate 		=> (estimateTable)Tables["estimate"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomephase 		=> (MetaTable)Tables["incomephase"];

	///<summary>
	///Movimento di entrata - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomelastTable incomelast 		=> (incomelastTable)Tables["incomelast"];

	///<summary>
	///Classificazione Movimenti di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomesortedTable incomesorted 		=> (incomesortedTable)Tables["incomesorted"];

	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeTable income 		=> (incomeTable)Tables["income"];

	///<summary>
	///Informazioni annuali su mov. di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeyearTable incomeyear 		=> (incomeyearTable)Tables["incomeyear"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin 		=> (finTable)Tables["fin"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry1 		=> (registryTable)Tables["registry1"];

	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomeestimate 		=> (MetaTable)Tables["incomeestimate"];

	///<summary>
	///Causali finanziarie (gerarchia)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive 		=> (MetaTable)Tables["finmotive"];

	///<summary>
	///Dettaglio causale finanziaria
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotivedetail 		=> (MetaTable)Tables["finmotivedetail"];

	///<summary>
	///Variazione movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomevarTable incomevar 		=> (incomevarTable)Tables["incomevar"];

	///<summary>
	///Crediti da comunicare al nodo pagamenti o simili, anche usata per i crediti che ci vengono comunicati dalle segreterie studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditiTable flussocrediti 		=> (flussocreditiTable)Tables["flussocrediti"];

	///<summary>
	///Dettaglio flusso crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditidetailTable flussocreditidetail 		=> (flussocreditidetailTable)Tables["flussocreditidetail"];

	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoiceTable invoice 		=> (invoiceTable)Tables["invoice"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomeinvoice 		=> (MetaTable)Tables["incomeinvoice"];

	///<summary>
	///Incassi comunicatici dal nodo pagamenti o simili
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussoincassiTable flussoincassi 		=> (flussoincassiTable)Tables["flussoincassi"];

	///<summary>
	///dettaglio flusso incassi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussoincassidetailTable flussoincassidetail 		=> (flussoincassidetailTable)Tables["flussoincassidetail"];

	///<summary>
	///Contatto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryreferenceTable registryreference 		=> (registryreferenceTable)Tables["registryreference"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	///<summary>
	///Valuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable currency 		=> (MetaTable)Tables["currency"];

	///<summary>
	///Registro iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivaregisterTable ivaregister 		=> (ivaregisterTable)Tables["ivaregister"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public listTable list 		=> (listTable)Tables["list"];

	///<summary>
	///collegamento tra registri iva e  tipo documento iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicekindregisterkind 		=> (MetaTable)Tables["invoicekindregisterkind"];

	///<summary>
	///Registro IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivaregisterkindTable ivaregisterkind 		=> (ivaregisterkindTable)Tables["ivaregisterkind"];

	///<summary>
	///Configurazione delle stampe
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable report 		=> (MetaTable)Tables["report"];

	///<summary>
	///Pagamento web
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public webpaymentTable webpayment 		=> (webpaymentTable)Tables["webpayment"];

	///<summary>
	///stato pagamento web
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable webpaymentstatus 		=> (MetaTable)Tables["webpaymentstatus"];

	///<summary>
	///Parametri prospetti generali
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable generalreportparameter 		=> (MetaTable)Tables["generalreportparameter"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new MetaTable("no_table");
	tno_table.defineColumn("idnotable", typeof(string),false);
	Tables.Add(tno_table);
	tno_table.defineKey("idnotable");

	//////////////////// LICENSE /////////////////////////////////
	var tlicense= new MetaTable("license");
	tlicense.defineColumn("dummykey", typeof(string),false);
	tlicense.defineColumn("address1", typeof(string));
	tlicense.defineColumn("address2", typeof(string));
	tlicense.defineColumn("agency", typeof(string));
	tlicense.defineColumn("agencycode", typeof(string));
	tlicense.defineColumn("agencyname", typeof(string));
	tlicense.defineColumn("annotations", typeof(string));
	tlicense.defineColumn("cap", typeof(string));
	tlicense.defineColumn("cf", typeof(string));
	tlicense.defineColumn("checkbackup1", typeof(string));
	tlicense.defineColumn("checkbackup2", typeof(string));
	tlicense.defineColumn("checkflag", typeof(string));
	tlicense.defineColumn("checklic", typeof(string));
	tlicense.defineColumn("checkman", typeof(string));
	tlicense.defineColumn("country", typeof(string));
	tlicense.defineColumn("dbname", typeof(string));
	tlicense.defineColumn("department", typeof(string));
	tlicense.defineColumn("departmentcode", typeof(string));
	tlicense.defineColumn("departmentname", typeof(string));
	tlicense.defineColumn("email", typeof(string));
	tlicense.defineColumn("expiringlic", typeof(DateTime));
	tlicense.defineColumn("expiringman", typeof(DateTime));
	tlicense.defineColumn("fax", typeof(string));
	tlicense.defineColumn("idcity", typeof(int));
	tlicense.defineColumn("iddb", typeof(int));
	tlicense.defineColumn("idreg", typeof(int));
	tlicense.defineColumn("lickind", typeof(string));
	tlicense.defineColumn("licstatus", typeof(string));
	tlicense.defineColumn("location", typeof(string));
	tlicense.defineColumn("lt", typeof(DateTime));
	tlicense.defineColumn("lu", typeof(string));
	tlicense.defineColumn("mankind", typeof(string));
	tlicense.defineColumn("manstatus", typeof(string));
	tlicense.defineColumn("nmsgs", typeof(int));
	tlicense.defineColumn("p_iva", typeof(string));
	tlicense.defineColumn("phonenumber", typeof(string));
	tlicense.defineColumn("referent", typeof(string));
	tlicense.defineColumn("sent", typeof(string));
	tlicense.defineColumn("serverbackup1", typeof(string));
	tlicense.defineColumn("serverbackup2", typeof(string));
	tlicense.defineColumn("servername", typeof(string));
	tlicense.defineColumn("swmorecode", typeof(string));
	tlicense.defineColumn("swmoreflag", typeof(int));
	Tables.Add(tlicense);
	tlicense.defineKey("dummykey");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","finvarofficial_default","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idregauto","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart","idivapayperiodicity","idsortingkind1","idsortingkind2","idsortingkind3","fin_kind","taxvaliditykind","flag_paymentamount","automanagekind","flag_autodocnumbering","flagbank_grouping","cashvaliditykind","wageimportappname","balancekind","idpaymethodabi","idpaymethodnoabi","iban_f24","cudactivitycode","startivabalance","flagivapaybyrow","idacc_unabatable","idacc_unabatable_refund","invoice_flagregister","default_idfinvarstatus","flagivaregphase","mainflagpayment","mainflagrefund","mainidfinivapayment","mainidfinivarefund","mainminpayment","mainminrefund","mainpaymentagency","mainrefundagency","mainflagivaregphase","mainstartivabalance","mainidacc_unabatable","mainidacc_unabatable_refund","idacc_mainivapayment","idacc_mainivapayment_internal","idacc_mainivarefund","idacc_mainivarefund_internal","flagva3","flagrefund12","flagpayment12","refundagency12","paymentagency12","idfinivarefund12","idfinivapayment12","minrefund12","minpayment12","idacc_ivapayment12","idacc_ivarefund12","idacc_mainivarefund12","idacc_mainivapayment12","idacc_mainivapayment_internal12","idacc_mainivarefund_internal12","startivabalance12","mainrefundagency12","mainpaymentagency12","mainflagrefund12","mainflagpayment12","mainidfinivarefund12","mainidfinivapayment12","mainminrefund12","mainminpayment12","mainstartivabalance12","idreg_csa","finvar_warnmail","flagdirectcsaclawback","idacc_revenue_gross_csa","idfinincome_gross_csa","idsor1_stock","idsor2_stock","idsor3_stock","idinpscenter","idivapayperiodicity_instit","idfin_store","flagpcashautopayment","flagpcashautoproceeds","email","lcard","booking_on_invoice");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new estimatedetailTable();
	testimatedetail.addBaseColumns("idestimkind","yestim","nestim","rownum","annotations","ct","cu","detaildescription","discount","idupb","lt","lu","ninvoiced","number","start","stop","tax","taxable","taxrate","toinvoice","idaccmotive","idreg","idgroup","competencystart","competencystop","idinc_taxable","idinc_iva","idivakind","idsor1","idsor2","idsor3","idaccmotiveannulment","epkind","idrevenuepartition","idepacc","idupb_iva","idlist","cigcode","iduniqueformcode","idfinmotive","flag","nform","idsor_siope","idepacc_pre");
	testimatedetail.defineColumn("!codeupb", typeof(string));
	testimatedetail.defineColumn("!codeupb_iva", typeof(string));
	testimatedetail.defineColumn("!registry", typeof(string));
	testimatedetail.defineColumn("!totaleriga", typeof(decimal));
	Tables.Add(testimatedetail);
	testimatedetail.defineKey("idestimkind", "yestim", "nestim", "rownum");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idcity","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","rtf","surname","title","txt","residence","idregistrykind","authorization_free","multi_cf","toredirect","idaccmotivedebit","idaccmotivecredit","ccp","flagbankitaliaproceeds","idexternal","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm","email_fe","pec_fe");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new estimatekindTable();
	testimatekind.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","linktoinvoice","multireg","deltaamount","deltapercentage","flag_autodocnumbering","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","idivakind_forced","flag");
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	//////////////////// ESTIMATE /////////////////////////////////
	var testimate= new estimateTable();
	testimate.addBaseColumns("idestimkind","yestim","nestim","active","adate","ct","cu","deliveryaddress","deliveryexpiration","description","doc","docdate","exchangerate","idreg","lt","lu","officiallyprinted","paymentexpiring","registryreference","txt","idman","idcurrency","idexpirationkind","flagintracom","idaccmotivecredit","idaccmotivecredit_crg","idaccmotivecredit_datacrg","idsor_underwriter","idunderwriting","idsor01","idsor02","idsor03","idsor04","idsor05","external_reference","cigcode");
	Tables.Add(testimate);
	testimate.defineKey("idestimkind", "yestim", "nestim");

	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new MetaTable("incomephase");
	tincomephase.defineColumn("nphase", typeof(byte),false);
	tincomephase.defineColumn("description", typeof(string),false);
	tincomephase.defineColumn("cu", typeof(string),false);
	tincomephase.defineColumn("ct", typeof(DateTime),false);
	tincomephase.defineColumn("lu", typeof(string),false);
	tincomephase.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tincomephase);
	tincomephase.defineKey("nphase");

	//////////////////// INCOMELAST /////////////////////////////////
	var tincomelast= new incomelastTable();
	tincomelast.addBaseColumns("idinc","ct","cu","flag","idpro","lt","lu","nbill","kpro","idacccredit");
	Tables.Add(tincomelast);
	tincomelast.defineKey("idinc");

	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new incomesortedTable();
	tincomesorted.addBaseColumns("idinc","idsor","idsubclass","amount","ayear","ct","cu","description","flagnodate","lt","lu","paridsor","paridsubclass","rtf","start","stop","tobecontinued","txt","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5");
	Tables.Add(tincomesorted);
	tincomesorted.defineKey("idinc", "idsor", "idsubclass");

	//////////////////// INCOME /////////////////////////////////
	var tincome= new incomeTable();
	tincome.addBaseColumns("idinc","nphase","ymov","nmov","parentidinc","idreg","idman","doc","docdate","description","idpayment","expiration","adate","cu","ct","lu","lt","autokind","autocode","cupcode","idunderwriting");
	Tables.Add(tincome);
	tincome.defineKey("idinc");

	//////////////////// INCOMEYEAR /////////////////////////////////
	var tincomeyear= new incomeyearTable();
	tincomeyear.addBaseColumns("idinc","ayear","idfin","idupb","amount","cu","ct","lu","lt");
	Tables.Add(tincomeyear);
	tincomeyear.defineKey("idinc", "ayear");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active","idsor01","idsor02","idsor03","idsor04","idsor05","idtreasurer");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// FIN /////////////////////////////////
	var tfin= new finTable();
	tfin.addBaseColumns("idfin","ayear","flag","codefin","paridfin","nlevel","printingorder","title","cu","ct","lu","lt");
	Tables.Add(tfin);
	tfin.defineKey("idfin");

	//////////////////// REGISTRY1 /////////////////////////////////
	var tregistry1= new registryTable();
	tregistry1.TableName = "registry1";
	tregistry1.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt","badgecode","idcategory","idcentralizedcategory","idmaritalstatus","idtitle","idregistryclass","maritalsurname","idcity","idnation","location","extmatricula");
	tregistry1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry1);
	tregistry1.defineKey("idreg");

	//////////////////// INCOMEESTIMATE /////////////////////////////////
	var tincomeestimate= new MetaTable("incomeestimate");
	tincomeestimate.defineColumn("idestimkind", typeof(string),false);
	tincomeestimate.defineColumn("yestim", typeof(short),false);
	tincomeestimate.defineColumn("nestim", typeof(int),false);
	tincomeestimate.defineColumn("idinc", typeof(int),false);
	tincomeestimate.defineColumn("movkind", typeof(short));
	tincomeestimate.defineColumn("cu", typeof(string),false);
	tincomeestimate.defineColumn("ct", typeof(DateTime),false);
	tincomeestimate.defineColumn("lu", typeof(string),false);
	tincomeestimate.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tincomeestimate);
	tincomeestimate.defineKey("idestimkind", "yestim", "nestim", "idinc");

	//////////////////// FINMOTIVE /////////////////////////////////
	var tfinmotive= new MetaTable("finmotive");
	tfinmotive.defineColumn("idfinmotive", typeof(string),false);
	tfinmotive.defineColumn("active", typeof(string),false);
	tfinmotive.defineColumn("codemotive", typeof(string),false);
	tfinmotive.defineColumn("paridfinmotive", typeof(string));
	tfinmotive.defineColumn("title", typeof(string),false);
	tfinmotive.defineColumn("lt", typeof(DateTime));
	tfinmotive.defineColumn("lu", typeof(string));
	tfinmotive.defineColumn("ct", typeof(DateTime));
	tfinmotive.defineColumn("cu", typeof(string));
	Tables.Add(tfinmotive);
	tfinmotive.defineKey("idfinmotive");

	//////////////////// FINMOTIVEDETAIL /////////////////////////////////
	var tfinmotivedetail= new MetaTable("finmotivedetail");
	tfinmotivedetail.defineColumn("idfinmotive", typeof(string),false);
	tfinmotivedetail.defineColumn("idfin", typeof(int),false);
	tfinmotivedetail.defineColumn("ayear", typeof(short),false);
	tfinmotivedetail.defineColumn("lu", typeof(string));
	tfinmotivedetail.defineColumn("cu", typeof(string));
	tfinmotivedetail.defineColumn("ct", typeof(DateTime));
	tfinmotivedetail.defineColumn("lt", typeof(DateTime));
	Tables.Add(tfinmotivedetail);
	tfinmotivedetail.defineKey("idfinmotive", "idfin", "ayear");

	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new incomevarTable();
	tincomevar.addBaseColumns("idinc","nvar","yvar","description","amount","doc","docdate","adate","txt","rtf","cu","ct","lu","lt","autokind","idinvkind","ninv","yinv");
	Tables.Add(tincomevar);
	tincomevar.defineKey("idinc", "nvar");

	//////////////////// FLUSSOCREDITI /////////////////////////////////
	var tflussocrediti= new flussocreditiTable();
	tflussocrediti.addBaseColumns("idflusso","cu","ct","lu","lt","datacreazioneflusso","flusso","istransmitted","docdate","idestimkind","idsor03","idsor02","idsor01","idsor04","idsor05","progday","filename");
	Tables.Add(tflussocrediti);
	tflussocrediti.defineKey("idflusso");

	//////////////////// FLUSSOCREDITIDETAIL /////////////////////////////////
	var tflussocreditidetail= new flussocreditidetailTable();
	tflussocreditidetail.addBaseColumns("idflusso","iddetail","cu","ct","lu","lt","importoversamento","idestimkind","yestim","nestim","rownum","idupb","idfinmotive","iduniqueformcode","idaccmotiverevenue","idaccmotivecredit","idaccmotiveundotax","idaccmotiveundotaxpost","idreg","nform","stop","competencystart","competencystop","description","idinvkind","yinv","ninv","invrownum","cf","annulment","flag","idunivoco","idsor1","idsor2","idsor3","idivakind","tax","number","idlist","p_iva","annotations","idupb_iva","iuv");
	Tables.Add(tflussocreditidetail);
	tflussocreditidetail.defineKey("idflusso", "iddetail");

	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new invoiceTable();
	tinvoice.addBaseColumns("ninv","yinv","active","adate","ct","cu","description","doc","docdate","exchangerate","flagdeferred","idreg","lt","lu","officiallyprinted","packinglistdate","packinglistnum","paymentexpiring","registryreference","rtf","txt","idinvkind","idcurrency","idexpirationkind","idtreasurer","flagintracom","iso_origin","iso_provenance","iso_destination","idcountry_origin","idcountry_destination","idintrastatkind","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idintrastatpaymethod","iso_payment","flag_ddt","flag","idblacklist","idinvkind_real","yinv_real","ninv_real","autoinvoice","idsor01","idsor02","idsor03","idsor04","idsor05","protocoldate","idfepaymethodcondition","idfepaymethod","nelectronicinvoice","yelectronicinvoice","annotations","arrivalprotocolnum","toincludeinpaymentindicator","resendingpcc","touniqueregister","idstampkind","flag_auto_split_payment","flag_enable_split_payment","idsdi_acquisto","idsdi_vendita","flag_reverse_charge","ipa_acq","rifamm_acq","ipa_ven_emittente","rifamm_ven_emittente","ipa_ven_cliente","rifamm_ven_cliente","ssntipospesa","ssnflagtipospesa","idinvkind_forwarder","yinv_forwarder","ninv_forwarder","flagbit","ssn_nprot","requested_doc","email_ven_cliente","pec_ven_cliente");
	tinvoice.defineColumn("!registry", typeof(string));
	Tables.Add(tinvoice);
	tinvoice.defineKey("ninv", "yinv", "idinvkind");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("ninv","rownum","yinv","annotations","competencystart","paymentcompetency","competencystop","ct","cu","detaildescription","discount","idaccmotive","idmankind","idupb","lt","lu","manrownum","nman","number","tax","taxable","unabatable","yman","idestimkind","estimrownum","nestim","yestim","idgroup","idexp_taxable","idexp_iva","idinc_taxable","idinc_iva","ninv_main","yinv_main","idivakind","idinvkind","idsor1","idsor2","idsor3","idintrastatcode","idintrastatmeasure","weight","va3type","intrastatoperationkind","idintrastatservice","idintrastatsupplymethod","idlist","idunit","idpackage","unitsforpackage","npackage","flag","exception12","intra12operationkind","move12","idupb_iva","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idpccdebitstatus","idpccdebitmotive","idcostpartition","expensekind","rounding","idepexp","idepacc","flagbit","idfinmotive","iduniqueformcode","ycon","ncon","codicevalore","codicetipo","idsor_siope","idepexp_pre");
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("ninv", "rownum", "yinv", "idinvkind");

	//////////////////// INCOMEINVOICE /////////////////////////////////
	var tincomeinvoice= new MetaTable("incomeinvoice");
	tincomeinvoice.defineColumn("ninv", typeof(int),false);
	tincomeinvoice.defineColumn("yinv", typeof(short),false);
	tincomeinvoice.defineColumn("ct", typeof(DateTime),false);
	tincomeinvoice.defineColumn("cu", typeof(string),false);
	tincomeinvoice.defineColumn("lt", typeof(DateTime),false);
	tincomeinvoice.defineColumn("lu", typeof(string),false);
	tincomeinvoice.defineColumn("idinc", typeof(int),false);
	tincomeinvoice.defineColumn("idinvkind", typeof(int),false);
	tincomeinvoice.defineColumn("movkind", typeof(short),false);
	Tables.Add(tincomeinvoice);
	tincomeinvoice.defineKey("ninv", "yinv", "idinc", "idinvkind");

	//////////////////// FLUSSOINCASSI /////////////////////////////////
	var tflussoincassi= new flussoincassiTable();
	tflussoincassi.addBaseColumns("idflusso","codiceflusso","trn","ct","cu","lt","lu","ayear","causale","dataincasso","nbill","importo","to_complete","elaborato","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tflussoincassi);
	tflussoincassi.defineKey("idflusso");

	//////////////////// FLUSSOINCASSIDETAIL /////////////////////////////////
	var tflussoincassidetail= new flussoincassidetailTable();
	tflussoincassidetail.addBaseColumns("idflusso","iddetail","iduniqueformcode","iuv","importo","ct","cu","lt","lu","cf","p_iva");
	Tables.Add(tflussoincassidetail);
	tflussoincassidetail.defineKey("idflusso", "iddetail");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new registryreferenceTable();
	tregistryreference.addBaseColumns("idreg","idregistryreference","referencename","ct","cu","email","faxnumber","flagdefault","lt","lu","mobilenumber","passwordweb","phonenumber","registryreferencerole","rtf","txt","userweb","skypenumber","msnnumber","activeweb","iterweb","saltweb");
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("ct","cu","description","lt","lu","codeinvkind","idinvkind","flag","flag_autodocnumbering","formatstring","active","idinvkind_auto","printingcode","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","notes1","notes2","notes3","ipa_fe","riferimento_amministrazione","enable_fe");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new MetaTable("currency");
	tcurrency.defineColumn("ct", typeof(DateTime),false);
	tcurrency.defineColumn("cu", typeof(string),false);
	tcurrency.defineColumn("description", typeof(string),false);
	tcurrency.defineColumn("lt", typeof(DateTime),false);
	tcurrency.defineColumn("lu", typeof(string),false);
	tcurrency.defineColumn("codecurrency", typeof(string));
	tcurrency.defineColumn("idcurrency", typeof(int),false);
	Tables.Add(tcurrency);
	tcurrency.defineKey("idcurrency");

	//////////////////// IVAREGISTER /////////////////////////////////
	var tivaregister= new ivaregisterTable();
	tivaregister.addBaseColumns("nivaregister","yivaregister","ct","cu","lt","lu","ninv","protocolnum","yinv","idinvkind","idivaregisterkind");
	Tables.Add(tivaregister);
	tivaregister.defineKey("nivaregister", "yivaregister", "idivaregisterkind");

	//////////////////// LIST /////////////////////////////////
	var tlist= new listTable();
	tlist.addBaseColumns("idlist","description","intcode","intbarcode","extcode","extbarcode","validitystop","active","idpackage","idunit","unitsforpackage","has_expiry","cu","ct","lu","lt","idlistclass","pic","picext","nmin","ntoreorder","tounload","timesupply","nmaxorder","price","insinfo","descrforuser");
	Tables.Add(tlist);
	tlist.defineKey("idlist");

	//////////////////// INVOICEKINDREGISTERKIND /////////////////////////////////
	var tinvoicekindregisterkind= new MetaTable("invoicekindregisterkind");
	tinvoicekindregisterkind.defineColumn("ct", typeof(DateTime),false);
	tinvoicekindregisterkind.defineColumn("cu", typeof(string),false);
	tinvoicekindregisterkind.defineColumn("lt", typeof(DateTime),false);
	tinvoicekindregisterkind.defineColumn("lu", typeof(string),false);
	tinvoicekindregisterkind.defineColumn("idinvkind", typeof(int),false);
	tinvoicekindregisterkind.defineColumn("idivaregisterkind", typeof(int),false);
	Tables.Add(tinvoicekindregisterkind);
	tinvoicekindregisterkind.defineKey("idinvkind", "idivaregisterkind");

	//////////////////// IVAREGISTERKIND /////////////////////////////////
	var tivaregisterkind= new ivaregisterkindTable();
	tivaregisterkind.addBaseColumns("ct","cu","description","lt","lu","registerclass","idivaregisterkindunified","flagactivity","codeivaregisterkind","idivaregisterkind","compensation","idtreasurer");
	Tables.Add(tivaregisterkind);
	tivaregisterkind.defineKey("idivaregisterkind");

	//////////////////// REPORT /////////////////////////////////
	var treport= new MetaTable("report");
	treport.defineColumn("modulename", typeof(string),false);
	treport.defineColumn("reportname", typeof(string),false);
	treport.defineColumn("description", typeof(string),false);
	treport.defineColumn("filename", typeof(string),false);
	treport.defineColumn("groupname", typeof(string));
	treport.defineColumn("orientation", typeof(string),false);
	treport.defineColumn("papersize", typeof(string));
	treport.defineColumn("sp_doupdate", typeof(string));
	treport.defineColumn("timeout", typeof(int));
	treport.defineColumn("webvisible", typeof(string));
	treport.defineColumn("active", typeof(string));
	treport.defineColumn("flag_both", typeof(string));
	treport.defineColumn("flag_cash", typeof(string));
	treport.defineColumn("flag_comp", typeof(string));
	treport.defineColumn("flag_credit", typeof(string));
	treport.defineColumn("flag_proceeds", typeof(string));
	Tables.Add(treport);
	treport.defineKey("reportname");

	//////////////////// WEBPAYMENT /////////////////////////////////
	var twebpayment= new webpaymentTable();
	twebpayment.addBaseColumns("idwebpayment","cf","ct","cu","email","forename","idcustomuser","idlcard","idman","lt","lu","nwebpayment","surname","ywebpayment","idwebpaymentstatus","idreg","iuv","qrcode","idflussocrediti","adate");
	Tables.Add(twebpayment);
	twebpayment.defineKey("idwebpayment");

	//////////////////// WEBPAYMENTSTATUS /////////////////////////////////
	var twebpaymentstatus= new MetaTable("webpaymentstatus");
	twebpaymentstatus.defineColumn("idwebpaymentstatus", typeof(short),false);
	twebpaymentstatus.defineColumn("ct", typeof(DateTime),false);
	twebpaymentstatus.defineColumn("cu", typeof(string),false);
	twebpaymentstatus.defineColumn("description", typeof(string),false);
	twebpaymentstatus.defineColumn("listingorder", typeof(int));
	twebpaymentstatus.defineColumn("lt", typeof(DateTime),false);
	twebpaymentstatus.defineColumn("lu", typeof(string),false);
	Tables.Add(twebpaymentstatus);
	twebpaymentstatus.defineKey("idwebpaymentstatus");

	//////////////////// GENERALREPORTPARAMETER /////////////////////////////////
	var tgeneralreportparameter= new MetaTable("generalreportparameter");
	tgeneralreportparameter.defineColumn("idparam", typeof(string),false);
	tgeneralreportparameter.defineColumn("paramvalue", typeof(string));
	tgeneralreportparameter.defineColumn("description", typeof(string));
	tgeneralreportparameter.defineColumn("lt", typeof(DateTime));
	tgeneralreportparameter.defineColumn("lu", typeof(string));
	tgeneralreportparameter.defineColumn("stop", typeof(DateTime));
	tgeneralreportparameter.defineColumn("start", typeof(DateTime),false);
	Tables.Add(tgeneralreportparameter);
	tgeneralreportparameter.defineKey("idparam", "start");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("ct","cu","description","lt","lu","rate","unabatabilitypercentage","active","idivataxablekind","idivakind","codeivakind","flag","annotations","idfenature");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	#endregion


	#region DataRelation creation
	this.defineRelation("income_incomeinvoice","income","incomeinvoice","idinc");
	var cPar = new []{income.Columns["idinc"]};
	var cChild = new []{invoicedetail.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("income_invoicedetail",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{invoicedetail.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("income_invoicedetail1",cPar,cChild,false));

	this.defineRelation("flussocrediti_flussocreditidetail","flussocrediti","flussocreditidetail","idflusso");
	this.defineRelation("registry_flussocreditidetail","registry","flussocreditidetail","idreg");
	this.defineRelation("finmotive_finmotivedetail","finmotive","finmotivedetail","idfinmotive");
	this.defineRelation("income_incomeestimate","income","incomeestimate","idinc");
	this.defineRelation("estimate_incomeestimate","estimate","incomeestimate","idestimkind","yestim","nestim");
	cPar = new []{income.Columns["idinc"]};
	cChild = new []{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("incomeincome",cPar,cChild,false));

	this.defineRelation("FK_estimate_estimatekind","estimatekind","estimate","idestimkind");
	this.defineRelation("FK_estimatedetail_estimatekind","estimatekind","estimatedetail","idestimkind");
	this.defineRelation("FK_estimatedetail_estimate","estimate","estimatedetail","idestimkind","yestim","nestim");
	this.defineRelation("registry_registryreference","registry","registryreference","idreg");
	this.defineRelation("invoicekind_invoicedetail","invoicekind","invoicedetail","idinvkind");
	this.defineRelation("currency_invoice","currency","invoice","idcurrency");
	this.defineRelation("list_flussocreditidetail","list","flussocreditidetail","idlist");
	this.defineRelation("ivaregisterkindivaregister","ivaregisterkind","ivaregister","idivaregisterkind");
	cPar = new []{flussocrediti.Columns["idflusso"]};
	cChild = new []{webpayment.Columns["idflussocrediti"]};
	Relations.Add(new DataRelation("flussocrediti_webpayment",cPar,cChild,false));

	this.defineRelation("webpaymentstatus_webpayment","webpaymentstatus","webpayment","idwebpaymentstatus");
	this.defineRelation("invoice_incomeinvoice","invoice","incomeinvoice","ninv","yinv","idinvkind");
	cPar = new []{invoicedetail.Columns["idinvkind"], invoicedetail.Columns["yinv"], invoicedetail.Columns["ninv"], invoicedetail.Columns["rownum"]};
	cChild = new []{flussocreditidetail.Columns["idinvkind"], flussocreditidetail.Columns["yinv"], flussocreditidetail.Columns["ninv"], flussocreditidetail.Columns["invrownum"]};
	Relations.Add(new DataRelation("invoicedetail_flussocreditidetail",cPar,cChild,false));

	this.defineRelation("estimatedetail_flussocreditidetail","estimatedetail","flussocreditidetail","idestimkind","yestim","nestim","rownum");
	this.defineRelation("income_incomelast","income","incomelast","idinc");
	this.defineRelation("income_incomesorted","income","incomesorted","idinc");
	this.defineRelation("income_incomeyear","income","incomeyear","idinc");
	this.defineRelation("FK_flussoincassi_flussoincassidetail","flussoincassi","flussoincassidetail","idflusso");
	this.defineRelation("invoice_invoicedetail","invoice","invoicedetail","idinvkind","yinv","ninv");
	this.defineRelation("ivaregisterinvoice","invoice","ivaregister","idinvkind","yinv","ninv");
	cPar = new []{income.Columns["idinc"]};
	cChild = new []{estimatedetail.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("income_estimatedetail",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{estimatedetail.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("income_estimatedetail1",cPar,cChild,false));

	this.defineRelation("income_incomevar","income","incomevar","idinc");
	#endregion

}
}
}
