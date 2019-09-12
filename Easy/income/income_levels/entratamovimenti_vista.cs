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
using meta_income;
using meta_manager;
using meta_incomeyear;
using meta_registry;
using meta_incomevar;
using meta_incomesorted;
using meta_sortingkind;
using meta_sorting;
using meta_proceedspart;
using meta_invoice;
using meta_invoicekind;
using meta_upb;
using meta_finview;
using meta_bill;
using meta_estimate;
using meta_estimatekind;
using meta_incomelast;
using meta_config;
using meta_proceeds;
using meta_account;
using meta_underwriting;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace income_levels {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeTable income 		=> (incomeTable)Tables["income"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomephase 		=> (MetaTable)Tables["incomephase"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public managerTable manager 		=> (managerTable)Tables["manager"];

	///<summary>
	///totalizzatore su mov. di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incometotal 		=> (MetaTable)Tables["incometotal"];

	///<summary>
	///Informazioni annuali su mov. di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomeyearTable incomeyear 		=> (incomeyearTable)Tables["incomeyear"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Variazione movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomevarTable incomevar 		=> (incomevarTable)Tables["incomevar"];

	///<summary>
	///Classificazione Movimenti di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomesortedTable incomesorted 		=> (incomesortedTable)Tables["incomesorted"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind 		=> (sortingkindTable)Tables["sortingkind"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

	///<summary>
	///Assegnazione credito al bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable creditpart 		=> (MetaTable)Tables["creditpart"];

	///<summary>
	///Assegnazione incasso al bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public proceedspartTable proceedspart 		=> (proceedspartTable)Tables["proceedspart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bilanciocrediti 		=> (MetaTable)Tables["bilanciocrediti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bilancioincassi 		=> (MetaTable)Tables["bilancioincassi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipomovimento 		=> (MetaTable)Tables["tipomovimento"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoiceTable invoice 		=> (invoiceTable)Tables["invoice"];

	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomeinvoice 		=> (MetaTable)Tables["incomeinvoice"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable finview 		=> (finviewTable)Tables["finview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable billview 		=> (MetaTable)Tables["billview"];

	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public billTable bill 		=> (billTable)Tables["bill"];

	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomeestimate 		=> (MetaTable)Tables["incomeestimate"];

	///<summary>
	///Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimateTable estimate 		=> (estimateTable)Tables["estimate"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind 		=> (estimatekindTable)Tables["estimatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatedetail_taxable 		=> (MetaTable)Tables["estimatedetail_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatedetail_iva 		=> (MetaTable)Tables["estimatedetail_iva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail_taxable 		=> (MetaTable)Tables["invoicedetail_taxable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable invoicedetail_iva 		=> (MetaTable)Tables["invoicedetail_iva"];

	///<summary>
	///Movimento di entrata - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public incomelastTable incomelast 		=> (incomelastTable)Tables["incomelast"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Documento di incasso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public proceedsTable proceeds 		=> (proceedsTable)Tables["proceeds"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account 		=> (accountTable)Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbcrediti 		=> (MetaTable)Tables["upbcrediti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbincassi 		=> (MetaTable)Tables["upbincassi"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public underwritingTable underwriting 		=> (underwritingTable)Tables["underwriting"];

	///<summary>
	///Sospeso attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomebill 		=> (MetaTable)Tables["incomebill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bill1 		=> (MetaTable)Tables["bill1"];

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
	//////////////////// INCOME /////////////////////////////////
	var tincome= new incomeTable();
	tincome.addBaseColumns("idinc","nphase","ymov","nmov","parentidinc","idreg","idman","doc","docdate","description","autokind","autocode","idpayment","expiration","adate","txt","rtf","cupcode","cu","ct","lu","lt","idunderwriting","external_reference");
	Tables.Add(tincome);
	tincome.defineKey("idinc");

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

	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new managerTable();
	tmanager.addBaseColumns("idman","title","iddivision","email","phonenumber","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tmanager);
	tmanager.defineKey("idman");

	//////////////////// INCOMETOTAL /////////////////////////////////
	var tincometotal= new MetaTable("incometotal");
	tincometotal.defineColumn("idinc", typeof(int),false);
	tincometotal.defineColumn("ayear", typeof(short),false);
	tincometotal.defineColumn("flag", typeof(byte),false);
	tincometotal.defineColumn("curramount", typeof(decimal));
	tincometotal.defineColumn("available", typeof(decimal));
	tincometotal.defineColumn("partitioned", typeof(decimal));
	Tables.Add(tincometotal);
	tincometotal.defineKey("idinc", "ayear");

	//////////////////// INCOMEYEAR /////////////////////////////////
	var tincomeyear= new incomeyearTable();
	tincomeyear.addBaseColumns("idinc","ayear","idfin","idupb","amount","cu","ct","lu","lt");
	Tables.Add(tincomeyear);
	tincomeyear.defineKey("idinc", "ayear");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","annotation","birthdate","gender","surname","forename","foreigncf","ccp","flagbankitaliaproceeds","active","txt","rtf","cu","ct","lu","lt");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new incomevarTable();
	tincomevar.addBaseColumns("idinc","nvar","yvar","description","amount","doc","docdate","adate","txt","transferkind","rtf","cu","ct","lu","lt","autokind","idinvkind","yinv","ninv","kproceedstransmission");
	Tables.Add(tincomevar);
	tincomevar.defineKey("idinc", "nvar");

	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new incomesortedTable();
	tincomesorted.addBaseColumns("idsor","idinc","idsubclass","amount","description","txt","rtf","cu","ct","lu","lt","flagnodate","tobecontinued","start","stop","valuen1","valuen2","valuen3","valuen4","valuen5","values1","values2","values3","values4","values5","valuev1","valuev2","valuev3","valuev4","valuev5","ayear","paridsor","paridsubclass");
	tincomesorted.defineColumn("!percentuale", typeof(string));
	tincomesorted.defineColumn("!codice", typeof(string));
	tincomesorted.defineColumn("!descr", typeof(string));
	tincomesorted.defineColumn("!idsorkind", typeof(int));
	Tables.Add(tincomesorted);
	tincomesorted.defineKey("idinc", "idsor", "idsubclass");

	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new sortingkindTable();
	tsortingkind.addBaseColumns("idsorkind","description","nphaseincome","nphaseexpense","cu","ct","lu","lt","labeln1","lockedn1","forcedn1","labeln2","lockedn2","forcedn2","labeln3","lockedn3","forcedn3","labeln4","lockedn4","forcedn4","labeln5","lockedn5","forcedn5","labels1","lockeds1","forceds1","labels2","lockeds2","forceds2","labels3","lockeds3","forceds3","labels4","lockeds4","forceds4","labels5","lockeds5","forceds5","labelv1","lockedv1","forcedv1","labelv2","lockedv2","forcedv2","labelv3","lockedv3","forcedv3","labelv4","lockedv4","forcedv4","labelv5","lockedv5","forcedv5","flagdate","labelfordate","nodatelabel","totalexpression");
	tsortingkind.defineColumn("!importo", typeof(decimal));
	Tables.Add(tsortingkind);
	tsortingkind.defineKey("idsorkind");

	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// CREDITPART /////////////////////////////////
	var tcreditpart= new MetaTable("creditpart");
	tcreditpart.defineColumn("idinc", typeof(int),false);
	tcreditpart.defineColumn("idfin", typeof(int),false);
	tcreditpart.defineColumn("!codbil", typeof(string));
	tcreditpart.defineColumn("!denombil", typeof(string));
	tcreditpart.defineColumn("ycreditpart", typeof(short),false);
	tcreditpart.defineColumn("ncreditpart", typeof(int),false);
	tcreditpart.defineColumn("description", typeof(string),false);
	tcreditpart.defineColumn("amount", typeof(decimal));
	tcreditpart.defineColumn("adate", typeof(DateTime),false);
	tcreditpart.defineColumn("txt", typeof(string));
	tcreditpart.defineColumn("rtf", typeof(Byte[]));
	tcreditpart.defineColumn("cu", typeof(string),false);
	tcreditpart.defineColumn("ct", typeof(DateTime),false);
	tcreditpart.defineColumn("lu", typeof(string),false);
	tcreditpart.defineColumn("lt", typeof(DateTime),false);
	tcreditpart.defineColumn("idupb", typeof(string));
	tcreditpart.defineColumn("!codeupb", typeof(string));
	tcreditpart.defineColumn("!upb", typeof(string));
	Tables.Add(tcreditpart);
	tcreditpart.defineKey("idinc", "ncreditpart");

	//////////////////// PROCEEDSPART /////////////////////////////////
	var tproceedspart= new proceedspartTable();
	tproceedspart.addBaseColumns("idinc","idfin","yproceedspart","nproceedspart","description","amount","adate","txt","rtf","cu","ct","lu","lt","idupb");
	tproceedspart.defineColumn("!codbil", typeof(string));
	tproceedspart.defineColumn("!denombil", typeof(string));
	tproceedspart.defineColumn("!codeupb", typeof(string));
	tproceedspart.defineColumn("!upb", typeof(string));
	Tables.Add(tproceedspart);
	tproceedspart.defineKey("idinc", "nproceedspart");

	//////////////////// BILANCIOCREDITI /////////////////////////////////
	var tbilanciocrediti= new MetaTable("bilanciocrediti");
	tbilanciocrediti.defineColumn("idfin", typeof(int),false);
	tbilanciocrediti.defineColumn("ayear", typeof(short),false);
	tbilanciocrediti.defineColumn("flag", typeof(byte),false);
	tbilanciocrediti.defineColumn("codefin", typeof(string),false);
	tbilanciocrediti.defineColumn("paridfin", typeof(int),false);
	tbilanciocrediti.defineColumn("nlevel", typeof(byte),false);
	tbilanciocrediti.defineColumn("printingorder", typeof(string),false);
	tbilanciocrediti.defineColumn("title", typeof(string),false);
	tbilanciocrediti.defineColumn("cu", typeof(string),false);
	tbilanciocrediti.defineColumn("ct", typeof(DateTime),false);
	tbilanciocrediti.defineColumn("lu", typeof(string),false);
	tbilanciocrediti.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tbilanciocrediti);
	tbilanciocrediti.defineKey("idfin");

	//////////////////// BILANCIOINCASSI /////////////////////////////////
	var tbilancioincassi= new MetaTable("bilancioincassi");
	tbilancioincassi.defineColumn("idfin", typeof(int),false);
	tbilancioincassi.defineColumn("ayear", typeof(short),false);
	tbilancioincassi.defineColumn("flag", typeof(byte),false);
	tbilancioincassi.defineColumn("codefin", typeof(string),false);
	tbilancioincassi.defineColumn("paridfin", typeof(int),false);
	tbilancioincassi.defineColumn("nlevel", typeof(byte),false);
	tbilancioincassi.defineColumn("printingorder", typeof(string),false);
	tbilancioincassi.defineColumn("title", typeof(string),false);
	tbilancioincassi.defineColumn("cu", typeof(string),false);
	tbilancioincassi.defineColumn("ct", typeof(DateTime),false);
	tbilancioincassi.defineColumn("lu", typeof(string),false);
	tbilancioincassi.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tbilancioincassi);
	tbilancioincassi.defineKey("idfin");

	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new MetaTable("tipomovimento");
	ttipomovimento.defineColumn("idtipo", typeof(int),false);
	ttipomovimento.defineColumn("descrizione", typeof(string));
	Tables.Add(ttipomovimento);
	ttipomovimento.defineKey("idtipo");

	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new MetaTable("expensephase");
	texpensephase.defineColumn("nphase", typeof(byte),false);
	texpensephase.defineColumn("description", typeof(string),false);
	texpensephase.defineColumn("cu", typeof(string),false);
	texpensephase.defineColumn("ct", typeof(DateTime),false);
	texpensephase.defineColumn("lu", typeof(string),false);
	texpensephase.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpensephase);
	texpensephase.defineKey("nphase");

	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new invoiceTable();
	tinvoice.addBaseColumns("idinvkind","yinv","ninv","idreg","registryreference","description","paymentexpiring","idexpirationkind","idcurrency","exchangerate","doc","docdate","adate","packinglistnum","packinglistdate","officiallyprinted","cu","ct","lu","lt","active","idaccmotivedebit","idaccmotivedebit_crg","idaccmotivedebit_datacrg","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tinvoice);
	tinvoice.defineKey("idinvkind", "yinv", "ninv");

	//////////////////// INCOMEINVOICE /////////////////////////////////
	var tincomeinvoice= new MetaTable("incomeinvoice");
	tincomeinvoice.defineColumn("idinvkind", typeof(int),false);
	tincomeinvoice.defineColumn("yinv", typeof(short),false);
	tincomeinvoice.defineColumn("ninv", typeof(int),false);
	tincomeinvoice.defineColumn("idinc", typeof(int),false);
	tincomeinvoice.defineColumn("movkind", typeof(short));
	tincomeinvoice.defineColumn("cu", typeof(string),false);
	tincomeinvoice.defineColumn("ct", typeof(DateTime),false);
	tincomeinvoice.defineColumn("lu", typeof(string),false);
	tincomeinvoice.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tincomeinvoice);
	tincomeinvoice.defineKey("idinvkind", "yinv", "ninv", "idinc");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("idinvkind","description","cu","ct","lu","lt","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","codeupb","title","paridupb","idunderwriter","idman","requested","granted","previousappropriation","expiration","txt","rtf","cu","ct","lu","lt","assured","printingorder","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new finviewTable();
	tfinview.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tfinview);
	tfinview.defineKey("idfin", "idupb");

	//////////////////// BILLVIEW /////////////////////////////////
	var tbillview= new MetaTable("billview");
	tbillview.defineColumn("ybill", typeof(short),false);
	tbillview.defineColumn("nbill", typeof(int),false);
	tbillview.defineColumn("billkind", typeof(string),false);
	tbillview.defineColumn("active", typeof(string));
	tbillview.defineColumn("adate", typeof(DateTime));
	tbillview.defineColumn("registry", typeof(string));
	tbillview.defineColumn("motive", typeof(string));
	tbillview.defineColumn("total", typeof(decimal));
	tbillview.defineColumn("covered", typeof(decimal));
	tbillview.defineColumn("toregularize", typeof(decimal));
	tbillview.defineColumn("idtreasurer", typeof(int));
	tbillview.defineColumn("treasurer", typeof(string));
	tbillview.defineColumn("regularizationnote", typeof(string));
	tbillview.defineColumn("cu", typeof(string),false);
	tbillview.defineColumn("ct", typeof(DateTime),false);
	tbillview.defineColumn("lu", typeof(string),false);
	tbillview.defineColumn("lt", typeof(DateTime),false);
	tbillview.defineColumn("idsor01", typeof(int));
	tbillview.defineColumn("idsor02", typeof(int));
	tbillview.defineColumn("idsor03", typeof(int));
	tbillview.defineColumn("idsor04", typeof(int));
	tbillview.defineColumn("idsor05", typeof(int));
	Tables.Add(tbillview);
	tbillview.defineKey("ybill", "billkind", "nbill");

	//////////////////// BILL /////////////////////////////////
	var tbill= new billTable();
	tbill.addBaseColumns("ybill","nbill","billkind","registry","covered","total","adate","active","motive","idtreasurer","regularizationnote","cu","ct","lu","lt");
	Tables.Add(tbill);
	tbill.defineKey("ybill", "nbill", "billkind");

	//////////////////// INCOMEESTIMATE /////////////////////////////////
	var tincomeestimate= new MetaTable("incomeestimate");
	tincomeestimate.defineColumn("idinc", typeof(int),false);
	tincomeestimate.defineColumn("idestimkind", typeof(string),false);
	tincomeestimate.defineColumn("nestim", typeof(int),false);
	tincomeestimate.defineColumn("yestim", typeof(short),false);
	tincomeestimate.defineColumn("ct", typeof(DateTime),false);
	tincomeestimate.defineColumn("cu", typeof(string),false);
	tincomeestimate.defineColumn("lt", typeof(DateTime),false);
	tincomeestimate.defineColumn("lu", typeof(string),false);
	tincomeestimate.defineColumn("movkind", typeof(short));
	Tables.Add(tincomeestimate);
	tincomeestimate.defineKey("idinc", "idestimkind", "nestim", "yestim");

	//////////////////// ESTIMATE /////////////////////////////////
	var testimate= new estimateTable();
	testimate.addBaseColumns("idestimkind","yestim","nestim","active","adate","ct","cu","deliveryaddress","deliveryexpiration","description","doc","docdate","exchangerate","idcurrency","idexpirationkind","idman","idreg","lt","lu","officiallyprinted","paymentexpiring","registryreference","idaccmotivecredit","idaccmotivecredit_crg","idaccmotivecredit_datacrg","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(testimate);
	testimate.defineKey("idestimkind", "yestim", "nestim");

	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new estimatekindTable();
	testimatekind.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","multireg","deltaamount","deltapercentage","idsor01","idsor02","idsor03","idsor04","idsor05","linktoinvoice");
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	//////////////////// ESTIMATEDETAIL_TAXABLE /////////////////////////////////
	var testimatedetail_taxable= new MetaTable("estimatedetail_taxable");
	testimatedetail_taxable.defineColumn("idestimkind", typeof(string),false);
	testimatedetail_taxable.defineColumn("yestim", typeof(short),false);
	testimatedetail_taxable.defineColumn("nestim", typeof(int),false);
	testimatedetail_taxable.defineColumn("rownum", typeof(int),false);
	testimatedetail_taxable.defineColumn("idgroup", typeof(int));
	testimatedetail_taxable.defineColumn("estimkind", typeof(string),false);
	testimatedetail_taxable.defineColumn("idreg", typeof(int));
	testimatedetail_taxable.defineColumn("registry", typeof(string));
	testimatedetail_taxable.defineColumn("detaildescription", typeof(string));
	testimatedetail_taxable.defineColumn("annotations", typeof(string));
	testimatedetail_taxable.defineColumn("number", typeof(decimal));
	testimatedetail_taxable.defineColumn("taxable", typeof(decimal));
	testimatedetail_taxable.defineColumn("taxrate", typeof(double));
	testimatedetail_taxable.defineColumn("tax", typeof(decimal));
	testimatedetail_taxable.defineColumn("discount", typeof(double));
	testimatedetail_taxable.defineColumn("start", typeof(DateTime));
	testimatedetail_taxable.defineColumn("stop", typeof(DateTime));
	testimatedetail_taxable.defineColumn("idinc_taxable", typeof(int));
	testimatedetail_taxable.defineColumn("idinc_iva", typeof(int));
	testimatedetail_taxable.defineColumn("taxable_euro", typeof(decimal),true,true);
	testimatedetail_taxable.defineColumn("iva_euro", typeof(decimal),true,true);
	testimatedetail_taxable.defineColumn("rowtotal", typeof(decimal),true,true);
	testimatedetail_taxable.defineColumn("idupb", typeof(string));
	testimatedetail_taxable.defineColumn("idupb_iva", typeof(string));
	testimatedetail_taxable.defineColumn("cu", typeof(string),false);
	testimatedetail_taxable.defineColumn("ct", typeof(DateTime),false);
	testimatedetail_taxable.defineColumn("lu", typeof(string),false);
	testimatedetail_taxable.defineColumn("lt", typeof(DateTime),false);
	testimatedetail_taxable.defineColumn("idaccmotive", typeof(string));
	testimatedetail_taxable.defineColumn("idivakind", typeof(int));
	testimatedetail_taxable.defineColumn("toinvoice", typeof(string));
	testimatedetail_taxable.defineColumn("exchangerate", typeof(double));
	testimatedetail_taxable.defineColumn("idsor_siope", typeof(int));
	Tables.Add(testimatedetail_taxable);
	testimatedetail_taxable.defineKey("idestimkind", "yestim", "nestim", "rownum");

	//////////////////// ESTIMATEDETAIL_IVA /////////////////////////////////
	var testimatedetail_iva= new MetaTable("estimatedetail_iva");
	testimatedetail_iva.defineColumn("idestimkind", typeof(string),false);
	testimatedetail_iva.defineColumn("yestim", typeof(short),false);
	testimatedetail_iva.defineColumn("nestim", typeof(int),false);
	testimatedetail_iva.defineColumn("rownum", typeof(int),false);
	testimatedetail_iva.defineColumn("idgroup", typeof(int));
	testimatedetail_iva.defineColumn("estimkind", typeof(string),false);
	testimatedetail_iva.defineColumn("idreg", typeof(int));
	testimatedetail_iva.defineColumn("registry", typeof(string));
	testimatedetail_iva.defineColumn("detaildescription", typeof(string));
	testimatedetail_iva.defineColumn("annotations", typeof(string));
	testimatedetail_iva.defineColumn("number", typeof(decimal));
	testimatedetail_iva.defineColumn("taxable", typeof(decimal));
	testimatedetail_iva.defineColumn("taxrate", typeof(double));
	testimatedetail_iva.defineColumn("tax", typeof(decimal));
	testimatedetail_iva.defineColumn("discount", typeof(double));
	testimatedetail_iva.defineColumn("start", typeof(DateTime));
	testimatedetail_iva.defineColumn("stop", typeof(DateTime));
	testimatedetail_iva.defineColumn("idinc_taxable", typeof(int));
	testimatedetail_iva.defineColumn("idinc_iva", typeof(int));
	testimatedetail_iva.defineColumn("taxable_euro", typeof(decimal),true,true);
	testimatedetail_iva.defineColumn("iva_euro", typeof(decimal),true,true);
	testimatedetail_iva.defineColumn("rowtotal", typeof(decimal),true,true);
	testimatedetail_iva.defineColumn("idupb", typeof(string));
	testimatedetail_iva.defineColumn("idupb_iva", typeof(string));
	testimatedetail_iva.defineColumn("cu", typeof(string),false);
	testimatedetail_iva.defineColumn("ct", typeof(DateTime),false);
	testimatedetail_iva.defineColumn("lu", typeof(string),false);
	testimatedetail_iva.defineColumn("lt", typeof(DateTime),false);
	testimatedetail_iva.defineColumn("idaccmotive", typeof(string));
	testimatedetail_iva.defineColumn("idivakind", typeof(int));
	testimatedetail_iva.defineColumn("toinvoice", typeof(string));
	testimatedetail_iva.defineColumn("exchangerate", typeof(double));
	testimatedetail_iva.defineColumn("idsor_siope", typeof(int));
	Tables.Add(testimatedetail_iva);
	testimatedetail_iva.defineKey("idestimkind", "yestim", "nestim", "rownum");

	//////////////////// INVOICEDETAIL_TAXABLE /////////////////////////////////
	var tinvoicedetail_taxable= new MetaTable("invoicedetail_taxable");
	tinvoicedetail_taxable.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("invoicekind", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("yinv", typeof(short),false);
	tinvoicedetail_taxable.defineColumn("ninv", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("flag", typeof(byte),false);
	tinvoicedetail_taxable.defineColumn("flagbuysell", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("flagvariation", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("rownum", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("detaildescription", typeof(string));
	tinvoicedetail_taxable.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail_taxable.defineColumn("ivakind", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("rate", typeof(decimal),false);
	tinvoicedetail_taxable.defineColumn("unabatabilitypercentage", typeof(decimal),false);
	tinvoicedetail_taxable.defineColumn("number", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("taxable", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("discount", typeof(double));
	tinvoicedetail_taxable.defineColumn("tax", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("exchangerate", typeof(double));
	tinvoicedetail_taxable.defineColumn("annotations", typeof(string));
	tinvoicedetail_taxable.defineColumn("idmankind", typeof(string));
	tinvoicedetail_taxable.defineColumn("mankind", typeof(string));
	tinvoicedetail_taxable.defineColumn("yman", typeof(short));
	tinvoicedetail_taxable.defineColumn("nman", typeof(int));
	tinvoicedetail_taxable.defineColumn("manrownum", typeof(int));
	tinvoicedetail_taxable.defineColumn("mandetaildescription", typeof(string));
	tinvoicedetail_taxable.defineColumn("idupb", typeof(string));
	tinvoicedetail_taxable.defineColumn("codeupb", typeof(string));
	tinvoicedetail_taxable.defineColumn("upb", typeof(string));
	tinvoicedetail_taxable.defineColumn("adate", typeof(DateTime),false);
	tinvoicedetail_taxable.defineColumn("idexp_iva", typeof(int));
	tinvoicedetail_taxable.defineColumn("idexp_taxable", typeof(int));
	tinvoicedetail_taxable.defineColumn("idexp_ivamand", typeof(int));
	tinvoicedetail_taxable.defineColumn("idexp_taxablemand", typeof(int));
	tinvoicedetail_taxable.defineColumn("idinc_iva", typeof(int));
	tinvoicedetail_taxable.defineColumn("idinc_taxable", typeof(int));
	tinvoicedetail_taxable.defineColumn("idinc_ivaestim", typeof(int));
	tinvoicedetail_taxable.defineColumn("idinc_taxableestim", typeof(int));
	tinvoicedetail_taxable.defineColumn("taxable_euro", typeof(decimal),true,true);
	tinvoicedetail_taxable.defineColumn("iva_euro", typeof(decimal),true,true);
	tinvoicedetail_taxable.defineColumn("rowtotal", typeof(decimal),true,true);
	tinvoicedetail_taxable.defineColumn("cu", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail_taxable.defineColumn("lu", typeof(string),false);
	tinvoicedetail_taxable.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail_taxable.defineColumn("idestimkind", typeof(string));
	tinvoicedetail_taxable.defineColumn("estimkind", typeof(string));
	tinvoicedetail_taxable.defineColumn("estimatedetaildescription", typeof(string));
	tinvoicedetail_taxable.defineColumn("yestim", typeof(short));
	tinvoicedetail_taxable.defineColumn("nestim", typeof(int));
	tinvoicedetail_taxable.defineColumn("estimrownum", typeof(int));
	tinvoicedetail_taxable.defineColumn("npackage", typeof(decimal));
	tinvoicedetail_taxable.defineColumn("idupb_iva", typeof(string));
	tinvoicedetail_taxable.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail_taxable.defineColumn("idsor_siope", typeof(int));
	tinvoicedetail_taxable.defineColumn("idpccdebitstatus", typeof(string));
	tinvoicedetail_taxable.defineColumn("intra12operationkind", typeof(string));
	tinvoicedetail_taxable.defineColumn("intrastatoperationkind", typeof(string));
	tinvoicedetail_taxable.defineColumn("move12", typeof(string));
	tinvoicedetail_taxable.defineColumn("exception12", typeof(string));
	Tables.Add(tinvoicedetail_taxable);
	tinvoicedetail_taxable.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// INVOICEDETAIL_IVA /////////////////////////////////
	var tinvoicedetail_iva= new MetaTable("invoicedetail_iva");
	tinvoicedetail_iva.defineColumn("idinvkind", typeof(int),false);
	tinvoicedetail_iva.defineColumn("invoicekind", typeof(string),false);
	tinvoicedetail_iva.defineColumn("yinv", typeof(short),false);
	tinvoicedetail_iva.defineColumn("ninv", typeof(int),false);
	tinvoicedetail_iva.defineColumn("flag", typeof(byte),false);
	tinvoicedetail_iva.defineColumn("flagbuysell", typeof(string),false);
	tinvoicedetail_iva.defineColumn("flagvariation", typeof(string),false);
	tinvoicedetail_iva.defineColumn("rownum", typeof(int),false);
	tinvoicedetail_iva.defineColumn("detaildescription", typeof(string));
	tinvoicedetail_iva.defineColumn("idivakind", typeof(int),false);
	tinvoicedetail_iva.defineColumn("ivakind", typeof(string),false);
	tinvoicedetail_iva.defineColumn("rate", typeof(decimal),false);
	tinvoicedetail_iva.defineColumn("unabatabilitypercentage", typeof(decimal),false);
	tinvoicedetail_iva.defineColumn("number", typeof(decimal));
	tinvoicedetail_iva.defineColumn("taxable", typeof(decimal));
	tinvoicedetail_iva.defineColumn("discount", typeof(double));
	tinvoicedetail_iva.defineColumn("tax", typeof(decimal));
	tinvoicedetail_iva.defineColumn("unabatable", typeof(decimal));
	tinvoicedetail_iva.defineColumn("exchangerate", typeof(double));
	tinvoicedetail_iva.defineColumn("annotations", typeof(string));
	tinvoicedetail_iva.defineColumn("idmankind", typeof(string));
	tinvoicedetail_iva.defineColumn("mankind", typeof(string));
	tinvoicedetail_iva.defineColumn("yman", typeof(short));
	tinvoicedetail_iva.defineColumn("nman", typeof(int));
	tinvoicedetail_iva.defineColumn("manrownum", typeof(int));
	tinvoicedetail_iva.defineColumn("mandetaildescription", typeof(string));
	tinvoicedetail_iva.defineColumn("idupb", typeof(string));
	tinvoicedetail_iva.defineColumn("codeupb", typeof(string));
	tinvoicedetail_iva.defineColumn("upb", typeof(string));
	tinvoicedetail_iva.defineColumn("adate", typeof(DateTime),false);
	tinvoicedetail_iva.defineColumn("idexp_iva", typeof(int));
	tinvoicedetail_iva.defineColumn("idexp_taxable", typeof(int));
	tinvoicedetail_iva.defineColumn("idexp_ivamand", typeof(int));
	tinvoicedetail_iva.defineColumn("idexp_taxablemand", typeof(int));
	tinvoicedetail_iva.defineColumn("idinc_iva", typeof(int));
	tinvoicedetail_iva.defineColumn("idinc_taxable", typeof(int));
	tinvoicedetail_iva.defineColumn("idinc_ivaestim", typeof(int));
	tinvoicedetail_iva.defineColumn("idinc_taxableestim", typeof(int));
	tinvoicedetail_iva.defineColumn("taxable_euro", typeof(decimal),true,true);
	tinvoicedetail_iva.defineColumn("iva_euro", typeof(decimal),true,true);
	tinvoicedetail_iva.defineColumn("rowtotal", typeof(decimal),true,true);
	tinvoicedetail_iva.defineColumn("cu", typeof(string),false);
	tinvoicedetail_iva.defineColumn("ct", typeof(DateTime),false);
	tinvoicedetail_iva.defineColumn("lu", typeof(string),false);
	tinvoicedetail_iva.defineColumn("lt", typeof(DateTime),false);
	tinvoicedetail_iva.defineColumn("idestimkind", typeof(string));
	tinvoicedetail_iva.defineColumn("estimkind", typeof(string));
	tinvoicedetail_iva.defineColumn("estimatedetaildescription", typeof(string));
	tinvoicedetail_iva.defineColumn("yestim", typeof(short));
	tinvoicedetail_iva.defineColumn("nestim", typeof(int));
	tinvoicedetail_iva.defineColumn("estimrownum", typeof(int));
	tinvoicedetail_iva.defineColumn("npackage", typeof(decimal));
	tinvoicedetail_iva.defineColumn("idupb_iva", typeof(string));
	tinvoicedetail_iva.defineColumn("idaccmotive", typeof(string));
	tinvoicedetail_iva.defineColumn("idsor_siope", typeof(int));
	tinvoicedetail_iva.defineColumn("idpccdebitstatus", typeof(string));
	tinvoicedetail_iva.defineColumn("intra12operationkind", typeof(string));
	tinvoicedetail_iva.defineColumn("intrastatoperationkind", typeof(string));
	tinvoicedetail_iva.defineColumn("move12", typeof(string));
	tinvoicedetail_iva.defineColumn("exception12", typeof(string));
	Tables.Add(tinvoicedetail_iva);
	tinvoicedetail_iva.defineKey("idinvkind", "yinv", "ninv", "rownum");

	//////////////////// INCOMELAST /////////////////////////////////
	var tincomelast= new incomelastTable();
	tincomelast.addBaseColumns("idinc","ct","cu","flag","idpro","lt","lu","nbill","kpro","idacccredit");
	Tables.Add(tincomelast);
	tincomelast.defineKey("idinc");

	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","cashvaliditykind","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idivapayperiodicity","idregauto","idsortingkind1","idsortingkind2","idsortingkind3","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// PROCEEDS /////////////////////////////////
	var tproceeds= new proceedsTable();
	tproceeds.addBaseColumns("npro","npro_treasurer","ypro","adate","annulmentdate","ct","cu","idreg","lt","lu","printdate","rtf","txt","idfin","idman","idtreasurer","flag","kpro","kproceedstransmission","idstamphandling","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tproceeds);
	tproceeds.defineKey("kpro");

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new accountTable();
	taccount.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// UPBCREDITI /////////////////////////////////
	var tupbcrediti= new MetaTable("upbcrediti");
	tupbcrediti.defineColumn("idupb", typeof(string),false);
	tupbcrediti.defineColumn("active", typeof(string));
	tupbcrediti.defineColumn("assured", typeof(string));
	tupbcrediti.defineColumn("codeupb", typeof(string),false);
	tupbcrediti.defineColumn("ct", typeof(DateTime),false);
	tupbcrediti.defineColumn("cu", typeof(string),false);
	tupbcrediti.defineColumn("expiration", typeof(DateTime));
	tupbcrediti.defineColumn("granted", typeof(decimal));
	tupbcrediti.defineColumn("lt", typeof(DateTime),false);
	tupbcrediti.defineColumn("lu", typeof(string),false);
	tupbcrediti.defineColumn("paridupb", typeof(string));
	tupbcrediti.defineColumn("previousappropriation", typeof(decimal));
	tupbcrediti.defineColumn("previousassessment", typeof(decimal));
	tupbcrediti.defineColumn("printingorder", typeof(string),false);
	tupbcrediti.defineColumn("requested", typeof(decimal));
	tupbcrediti.defineColumn("rtf", typeof(Byte[]));
	tupbcrediti.defineColumn("title", typeof(string),false);
	tupbcrediti.defineColumn("txt", typeof(string));
	tupbcrediti.defineColumn("idman", typeof(int));
	tupbcrediti.defineColumn("idunderwriter", typeof(int));
	tupbcrediti.defineColumn("cupcode", typeof(string));
	tupbcrediti.defineColumn("idsor01", typeof(int));
	tupbcrediti.defineColumn("idsor02", typeof(int));
	tupbcrediti.defineColumn("idsor03", typeof(int));
	tupbcrediti.defineColumn("idsor04", typeof(int));
	tupbcrediti.defineColumn("idsor05", typeof(int));
	Tables.Add(tupbcrediti);
	tupbcrediti.defineKey("idupb");

	//////////////////// UPBINCASSI /////////////////////////////////
	var tupbincassi= new MetaTable("upbincassi");
	tupbincassi.defineColumn("idupb", typeof(string),false);
	tupbincassi.defineColumn("active", typeof(string));
	tupbincassi.defineColumn("assured", typeof(string));
	tupbincassi.defineColumn("codeupb", typeof(string),false);
	tupbincassi.defineColumn("ct", typeof(DateTime),false);
	tupbincassi.defineColumn("cu", typeof(string),false);
	tupbincassi.defineColumn("expiration", typeof(DateTime));
	tupbincassi.defineColumn("granted", typeof(decimal));
	tupbincassi.defineColumn("lt", typeof(DateTime),false);
	tupbincassi.defineColumn("lu", typeof(string),false);
	tupbincassi.defineColumn("paridupb", typeof(string));
	tupbincassi.defineColumn("previousappropriation", typeof(decimal));
	tupbincassi.defineColumn("previousassessment", typeof(decimal));
	tupbincassi.defineColumn("printingorder", typeof(string),false);
	tupbincassi.defineColumn("requested", typeof(decimal));
	tupbincassi.defineColumn("rtf", typeof(Byte[]));
	tupbincassi.defineColumn("title", typeof(string),false);
	tupbincassi.defineColumn("txt", typeof(string));
	tupbincassi.defineColumn("idman", typeof(int));
	tupbincassi.defineColumn("idunderwriter", typeof(int));
	tupbincassi.defineColumn("cupcode", typeof(string));
	tupbincassi.defineColumn("idsor01", typeof(int));
	tupbincassi.defineColumn("idsor02", typeof(int));
	tupbincassi.defineColumn("idsor03", typeof(int));
	tupbincassi.defineColumn("idsor04", typeof(int));
	tupbincassi.defineColumn("idsor05", typeof(int));
	Tables.Add(tupbincassi);
	tupbincassi.defineKey("idupb");

	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new underwritingTable();
	tunderwriting.addBaseColumns("idunderwriting","idunderwriter","idsor01","idsor02","idsor03","idsor04","idsor05","cu","ct","lu","lt","title","active","doc","docdate");
	Tables.Add(tunderwriting);
	tunderwriting.defineKey("idunderwriting");

	//////////////////// INCOMEBILL /////////////////////////////////
	var tincomebill= new MetaTable("incomebill");
	tincomebill.defineColumn("idinc", typeof(int),false);
	tincomebill.defineColumn("ybill", typeof(short),false);
	tincomebill.defineColumn("nbill", typeof(int),false);
	tincomebill.defineColumn("amount", typeof(decimal),false);
	tincomebill.defineColumn("lu", typeof(string),false);
	tincomebill.defineColumn("lt", typeof(DateTime),false);
	tincomebill.defineColumn("cu", typeof(string),false);
	tincomebill.defineColumn("ct", typeof(DateTime),false);
	tincomebill.defineColumn("!anagrafica", typeof(string));
	tincomebill.defineColumn("!data", typeof(string));
	tincomebill.defineColumn("!causale", typeof(string));
	Tables.Add(tincomebill);
	tincomebill.defineKey("idinc", "ybill", "nbill");

	//////////////////// BILL1 /////////////////////////////////
	var tbill1= new MetaTable("bill1");
	tbill1.defineColumn("ybill", typeof(short),false);
	tbill1.defineColumn("nbill", typeof(int),false);
	tbill1.defineColumn("billkind", typeof(string),false);
	tbill1.defineColumn("registry", typeof(string));
	tbill1.defineColumn("covered", typeof(decimal));
	tbill1.defineColumn("total", typeof(decimal));
	tbill1.defineColumn("adate", typeof(DateTime));
	tbill1.defineColumn("active", typeof(string));
	tbill1.defineColumn("motive", typeof(string));
	tbill1.defineColumn("ct", typeof(DateTime),false);
	tbill1.defineColumn("cu", typeof(string),false);
	tbill1.defineColumn("lt", typeof(DateTime),false);
	tbill1.defineColumn("lu", typeof(string),false);
	tbill1.defineColumn("idtreasurer", typeof(int));
	tbill1.defineColumn("regularizationnote", typeof(string));
	tbill1.defineColumn("reduction", typeof(decimal));
	tbill1.defineColumn("banknum", typeof(int));
	tbill1.defineColumn("idbank", typeof(string));
	Tables.Add(tbill1);
	tbill1.defineKey("ybill", "nbill", "billkind");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_bill1_incomebill","bill1","incomebill","ybill","nbill");
	this.defineRelation("income_incomebill","income","incomebill","idinc");
	this.defineRelation("proceeds_incomelast","proceeds","incomelast","kpro");
	this.defineRelation("bill_incomelast","bill","incomelast","nbill");
	this.defineRelation("income_incomelast","income","incomelast","idinc");
	var cPar = new []{account.Columns["idacc"]};
	var cChild = new []{incomelast.Columns["idacccredit"]};
	Relations.Add(new DataRelation("FK_account_incomelast",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{invoicedetail_iva.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomeinvoicedetail_iva",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{invoicedetail_taxable.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomeinvoicedetail_taxable1",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{invoicedetail_taxable.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("incomeinvoicedetail_taxable",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{estimatedetail_iva.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomeestimatedetail_iva",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{estimatedetail_taxable.Columns["idinc_iva"]};
	Relations.Add(new DataRelation("incomeestimatedetail_taxable1",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{estimatedetail_taxable.Columns["idinc_taxable"]};
	Relations.Add(new DataRelation("incomeestimatedetail_taxable",cPar,cChild,false));

	this.defineRelation("estimatekindestimate","estimatekind","estimate","idestimkind");
	this.defineRelation("incomeincomeestimate","income","incomeestimate","idinc");
	this.defineRelation("estimateincomeestimate","estimate","incomeestimate","idestimkind","yestim","nestim");
	this.defineRelation("invoiceincomeinvoice","invoice","incomeinvoice","idinvkind","yinv","ninv");
	this.defineRelation("incomeincomeinvoice","income","incomeinvoice","idinc");
	this.defineRelation("invoicekindinvoice","invoicekind","invoice","idinvkind");
	this.defineRelation("incomeproceedspart","income","proceedspart","idinc");
	this.defineRelation("bilancioincassiproceedspart","bilancioincassi","proceedspart","idfin");
	this.defineRelation("upbincassi_proceedspart","upbincassi","proceedspart","idupb");
	this.defineRelation("upbcrediti_creditpart","upbcrediti","creditpart","idupb");
	this.defineRelation("incomecreditpart","income","creditpart","idinc");
	this.defineRelation("bilanciocrediticreditpart","bilanciocrediti","creditpart","idfin");
	cPar = new []{income.Columns["nphase"]};
	cChild = new []{sortingkind.Columns["nphaseincome"]};
	Relations.Add(new DataRelation("incomesortingkind",cPar,cChild,false));

	this.defineRelation("incomeincomesorted","income","incomesorted","idinc");
	this.defineRelation("sortingincomesorted","sorting","incomesorted","idsor");
	this.defineRelation("incomeincomevar","income","incomevar","idinc");
	this.defineRelation("finviewincomeyear","finview","incomeyear","idfin","idupb");
	this.defineRelation("upbincomeyear","upb","incomeyear","idupb");
	this.defineRelation("incomeincomeyear","income","incomeyear","idinc");
	this.defineRelation("incomeincometotal","income","incometotal","idinc");
	this.defineRelation("FK_underwriting_income","underwriting","income","idunderwriting");
	this.defineRelation("incomephaseincome","incomephase","income","nphase");
	this.defineRelation("managerincome","manager","income","idman");
	this.defineRelation("registryincome","registry","income","idreg");
	#endregion

}
}
}
