
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
using meta_mandate;
using meta_manager;
using meta_mandatedetail;
using meta_mandatekind;
using meta_invoicedetail;
using meta_config;
using meta_expensevar;
using meta_registry;
using meta_expensesorted;
using meta_ivakind;
using meta_list;
using meta_upb;
using meta_accmotive;
using meta_inventorytree;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace mandate_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Contratto Passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandateTable mandate 		=> (mandateTable)Tables["mandate"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	///<summary>
	/// Tipo Scadenza
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expirationkind 		=> (MetaTable)Tables["expirationkind"];

	///<summary>
	///Valuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable currency 		=> (MetaTable)Tables["currency"];

	///<summary>
	///Dettaglio contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatedetailTable mandatedetail 		=> (mandatedetailTable)Tables["mandatedetail"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public mandatekindTable mandatekind 		=> (mandatekindTable)Tables["mandatekind"];

	///<summary>
	///Classificazione Contratto Passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatesorting 		=> (MetaTable)Tables["mandatesorting"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicedetailTable invoicedetail 		=> (invoicedetailTable)Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Variazione movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensevarTable expensevar 		=> (expensevarTable)Tables["expensevar"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb_detail 		=> (MetaTable)Tables["upb_detail"];

	///<summary>
	///Classificazione Movimenti di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public expensesortedTable expensesorted 		=> (expensesortedTable)Tables["expensesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_debit 		=> (MetaTable)Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotiveapplied_crg 		=> (MetaTable)Tables["accmotiveapplied_crg"];

	///<summary>
	///stato contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatestatus 		=> (MetaTable)Tables["mandatestatus"];

	///<summary>
	///Magazzino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable store 		=> (MetaTable)Tables["store"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stockview 		=> (MetaTable)Tables["stockview"];

	///<summary>
	///Allegato a  c.passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandateattachment 		=> (MetaTable)Tables["mandateattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingview 		=> (MetaTable)Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting01 		=> (MetaTable)Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting02 		=> (MetaTable)Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting03 		=> (MetaTable)Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting04 		=> (MetaTable)Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting05 		=> (MetaTable)Tables["sorting05"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatedetailview 		=> (MetaTable)Tables["mandatedetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatesortingview 		=> (MetaTable)Tables["mandatesortingview"];

	///<summary>
	///Variazione movimento Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpvar 		=> (MetaTable)Tables["epexpvar"];

	///<summary>
	///Classificazione Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epexpsorting 		=> (MetaTable)Tables["epexpsorting"];

	///<summary>
	///Partecipanti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandateavcp 		=> (MetaTable)Tables["mandateavcp"];

	///<summary>
	///lotto(CIG)  associato ad un partecipante
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandateavcpdetail 		=> (MetaTable)Tables["mandateavcpdetail"];

	///<summary>
	///lotto associato a contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandatecig 		=> (MetaTable)Tables["mandatecig"];

	///<summary>
	///Registro unico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable uniqueregister 		=> (MetaTable)Tables["uniqueregister"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pccview 		=> (MetaTable)Tables["pccview"];

	///<summary>
	///Dichiarazione ai fini CONSIP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable consipkind 		=> (MetaTable)Tables["consipkind"];

	///<summary>
	///Dichiarazione ai fini CONSIP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable consipkind_ext 		=> (MetaTable)Tables["consipkind_ext"];

	///<summary>
	///Categorie Merceologiche CONSIP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable consipcategory 		=> (MetaTable)Tables["consipcategory"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public listTable list 		=> (listTable)Tables["list"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive 		=> (accmotiveTable)Tables["accmotive"];

	///<summary>
	///Classificazione inventariale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public inventorytreeTable inventorytree 		=> (inventorytreeTable)Tables["inventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview_rup 		=> (MetaTable)Tables["registrymainview_rup"];

	///<summary>
	///Tipo allegato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attachmentkind 		=> (MetaTable)Tables["attachmentkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mandateview 		=> (MetaTable)Tables["mandateview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable wsaggiudicatario 		=> (MetaTable)Tables["wsaggiudicatario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable wspartecipante 		=> (MetaTable)Tables["wspartecipante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable wsgara 		=> (MetaTable)Tables["wsgara"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable wslotto 		=> (MetaTable)Tables["wslotto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable garatraspareview 		=> (MetaTable)Tables["garatraspareview"];

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
	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new mandateTable();
	tmandate.addBaseColumns("yman","nman","idreg","registryreference","description","idman","deliveryexpiration","deliveryaddress","paymentexpiring","idexpirationkind","idcurrency","exchangerate","doc","docdate","adate","officiallyprinted","txt","rtf","cu","ct","lu","lt","active","idmankind","flagintracom","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","applierannotations","idmandatestatus","idstore","cigcode","idsor01","idsor02","idsor03","idsor04","idsor05","idconsipkind","flagdanger","idmankind_origin","yman_origin","nman_origin","subappropriation","finsubappropriation","adatesubappropriation","arrivalprotocolnum","arrivaldate","annotations","resendingpcc","external_reference","idconsipkind_ext","consipmotive","flagtenderresult","motiveassignment","idreg_rupanac","tenderkind","anacreduced","publishdate","publishdatekind","requested_doc","flagbit");
	Tables.Add(tmandate);
	tmandate.defineKey("yman", "nman", "idmankind");

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("idman","title","iddivision","email","phonenumber","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// EXPIRATIONKIND /////////////////////////////////
	var texpirationkind= new MetaTable("expirationkind");
	texpirationkind.defineColumn("idexpirationkind", typeof(short),false);
	texpirationkind.defineColumn("description", typeof(string),false);
	texpirationkind.defineColumn("active", typeof(string));
	Tables.Add(texpirationkind);
	texpirationkind.defineKey("idexpirationkind");

	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new MetaTable("currency");
	tcurrency.defineColumn("idcurrency", typeof(int),false);
	tcurrency.defineColumn("codecurrency", typeof(string),false);
	tcurrency.defineColumn("description", typeof(string),false);
	tcurrency.defineColumn("cu", typeof(string),false);
	tcurrency.defineColumn("ct", typeof(DateTime),false);
	tcurrency.defineColumn("lu", typeof(string),false);
	tcurrency.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tcurrency);
	tcurrency.defineKey("idcurrency");

	//////////////////// MANDATEDETAIL /////////////////////////////////
	var tmandatedetail= new mandatedetailTable();
	tmandatedetail.addBaseColumns("yman","nman","rownum","detaildescription","annotations","number","taxable","taxrate","discount","start","stop","cu","ct","lu","lt","idinv","assetkind","idexp_iva","idexp_taxable","idupb","toinvoice","idsor1","idsor2","idsor3","idmankind","competencystart","competencystop","tax","idaccmotive","idivakind","unabatable","flagmixed","idreg","idgroup","ninvoiced","idaccmotiveannulment","applierannotations","flagactivity","va3type","ivanotes","idlist","idunit","idpackage","unitsforpackage","cupcode","npackage","cigcode","flagto_unload","epkind","rownum_origin","contractamount","idavcp","idavcp_choice","avcp_startcontract","avcp_stopcontract","avcp_description","idcostpartition","idpccdebitstatus","idpccdebitmotive","expensekind","idepexp","idepacc","idlocation","idupb_iva","idsor_siope","idepexp_pre","rownum_main");
	tmandatedetail.defineColumn("!totaleriga", typeof(decimal));
	tmandatedetail.defineColumn("!codeupb", typeof(string));
	tmandatedetail.defineColumn("!registry", typeof(string));
	tmandatedetail.defineColumn("!tipoiva", typeof(string));
	tmandatedetail.defineColumn("!imponibile", typeof(decimal));
	tmandatedetail.defineColumn("!iva", typeof(decimal));
	tmandatedetail.defineColumn("!list", typeof(string));
	Tables.Add(tmandatedetail);
	tmandatedetail.defineKey("yman", "nman", "rownum", "idmankind");

	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new mandatekindTable();
	tmandatekind.addBaseColumns("idmankind","description","idupb","cu","ct","lu","lt","multireg","linktoinvoice","flag_autodocnumbering","flagactivity","isrequest","warnmail","idsor01","idsor02","idsor03","idsor04","idsor05","assetkind","dangermail","active","flag","touniqueregister","flagcreatedoubleentry","idivakind_forced","idreg_rupanac","requested_doc");
	Tables.Add(tmandatekind);
	tmandatekind.defineKey("idmankind");

	//////////////////// MANDATESORTING /////////////////////////////////
	var tmandatesorting= new MetaTable("mandatesorting");
	tmandatesorting.defineColumn("idsor", typeof(int),false);
	tmandatesorting.defineColumn("idmankind", typeof(string),false);
	tmandatesorting.defineColumn("yman", typeof(short),false);
	tmandatesorting.defineColumn("nman", typeof(int),false);
	tmandatesorting.defineColumn("ct", typeof(DateTime),false);
	tmandatesorting.defineColumn("cu", typeof(string),false);
	tmandatesorting.defineColumn("lt", typeof(DateTime),false);
	tmandatesorting.defineColumn("lu", typeof(string),false);
	tmandatesorting.defineColumn("!sortingkind", typeof(string));
	tmandatesorting.defineColumn("!codiceclass", typeof(string));
	tmandatesorting.defineColumn("!descrizione", typeof(string));
	tmandatesorting.defineColumn("quota", typeof(double));
	Tables.Add(tmandatesorting);
	tmandatesorting.defineKey("idmankind", "idsor", "nman", "yman");

	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new invoicedetailTable();
	tinvoicedetail.addBaseColumns("idinvkind","ninv","rownum","yinv","annotations","competencystart","competencystop","ct","cu","detaildescription","discount","idaccmotive","idivakind","idmankind","idsor1","idsor2","idsor3","idupb","lt","lu","manrownum","nman","number","tax","taxable","unabatable","yman","idestimkind","estimrownum","nestim","yestim","idexp_iva","idexp_taxable","idinc_iva","idinc_taxable","idgroup","expensekind","idepexp","idupb_iva","idlist","idsor_siope","paymentcompetency","yinv_main","ninv_main","va3type","idintrastatcode","idintrastatmeasure","weight","intrastatoperationkind","idintrastatservice","idunit","idpackage","unitsforpackage","idintrastatsupplymethod","flag","exception12","intra12operationkind","move12","idinvkind_main","leasing","usedmodesospesometro","resetresidualmandate","idfetransfer","fereferencerule","cupcode","cigcode","idcostpartition","idpccdebitstatus","idpccdebitmotive","rounding","idepacc","flagbit","iduniqueformcode","idfinmotive","ycon","ncon","codicetipo","codicevalore","idepexp_pre","idtassonomia","idfinmotive_iva","rownum_main");
	Tables.Add(tinvoicedetail);
	tinvoicedetail.defineKey("idinvkind", "ninv", "rownum", "yinv");

	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new MetaTable("registrymainview");
	tregistrymainview.defineColumn("idreg", typeof(int),false);
	tregistrymainview.defineColumn("title", typeof(string),false);
	tregistrymainview.defineColumn("idregistryclass", typeof(string));
	tregistrymainview.defineColumn("registryclass", typeof(string));
	tregistrymainview.defineColumn("surname", typeof(string));
	tregistrymainview.defineColumn("forename", typeof(string));
	tregistrymainview.defineColumn("cf", typeof(string));
	tregistrymainview.defineColumn("p_iva", typeof(string));
	tregistrymainview.defineColumn("residence", typeof(int),false);
	tregistrymainview.defineColumn("residencekind", typeof(string));
	tregistrymainview.defineColumn("annotation", typeof(string));
	tregistrymainview.defineColumn("birthdate", typeof(DateTime));
	tregistrymainview.defineColumn("idcity", typeof(int));
	tregistrymainview.defineColumn("city", typeof(string));
	tregistrymainview.defineColumn("gender", typeof(string));
	tregistrymainview.defineColumn("foreigncf", typeof(string));
	tregistrymainview.defineColumn("idtitle", typeof(string));
	tregistrymainview.defineColumn("qualification", typeof(string));
	tregistrymainview.defineColumn("idmaritalstatus", typeof(string));
	tregistrymainview.defineColumn("maritalstatus", typeof(string));
	tregistrymainview.defineColumn("sortcode", typeof(string));
	tregistrymainview.defineColumn("registrykind", typeof(string));
	tregistrymainview.defineColumn("human", typeof(string));
	tregistrymainview.defineColumn("active", typeof(string),false);
	tregistrymainview.defineColumn("badgecode", typeof(string));
	tregistrymainview.defineColumn("maritalsurname", typeof(string));
	tregistrymainview.defineColumn("idcategory", typeof(string));
	tregistrymainview.defineColumn("extmatricula", typeof(string));
	tregistrymainview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrymainview.defineColumn("cu", typeof(string),false);
	tregistrymainview.defineColumn("ct", typeof(DateTime),false);
	tregistrymainview.defineColumn("lu", typeof(string),false);
	tregistrymainview.defineColumn("lt", typeof(DateTime),false);
	tregistrymainview.defineColumn("location", typeof(string));
	tregistrymainview.defineColumn("idnation", typeof(int));
	tregistrymainview.defineColumn("nation", typeof(string));
	tregistrymainview.defineColumn("idaccmotivedebit", typeof(string));
	Tables.Add(tregistrymainview);
	tregistrymainview.defineKey("idreg");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart","flag_autodocnumbering","flag");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new expensevarTable();
	texpensevar.addBaseColumns("nvar","adate","amount","ct","cu","description","doc","docdate","lt","lu","rtf","transferkind","txt","yvar","ninv","yinv","idexp","idpayment","autokind","autocode","idinvkind","movkind","idunderwriting");
	Tables.Add(texpensevar);
	texpensevar.defineKey("nvar", "idexp");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// UPB_DETAIL /////////////////////////////////
	var tupb_detail= new MetaTable("upb_detail");
	tupb_detail.defineColumn("idupb", typeof(string),false);
	tupb_detail.defineColumn("codeupb", typeof(string),false);
	Tables.Add(tupb_detail);
	tupb_detail.defineKey("idupb");

	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new expensesortedTable();
	texpensesorted.addBaseColumns("idsubclass","amount","ayear","ct","cu","description","flagnodate","lt","lu","paridsor","paridsubclass","rtf","start","stop","tobecontinued","txt","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5","idexp","idsor");
	Tables.Add(texpensesorted);
	texpensesorted.defineKey("idsubclass", "idexp", "idsor");

	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new MetaTable("accmotiveapplied_debit");
	taccmotiveapplied_debit.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_debit.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_debit.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_debit.defineColumn("active", typeof(string));
	taccmotiveapplied_debit.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_debit.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_debit.defineColumn("in_use", typeof(string),false);
	taccmotiveapplied_debit.defineColumn("flagdep", typeof(string));
	taccmotiveapplied_debit.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveapplied_debit);
	taccmotiveapplied_debit.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_CRG /////////////////////////////////
	var taccmotiveapplied_crg= new MetaTable("accmotiveapplied_crg");
	taccmotiveapplied_crg.defineColumn("idaccmotive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("paridaccmotive", typeof(string));
	taccmotiveapplied_crg.defineColumn("codemotive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("motive", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("cu", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("ct", typeof(DateTime),false);
	taccmotiveapplied_crg.defineColumn("lu", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("lt", typeof(DateTime),false);
	taccmotiveapplied_crg.defineColumn("active", typeof(string));
	taccmotiveapplied_crg.defineColumn("idepoperation", typeof(string));
	taccmotiveapplied_crg.defineColumn("epoperation", typeof(string));
	taccmotiveapplied_crg.defineColumn("in_use", typeof(string),false);
	taccmotiveapplied_crg.defineColumn("flagdep", typeof(string));
	taccmotiveapplied_crg.defineColumn("flagamm", typeof(string));
	Tables.Add(taccmotiveapplied_crg);
	taccmotiveapplied_crg.defineKey("idaccmotive");

	//////////////////// MANDATESTATUS /////////////////////////////////
	var tmandatestatus= new MetaTable("mandatestatus");
	tmandatestatus.defineColumn("ct", typeof(DateTime),false);
	tmandatestatus.defineColumn("cu", typeof(string),false);
	tmandatestatus.defineColumn("description", typeof(string),false);
	tmandatestatus.defineColumn("lt", typeof(DateTime),false);
	tmandatestatus.defineColumn("lu", typeof(string),false);
	tmandatestatus.defineColumn("idmandatestatus", typeof(short),false);
	Tables.Add(tmandatestatus);
	tmandatestatus.defineKey("idmandatestatus");

	//////////////////// STORE /////////////////////////////////
	var tstore= new MetaTable("store");
	tstore.defineColumn("idstore", typeof(int),false);
	tstore.defineColumn("description", typeof(string),false);
	tstore.defineColumn("deliveryaddress", typeof(string),false);
	tstore.defineColumn("active", typeof(string));
	tstore.defineColumn("idsor01", typeof(int));
	tstore.defineColumn("idsor02", typeof(int));
	tstore.defineColumn("idsor03", typeof(int));
	tstore.defineColumn("idsor04", typeof(int));
	tstore.defineColumn("idsor05", typeof(int));
	tstore.defineColumn("cu", typeof(string));
	tstore.defineColumn("ct", typeof(DateTime));
	tstore.defineColumn("lu", typeof(string));
	tstore.defineColumn("lt", typeof(DateTime));
	Tables.Add(tstore);
	tstore.defineKey("idstore");

	//////////////////// STOCKVIEW /////////////////////////////////
	var tstockview= new MetaTable("stockview");
	tstockview.defineColumn("idstock", typeof(int),false);
	tstockview.defineColumn("idstore", typeof(int),false);
	tstockview.defineColumn("store", typeof(string),false);
	tstockview.defineColumn("idlist", typeof(int),false);
	tstockview.defineColumn("number", typeof(decimal),false);
	tstockview.defineColumn("residual", typeof(decimal),true,true);
	tstockview.defineColumn("amount", typeof(decimal),false);
	tstockview.defineColumn("expiry", typeof(DateTime));
	tstockview.defineColumn("idmankind", typeof(string));
	tstockview.defineColumn("mandatekind", typeof(string));
	tstockview.defineColumn("yman", typeof(short));
	tstockview.defineColumn("nman", typeof(int));
	tstockview.defineColumn("man_idgroup", typeof(int));
	tstockview.defineColumn("idinvkind", typeof(int));
	tstockview.defineColumn("invoicekind", typeof(string));
	tstockview.defineColumn("yinv", typeof(short));
	tstockview.defineColumn("ninv", typeof(int));
	tstockview.defineColumn("inv_idgroup", typeof(int));
	tstockview.defineColumn("idddt_in", typeof(int));
	tstockview.defineColumn("idstoreload_motive", typeof(int));
	tstockview.defineColumn("storeload_motive", typeof(string));
	tstockview.defineColumn("list", typeof(string),false);
	tstockview.defineColumn("intcode", typeof(string),false);
	tstockview.defineColumn("yddt_in", typeof(short));
	tstockview.defineColumn("nddt_in", typeof(string));
	Tables.Add(tstockview);

	//////////////////// MANDATEATTACHMENT /////////////////////////////////
	var tmandateattachment= new MetaTable("mandateattachment");
	tmandateattachment.defineColumn("idmankind", typeof(string),false);
	tmandateattachment.defineColumn("yman", typeof(short),false);
	tmandateattachment.defineColumn("nman", typeof(int),false);
	tmandateattachment.defineColumn("idattachment", typeof(int),false);
	tmandateattachment.defineColumn("attachment", typeof(Byte[]));
	tmandateattachment.defineColumn("filename", typeof(string));
	tmandateattachment.defineColumn("lt", typeof(DateTime),false);
	tmandateattachment.defineColumn("lu", typeof(string),false);
	tmandateattachment.defineColumn("ct", typeof(DateTime),false);
	tmandateattachment.defineColumn("cu", typeof(string),false);
	tmandateattachment.defineColumn("idattachmentkind", typeof(int));
	tmandateattachment.defineColumn("!attachmentkind", typeof(string));
	Tables.Add(tmandateattachment);
	tmandateattachment.defineKey("idmankind", "yman", "nman", "idattachment");

	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new MetaTable("sortingview");
	tsortingview.defineColumn("sortingkind", typeof(string),false);
	tsortingview.defineColumn("idsor", typeof(int),false);
	tsortingview.defineColumn("sortcode", typeof(string),false);
	tsortingview.defineColumn("description", typeof(string),false);
	Tables.Add(tsortingview);
	tsortingview.defineKey("idsor");

	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new MetaTable("sorting01");
	tsorting01.defineColumn("ct", typeof(DateTime),false);
	tsorting01.defineColumn("cu", typeof(string),false);
	tsorting01.defineColumn("defaultN1", typeof(decimal));
	tsorting01.defineColumn("defaultN2", typeof(decimal));
	tsorting01.defineColumn("defaultN3", typeof(decimal));
	tsorting01.defineColumn("defaultN4", typeof(decimal));
	tsorting01.defineColumn("defaultN5", typeof(decimal));
	tsorting01.defineColumn("defaultS1", typeof(string));
	tsorting01.defineColumn("defaultS2", typeof(string));
	tsorting01.defineColumn("defaultS3", typeof(string));
	tsorting01.defineColumn("defaultS4", typeof(string));
	tsorting01.defineColumn("defaultS5", typeof(string));
	tsorting01.defineColumn("defaultv1", typeof(decimal));
	tsorting01.defineColumn("defaultv2", typeof(decimal));
	tsorting01.defineColumn("defaultv3", typeof(decimal));
	tsorting01.defineColumn("defaultv4", typeof(decimal));
	tsorting01.defineColumn("defaultv5", typeof(decimal));
	tsorting01.defineColumn("description", typeof(string),false);
	tsorting01.defineColumn("flagnodate", typeof(string));
	tsorting01.defineColumn("lt", typeof(DateTime),false);
	tsorting01.defineColumn("lu", typeof(string),false);
	tsorting01.defineColumn("movkind", typeof(string));
	tsorting01.defineColumn("printingorder", typeof(string));
	tsorting01.defineColumn("rtf", typeof(Byte[]));
	tsorting01.defineColumn("sortcode", typeof(string),false);
	tsorting01.defineColumn("txt", typeof(string));
	tsorting01.defineColumn("idsorkind", typeof(int),false);
	tsorting01.defineColumn("idsor", typeof(int),false);
	tsorting01.defineColumn("paridsor", typeof(int));
	tsorting01.defineColumn("nlevel", typeof(byte),false);
	tsorting01.defineColumn("start", typeof(short));
	tsorting01.defineColumn("stop", typeof(short));
	Tables.Add(tsorting01);
	tsorting01.defineKey("idsor");

	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new MetaTable("sorting02");
	tsorting02.defineColumn("ct", typeof(DateTime),false);
	tsorting02.defineColumn("cu", typeof(string),false);
	tsorting02.defineColumn("defaultN1", typeof(decimal));
	tsorting02.defineColumn("defaultN2", typeof(decimal));
	tsorting02.defineColumn("defaultN3", typeof(decimal));
	tsorting02.defineColumn("defaultN4", typeof(decimal));
	tsorting02.defineColumn("defaultN5", typeof(decimal));
	tsorting02.defineColumn("defaultS1", typeof(string));
	tsorting02.defineColumn("defaultS2", typeof(string));
	tsorting02.defineColumn("defaultS3", typeof(string));
	tsorting02.defineColumn("defaultS4", typeof(string));
	tsorting02.defineColumn("defaultS5", typeof(string));
	tsorting02.defineColumn("defaultv1", typeof(decimal));
	tsorting02.defineColumn("defaultv2", typeof(decimal));
	tsorting02.defineColumn("defaultv3", typeof(decimal));
	tsorting02.defineColumn("defaultv4", typeof(decimal));
	tsorting02.defineColumn("defaultv5", typeof(decimal));
	tsorting02.defineColumn("description", typeof(string),false);
	tsorting02.defineColumn("flagnodate", typeof(string));
	tsorting02.defineColumn("lt", typeof(DateTime),false);
	tsorting02.defineColumn("lu", typeof(string),false);
	tsorting02.defineColumn("movkind", typeof(string));
	tsorting02.defineColumn("printingorder", typeof(string));
	tsorting02.defineColumn("rtf", typeof(Byte[]));
	tsorting02.defineColumn("sortcode", typeof(string),false);
	tsorting02.defineColumn("txt", typeof(string));
	tsorting02.defineColumn("idsorkind", typeof(int),false);
	tsorting02.defineColumn("idsor", typeof(int),false);
	tsorting02.defineColumn("paridsor", typeof(int));
	tsorting02.defineColumn("nlevel", typeof(byte),false);
	tsorting02.defineColumn("start", typeof(short));
	tsorting02.defineColumn("stop", typeof(short));
	Tables.Add(tsorting02);
	tsorting02.defineKey("idsor");

	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new MetaTable("sorting03");
	tsorting03.defineColumn("ct", typeof(DateTime),false);
	tsorting03.defineColumn("cu", typeof(string),false);
	tsorting03.defineColumn("defaultN1", typeof(decimal));
	tsorting03.defineColumn("defaultN2", typeof(decimal));
	tsorting03.defineColumn("defaultN3", typeof(decimal));
	tsorting03.defineColumn("defaultN4", typeof(decimal));
	tsorting03.defineColumn("defaultN5", typeof(decimal));
	tsorting03.defineColumn("defaultS1", typeof(string));
	tsorting03.defineColumn("defaultS2", typeof(string));
	tsorting03.defineColumn("defaultS3", typeof(string));
	tsorting03.defineColumn("defaultS4", typeof(string));
	tsorting03.defineColumn("defaultS5", typeof(string));
	tsorting03.defineColumn("defaultv1", typeof(decimal));
	tsorting03.defineColumn("defaultv2", typeof(decimal));
	tsorting03.defineColumn("defaultv3", typeof(decimal));
	tsorting03.defineColumn("defaultv4", typeof(decimal));
	tsorting03.defineColumn("defaultv5", typeof(decimal));
	tsorting03.defineColumn("description", typeof(string),false);
	tsorting03.defineColumn("flagnodate", typeof(string));
	tsorting03.defineColumn("lt", typeof(DateTime),false);
	tsorting03.defineColumn("lu", typeof(string),false);
	tsorting03.defineColumn("movkind", typeof(string));
	tsorting03.defineColumn("printingorder", typeof(string));
	tsorting03.defineColumn("rtf", typeof(Byte[]));
	tsorting03.defineColumn("sortcode", typeof(string),false);
	tsorting03.defineColumn("txt", typeof(string));
	tsorting03.defineColumn("idsorkind", typeof(int),false);
	tsorting03.defineColumn("idsor", typeof(int),false);
	tsorting03.defineColumn("paridsor", typeof(int));
	tsorting03.defineColumn("nlevel", typeof(byte),false);
	tsorting03.defineColumn("start", typeof(short));
	tsorting03.defineColumn("stop", typeof(short));
	Tables.Add(tsorting03);
	tsorting03.defineKey("idsor");

	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new MetaTable("sorting04");
	tsorting04.defineColumn("ct", typeof(DateTime),false);
	tsorting04.defineColumn("cu", typeof(string),false);
	tsorting04.defineColumn("defaultN1", typeof(decimal));
	tsorting04.defineColumn("defaultN2", typeof(decimal));
	tsorting04.defineColumn("defaultN3", typeof(decimal));
	tsorting04.defineColumn("defaultN4", typeof(decimal));
	tsorting04.defineColumn("defaultN5", typeof(decimal));
	tsorting04.defineColumn("defaultS1", typeof(string));
	tsorting04.defineColumn("defaultS2", typeof(string));
	tsorting04.defineColumn("defaultS3", typeof(string));
	tsorting04.defineColumn("defaultS4", typeof(string));
	tsorting04.defineColumn("defaultS5", typeof(string));
	tsorting04.defineColumn("defaultv1", typeof(decimal));
	tsorting04.defineColumn("defaultv2", typeof(decimal));
	tsorting04.defineColumn("defaultv3", typeof(decimal));
	tsorting04.defineColumn("defaultv4", typeof(decimal));
	tsorting04.defineColumn("defaultv5", typeof(decimal));
	tsorting04.defineColumn("description", typeof(string),false);
	tsorting04.defineColumn("flagnodate", typeof(string));
	tsorting04.defineColumn("lt", typeof(DateTime),false);
	tsorting04.defineColumn("lu", typeof(string),false);
	tsorting04.defineColumn("movkind", typeof(string));
	tsorting04.defineColumn("printingorder", typeof(string));
	tsorting04.defineColumn("rtf", typeof(Byte[]));
	tsorting04.defineColumn("sortcode", typeof(string),false);
	tsorting04.defineColumn("txt", typeof(string));
	tsorting04.defineColumn("idsorkind", typeof(int),false);
	tsorting04.defineColumn("idsor", typeof(int),false);
	tsorting04.defineColumn("paridsor", typeof(int));
	tsorting04.defineColumn("nlevel", typeof(byte),false);
	tsorting04.defineColumn("start", typeof(short));
	tsorting04.defineColumn("stop", typeof(short));
	Tables.Add(tsorting04);
	tsorting04.defineKey("idsor");

	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new MetaTable("sorting05");
	tsorting05.defineColumn("ct", typeof(DateTime),false);
	tsorting05.defineColumn("cu", typeof(string),false);
	tsorting05.defineColumn("defaultN1", typeof(decimal));
	tsorting05.defineColumn("defaultN2", typeof(decimal));
	tsorting05.defineColumn("defaultN3", typeof(decimal));
	tsorting05.defineColumn("defaultN4", typeof(decimal));
	tsorting05.defineColumn("defaultN5", typeof(decimal));
	tsorting05.defineColumn("defaultS1", typeof(string));
	tsorting05.defineColumn("defaultS2", typeof(string));
	tsorting05.defineColumn("defaultS3", typeof(string));
	tsorting05.defineColumn("defaultS4", typeof(string));
	tsorting05.defineColumn("defaultS5", typeof(string));
	tsorting05.defineColumn("defaultv1", typeof(decimal));
	tsorting05.defineColumn("defaultv2", typeof(decimal));
	tsorting05.defineColumn("defaultv3", typeof(decimal));
	tsorting05.defineColumn("defaultv4", typeof(decimal));
	tsorting05.defineColumn("defaultv5", typeof(decimal));
	tsorting05.defineColumn("description", typeof(string),false);
	tsorting05.defineColumn("flagnodate", typeof(string));
	tsorting05.defineColumn("lt", typeof(DateTime),false);
	tsorting05.defineColumn("lu", typeof(string),false);
	tsorting05.defineColumn("movkind", typeof(string));
	tsorting05.defineColumn("printingorder", typeof(string));
	tsorting05.defineColumn("rtf", typeof(Byte[]));
	tsorting05.defineColumn("sortcode", typeof(string),false);
	tsorting05.defineColumn("txt", typeof(string));
	tsorting05.defineColumn("idsorkind", typeof(int),false);
	tsorting05.defineColumn("idsor", typeof(int),false);
	tsorting05.defineColumn("paridsor", typeof(int));
	tsorting05.defineColumn("nlevel", typeof(byte),false);
	tsorting05.defineColumn("start", typeof(short));
	tsorting05.defineColumn("stop", typeof(short));
	Tables.Add(tsorting05);
	tsorting05.defineKey("idsor");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("idivakind","description","codeivakind");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// MANDATEDETAILVIEW /////////////////////////////////
	var tmandatedetailview= new MetaTable("mandatedetailview");
	tmandatedetailview.defineColumn("idmankind", typeof(string),false);
	tmandatedetailview.defineColumn("yman", typeof(short),false);
	tmandatedetailview.defineColumn("nman", typeof(int),false);
	tmandatedetailview.defineColumn("rownum", typeof(int),false);
	tmandatedetailview.defineColumn("idgroup", typeof(int));
	tmandatedetailview.defineColumn("mankind", typeof(string),false);
	tmandatedetailview.defineColumn("idinv", typeof(int));
	tmandatedetailview.defineColumn("codeinv", typeof(string));
	tmandatedetailview.defineColumn("inventorytree", typeof(string));
	tmandatedetailview.defineColumn("idreg", typeof(int));
	tmandatedetailview.defineColumn("registry", typeof(string));
	tmandatedetailview.defineColumn("detaildescription", typeof(string));
	tmandatedetailview.defineColumn("annotations", typeof(string));
	tmandatedetailview.defineColumn("number", typeof(decimal));
	tmandatedetailview.defineColumn("taxable", typeof(decimal));
	tmandatedetailview.defineColumn("taxrate", typeof(double));
	tmandatedetailview.defineColumn("tax", typeof(decimal));
	tmandatedetailview.defineColumn("discount", typeof(double));
	tmandatedetailview.defineColumn("assetkind", typeof(string),false);
	tmandatedetailview.defineColumn("start", typeof(DateTime));
	tmandatedetailview.defineColumn("stop", typeof(DateTime));
	tmandatedetailview.defineColumn("idexp_taxable", typeof(int));
	tmandatedetailview.defineColumn("idexp_iva", typeof(int));
	tmandatedetailview.defineColumn("taxable_euro", typeof(decimal),true,true);
	tmandatedetailview.defineColumn("iva_euro", typeof(decimal),true,true);
	tmandatedetailview.defineColumn("rowtotal", typeof(decimal),true,true);
	tmandatedetailview.defineColumn("idupb", typeof(string));
	tmandatedetailview.defineColumn("codeupb", typeof(string));
	tmandatedetailview.defineColumn("upb", typeof(string));
	tmandatedetailview.defineColumn("idman", typeof(int));
	tmandatedetailview.defineColumn("manager", typeof(string));
	tmandatedetailview.defineColumn("cu", typeof(string),false);
	tmandatedetailview.defineColumn("ct", typeof(DateTime),false);
	tmandatedetailview.defineColumn("lu", typeof(string),false);
	tmandatedetailview.defineColumn("lt", typeof(DateTime),false);
	tmandatedetailview.defineColumn("idaccmotive", typeof(string));
	tmandatedetailview.defineColumn("codemotive", typeof(string));
	tmandatedetailview.defineColumn("idaccmotiveannulment", typeof(string));
	tmandatedetailview.defineColumn("codemotiveannulment", typeof(string));
	tmandatedetailview.defineColumn("idsor1", typeof(int));
	tmandatedetailview.defineColumn("idsor2", typeof(int));
	tmandatedetailview.defineColumn("idsor3", typeof(int));
	tmandatedetailview.defineColumn("sortcode1", typeof(string));
	tmandatedetailview.defineColumn("sortcode2", typeof(string));
	tmandatedetailview.defineColumn("sortcode3", typeof(string));
	tmandatedetailview.defineColumn("competencystart", typeof(DateTime));
	tmandatedetailview.defineColumn("competencystop", typeof(DateTime));
	tmandatedetailview.defineColumn("idivakind", typeof(int));
	tmandatedetailview.defineColumn("ivakind", typeof(string));
	tmandatedetailview.defineColumn("unabatable", typeof(decimal));
	tmandatedetailview.defineColumn("flagmixed", typeof(string));
	tmandatedetailview.defineColumn("toinvoice", typeof(string));
	tmandatedetailview.defineColumn("exchangerate", typeof(double));
	tmandatedetailview.defineColumn("description", typeof(string),false);
	tmandatedetailview.defineColumn("flagactivity", typeof(short));
	tmandatedetailview.defineColumn("va3type", typeof(string));
	tmandatedetailview.defineColumn("flagintracom", typeof(string));
	tmandatedetailview.defineColumn("ivanotes", typeof(string));
	tmandatedetailview.defineColumn("idlist", typeof(int));
	tmandatedetailview.defineColumn("intcode", typeof(string));
	tmandatedetailview.defineColumn("idunit", typeof(int));
	tmandatedetailview.defineColumn("idpackage", typeof(int));
	tmandatedetailview.defineColumn("unitsforpackage", typeof(int));
	tmandatedetailview.defineColumn("npackage", typeof(decimal));
	tmandatedetailview.defineColumn("idstore", typeof(int));
	tmandatedetailview.defineColumn("store", typeof(string));
	tmandatedetailview.defineColumn("cupcode", typeof(string));
	tmandatedetailview.defineColumn("flagto_unload", typeof(string));
	tmandatedetailview.defineColumn("applierannotations", typeof(string));
	tmandatedetailview.defineColumn("cigcode", typeof(string));
	tmandatedetailview.defineColumn("ninvoiced", typeof(decimal));
	tmandatedetailview.defineColumn("idsor01", typeof(int),true,true);
	tmandatedetailview.defineColumn("idsor02", typeof(int),true,true);
	tmandatedetailview.defineColumn("idsor03", typeof(int),true,true);
	tmandatedetailview.defineColumn("idsor04", typeof(int),true,true);
	tmandatedetailview.defineColumn("idsor05", typeof(int),true,true);
	tmandatedetailview.defineColumn("rownum_origin", typeof(string));
	tmandatedetailview.defineColumn("epkind", typeof(string));
	tmandatedetailview.defineColumn("contractamount", typeof(decimal));
	tmandatedetailview.defineColumn("idavcp", typeof(int));
	tmandatedetailview.defineColumn("idavcp_choice", typeof(string));
	tmandatedetailview.defineColumn("avcp_startcontract", typeof(DateTime));
	tmandatedetailview.defineColumn("avcp_stopcontract", typeof(DateTime));
	tmandatedetailview.defineColumn("avcp_description", typeof(string));
	tmandatedetailview.defineColumn("idcostpartition", typeof(int));
	tmandatedetailview.defineColumn("idpccdebitstatus", typeof(string));
	tmandatedetailview.defineColumn("idpccdebitmotive", typeof(string));
	tmandatedetailview.defineColumn("expensekind", typeof(string));
	tmandatedetailview.defineColumn("idepexp", typeof(int));
	tmandatedetailview.defineColumn("idepacc", typeof(int));
	tmandatedetailview.defineColumn("idlocation", typeof(int));
	tmandatedetailview.defineColumn("idupb_iva", typeof(string));
	tmandatedetailview.defineColumn("idsor_siope", typeof(int));
	tmandatedetailview.defineColumn("idepexp_pre", typeof(int));
	tmandatedetailview.defineColumn("rownum_main", typeof(int));
	Tables.Add(tmandatedetailview);
	tmandatedetailview.defineKey("idmankind", "yman", "nman", "rownum");

	//////////////////// MANDATESORTINGVIEW /////////////////////////////////
	var tmandatesortingview= new MetaTable("mandatesortingview");
	tmandatesortingview.defineColumn("idmankind", typeof(string),false);
	tmandatesortingview.defineColumn("mankind", typeof(string),false);
	tmandatesortingview.defineColumn("yman", typeof(short),false);
	tmandatesortingview.defineColumn("nman", typeof(int),false);
	tmandatesortingview.defineColumn("quota", typeof(double));
	tmandatesortingview.defineColumn("idsor", typeof(int),false);
	tmandatesortingview.defineColumn("sortingkind", typeof(string),false);
	tmandatesortingview.defineColumn("sortcode", typeof(string),false);
	tmandatesortingview.defineColumn("sorting", typeof(string),false);
	tmandatesortingview.defineColumn("lt", typeof(DateTime),false);
	tmandatesortingview.defineColumn("lu", typeof(string),false);
	tmandatesortingview.defineColumn("ct", typeof(DateTime),false);
	tmandatesortingview.defineColumn("cu", typeof(string),false);
	Tables.Add(tmandatesortingview);
	tmandatesortingview.defineKey("idmankind", "yman", "nman", "idsor");

	//////////////////// EPEXPVAR /////////////////////////////////
	var tepexpvar= new MetaTable("epexpvar");
	tepexpvar.defineColumn("idepexp", typeof(int),false);
	tepexpvar.defineColumn("nvar", typeof(int),false);
	tepexpvar.defineColumn("adate", typeof(DateTime),false);
	tepexpvar.defineColumn("amount", typeof(decimal),false);
	tepexpvar.defineColumn("amount2", typeof(decimal));
	tepexpvar.defineColumn("amount3", typeof(decimal));
	tepexpvar.defineColumn("amount4", typeof(decimal));
	tepexpvar.defineColumn("amount5", typeof(decimal));
	tepexpvar.defineColumn("ct", typeof(DateTime),false);
	tepexpvar.defineColumn("cu", typeof(string),false);
	tepexpvar.defineColumn("description", typeof(string),false);
	tepexpvar.defineColumn("lt", typeof(DateTime),false);
	tepexpvar.defineColumn("lu", typeof(string),false);
	tepexpvar.defineColumn("yvar", typeof(short),false);
	Tables.Add(tepexpvar);
	tepexpvar.defineKey("idepexp", "nvar");

	//////////////////// EPEXPSORTING /////////////////////////////////
	var tepexpsorting= new MetaTable("epexpsorting");
	tepexpsorting.defineColumn("idepexp", typeof(int),false);
	tepexpsorting.defineColumn("rownum", typeof(int),false);
	tepexpsorting.defineColumn("adate", typeof(DateTime),false);
	tepexpsorting.defineColumn("amount", typeof(decimal),false);
	tepexpsorting.defineColumn("ayear", typeof(short),false);
	tepexpsorting.defineColumn("ct", typeof(DateTime),false);
	tepexpsorting.defineColumn("cu", typeof(string),false);
	tepexpsorting.defineColumn("description", typeof(string));
	tepexpsorting.defineColumn("idsor", typeof(int),false);
	tepexpsorting.defineColumn("kind", typeof(string));
	tepexpsorting.defineColumn("lt", typeof(DateTime),false);
	tepexpsorting.defineColumn("lu", typeof(string),false);
	Tables.Add(tepexpsorting);
	tepexpsorting.defineKey("idepexp", "rownum");

	//////////////////// MANDATEAVCP /////////////////////////////////
	var tmandateavcp= new MetaTable("mandateavcp");
	tmandateavcp.defineColumn("idmankind", typeof(string),false);
	tmandateavcp.defineColumn("yman", typeof(short),false);
	tmandateavcp.defineColumn("nman", typeof(int),false);
	tmandateavcp.defineColumn("idavcp", typeof(int),false);
	tmandateavcp.defineColumn("idreg", typeof(int));
	tmandateavcp.defineColumn("cf", typeof(string));
	tmandateavcp.defineColumn("foreigncf", typeof(string));
	tmandateavcp.defineColumn("title", typeof(string),false);
	tmandateavcp.defineColumn("idavcp_role", typeof(string));
	tmandateavcp.defineColumn("flagcontractor", typeof(string),false);
	tmandateavcp.defineColumn("cu", typeof(string),false);
	tmandateavcp.defineColumn("ct", typeof(DateTime),false);
	tmandateavcp.defineColumn("lu", typeof(string),false);
	tmandateavcp.defineColumn("lt", typeof(DateTime),false);
	tmandateavcp.defineColumn("idmain_avcp", typeof(int));
	tmandateavcp.defineColumn("!capogruppo", typeof(string));
	tmandateavcp.defineColumn("flagnonparticipating", typeof(string));
	Tables.Add(tmandateavcp);
	tmandateavcp.defineKey("idmankind", "yman", "nman", "idavcp");

	//////////////////// MANDATEAVCPDETAIL /////////////////////////////////
	var tmandateavcpdetail= new MetaTable("mandateavcpdetail");
	tmandateavcpdetail.defineColumn("idmankind", typeof(string),false);
	tmandateavcpdetail.defineColumn("yman", typeof(short),false);
	tmandateavcpdetail.defineColumn("nman", typeof(int),false);
	tmandateavcpdetail.defineColumn("idavcp", typeof(int),false);
	tmandateavcpdetail.defineColumn("cigcode", typeof(string),false);
	tmandateavcpdetail.defineColumn("lt", typeof(DateTime),false);
	tmandateavcpdetail.defineColumn("lu", typeof(string),false);
	Tables.Add(tmandateavcpdetail);
	tmandateavcpdetail.defineKey("idmankind", "yman", "nman", "idavcp", "cigcode");

	//////////////////// MANDATECIG /////////////////////////////////
	var tmandatecig= new MetaTable("mandatecig");
	tmandatecig.defineColumn("idmankind", typeof(string),false);
	tmandatecig.defineColumn("yman", typeof(short),false);
	tmandatecig.defineColumn("nman", typeof(int),false);
	tmandatecig.defineColumn("cigcode", typeof(string),false);
	tmandatecig.defineColumn("contractamount", typeof(decimal));
	tmandatecig.defineColumn("idavcp_choice", typeof(string));
	tmandatecig.defineColumn("start_contract", typeof(DateTime));
	tmandatecig.defineColumn("stop_contract", typeof(DateTime));
	tmandatecig.defineColumn("description", typeof(string));
	tmandatecig.defineColumn("ct", typeof(DateTime));
	tmandatecig.defineColumn("cu", typeof(string));
	tmandatecig.defineColumn("lt", typeof(DateTime));
	tmandatecig.defineColumn("lu", typeof(string));
	tmandatecig.defineColumn("idavcp", typeof(int));
	tmandatecig.defineColumn("!capogruppo", typeof(string));
	Tables.Add(tmandatecig);
	tmandatecig.defineKey("idmankind", "yman", "nman", "cigcode");

	//////////////////// UNIQUEREGISTER /////////////////////////////////
	var tuniqueregister= new MetaTable("uniqueregister");
	tuniqueregister.defineColumn("iduniqueregister", typeof(int),false);
	tuniqueregister.defineColumn("yinv", typeof(short));
	tuniqueregister.defineColumn("ninv", typeof(int));
	tuniqueregister.defineColumn("idinvkind", typeof(int));
	tuniqueregister.defineColumn("ycon", typeof(int));
	tuniqueregister.defineColumn("ncon", typeof(int));
	tuniqueregister.defineColumn("yman", typeof(short),false);
	tuniqueregister.defineColumn("nman", typeof(int),false);
	tuniqueregister.defineColumn("idmankind", typeof(string),false);
	tuniqueregister.defineColumn("ct", typeof(DateTime),false);
	tuniqueregister.defineColumn("cu", typeof(string),false);
	tuniqueregister.defineColumn("lt", typeof(DateTime),false);
	tuniqueregister.defineColumn("lu", typeof(string),false);
	Tables.Add(tuniqueregister);
	tuniqueregister.defineKey("iduniqueregister", "yman", "nman", "idmankind");

	//////////////////// PCCVIEW /////////////////////////////////
	var tpccview= new MetaTable("pccview");
	tpccview.defineColumn("opkind", typeof(string),false);
	tpccview.defineColumn("idpcc", typeof(int),false);
	tpccview.defineColumn("idinvkind", typeof(int));
	tpccview.defineColumn("invoicekind", typeof(string));
	tpccview.defineColumn("yinv", typeof(short));
	tpccview.defineColumn("ninv", typeof(int));
	tpccview.defineColumn("ycon", typeof(int));
	tpccview.defineColumn("ncon", typeof(int));
	tpccview.defineColumn("idmankind", typeof(string));
	tpccview.defineColumn("mandatekind", typeof(string));
	tpccview.defineColumn("yman", typeof(short));
	tpccview.defineColumn("nman", typeof(int));
	Tables.Add(tpccview);

	//////////////////// CONSIPKIND /////////////////////////////////
	var tconsipkind= new MetaTable("consipkind");
	tconsipkind.defineColumn("idconsipkind", typeof(int),false);
	tconsipkind.defineColumn("ct", typeof(DateTime),false);
	tconsipkind.defineColumn("cu", typeof(string),false);
	tconsipkind.defineColumn("description", typeof(string),false);
	tconsipkind.defineColumn("lt", typeof(DateTime),false);
	tconsipkind.defineColumn("lu", typeof(string),false);
	tconsipkind.defineColumn("active", typeof(string));
	tconsipkind.defineColumn("flagpurchaseperformed", typeof(string));
	tconsipkind.defineColumn("position", typeof(int));
	tconsipkind.defineColumn("flagheader", typeof(string));
	tconsipkind.defineColumn("shortdescription", typeof(string));
	tconsipkind.defineColumn("flagdynamictext", typeof(string));
	Tables.Add(tconsipkind);
	tconsipkind.defineKey("idconsipkind");

	//////////////////// CONSIPKIND_EXT /////////////////////////////////
	var tconsipkind_ext= new MetaTable("consipkind_ext");
	tconsipkind_ext.defineColumn("idconsipkind", typeof(int),false);
	tconsipkind_ext.defineColumn("ct", typeof(DateTime),false);
	tconsipkind_ext.defineColumn("cu", typeof(string),false);
	tconsipkind_ext.defineColumn("description", typeof(string),false);
	tconsipkind_ext.defineColumn("lt", typeof(DateTime),false);
	tconsipkind_ext.defineColumn("lu", typeof(string),false);
	tconsipkind_ext.defineColumn("active", typeof(string));
	tconsipkind_ext.defineColumn("position", typeof(int));
	tconsipkind_ext.defineColumn("shortdescription", typeof(string));
	tconsipkind_ext.defineColumn("flagheader", typeof(string));
	Tables.Add(tconsipkind_ext);
	tconsipkind_ext.defineKey("idconsipkind");

	//////////////////// CONSIPCATEGORY /////////////////////////////////
	var tconsipcategory= new MetaTable("consipcategory");
	tconsipcategory.defineColumn("idconsipcategory", typeof(int),false);
	tconsipcategory.defineColumn("description", typeof(string));
	tconsipcategory.defineColumn("active", typeof(string));
	Tables.Add(tconsipcategory);
	tconsipcategory.defineKey("idconsipcategory");

	//////////////////// LIST /////////////////////////////////
	var tlist= new listTable();
	tlist.addBaseColumns("idlist","description","intcode","intbarcode","extcode","extbarcode","validitystop","active","idpackage","idunit","unitsforpackage","has_expiry","cu","ct","lu","lt","idlistclass","pic","picext","nmin","ntoreorder","tounload","timesupply","nmaxorder");
	Tables.Add(tlist);
	tlist.defineKey("idlist");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode","idepupbkind");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new accmotiveTable();
	taccmotive.addBaseColumns("idaccmotive","active","codemotive","ct","cu","lt","lu","paridaccmotive","title","flagdep","flagamm","expensekind");
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// INVENTORYTREE /////////////////////////////////
	var tinventorytree= new inventorytreeTable();
	tinventorytree.addBaseColumns("codeinv","ct","cu","description","lt","lu","rtf","txt","idaccmotiveunload","idaccmotiveload","nlevel","idinv","paridinv","lookupcode");
	Tables.Add(tinventorytree);
	tinventorytree.defineKey("idinv");

	//////////////////// REGISTRYMAINVIEW_RUP /////////////////////////////////
	var tregistrymainview_rup= new MetaTable("registrymainview_rup");
	tregistrymainview_rup.defineColumn("idreg", typeof(int),false);
	tregistrymainview_rup.defineColumn("title", typeof(string),false);
	tregistrymainview_rup.defineColumn("idregistryclass", typeof(string));
	tregistrymainview_rup.defineColumn("registryclass", typeof(string));
	tregistrymainview_rup.defineColumn("surname", typeof(string));
	tregistrymainview_rup.defineColumn("forename", typeof(string));
	tregistrymainview_rup.defineColumn("cf", typeof(string));
	tregistrymainview_rup.defineColumn("p_iva", typeof(string));
	tregistrymainview_rup.defineColumn("residence", typeof(int),false);
	tregistrymainview_rup.defineColumn("coderesidence", typeof(string));
	tregistrymainview_rup.defineColumn("residencekind", typeof(string));
	tregistrymainview_rup.defineColumn("annotation", typeof(string));
	tregistrymainview_rup.defineColumn("birthdate", typeof(DateTime));
	tregistrymainview_rup.defineColumn("idcity", typeof(int));
	tregistrymainview_rup.defineColumn("city", typeof(string));
	tregistrymainview_rup.defineColumn("gender", typeof(string));
	tregistrymainview_rup.defineColumn("foreigncf", typeof(string));
	tregistrymainview_rup.defineColumn("idtitle", typeof(string));
	tregistrymainview_rup.defineColumn("qualification", typeof(string));
	tregistrymainview_rup.defineColumn("idmaritalstatus", typeof(string));
	tregistrymainview_rup.defineColumn("maritalstatus", typeof(string));
	tregistrymainview_rup.defineColumn("idregistrykind", typeof(int));
	tregistrymainview_rup.defineColumn("sortcode", typeof(string));
	tregistrymainview_rup.defineColumn("registrykind", typeof(string));
	tregistrymainview_rup.defineColumn("human", typeof(string));
	tregistrymainview_rup.defineColumn("active", typeof(string),false);
	tregistrymainview_rup.defineColumn("badgecode", typeof(string));
	tregistrymainview_rup.defineColumn("maritalsurname", typeof(string));
	tregistrymainview_rup.defineColumn("idcategory", typeof(string));
	tregistrymainview_rup.defineColumn("category", typeof(string));
	tregistrymainview_rup.defineColumn("extmatricula", typeof(string));
	tregistrymainview_rup.defineColumn("idcentralizedcategory", typeof(string));
	tregistrymainview_rup.defineColumn("cu", typeof(string),false);
	tregistrymainview_rup.defineColumn("ct", typeof(DateTime),false);
	tregistrymainview_rup.defineColumn("lu", typeof(string),false);
	tregistrymainview_rup.defineColumn("lt", typeof(DateTime),false);
	tregistrymainview_rup.defineColumn("location", typeof(string));
	tregistrymainview_rup.defineColumn("idnation", typeof(int));
	tregistrymainview_rup.defineColumn("nation", typeof(string));
	tregistrymainview_rup.defineColumn("authorization_free", typeof(string));
	tregistrymainview_rup.defineColumn("multi_cf", typeof(string));
	tregistrymainview_rup.defineColumn("toredirect", typeof(int));
	tregistrymainview_rup.defineColumn("idaccmotivedebit", typeof(string));
	tregistrymainview_rup.defineColumn("codemotivedebit", typeof(string));
	tregistrymainview_rup.defineColumn("idaccmotivecredit", typeof(string));
	tregistrymainview_rup.defineColumn("codemotivecredit", typeof(string));
	tregistrymainview_rup.defineColumn("ccp", typeof(string));
	tregistrymainview_rup.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistrymainview_rup.defineColumn("ipa_fe", typeof(string));
	tregistrymainview_rup.defineColumn("flag_pa", typeof(string));
	tregistrymainview_rup.defineColumn("sdi_norifamm", typeof(string));
	tregistrymainview_rup.defineColumn("sdi_defrifamm", typeof(string));
	Tables.Add(tregistrymainview_rup);
	tregistrymainview_rup.defineKey("idreg");

	//////////////////// ATTACHMENTKIND /////////////////////////////////
	var tattachmentkind= new MetaTable("attachmentkind");
	tattachmentkind.defineColumn("idattachmentkind", typeof(int),false);
	tattachmentkind.defineColumn("title", typeof(string),false);
	tattachmentkind.defineColumn("lt", typeof(DateTime));
	tattachmentkind.defineColumn("lu", typeof(string));
	tattachmentkind.defineColumn("ct", typeof(DateTime));
	tattachmentkind.defineColumn("cu", typeof(string));
	tattachmentkind.defineColumn("active", typeof(string),false);
	Tables.Add(tattachmentkind);
	tattachmentkind.defineKey("idattachmentkind");

	//////////////////// MANDATEVIEW /////////////////////////////////
	var tmandateview= new MetaTable("mandateview");
	tmandateview.defineColumn("idmankind", typeof(string),false);
	tmandateview.defineColumn("yman", typeof(short),false);
	tmandateview.defineColumn("nman", typeof(int),false);
	tmandateview.defineColumn("mankind", typeof(string),false);
	tmandateview.defineColumn("idreg", typeof(int));
	tmandateview.defineColumn("registry", typeof(string));
	tmandateview.defineColumn("registryreference", typeof(string));
	tmandateview.defineColumn("description", typeof(string),false);
	tmandateview.defineColumn("idman", typeof(int));
	tmandateview.defineColumn("manager", typeof(string));
	tmandateview.defineColumn("deliveryexpiration", typeof(string));
	tmandateview.defineColumn("deliveryaddress", typeof(string));
	tmandateview.defineColumn("paymentexpiring", typeof(short));
	tmandateview.defineColumn("idexpirationkind", typeof(short));
	tmandateview.defineColumn("idcurrency", typeof(int));
	tmandateview.defineColumn("codecurrency", typeof(string));
	tmandateview.defineColumn("currency", typeof(string));
	tmandateview.defineColumn("exchangerate", typeof(double));
	tmandateview.defineColumn("doc", typeof(string));
	tmandateview.defineColumn("docdate", typeof(DateTime));
	tmandateview.defineColumn("adate", typeof(DateTime),false);
	tmandateview.defineColumn("officiallyprinted", typeof(string),false);
	tmandateview.defineColumn("txt", typeof(string));
	tmandateview.defineColumn("cu", typeof(string),false);
	tmandateview.defineColumn("ct", typeof(DateTime),false);
	tmandateview.defineColumn("lu", typeof(string),false);
	tmandateview.defineColumn("lt", typeof(DateTime),false);
	tmandateview.defineColumn("taxable_euro", typeof(decimal),true,true);
	tmandateview.defineColumn("iva_euro", typeof(decimal),true,true);
	tmandateview.defineColumn("total", typeof(decimal),true,true);
	tmandateview.defineColumn("active", typeof(string));
	tmandateview.defineColumn("flagintracom", typeof(string));
	tmandateview.defineColumn("idaccmotivedebit", typeof(string));
	tmandateview.defineColumn("codemotivedebit", typeof(string));
	tmandateview.defineColumn("idaccmotivedebit_crg", typeof(string));
	tmandateview.defineColumn("codemotivedebit_crg", typeof(string));
	tmandateview.defineColumn("idaccmotivedebit_datacrg", typeof(DateTime));
	tmandateview.defineColumn("applierannotations", typeof(string));
	tmandateview.defineColumn("idmandatestatus", typeof(short));
	tmandateview.defineColumn("mandatestatus", typeof(string));
	tmandateview.defineColumn("idstore", typeof(int));
	tmandateview.defineColumn("store", typeof(string));
	tmandateview.defineColumn("statusimage", typeof(string),true,true);
	tmandateview.defineColumn("listingorder", typeof(short));
	tmandateview.defineColumn("linkedtotal", typeof(decimal),true,true);
	tmandateview.defineColumn("isrequest", typeof(string));
	tmandateview.defineColumn("cigcode", typeof(string));
	tmandateview.defineColumn("idsor01", typeof(int));
	tmandateview.defineColumn("idsor02", typeof(int));
	tmandateview.defineColumn("idsor03", typeof(int));
	tmandateview.defineColumn("idsor04", typeof(int));
	tmandateview.defineColumn("idsor05", typeof(int));
	tmandateview.defineColumn("idconsipkind", typeof(int));
	tmandateview.defineColumn("consipkind", typeof(string));
	tmandateview.defineColumn("idconsipkind_ext", typeof(int));
	tmandateview.defineColumn("consipkind_ext", typeof(string));
	tmandateview.defineColumn("consipmotive", typeof(string));
	tmandateview.defineColumn("flagdanger", typeof(string),true,true);
	tmandateview.defineColumn("mankind_origin", typeof(string));
	tmandateview.defineColumn("idmankind_origin", typeof(string));
	tmandateview.defineColumn("yman_origin", typeof(short));
	tmandateview.defineColumn("nman_origin", typeof(int));
	tmandateview.defineColumn("mankind_dest", typeof(string));
	tmandateview.defineColumn("idmankind_dest", typeof(string));
	tmandateview.defineColumn("yman_dest", typeof(short));
	tmandateview.defineColumn("nman_dest", typeof(int));
	tmandateview.defineColumn("subappropriation", typeof(string));
	tmandateview.defineColumn("finsubappropriation", typeof(string));
	tmandateview.defineColumn("adatesubappropriation", typeof(DateTime));
	tmandateview.defineColumn("arrivalprotocolnum", typeof(string));
	tmandateview.defineColumn("arrivaldate", typeof(DateTime));
	tmandateview.defineColumn("annotations", typeof(string));
	tmandateview.defineColumn("iduniqueregister", typeof(int));
	tmandateview.defineColumn("resendingpcc", typeof(string));
	tmandateview.defineColumn("ipa_fe", typeof(string));
	tmandateview.defineColumn("expirationkind", typeof(string));
	tmandateview.defineColumn("expiration", typeof(DateTime),true,true);
	tmandateview.defineColumn("external_reference", typeof(string));
	tmandateview.defineColumn("officecode", typeof(string));
	tmandateview.defineColumn("officedescription", typeof(string));
	tmandateview.defineColumn("officetitle", typeof(string));
	tmandateview.defineColumn("flagtenderresult", typeof(string));
	tmandateview.defineColumn("motiveassignment", typeof(string));
	tmandateview.defineColumn("anacreduced", typeof(double));
	tmandateview.defineColumn("idreg_rupanac", typeof(int));
	tmandateview.defineColumn("rupanac", typeof(string));
	tmandateview.defineColumn("tenderresult", typeof(string),true,true);
	tmandateview.defineColumn("tenderkind", typeof(string));
	tmandateview.defineColumn("tenderkinddescr", typeof(string),true,true);
	tmandateview.defineColumn("publishdate", typeof(DateTime));
	tmandateview.defineColumn("publishdatekind", typeof(string));
	tmandateview.defineColumn("publishdatekinddescr", typeof(string),true,true);
	tmandateview.defineColumn("requested_doc", typeof(int));
	Tables.Add(tmandateview);

	//////////////////// WSAGGIUDICATARIO /////////////////////////////////
	var twsaggiudicatario= new MetaTable("wsaggiudicatario");
	twsaggiudicatario.defineColumn("idAggiudicatario", typeof(int),false,true);
	twsaggiudicatario.defineColumn("idLotto", typeof(int),false);
	twsaggiudicatario.defineColumn("codiceFiscale", typeof(string));
	twsaggiudicatario.defineColumn("identificativoFiscaleEstero", typeof(string));
	twsaggiudicatario.defineColumn("ragioneSociale", typeof(string));
	twsaggiudicatario.defineColumn("ruolo", typeof(string));
	twsaggiudicatario.defineColumn("yman", typeof(short));
	twsaggiudicatario.defineColumn("nman", typeof(int));
	twsaggiudicatario.defineColumn("idmankind", typeof(string));
	twsaggiudicatario.defineColumn("cu", typeof(string),false);
	twsaggiudicatario.defineColumn("ct", typeof(DateTime),false);
	twsaggiudicatario.defineColumn("lu", typeof(string),false);
	twsaggiudicatario.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(twsaggiudicatario);
	twsaggiudicatario.defineKey("idAggiudicatario");

	//////////////////// WSPARTECIPANTE /////////////////////////////////
	var twspartecipante= new MetaTable("wspartecipante");
	twspartecipante.defineColumn("idPartecipante", typeof(int),false,true);
	twspartecipante.defineColumn("idLotto", typeof(int),false);
	twspartecipante.defineColumn("codiceFiscale", typeof(string));
	twspartecipante.defineColumn("identificativoFiscaleEstero", typeof(string));
	twspartecipante.defineColumn("ragioneSociale", typeof(string));
	twspartecipante.defineColumn("ruolo", typeof(string));
	twspartecipante.defineColumn("cu", typeof(string),false);
	twspartecipante.defineColumn("ct", typeof(DateTime),false);
	twspartecipante.defineColumn("lu", typeof(string),false);
	twspartecipante.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(twspartecipante);
	twspartecipante.defineKey("idPartecipante");

	//////////////////// WSGARA /////////////////////////////////
	var twsgara= new MetaTable("wsgara");
	twsgara.defineColumn("idGara", typeof(int),false,true);
	twsgara.defineColumn("idGaraTraspare", typeof(int),false);
	twsgara.defineColumn("titoloGara", typeof(string));
	twsgara.defineColumn("abstractGara", typeof(string));
	twsgara.defineColumn("idStrutturaTraspare", typeof(int),false);
	twsgara.defineColumn("annoAggiudicazioneGara", typeof(int),false);
	twsgara.defineColumn("esitoGara", typeof(int),false);
	twsgara.defineColumn("tipoGara", typeof(int),false);
	twsgara.defineColumn("rupNome", typeof(string));
	twsgara.defineColumn("rupCognome", typeof(string));
	twsgara.defineColumn("rupCodiceFiscale", typeof(string));
	twsgara.defineColumn("dataPubblicazione", typeof(DateTime),false);
	twsgara.defineColumn("tipoPubblicazione", typeof(int),false);
	twsgara.defineColumn("motivazioneAffidamento", typeof(string));
	twsgara.defineColumn("ribasso", typeof(double));
	twsgara.defineColumn("json", typeof(string));
	twsgara.defineColumn("cu", typeof(string),false);
	twsgara.defineColumn("ct", typeof(DateTime),false);
	twsgara.defineColumn("lu", typeof(string),false);
	twsgara.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(twsgara);
	twsgara.defineKey("idGara");

	//////////////////// WSLOTTO /////////////////////////////////
	var twslotto= new MetaTable("wslotto");
	twslotto.defineColumn("idLotto", typeof(int),false,true);
	twslotto.defineColumn("idGara", typeof(int),false);
	twslotto.defineColumn("cig", typeof(string));
	twslotto.defineColumn("spCodiceFiscale", typeof(string));
	twslotto.defineColumn("spDenominazione", typeof(string));
	twslotto.defineColumn("oggetto", typeof(string));
	twslotto.defineColumn("sceltaContraente", typeof(string));
	twslotto.defineColumn("importoAggiudicazione", typeof(double),false);
	twslotto.defineColumn("dataInizio", typeof(DateTime));
	twslotto.defineColumn("dataUltimazione", typeof(DateTime));
	twslotto.defineColumn("importoSommeLiquidate", typeof(double),false);
	twslotto.defineColumn("cu", typeof(string),false);
	twslotto.defineColumn("ct", typeof(DateTime),false);
	twslotto.defineColumn("lu", typeof(string),false);
	twslotto.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(twslotto);
	twslotto.defineKey("idLotto");

	//////////////////// GARATRASPAREVIEW /////////////////////////////////
	var tgaratraspareview= new MetaTable("garatraspareview");
	tgaratraspareview.defineColumn("idGaraTraspare", typeof(int),false);
	tgaratraspareview.defineColumn("cig", typeof(string),false);
	tgaratraspareview.defineColumn("Fornitore", typeof(string));
	tgaratraspareview.defineColumn("FornitoreCFPIva", typeof(string),false);
	tgaratraspareview.defineColumn("FornitoreIdEstero", typeof(string),false);
	tgaratraspareview.defineColumn("ImportoAggiudicazione", typeof(double));
	tgaratraspareview.defineColumn("Rup", typeof(string));
	tgaratraspareview.defineColumn("RupCF", typeof(string),false);
	Tables.Add(tgaratraspareview);
	tgaratraspareview.defineKey("idGaraTraspare", "cig", "FornitoreCFPIva", "FornitoreIdEstero", "RupCF");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_wsaggiudicatario_mandate","mandate","wsaggiudicatario","yman","nman","idmankind");
	this.defineRelation("FK_mandate_pccview","mandate","pccview","yman","nman","idmankind");
	this.defineRelation("mandate_uniqueregister","mandate","uniqueregister","yman","nman","idmankind");
	this.defineRelation("mandate_mandatecig","mandate","mandatecig","yman","nman","idmankind");
	this.defineRelation("mandateavcp_mandateavcpdetail","mandateavcp","mandateavcpdetail","idmankind","yman","nman","idavcp");
	this.defineRelation("mandate_mandateavcpdetail","mandate","mandateavcpdetail","yman","nman","idmankind");
	this.defineRelation("mandate_mandateavcp","mandate","mandateavcp","yman","nman","idmankind");
	var cPar = new []{mandateavcp.Columns["idmankind"], mandateavcp.Columns["yman"], mandateavcp.Columns["nman"], mandateavcp.Columns["idavcp"]};
	var cChild = new []{mandateavcp.Columns["idmankind"], mandateavcp.Columns["yman"], mandateavcp.Columns["nman"], mandateavcp.Columns["idmain_avcp"]};
	Relations.Add(new DataRelation("mandateavcp_mandateavcp",cPar,cChild,false));

	this.defineRelation("mandate_mandateattachment","mandate","mandateattachment","yman","nman","idmankind");
	this.defineRelation("FK_mandate_stockview","mandate","stockview","yman","nman","idmankind");
	this.defineRelation("mandateinvoicedetail","mandate","invoicedetail","yman","nman","idmankind");
	this.defineRelation("mandatemandatesorting","mandate","mandatesorting","yman","nman","idmankind");
	this.defineRelation("FK_sortingview_mandatesorting","sortingview","mandatesorting","idsor");
	this.defineRelation("list_mandatedetail","list","mandatedetail","idlist");
	this.defineRelation("ivakind_mandatedetail","ivakind","mandatedetail","idivakind");
	this.defineRelation("upb_detail_mandatedetail","upb_detail","mandatedetail","idupb");
	this.defineRelation("registry_mandatedetail","registry","mandatedetail","idreg");
	this.defineRelation("mandatemandatedetail","mandate","mandatedetail","yman","nman","idmankind");
	this.defineRelation("registrymainview_mandate","registrymainview","mandate","idreg");
	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{mandate.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_mandate",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{mandate.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_mandate",cPar,cChild,false));

	this.defineRelation("mandatestatus_mandate","mandatestatus","mandate","idmandatestatus");
	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{mandate.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_mandate",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{mandate.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_mandate",cPar,cChild,false));

	this.defineRelation("mandatekindmandate","mandatekind","mandate","idmankind");
	this.defineRelation("managermandate","manager","mandate","idman");
	this.defineRelation("expirationkindmandate","expirationkind","mandate","idexpirationkind");
	this.defineRelation("currencymandate","currency","mandate","idcurrency");
	this.defineRelation("FK_store_mandate","store","mandate","idstore");
	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{mandate.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_mandate",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{mandate.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_mandate",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{mandate.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_mandate",cPar,cChild,false));

	cPar = new []{registrymainview_rup.Columns["idreg"]};
	cChild = new []{mandate.Columns["idreg_rupanac"]};
	Relations.Add(new DataRelation("FK_registrymainview_rup_mandate",cPar,cChild,false));

	this.defineRelation("attachmentkind_mandateattachment","attachmentkind","mandateattachment","idattachmentkind");
	this.defineRelation("FK_wsAggiudicatario_wsLotto_idLotto","wslotto","wsaggiudicatario","idLotto");
	this.defineRelation("FK_wsPartecipante_wsLotto_idLotto","wslotto","wspartecipante","idLotto");
	this.defineRelation("FK_wsLotto_wsGara_idGara","wsgara","wslotto","idGara");
	#endregion

}
}
}
