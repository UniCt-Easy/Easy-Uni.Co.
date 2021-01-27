
/*
Easy
Copyright (C) 2021 Universit� degli Studi di Catania (www.unict.it)
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
using meta_assetloadkind;
using meta_assetunloadkind;
using meta_account;
using meta_sortingkind;
using meta_registry;
using meta_finview;
using meta_accmotiveapplied;
using meta_sorting;
using meta_ivakind;
using meta_accmotive;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace config_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public configTable config 		=> (configTable)Tables["config"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetloadkindTable assetloadkind 		=> (assetloadkindTable)Tables["assetloadkind"];

	///<summary>
	///Tipi di buoni di scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public assetunloadkindTable assetunloadkind 		=> (assetunloadkindTable)Tables["assetunloadkind"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_pat 		=> (accountTable)Tables["account_pat"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_economic_result 		=> (accountTable)Tables["account_economic_result"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_previous_economic_result 		=> (accountTable)Tables["account_previous_economic_result"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_ivapayment 		=> (accountTable)Tables["account_ivapayment"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_supplier 		=> (accountTable)Tables["account_supplier"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_ivarefund 		=> (accountTable)Tables["account_ivarefund"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_customer 		=> (accountTable)Tables["account_customer"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_accruedcost 		=> (accountTable)Tables["account_accruedcost"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_accruedrevenue 		=> (accountTable)Tables["account_accruedrevenue"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_deferredcost 		=> (accountTable)Tables["account_deferredcost"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_deferredrevenue 		=> (accountTable)Tables["account_deferredrevenue"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_pl 		=> (accountTable)Tables["account_pl"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	///<summary>
	///Livelli del bilancio annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finlevel 		=> (MetaTable)Tables["finlevel"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind1 		=> (sortingkindTable)Tables["sortingkind1"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind2 		=> (sortingkindTable)Tables["sortingkind2"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind3 		=> (sortingkindTable)Tables["sortingkind3"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry_csa 		=> (registryTable)Tables["registry_csa"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomephase 		=> (MetaTable)Tables["incomephase"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase1 		=> (MetaTable)Tables["expensephase1"];

	///<summary>
	///Livelli del bilancio annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finlevel1 		=> (MetaTable)Tables["finlevel1"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomephase1 		=> (MetaTable)Tables["incomephase1"];

	///<summary>
	///Peridiocità della liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ivapayperiodicity 		=> (MetaTable)Tables["ivapayperiodicity"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable bilancioversamento 		=> (finviewTable)Tables["bilancioversamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable bilanciorimborso 		=> (finviewTable)Tables["bilanciorimborso"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable creddebrimborso 		=> (registryTable)Tables["creddebrimborso"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable creddebversamento 		=> (registryTable)Tables["creddebversamento"];

	///<summary>
	///Tipi di recupero
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable clawback 		=> (MetaTable)Tables["clawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable bilanciospesa 		=> (finviewTable)Tables["bilanciospesa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_admincar 		=> (accmotiveappliedTable)Tables["accmotiveapplied_admincar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_owncar 		=> (accmotiveappliedTable)Tables["accmotiveapplied_owncar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_foot 		=> (accmotiveappliedTable)Tables["accmotiveapplied_foot"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appkind 		=> (MetaTable)Tables["appkind"];

	///<summary>
	///Modalità di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable paymethodabi 		=> (MetaTable)Tables["paymethodabi"];

	///<summary>
	///Modalità di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable paymethodnoabi 		=> (MetaTable)Tables["paymethodnoabi"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_unabatable_versamento 		=> (accountTable)Tables["account_unabatable_versamento"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_unabatable_rimborso 		=> (accountTable)Tables["account_unabatable_rimborso"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable maincreddebrimborso 		=> (registryTable)Tables["maincreddebrimborso"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable maincreddebversamento 		=> (registryTable)Tables["maincreddebversamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable mainbilanciorimborso 		=> (finviewTable)Tables["mainbilanciorimborso"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable mainbilancioversamento 		=> (finviewTable)Tables["mainbilancioversamento"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainunabatable_versamento 		=> (accountTable)Tables["account_mainunabatable_versamento"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainunabatable_rimborso 		=> (accountTable)Tables["account_mainunabatable_rimborso"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivapayment 		=> (accountTable)Tables["account_mainivapayment"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivapayment_internal 		=> (accountTable)Tables["account_mainivapayment_internal"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivarefund 		=> (accountTable)Tables["account_mainivarefund"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivarefund_internal 		=> (accountTable)Tables["account_mainivarefund_internal"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_ivarefund12 		=> (accountTable)Tables["account_ivarefund12"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_ivapayment12 		=> (accountTable)Tables["account_ivapayment12"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivarefund12 		=> (accountTable)Tables["account_mainivarefund12"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivarefund_internal12 		=> (accountTable)Tables["account_mainivarefund_internal12"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivapayment12 		=> (accountTable)Tables["account_mainivapayment12"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_mainivapayment_internal12 		=> (accountTable)Tables["account_mainivapayment_internal12"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable bilancioversamento12 		=> (finviewTable)Tables["bilancioversamento12"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable bilanciorimborso12 		=> (finviewTable)Tables["bilanciorimborso12"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable creddebversamento12 		=> (registryTable)Tables["creddebversamento12"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable creddebrimborso12 		=> (registryTable)Tables["creddebrimborso12"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable mainbilanciorimborso12 		=> (finviewTable)Tables["mainbilanciorimborso12"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable mainbilancioversamento12 		=> (finviewTable)Tables["mainbilancioversamento12"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable maincreddebversamento12 		=> (registryTable)Tables["maincreddebversamento12"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable maincreddebrimborso12 		=> (registryTable)Tables["maincreddebrimborso12"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable fin_income_gross_csa 		=> (finviewTable)Tables["fin_income_gross_csa"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_revenue_gross_csa 		=> (accountTable)Tables["account_revenue_gross_csa"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting3 		=> (sortingTable)Tables["sorting3"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting1 		=> (sortingTable)Tables["sorting1"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting2 		=> (sortingTable)Tables["sorting2"];

	///<summary>
	///Ufficio inps
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inpscenter 		=> (MetaTable)Tables["inpscenter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable fin_store 		=> (finviewTable)Tables["fin_store"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sortingincomecsa 		=> (sortingTable)Tables["sortingincomecsa"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_invoicetoreceive 		=> (accountTable)Tables["account_invoicetoreceive"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_invoicetoemit 		=> (accountTable)Tables["account_invoicetoemit"];

	///<summary>
	///trattasi di valori codificati dalla PCC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pccdebitstatus 		=> (MetaTable)Tables["pccdebitstatus"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_unabatable_split 		=> (accountTable)Tables["account_unabatable_split"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_split_ivapayment 		=> (accountTable)Tables["account_split_ivapayment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finviewTable mainbilancioversamentosplit 		=> (finviewTable)Tables["mainbilancioversamentosplit"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable maincreddebversamentosplit 		=> (registryTable)Tables["maincreddebversamentosplit"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_bankpaydoc 		=> (accountTable)Tables["account_bankpaydoc"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accountTable account_bankprodoc 		=> (accountTable)Tables["account_bankprodoc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_forwarder 		=> (accmotiveappliedTable)Tables["accmotiveapplied_forwarder"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive_grantdeferredcost 		=> (accmotiveTable)Tables["accmotive_grantdeferredcost"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive_grantrevenue 		=> (accmotiveTable)Tables["accmotive_grantrevenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_assetrevenue 		=> (accmotiveappliedTable)Tables["accmotiveapplied_assetrevenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_prorata_cost 		=> (accmotiveappliedTable)Tables["accmotiveapplied_prorata_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_prorata_revenue 		=> (accmotiveappliedTable)Tables["accmotiveapplied_prorata_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting_siopeivaexp 		=> (MetaTable)Tables["sorting_siopeivaexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting_siopeiva12exp 		=> (MetaTable)Tables["sorting_siopeiva12exp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting_siopeivasplitexp 		=> (MetaTable)Tables["sorting_siopeivasplitexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting_siopeiva12inc 		=> (MetaTable)Tables["sorting_siopeiva12inc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting_siopeivainc 		=> (MetaTable)Tables["sorting_siopeivainc"];

	///<summary>
	///Trattamento delle spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable chargehandling 		=> (MetaTable)Tables["chargehandling"];

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
	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new configTable();
	tconfig.addBaseColumns("ayear","agencycode","appname","appropriationphasecode","assessmentphasecode","asset_flagnumbering","asset_flagrestart","assetload_flag","boxpartitiontitle","casualcontract_flagrestart","ct","cu","currpartitiontitle","deferredexpensephase","deferredincomephase","electronicimport","electronictrasmission","expense_expiringdays","expensephase","flagautopayment","flagautoproceeds","flagcredit","flagepexp","flagfruitful","flagpayment","flagproceeds","flagrefund","foreignhours","idacc_accruedcost","idacc_accruedrevenue","idacc_customer","idacc_deferredcost","idacc_deferredcredit","idacc_deferreddebit","idacc_deferredrevenue","idacc_ivapayment","idacc_ivarefund","idacc_patrimony","idacc_pl","idacc_supplier","idacc_economic_result","idacc_previous_economic_result","idaccmotive_admincar","idaccmotive_foot","idaccmotive_owncar","idclawback","idfinexpense","idfinexpensesurplus","idfinincomesurplus","idfinivapayment","idfinivarefund","idregauto","idreg_csa","importappname","income_expiringdays","incomephase","linktoinvoice","lt","lu","minpayment","minrefund","motivelen","motiveprefix","motiveseparator","payment_finlevel","payment_flag","payment_flagautoprintdate","paymentagency","prevpartitiontitle","proceeds_finlevel","proceeds_flag","proceeds_flagautoprintdate","profservice_flagrestart","refundagency","wageaddition_flagrestart","idivapayperiodicity","idsortingkind1","idsortingkind2","idsortingkind3","fin_kind","taxvaliditykind","flag_paymentamount","automanagekind","flag_autodocnumbering","flagbank_grouping","cashvaliditykind","wageimportappname","balancekind","idpaymethodabi","idpaymethodnoabi","finvarofficial_default","iban_f24","cudactivitycode","flagivapaybyrow","startivabalance","idacc_unabatable","idacc_unabatable_refund","invoice_flagregister","default_idfinvarstatus","flagivaregphase","mainrefundagency","mainpaymentagency","mainminrefund","mainminpayment","mainidfinivarefund","mainidfinivapayment","mainflagrefund","mainflagpayment","mainflagivaregphase","mainstartivabalance","mainidacc_unabatable","mainidacc_unabatable_refund","idacc_mainivapayment","idacc_mainivapayment_internal","idacc_mainivarefund","idacc_mainivarefund_internal","flagva3","flagrefund12","flagpayment12","refundagency12","paymentagency12","idfinivarefund12","idfinivapayment12","minrefund12","minpayment12","idacc_ivapayment12","idacc_ivarefund12","idacc_mainivarefund12","idacc_mainivapayment12","idacc_mainivapayment_internal12","idacc_mainivarefund_internal12","startivabalance12","mainrefundagency12","mainpaymentagency12","mainflagrefund12","mainflagpayment12","mainidfinivarefund12","mainidfinivapayment12","mainminrefund12","mainminpayment12","mainstartivabalance12","idfinincome_gross_csa","idacc_revenue_gross_csa","flagdirectcsaclawback","finvar_warnmail","idsor1_stock","idsor2_stock","idsor3_stock","idinpscenter","flagpcashautopayment","flagpcashautoproceeds","idfin_store","email","booking_on_invoice","itineration_directauth","email_f24","csa_flaggroupby_income","csa_flaggroupby_expense","csa_flaglinktoexp","csa_nominativo","idsiopeincome_csa","idacc_invoicetoreceive","idacc_invoicetoemit","epannualthreeshold","flagbalance_csa","flagiva_immediate_or_deferred","flagenabletransmission","idpccdebitstatus","flagsplitpayment","idacc_ivapaymentsplit","idacc_unabatable_split","flagpaymentsplit","paymentagencysplit","idfinivapaymentsplit","startivabalancesplit","agencynumber","femode","idacc_bankpaydoc","idacc_bankprodoc","csa_flagtransmissionlinking","csa_idchargehandling","csa_flag","idaccmotive_forwarder","idivakind_forwarder","idaccmotive_grantrevenue","idaccmotive_grantdeferredcost","idaccmotive_assetrevenue","idaccmotive_prorata_cost","idaccmotive_prorata_revenue","idsor_siopeivaexp","idsor_siopeiva12exp","idsor_siopeivasplitexp","idsor_siopeiva12inc","idsor_siopeivainc","flag","assignedrequirement");
	Tables.Add(tconfig);
	tconfig.defineKey("ayear");

	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new assetloadkindTable();
	tassetloadkind.addBaseColumns("idassetloadkind","description","idinventory","startnumber","cu","ct","lu","lt");
	Tables.Add(tassetloadkind);
	tassetloadkind.defineKey("idassetloadkind");

	//////////////////// ASSETUNLOADKIND /////////////////////////////////
	var tassetunloadkind= new assetunloadkindTable();
	tassetunloadkind.addBaseColumns("idassetunloadkind","description","idinventory","startnumber","cu","ct","lu","lt");
	Tables.Add(tassetunloadkind);
	tassetunloadkind.defineKey("idassetunloadkind");

	//////////////////// ACCOUNT_PAT /////////////////////////////////
	var taccount_pat= new accountTable();
	taccount_pat.TableName = "account_pat";
	taccount_pat.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_pat.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_pat);
	taccount_pat.defineKey("idacc");

	//////////////////// ACCOUNT_ECONOMIC_RESULT /////////////////////////////////
	var taccount_economic_result= new accountTable();
	taccount_economic_result.TableName = "account_economic_result";
	taccount_economic_result.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb","idplaccount","idpatrimony","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag","idacc_special","flagenablebudgetprev","flagaccountusage");
	taccount_economic_result.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_economic_result);
	taccount_economic_result.defineKey("idacc");

	//////////////////// ACCOUNT_PREVIOUS_ECONOMIC_RESULT /////////////////////////////////
	var taccount_previous_economic_result= new accountTable();
	taccount_previous_economic_result.TableName = "account_previous_economic_result";
	taccount_previous_economic_result.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb","idplaccount","idpatrimony","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag","idacc_special","flagenablebudgetprev","flagaccountusage");
	taccount_previous_economic_result.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_previous_economic_result);
	taccount_previous_economic_result.defineKey("idacc");

	//////////////////// ACCOUNT_IVAPAYMENT /////////////////////////////////
	var taccount_ivapayment= new accountTable();
	taccount_ivapayment.TableName = "account_ivapayment";
	taccount_ivapayment.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_ivapayment.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_ivapayment);
	taccount_ivapayment.defineKey("idacc");

	//////////////////// ACCOUNT_SUPPLIER /////////////////////////////////
	var taccount_supplier= new accountTable();
	taccount_supplier.TableName = "account_supplier";
	taccount_supplier.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_supplier.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_supplier);
	taccount_supplier.defineKey("idacc");

	//////////////////// ACCOUNT_IVAREFUND /////////////////////////////////
	var taccount_ivarefund= new accountTable();
	taccount_ivarefund.TableName = "account_ivarefund";
	taccount_ivarefund.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_ivarefund.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_ivarefund);
	taccount_ivarefund.defineKey("idacc");

	//////////////////// ACCOUNT_CUSTOMER /////////////////////////////////
	var taccount_customer= new accountTable();
	taccount_customer.TableName = "account_customer";
	taccount_customer.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_customer.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_customer);
	taccount_customer.defineKey("idacc");

	//////////////////// ACCOUNT_ACCRUEDCOST /////////////////////////////////
	var taccount_accruedcost= new accountTable();
	taccount_accruedcost.TableName = "account_accruedcost";
	taccount_accruedcost.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_accruedcost.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_accruedcost);
	taccount_accruedcost.defineKey("idacc");

	//////////////////// ACCOUNT_ACCRUEDREVENUE /////////////////////////////////
	var taccount_accruedrevenue= new accountTable();
	taccount_accruedrevenue.TableName = "account_accruedrevenue";
	taccount_accruedrevenue.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_accruedrevenue.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_accruedrevenue);
	taccount_accruedrevenue.defineKey("idacc");

	//////////////////// ACCOUNT_DEFERREDCOST /////////////////////////////////
	var taccount_deferredcost= new accountTable();
	taccount_deferredcost.TableName = "account_deferredcost";
	taccount_deferredcost.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_deferredcost.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_deferredcost);
	taccount_deferredcost.defineKey("idacc");

	//////////////////// ACCOUNT_DEFERREDREVENUE /////////////////////////////////
	var taccount_deferredrevenue= new accountTable();
	taccount_deferredrevenue.TableName = "account_deferredrevenue";
	taccount_deferredrevenue.addBaseColumns("idacc","ayear","codeacc","paridacc","printingorder","title","flagtransitory","txt","rtf","cu","ct","lu","lt","nlevel","idaccountkind","flagregistry","flagupb");
	taccount_deferredrevenue.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_deferredrevenue);
	taccount_deferredrevenue.defineKey("idacc");

	//////////////////// ACCOUNT_PL /////////////////////////////////
	var taccount_pl= new accountTable();
	taccount_pl.TableName = "account_pl";
	taccount_pl.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_pl.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_pl);
	taccount_pl.defineKey("idacc");

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

	//////////////////// FINLEVEL /////////////////////////////////
	var tfinlevel= new MetaTable("finlevel");
	tfinlevel.defineColumn("ayear", typeof(short),false);
	tfinlevel.defineColumn("nlevel", typeof(byte),false);
	tfinlevel.defineColumn("description", typeof(string),false);
	tfinlevel.defineColumn("cu", typeof(string),false);
	tfinlevel.defineColumn("ct", typeof(DateTime),false);
	tfinlevel.defineColumn("lu", typeof(string),false);
	tfinlevel.defineColumn("lt", typeof(DateTime),false);
	tfinlevel.defineColumn("flag", typeof(short),false);
	Tables.Add(tfinlevel);
	tfinlevel.defineKey("ayear", "nlevel");

	//////////////////// SORTINGKIND1 /////////////////////////////////
	var tsortingkind1= new sortingkindTable();
	tsortingkind1.TableName = "sortingkind1";
	tsortingkind1.addBaseColumns("idsorkind","description","nphaseincome","nphaseexpense");
	tsortingkind1.ExtendedProperties["TableForReading"]="sortingkind";
	Tables.Add(tsortingkind1);
	tsortingkind1.defineKey("idsorkind");

	//////////////////// SORTINGKIND2 /////////////////////////////////
	var tsortingkind2= new sortingkindTable();
	tsortingkind2.TableName = "sortingkind2";
	tsortingkind2.addBaseColumns("idsorkind","description","nphaseincome","nphaseexpense");
	tsortingkind2.ExtendedProperties["TableForReading"]="sortingkind";
	Tables.Add(tsortingkind2);
	tsortingkind2.defineKey("idsorkind");

	//////////////////// SORTINGKIND3 /////////////////////////////////
	var tsortingkind3= new sortingkindTable();
	tsortingkind3.TableName = "sortingkind3";
	tsortingkind3.addBaseColumns("idsorkind","description","nphaseincome","nphaseexpense");
	tsortingkind3.ExtendedProperties["TableForReading"]="sortingkind";
	Tables.Add(tsortingkind3);
	tsortingkind3.defineKey("idsorkind");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRY_CSA /////////////////////////////////
	var tregistry_csa= new registryTable();
	tregistry_csa.TableName = "registry_csa";
	tregistry_csa.addBaseColumns("idreg","title","active");
	tregistry_csa.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_csa);
	tregistry_csa.defineKey("idreg");

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

	//////////////////// EXPENSEPHASE1 /////////////////////////////////
	var texpensephase1= new MetaTable("expensephase1");
	texpensephase1.defineColumn("nphase", typeof(byte),false);
	texpensephase1.defineColumn("description", typeof(string),false);
	texpensephase1.defineColumn("cu", typeof(string),false);
	texpensephase1.defineColumn("ct", typeof(DateTime),false);
	texpensephase1.defineColumn("lu", typeof(string),false);
	texpensephase1.defineColumn("lt", typeof(DateTime),false);
	texpensephase1.ExtendedProperties["TableForReading"]="expensephase";
	Tables.Add(texpensephase1);
	texpensephase1.defineKey("nphase");

	//////////////////// FINLEVEL1 /////////////////////////////////
	var tfinlevel1= new MetaTable("finlevel1");
	tfinlevel1.defineColumn("ayear", typeof(short),false);
	tfinlevel1.defineColumn("nlevel", typeof(byte),false);
	tfinlevel1.defineColumn("description", typeof(string),false);
	tfinlevel1.defineColumn("cu", typeof(string),false);
	tfinlevel1.defineColumn("ct", typeof(DateTime),false);
	tfinlevel1.defineColumn("lu", typeof(string),false);
	tfinlevel1.defineColumn("lt", typeof(DateTime),false);
	tfinlevel1.defineColumn("flag", typeof(short),false);
	tfinlevel1.ExtendedProperties["TableForReading"]="finlevel";
	Tables.Add(tfinlevel1);
	tfinlevel1.defineKey("ayear", "nlevel");

	//////////////////// INCOMEPHASE1 /////////////////////////////////
	var tincomephase1= new MetaTable("incomephase1");
	tincomephase1.defineColumn("nphase", typeof(byte),false);
	tincomephase1.defineColumn("ct", typeof(DateTime),false);
	tincomephase1.defineColumn("cu", typeof(string),false);
	tincomephase1.defineColumn("description", typeof(string),false);
	tincomephase1.defineColumn("lt", typeof(DateTime),false);
	tincomephase1.defineColumn("lu", typeof(string),false);
	tincomephase1.ExtendedProperties["TableForReading"]="incomephase";
	Tables.Add(tincomephase1);
	tincomephase1.defineKey("nphase");

	//////////////////// IVAPAYPERIODICITY /////////////////////////////////
	var tivapayperiodicity= new MetaTable("ivapayperiodicity");
	tivapayperiodicity.defineColumn("idivapayperiodicity", typeof(int),false);
	tivapayperiodicity.defineColumn("description", typeof(string),false);
	tivapayperiodicity.defineColumn("periodicity", typeof(int),false);
	tivapayperiodicity.defineColumn("periodicday", typeof(int),false);
	tivapayperiodicity.defineColumn("periodicmonth", typeof(int),false);
	tivapayperiodicity.defineColumn("cu", typeof(string),false);
	tivapayperiodicity.defineColumn("ct", typeof(DateTime),false);
	tivapayperiodicity.defineColumn("lu", typeof(string),false);
	tivapayperiodicity.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tivapayperiodicity);
	tivapayperiodicity.defineKey("idivapayperiodicity");

	//////////////////// BILANCIOVERSAMENTO /////////////////////////////////
	var tbilancioversamento= new finviewTable();
	tbilancioversamento.TableName = "bilancioversamento";
	tbilancioversamento.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tbilancioversamento.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tbilancioversamento);
	tbilancioversamento.defineKey("idfin");

	//////////////////// BILANCIORIMBORSO /////////////////////////////////
	var tbilanciorimborso= new finviewTable();
	tbilanciorimborso.TableName = "bilanciorimborso";
	tbilanciorimborso.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tbilanciorimborso.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tbilanciorimborso);
	tbilanciorimborso.defineKey("idfin");

	//////////////////// CREDDEBRIMBORSO /////////////////////////////////
	var tcreddebrimborso= new registryTable();
	tcreddebrimborso.TableName = "creddebrimborso";
	tcreddebrimborso.addBaseColumns("idreg","title");
	tcreddebrimborso.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tcreddebrimborso);
	tcreddebrimborso.defineKey("idreg");

	//////////////////// CREDDEBVERSAMENTO /////////////////////////////////
	var tcreddebversamento= new registryTable();
	tcreddebversamento.TableName = "creddebversamento";
	tcreddebversamento.addBaseColumns("idreg","title");
	tcreddebversamento.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tcreddebversamento);
	tcreddebversamento.defineKey("idreg");

	//////////////////// CLAWBACK /////////////////////////////////
	var tclawback= new MetaTable("clawback");
	tclawback.defineColumn("idclawback", typeof(int),false);
	tclawback.defineColumn("description", typeof(string),false);
	tclawback.defineColumn("cu", typeof(string),false);
	tclawback.defineColumn("ct", typeof(DateTime),false);
	tclawback.defineColumn("lu", typeof(string),false);
	tclawback.defineColumn("lt", typeof(DateTime),false);
	tclawback.defineColumn("active", typeof(string));
	Tables.Add(tclawback);
	tclawback.defineKey("idclawback");

	//////////////////// BILANCIOSPESA /////////////////////////////////
	var tbilanciospesa= new finviewTable();
	tbilanciospesa.TableName = "bilanciospesa";
	tbilanciospesa.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tbilanciospesa.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tbilanciospesa);
	tbilanciospesa.defineKey("idfin");

	//////////////////// ACCMOTIVEAPPLIED_ADMINCAR /////////////////////////////////
	var taccmotiveapplied_admincar= new accmotiveappliedTable();
	taccmotiveapplied_admincar.TableName = "accmotiveapplied_admincar";
	taccmotiveapplied_admincar.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation");
	taccmotiveapplied_admincar.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_admincar);
	taccmotiveapplied_admincar.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_OWNCAR /////////////////////////////////
	var taccmotiveapplied_owncar= new accmotiveappliedTable();
	taccmotiveapplied_owncar.TableName = "accmotiveapplied_owncar";
	taccmotiveapplied_owncar.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation");
	taccmotiveapplied_owncar.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_owncar);
	taccmotiveapplied_owncar.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_FOOT /////////////////////////////////
	var taccmotiveapplied_foot= new accmotiveappliedTable();
	taccmotiveapplied_foot.TableName = "accmotiveapplied_foot";
	taccmotiveapplied_foot.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation");
	taccmotiveapplied_foot.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_foot);
	taccmotiveapplied_foot.defineKey("idaccmotive");

	//////////////////// APPKIND /////////////////////////////////
	var tappkind= new MetaTable("appkind");
	tappkind.defineColumn("code", typeof(string),false);
	tappkind.defineColumn("description", typeof(string));
	Tables.Add(tappkind);
	tappkind.defineKey("code");

	//////////////////// PAYMETHODABI /////////////////////////////////
	var tpaymethodabi= new MetaTable("paymethodabi");
	tpaymethodabi.defineColumn("active", typeof(string));
	tpaymethodabi.defineColumn("allowdeputy", typeof(string));
	tpaymethodabi.defineColumn("ct", typeof(DateTime),false);
	tpaymethodabi.defineColumn("cu", typeof(string),false);
	tpaymethodabi.defineColumn("description", typeof(string),false);
	tpaymethodabi.defineColumn("lt", typeof(DateTime),false);
	tpaymethodabi.defineColumn("lu", typeof(string),false);
	tpaymethodabi.defineColumn("methodbankcode", typeof(string));
	tpaymethodabi.defineColumn("footerpaymentadvice", typeof(string));
	tpaymethodabi.defineColumn("idpaymethod", typeof(int),false);
	tpaymethodabi.defineColumn("flag", typeof(int),false);
	tpaymethodabi.ExtendedProperties["TableForReading"]="paymethod";
	Tables.Add(tpaymethodabi);
	tpaymethodabi.defineKey("idpaymethod");

	//////////////////// PAYMETHODNOABI /////////////////////////////////
	var tpaymethodnoabi= new MetaTable("paymethodnoabi");
	tpaymethodnoabi.defineColumn("active", typeof(string));
	tpaymethodnoabi.defineColumn("allowdeputy", typeof(string));
	tpaymethodnoabi.defineColumn("ct", typeof(DateTime),false);
	tpaymethodnoabi.defineColumn("cu", typeof(string),false);
	tpaymethodnoabi.defineColumn("description", typeof(string),false);
	tpaymethodnoabi.defineColumn("lt", typeof(DateTime),false);
	tpaymethodnoabi.defineColumn("lu", typeof(string),false);
	tpaymethodnoabi.defineColumn("methodbankcode", typeof(string));
	tpaymethodnoabi.defineColumn("footerpaymentadvice", typeof(string));
	tpaymethodnoabi.defineColumn("idpaymethod", typeof(int),false);
	tpaymethodnoabi.defineColumn("flag", typeof(int),false);
	tpaymethodnoabi.ExtendedProperties["TableForReading"]="paymethod";
	Tables.Add(tpaymethodnoabi);
	tpaymethodnoabi.defineKey("idpaymethod");

	//////////////////// ACCOUNT_UNABATABLE_VERSAMENTO /////////////////////////////////
	var taccount_unabatable_versamento= new accountTable();
	taccount_unabatable_versamento.TableName = "account_unabatable_versamento";
	taccount_unabatable_versamento.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_unabatable_versamento.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_unabatable_versamento);
	taccount_unabatable_versamento.defineKey("idacc");

	//////////////////// ACCOUNT_UNABATABLE_RIMBORSO /////////////////////////////////
	var taccount_unabatable_rimborso= new accountTable();
	taccount_unabatable_rimborso.TableName = "account_unabatable_rimborso";
	taccount_unabatable_rimborso.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_unabatable_rimborso.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_unabatable_rimborso);
	taccount_unabatable_rimborso.defineKey("idacc");

	//////////////////// MAINCREDDEBRIMBORSO /////////////////////////////////
	var tmaincreddebrimborso= new registryTable();
	tmaincreddebrimborso.TableName = "maincreddebrimborso";
	tmaincreddebrimborso.addBaseColumns("idreg","title");
	tmaincreddebrimborso.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tmaincreddebrimborso);
	tmaincreddebrimborso.defineKey("idreg");

	//////////////////// MAINCREDDEBVERSAMENTO /////////////////////////////////
	var tmaincreddebversamento= new registryTable();
	tmaincreddebversamento.TableName = "maincreddebversamento";
	tmaincreddebversamento.addBaseColumns("idreg","title");
	tmaincreddebversamento.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tmaincreddebversamento);
	tmaincreddebversamento.defineKey("idreg");

	//////////////////// MAINBILANCIORIMBORSO /////////////////////////////////
	var tmainbilanciorimborso= new finviewTable();
	tmainbilanciorimborso.TableName = "mainbilanciorimborso";
	tmainbilanciorimborso.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tmainbilanciorimborso.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tmainbilanciorimborso);

	//////////////////// MAINBILANCIOVERSAMENTO /////////////////////////////////
	var tmainbilancioversamento= new finviewTable();
	tmainbilancioversamento.TableName = "mainbilancioversamento";
	tmainbilancioversamento.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tmainbilancioversamento.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tmainbilancioversamento);
	tmainbilancioversamento.defineKey("idfin");

	//////////////////// ACCOUNT_MAINUNABATABLE_VERSAMENTO /////////////////////////////////
	var taccount_mainunabatable_versamento= new accountTable();
	taccount_mainunabatable_versamento.TableName = "account_mainunabatable_versamento";
	taccount_mainunabatable_versamento.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainunabatable_versamento.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainunabatable_versamento);
	taccount_mainunabatable_versamento.defineKey("idacc");

	//////////////////// ACCOUNT_MAINUNABATABLE_RIMBORSO /////////////////////////////////
	var taccount_mainunabatable_rimborso= new accountTable();
	taccount_mainunabatable_rimborso.TableName = "account_mainunabatable_rimborso";
	taccount_mainunabatable_rimborso.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainunabatable_rimborso.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainunabatable_rimborso);
	taccount_mainunabatable_rimborso.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAPAYMENT /////////////////////////////////
	var taccount_mainivapayment= new accountTable();
	taccount_mainivapayment.TableName = "account_mainivapayment";
	taccount_mainivapayment.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivapayment.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivapayment);
	taccount_mainivapayment.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAPAYMENT_INTERNAL /////////////////////////////////
	var taccount_mainivapayment_internal= new accountTable();
	taccount_mainivapayment_internal.TableName = "account_mainivapayment_internal";
	taccount_mainivapayment_internal.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivapayment_internal.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivapayment_internal);
	taccount_mainivapayment_internal.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAREFUND /////////////////////////////////
	var taccount_mainivarefund= new accountTable();
	taccount_mainivarefund.TableName = "account_mainivarefund";
	taccount_mainivarefund.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivarefund.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivarefund);
	taccount_mainivarefund.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAREFUND_INTERNAL /////////////////////////////////
	var taccount_mainivarefund_internal= new accountTable();
	taccount_mainivarefund_internal.TableName = "account_mainivarefund_internal";
	taccount_mainivarefund_internal.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivarefund_internal.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivarefund_internal);
	taccount_mainivarefund_internal.defineKey("idacc");

	//////////////////// ACCOUNT_IVAREFUND12 /////////////////////////////////
	var taccount_ivarefund12= new accountTable();
	taccount_ivarefund12.TableName = "account_ivarefund12";
	taccount_ivarefund12.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_ivarefund12.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_ivarefund12);
	taccount_ivarefund12.defineKey("idacc");

	//////////////////// ACCOUNT_IVAPAYMENT12 /////////////////////////////////
	var taccount_ivapayment12= new accountTable();
	taccount_ivapayment12.TableName = "account_ivapayment12";
	taccount_ivapayment12.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_ivapayment12.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_ivapayment12);
	taccount_ivapayment12.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAREFUND12 /////////////////////////////////
	var taccount_mainivarefund12= new accountTable();
	taccount_mainivarefund12.TableName = "account_mainivarefund12";
	taccount_mainivarefund12.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivarefund12.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivarefund12);
	taccount_mainivarefund12.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAREFUND_INTERNAL12 /////////////////////////////////
	var taccount_mainivarefund_internal12= new accountTable();
	taccount_mainivarefund_internal12.TableName = "account_mainivarefund_internal12";
	taccount_mainivarefund_internal12.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivarefund_internal12.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivarefund_internal12);
	taccount_mainivarefund_internal12.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAPAYMENT12 /////////////////////////////////
	var taccount_mainivapayment12= new accountTable();
	taccount_mainivapayment12.TableName = "account_mainivapayment12";
	taccount_mainivapayment12.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivapayment12.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivapayment12);
	taccount_mainivapayment12.defineKey("idacc");

	//////////////////// ACCOUNT_MAINIVAPAYMENT_INTERNAL12 /////////////////////////////////
	var taccount_mainivapayment_internal12= new accountTable();
	taccount_mainivapayment_internal12.TableName = "account_mainivapayment_internal12";
	taccount_mainivapayment_internal12.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag");
	taccount_mainivapayment_internal12.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_mainivapayment_internal12);
	taccount_mainivapayment_internal12.defineKey("idacc");

	//////////////////// BILANCIOVERSAMENTO12 /////////////////////////////////
	var tbilancioversamento12= new finviewTable();
	tbilancioversamento12.TableName = "bilancioversamento12";
	tbilancioversamento12.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tbilancioversamento12.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tbilancioversamento12);
	tbilancioversamento12.defineKey("idfin");

	//////////////////// BILANCIORIMBORSO12 /////////////////////////////////
	var tbilanciorimborso12= new finviewTable();
	tbilanciorimborso12.TableName = "bilanciorimborso12";
	tbilanciorimborso12.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tbilanciorimborso12.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tbilanciorimborso12);
	tbilanciorimborso12.defineKey("idfin");

	//////////////////// CREDDEBVERSAMENTO12 /////////////////////////////////
	var tcreddebversamento12= new registryTable();
	tcreddebversamento12.TableName = "creddebversamento12";
	tcreddebversamento12.addBaseColumns("idreg","title");
	tcreddebversamento12.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tcreddebversamento12);
	tcreddebversamento12.defineKey("idreg");

	//////////////////// CREDDEBRIMBORSO12 /////////////////////////////////
	var tcreddebrimborso12= new registryTable();
	tcreddebrimborso12.TableName = "creddebrimborso12";
	tcreddebrimborso12.addBaseColumns("idreg","title");
	tcreddebrimborso12.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tcreddebrimborso12);
	tcreddebrimborso12.defineKey("idreg");

	//////////////////// MAINBILANCIORIMBORSO12 /////////////////////////////////
	var tmainbilanciorimborso12= new finviewTable();
	tmainbilanciorimborso12.TableName = "mainbilanciorimborso12";
	tmainbilanciorimborso12.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tmainbilanciorimborso12.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tmainbilanciorimborso12);
	tmainbilanciorimborso12.defineKey("idfin");

	//////////////////// MAINBILANCIOVERSAMENTO12 /////////////////////////////////
	var tmainbilancioversamento12= new finviewTable();
	tmainbilancioversamento12.TableName = "mainbilancioversamento12";
	tmainbilancioversamento12.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tmainbilancioversamento12.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tmainbilancioversamento12);
	tmainbilancioversamento12.defineKey("idfin");

	//////////////////// MAINCREDDEBVERSAMENTO12 /////////////////////////////////
	var tmaincreddebversamento12= new registryTable();
	tmaincreddebversamento12.TableName = "maincreddebversamento12";
	tmaincreddebversamento12.addBaseColumns("idreg","title");
	tmaincreddebversamento12.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tmaincreddebversamento12);
	tmaincreddebversamento12.defineKey("idreg");

	//////////////////// MAINCREDDEBRIMBORSO12 /////////////////////////////////
	var tmaincreddebrimborso12= new registryTable();
	tmaincreddebrimborso12.TableName = "maincreddebrimborso12";
	tmaincreddebrimborso12.addBaseColumns("idreg","title");
	tmaincreddebrimborso12.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tmaincreddebrimborso12);
	tmaincreddebrimborso12.defineKey("idreg");

	//////////////////// FIN_INCOME_GROSS_CSA /////////////////////////////////
	var tfin_income_gross_csa= new finviewTable();
	tfin_income_gross_csa.TableName = "fin_income_gross_csa";
	tfin_income_gross_csa.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tfin_income_gross_csa.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tfin_income_gross_csa);
	tfin_income_gross_csa.defineKey("idfin");

	//////////////////// ACCOUNT_REVENUE_GROSS_CSA /////////////////////////////////
	var taccount_revenue_gross_csa= new accountTable();
	taccount_revenue_gross_csa.TableName = "account_revenue_gross_csa";
	taccount_revenue_gross_csa.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_revenue_gross_csa.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_revenue_gross_csa);
	taccount_revenue_gross_csa.defineKey("idacc");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new sortingTable();
	tsorting3.TableName = "sorting3";
	tsorting3.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting3.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new sortingTable();
	tsorting1.TableName = "sorting1";
	tsorting1.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting1.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new sortingTable();
	tsorting2.TableName = "sorting2";
	tsorting2.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","flagnodate","movkind","printingorder","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5");
	tsorting2.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// INPSCENTER /////////////////////////////////
	var tinpscenter= new MetaTable("inpscenter");
	tinpscenter.defineColumn("idinpscenter", typeof(string),false);
	tinpscenter.defineColumn("ccp", typeof(string));
	tinpscenter.defineColumn("othercentercode", typeof(string));
	tinpscenter.defineColumn("title", typeof(string));
	Tables.Add(tinpscenter);
	tinpscenter.defineKey("idinpscenter");

	//////////////////// FIN_STORE /////////////////////////////////
	var tfin_store= new finviewTable();
	tfin_store.TableName = "fin_store";
	tfin_store.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tfin_store.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tfin_store);
	tfin_store.defineKey("idfin");

	//////////////////// SORTINGINCOMECSA /////////////////////////////////
	var tsortingincomecsa= new sortingTable();
	tsortingincomecsa.TableName = "sortingincomecsa";
	tsortingincomecsa.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsortingincomecsa.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsortingincomecsa);
	tsortingincomecsa.defineKey("idsor");

	//////////////////// ACCOUNT_INVOICETORECEIVE /////////////////////////////////
	var taccount_invoicetoreceive= new accountTable();
	taccount_invoicetoreceive.TableName = "account_invoicetoreceive";
	taccount_invoicetoreceive.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_invoicetoreceive.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_invoicetoreceive);
	taccount_invoicetoreceive.defineKey("idacc");

	//////////////////// ACCOUNT_INVOICETOEMIT /////////////////////////////////
	var taccount_invoicetoemit= new accountTable();
	taccount_invoicetoemit.TableName = "account_invoicetoemit";
	taccount_invoicetoemit.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_invoicetoemit.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_invoicetoemit);
	taccount_invoicetoemit.defineKey("idacc");

	//////////////////// PCCDEBITSTATUS /////////////////////////////////
	var tpccdebitstatus= new MetaTable("pccdebitstatus");
	tpccdebitstatus.defineColumn("idpccdebitstatus", typeof(string),false);
	tpccdebitstatus.defineColumn("description", typeof(string));
	tpccdebitstatus.defineColumn("lt", typeof(DateTime),false);
	tpccdebitstatus.defineColumn("lu", typeof(string),false);
	tpccdebitstatus.defineColumn("listingorder", typeof(int));
	tpccdebitstatus.defineColumn("flag", typeof(int));
	Tables.Add(tpccdebitstatus);
	tpccdebitstatus.defineKey("idpccdebitstatus");

	//////////////////// ACCOUNT_UNABATABLE_SPLIT /////////////////////////////////
	var taccount_unabatable_split= new accountTable();
	taccount_unabatable_split.TableName = "account_unabatable_split";
	taccount_unabatable_split.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_unabatable_split.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_unabatable_split);
	taccount_unabatable_split.defineKey("idacc");

	//////////////////// ACCOUNT_SPLIT_IVAPAYMENT /////////////////////////////////
	var taccount_split_ivapayment= new accountTable();
	taccount_split_ivapayment.TableName = "account_split_ivapayment";
	taccount_split_ivapayment.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency");
	taccount_split_ivapayment.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_split_ivapayment);
	taccount_split_ivapayment.defineKey("idacc");

	//////////////////// MAINBILANCIOVERSAMENTOSPLIT /////////////////////////////////
	var tmainbilancioversamentosplit= new finviewTable();
	tmainbilancioversamentosplit.TableName = "mainbilancioversamentosplit";
	tmainbilancioversamentosplit.addBaseColumns("idfin","ayear","finpart","codefin","nlevel","leveldescr","paridfin","idman","manager","printingorder","title","prevision","currentprevision","availableprevision","previousprevision","secondaryprev","currentsecondaryprev","availablesecondaryprev","previoussecondaryprev","currentarrears","previousarrears","prevision2","prevision3","prevision4","prevision5","expiration","flag","flagusable","idupb","codeupb","upb","cu","ct","lu","lt");
	tmainbilancioversamentosplit.ExtendedProperties["TableForReading"]="finview";
	Tables.Add(tmainbilancioversamentosplit);
	tmainbilancioversamentosplit.defineKey("idfin");

	//////////////////// MAINCREDDEBVERSAMENTOSPLIT /////////////////////////////////
	var tmaincreddebversamentosplit= new registryTable();
	tmaincreddebversamentosplit.TableName = "maincreddebversamentosplit";
	tmaincreddebversamentosplit.addBaseColumns("idreg","title");
	tmaincreddebversamentosplit.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tmaincreddebversamentosplit);
	tmaincreddebversamentosplit.defineKey("idreg");

	//////////////////// ACCOUNT_BANKPAYDOC /////////////////////////////////
	var taccount_bankpaydoc= new accountTable();
	taccount_bankpaydoc.TableName = "account_bankpaydoc";
	taccount_bankpaydoc.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag","idacc_special","flagenablebudgetprev","flagaccountusage");
	taccount_bankpaydoc.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_bankpaydoc);
	taccount_bankpaydoc.defineKey("idacc");

	//////////////////// ACCOUNT_BANKPRODOC /////////////////////////////////
	var taccount_bankprodoc= new accountTable();
	taccount_bankprodoc.TableName = "account_bankprodoc";
	taccount_bankprodoc.addBaseColumns("idacc","ayear","codeacc","ct","cu","flagregistry","flagtransitory","flagupb","idaccountkind","lt","lu","nlevel","paridacc","printingorder","rtf","title","txt","idpatrimony","idplaccount","flagprofit","flagloss","placcount_sign","patrimony_sign","flagcompetency","flag","idacc_special","flagenablebudgetprev","flagaccountusage");
	taccount_bankprodoc.ExtendedProperties["TableForReading"]="account";
	Tables.Add(taccount_bankprodoc);
	taccount_bankprodoc.defineKey("idacc");

	//////////////////// ACCMOTIVEAPPLIED_FORWARDER /////////////////////////////////
	var taccmotiveapplied_forwarder= new accmotiveappliedTable();
	taccmotiveapplied_forwarder.TableName = "accmotiveapplied_forwarder";
	taccmotiveapplied_forwarder.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep","expensekind");
	taccmotiveapplied_forwarder.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_forwarder);

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("ct","cu","description","lt","lu","rate","unabatabilitypercentage","active","idivataxablekind","idivakind","codeivakind","flag","annotations","idfenature");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// ACCMOTIVE_GRANTDEFERREDCOST /////////////////////////////////
	var taccmotive_grantdeferredcost= new accmotiveTable();
	taccmotive_grantdeferredcost.TableName = "accmotive_grantdeferredcost";
	taccmotive_grantdeferredcost.addBaseColumns("idaccmotive","active","codemotive","ct","cu","flagamm","flagdep","lt","lu","paridaccmotive","title","expensekind","flag");
	taccmotive_grantdeferredcost.ExtendedProperties["TableForReading"]="accmotive";
	Tables.Add(taccmotive_grantdeferredcost);
	taccmotive_grantdeferredcost.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE_GRANTREVENUE /////////////////////////////////
	var taccmotive_grantrevenue= new accmotiveTable();
	taccmotive_grantrevenue.TableName = "accmotive_grantrevenue";
	taccmotive_grantrevenue.addBaseColumns("idaccmotive","active","codemotive","ct","cu","flagamm","flagdep","lt","lu","paridaccmotive","title","expensekind","flag");
	taccmotive_grantrevenue.ExtendedProperties["TableForReading"]="accmotive";
	Tables.Add(taccmotive_grantrevenue);
	taccmotive_grantrevenue.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_ASSETREVENUE /////////////////////////////////
	var taccmotiveapplied_assetrevenue= new accmotiveappliedTable();
	taccmotiveapplied_assetrevenue.TableName = "accmotiveapplied_assetrevenue";
	taccmotiveapplied_assetrevenue.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation");
	taccmotiveapplied_assetrevenue.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_assetrevenue);
	taccmotiveapplied_assetrevenue.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_PRORATA_COST /////////////////////////////////
	var taccmotiveapplied_prorata_cost= new accmotiveappliedTable();
	taccmotiveapplied_prorata_cost.TableName = "accmotiveapplied_prorata_cost";
	taccmotiveapplied_prorata_cost.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation");
	taccmotiveapplied_prorata_cost.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_prorata_cost);
	taccmotiveapplied_prorata_cost.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_PRORATA_REVENUE /////////////////////////////////
	var taccmotiveapplied_prorata_revenue= new accmotiveappliedTable();
	taccmotiveapplied_prorata_revenue.TableName = "accmotiveapplied_prorata_revenue";
	taccmotiveapplied_prorata_revenue.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation");
	taccmotiveapplied_prorata_revenue.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_prorata_revenue);
	taccmotiveapplied_prorata_revenue.defineKey("idaccmotive");

	//////////////////// SORTING_SIOPEIVAEXP /////////////////////////////////
	var tsorting_siopeivaexp= new MetaTable("sorting_siopeivaexp");
	tsorting_siopeivaexp.defineColumn("ct", typeof(DateTime),false);
	tsorting_siopeivaexp.defineColumn("cu", typeof(string),false);
	tsorting_siopeivaexp.defineColumn("defaultN1", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultN2", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultN3", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultN4", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultN5", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultS1", typeof(string));
	tsorting_siopeivaexp.defineColumn("defaultS2", typeof(string));
	tsorting_siopeivaexp.defineColumn("defaultS3", typeof(string));
	tsorting_siopeivaexp.defineColumn("defaultS4", typeof(string));
	tsorting_siopeivaexp.defineColumn("defaultS5", typeof(string));
	tsorting_siopeivaexp.defineColumn("defaultv1", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultv2", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultv3", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultv4", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("defaultv5", typeof(decimal));
	tsorting_siopeivaexp.defineColumn("description", typeof(string),false);
	tsorting_siopeivaexp.defineColumn("flagnodate", typeof(string));
	tsorting_siopeivaexp.defineColumn("lt", typeof(DateTime),false);
	tsorting_siopeivaexp.defineColumn("lu", typeof(string),false);
	tsorting_siopeivaexp.defineColumn("movkind", typeof(string));
	tsorting_siopeivaexp.defineColumn("printingorder", typeof(string));
	tsorting_siopeivaexp.defineColumn("rtf", typeof(Byte[]));
	tsorting_siopeivaexp.defineColumn("sortcode", typeof(string),false);
	tsorting_siopeivaexp.defineColumn("txt", typeof(string));
	tsorting_siopeivaexp.defineColumn("idsorkind", typeof(int),false);
	tsorting_siopeivaexp.defineColumn("idsor", typeof(int),false);
	tsorting_siopeivaexp.defineColumn("paridsor", typeof(int));
	tsorting_siopeivaexp.defineColumn("nlevel", typeof(byte),false);
	tsorting_siopeivaexp.defineColumn("start", typeof(short));
	tsorting_siopeivaexp.defineColumn("stop", typeof(short));
	tsorting_siopeivaexp.defineColumn("email", typeof(string));
	Tables.Add(tsorting_siopeivaexp);
	tsorting_siopeivaexp.defineKey("idsor");

	//////////////////// SORTING_SIOPEIVA12EXP /////////////////////////////////
	var tsorting_siopeiva12exp= new MetaTable("sorting_siopeiva12exp");
	tsorting_siopeiva12exp.defineColumn("ct", typeof(DateTime),false);
	tsorting_siopeiva12exp.defineColumn("cu", typeof(string),false);
	tsorting_siopeiva12exp.defineColumn("defaultN1", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultN2", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultN3", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultN4", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultN5", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultS1", typeof(string));
	tsorting_siopeiva12exp.defineColumn("defaultS2", typeof(string));
	tsorting_siopeiva12exp.defineColumn("defaultS3", typeof(string));
	tsorting_siopeiva12exp.defineColumn("defaultS4", typeof(string));
	tsorting_siopeiva12exp.defineColumn("defaultS5", typeof(string));
	tsorting_siopeiva12exp.defineColumn("defaultv1", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultv2", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultv3", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultv4", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("defaultv5", typeof(decimal));
	tsorting_siopeiva12exp.defineColumn("description", typeof(string),false);
	tsorting_siopeiva12exp.defineColumn("flagnodate", typeof(string));
	tsorting_siopeiva12exp.defineColumn("lt", typeof(DateTime),false);
	tsorting_siopeiva12exp.defineColumn("lu", typeof(string),false);
	tsorting_siopeiva12exp.defineColumn("movkind", typeof(string));
	tsorting_siopeiva12exp.defineColumn("printingorder", typeof(string));
	tsorting_siopeiva12exp.defineColumn("rtf", typeof(Byte[]));
	tsorting_siopeiva12exp.defineColumn("sortcode", typeof(string),false);
	tsorting_siopeiva12exp.defineColumn("txt", typeof(string));
	tsorting_siopeiva12exp.defineColumn("idsorkind", typeof(int),false);
	tsorting_siopeiva12exp.defineColumn("idsor", typeof(int),false);
	tsorting_siopeiva12exp.defineColumn("paridsor", typeof(int));
	tsorting_siopeiva12exp.defineColumn("nlevel", typeof(byte),false);
	tsorting_siopeiva12exp.defineColumn("start", typeof(short));
	tsorting_siopeiva12exp.defineColumn("stop", typeof(short));
	tsorting_siopeiva12exp.defineColumn("email", typeof(string));
	Tables.Add(tsorting_siopeiva12exp);
	tsorting_siopeiva12exp.defineKey("idsor");

	//////////////////// SORTING_SIOPEIVASPLITEXP /////////////////////////////////
	var tsorting_siopeivasplitexp= new MetaTable("sorting_siopeivasplitexp");
	tsorting_siopeivasplitexp.defineColumn("ct", typeof(DateTime),false);
	tsorting_siopeivasplitexp.defineColumn("cu", typeof(string),false);
	tsorting_siopeivasplitexp.defineColumn("defaultN1", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultN2", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultN3", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultN4", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultN5", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultS1", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("defaultS2", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("defaultS3", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("defaultS4", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("defaultS5", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("defaultv1", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultv2", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultv3", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultv4", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("defaultv5", typeof(decimal));
	tsorting_siopeivasplitexp.defineColumn("description", typeof(string),false);
	tsorting_siopeivasplitexp.defineColumn("flagnodate", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("lt", typeof(DateTime),false);
	tsorting_siopeivasplitexp.defineColumn("lu", typeof(string),false);
	tsorting_siopeivasplitexp.defineColumn("movkind", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("printingorder", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("rtf", typeof(Byte[]));
	tsorting_siopeivasplitexp.defineColumn("sortcode", typeof(string),false);
	tsorting_siopeivasplitexp.defineColumn("txt", typeof(string));
	tsorting_siopeivasplitexp.defineColumn("idsorkind", typeof(int),false);
	tsorting_siopeivasplitexp.defineColumn("idsor", typeof(int),false);
	tsorting_siopeivasplitexp.defineColumn("paridsor", typeof(int));
	tsorting_siopeivasplitexp.defineColumn("nlevel", typeof(byte),false);
	tsorting_siopeivasplitexp.defineColumn("start", typeof(short));
	tsorting_siopeivasplitexp.defineColumn("stop", typeof(short));
	tsorting_siopeivasplitexp.defineColumn("email", typeof(string));
	Tables.Add(tsorting_siopeivasplitexp);
	tsorting_siopeivasplitexp.defineKey("idsor");

	//////////////////// SORTING_SIOPEIVA12INC /////////////////////////////////
	var tsorting_siopeiva12inc= new MetaTable("sorting_siopeiva12inc");
	tsorting_siopeiva12inc.defineColumn("ct", typeof(DateTime),false);
	tsorting_siopeiva12inc.defineColumn("cu", typeof(string),false);
	tsorting_siopeiva12inc.defineColumn("defaultN1", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultN2", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultN3", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultN4", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultN5", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultS1", typeof(string));
	tsorting_siopeiva12inc.defineColumn("defaultS2", typeof(string));
	tsorting_siopeiva12inc.defineColumn("defaultS3", typeof(string));
	tsorting_siopeiva12inc.defineColumn("defaultS4", typeof(string));
	tsorting_siopeiva12inc.defineColumn("defaultS5", typeof(string));
	tsorting_siopeiva12inc.defineColumn("defaultv1", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultv2", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultv3", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultv4", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("defaultv5", typeof(decimal));
	tsorting_siopeiva12inc.defineColumn("description", typeof(string),false);
	tsorting_siopeiva12inc.defineColumn("flagnodate", typeof(string));
	tsorting_siopeiva12inc.defineColumn("lt", typeof(DateTime),false);
	tsorting_siopeiva12inc.defineColumn("lu", typeof(string),false);
	tsorting_siopeiva12inc.defineColumn("movkind", typeof(string));
	tsorting_siopeiva12inc.defineColumn("printingorder", typeof(string));
	tsorting_siopeiva12inc.defineColumn("rtf", typeof(Byte[]));
	tsorting_siopeiva12inc.defineColumn("sortcode", typeof(string),false);
	tsorting_siopeiva12inc.defineColumn("txt", typeof(string));
	tsorting_siopeiva12inc.defineColumn("idsorkind", typeof(int),false);
	tsorting_siopeiva12inc.defineColumn("idsor", typeof(int),false);
	tsorting_siopeiva12inc.defineColumn("paridsor", typeof(int));
	tsorting_siopeiva12inc.defineColumn("nlevel", typeof(byte),false);
	tsorting_siopeiva12inc.defineColumn("start", typeof(short));
	tsorting_siopeiva12inc.defineColumn("stop", typeof(short));
	tsorting_siopeiva12inc.defineColumn("email", typeof(string));
	Tables.Add(tsorting_siopeiva12inc);
	tsorting_siopeiva12inc.defineKey("idsor");

	//////////////////// SORTING_SIOPEIVAINC /////////////////////////////////
	var tsorting_siopeivainc= new MetaTable("sorting_siopeivainc");
	tsorting_siopeivainc.defineColumn("ct", typeof(DateTime),false);
	tsorting_siopeivainc.defineColumn("cu", typeof(string),false);
	tsorting_siopeivainc.defineColumn("defaultN1", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultN2", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultN3", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultN4", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultN5", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultS1", typeof(string));
	tsorting_siopeivainc.defineColumn("defaultS2", typeof(string));
	tsorting_siopeivainc.defineColumn("defaultS3", typeof(string));
	tsorting_siopeivainc.defineColumn("defaultS4", typeof(string));
	tsorting_siopeivainc.defineColumn("defaultS5", typeof(string));
	tsorting_siopeivainc.defineColumn("defaultv1", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultv2", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultv3", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultv4", typeof(decimal));
	tsorting_siopeivainc.defineColumn("defaultv5", typeof(decimal));
	tsorting_siopeivainc.defineColumn("description", typeof(string),false);
	tsorting_siopeivainc.defineColumn("flagnodate", typeof(string));
	tsorting_siopeivainc.defineColumn("lt", typeof(DateTime),false);
	tsorting_siopeivainc.defineColumn("lu", typeof(string),false);
	tsorting_siopeivainc.defineColumn("movkind", typeof(string));
	tsorting_siopeivainc.defineColumn("printingorder", typeof(string));
	tsorting_siopeivainc.defineColumn("rtf", typeof(Byte[]));
	tsorting_siopeivainc.defineColumn("sortcode", typeof(string),false);
	tsorting_siopeivainc.defineColumn("txt", typeof(string));
	tsorting_siopeivainc.defineColumn("idsorkind", typeof(int),false);
	tsorting_siopeivainc.defineColumn("idsor", typeof(int),false);
	tsorting_siopeivainc.defineColumn("paridsor", typeof(int));
	tsorting_siopeivainc.defineColumn("nlevel", typeof(byte),false);
	tsorting_siopeivainc.defineColumn("start", typeof(short));
	tsorting_siopeivainc.defineColumn("stop", typeof(short));
	tsorting_siopeivainc.defineColumn("email", typeof(string));
	Tables.Add(tsorting_siopeivainc);
	tsorting_siopeivainc.defineKey("idsor");

	//////////////////// CHARGEHANDLING /////////////////////////////////
	var tchargehandling= new MetaTable("chargehandling");
	tchargehandling.defineColumn("active", typeof(string));
	tchargehandling.defineColumn("ct", typeof(DateTime),false);
	tchargehandling.defineColumn("cu", typeof(string),false);
	tchargehandling.defineColumn("description", typeof(string),false);
	tchargehandling.defineColumn("lt", typeof(DateTime),false);
	tchargehandling.defineColumn("lu", typeof(string),false);
	tchargehandling.defineColumn("handlingbankcode", typeof(string));
	tchargehandling.defineColumn("flag", typeof(int));
	tchargehandling.defineColumn("idchargehandling", typeof(int),false);
	tchargehandling.defineColumn("motive", typeof(string));
	tchargehandling.defineColumn("payment_kind", typeof(string));
	Tables.Add(tchargehandling);
	tchargehandling.defineKey("idchargehandling");

	#endregion


	#region DataRelation creation
	var cPar = new []{accmotive_grantdeferredcost.Columns["idaccmotive"]};
	var cChild = new []{config.Columns["idaccmotive_grantdeferredcost"]};
	Relations.Add(new DataRelation("config_accmotive_grantdeferredcost",cPar,cChild,false));

	cPar = new []{accmotive_grantrevenue.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_grantrevenue"]};
	Relations.Add(new DataRelation("config_accmotive_grantrevenue",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{config.Columns["idivakind_forwarder"]};
	Relations.Add(new DataRelation("FK_ivakind_config",cPar,cChild,false));

	cPar = new []{accmotiveapplied_forwarder.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_forwarder"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_forwarder_config",cPar,cChild,false));

	this.defineRelation("FK_pccdebitstatus_config","pccdebitstatus","config","idpccdebitstatus");
	cPar = new []{sortingincomecsa.Columns["idsor"]};
	cChild = new []{config.Columns["idsiopeincome_csa"]};
	Relations.Add(new DataRelation("sortingincomecsa_config",cPar,cChild,false));

	cPar = new []{fin_store.Columns["idfin"]};
	cChild = new []{config.Columns["idfin_store"]};
	Relations.Add(new DataRelation("fin_store_config",cPar,cChild,false));

	this.defineRelation("inpscenter_config","inpscenter","config","idinpscenter");
	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{config.Columns["idsor3_stock"]};
	Relations.Add(new DataRelation("sorting3_config",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{config.Columns["idsor2_stock"]};
	Relations.Add(new DataRelation("sorting2_config",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{config.Columns["idsor1_stock"]};
	Relations.Add(new DataRelation("sorting1_config",cPar,cChild,false));

	cPar = new []{account_revenue_gross_csa.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_revenue_gross_csa"]};
	Relations.Add(new DataRelation("account_revenue_gross_csa_config",cPar,cChild,false));

	cPar = new []{fin_income_gross_csa.Columns["idfin"]};
	cChild = new []{config.Columns["idfinincome_gross_csa"]};
	Relations.Add(new DataRelation("fin_income_gross_csa_config",cPar,cChild,false));

	cPar = new []{mainbilanciorimborso.Columns["idfin"]};
	cChild = new []{config.Columns["mainidfinivarefund"]};
	Relations.Add(new DataRelation("FK_mainbilanciorimborso_config",cPar,cChild,false));

	cPar = new []{mainbilancioversamento.Columns["idfin"]};
	cChild = new []{config.Columns["mainidfinivapayment"]};
	Relations.Add(new DataRelation("FK_mainbilancioversamento_config",cPar,cChild,false));

	cPar = new []{maincreddebversamento.Columns["idreg"]};
	cChild = new []{config.Columns["mainpaymentagency"]};
	Relations.Add(new DataRelation("FK_maincreddebversamento_config",cPar,cChild,false));

	cPar = new []{maincreddebrimborso.Columns["idreg"]};
	cChild = new []{config.Columns["mainrefundagency"]};
	Relations.Add(new DataRelation("FK_maincreddebrimborso_config",cPar,cChild,false));

	cPar = new []{account_pl.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_pl"]};
	Relations.Add(new DataRelation("account_plentrysetup",cPar,cChild,false));

	cPar = new []{accmotiveapplied_foot.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_foot"]};
	Relations.Add(new DataRelation("accmotiveapplied_footitinerationsetup",cPar,cChild,false));

	cPar = new []{accmotiveapplied_owncar.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_owncar"]};
	Relations.Add(new DataRelation("accmotiveapplied_owncaritinerationsetup",cPar,cChild,false));

	cPar = new []{accmotiveapplied_admincar.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_admincar"]};
	Relations.Add(new DataRelation("accmotiveapplied_admincaritinerationsetup",cPar,cChild,false));

	this.defineRelation("clawbackitinerationsetup","clawback","config","idclawback");
	cPar = new []{bilanciospesa.Columns["idfin"]};
	cChild = new []{config.Columns["idfinexpense"]};
	Relations.Add(new DataRelation("bilanciospesaitinerationsetup",cPar,cChild,false));

	cPar = new []{creddebversamento.Columns["idreg"]};
	cChild = new []{config.Columns["paymentagency"]};
	Relations.Add(new DataRelation("registryinvoicesetup",cPar,cChild,false));

	cPar = new []{creddebrimborso.Columns["idreg"]};
	cChild = new []{config.Columns["refundagency"]};
	Relations.Add(new DataRelation("creddebrimborsoinvoicesetup",cPar,cChild,false));

	this.defineRelation("ivapayperiodicityinvoicesetup","ivapayperiodicity","config","idivapayperiodicity");
	cPar = new []{finlevel1.Columns["ayear"], finlevel1.Columns["nlevel"]};
	cChild = new []{config.Columns["ayear"], config.Columns["proceeds_finlevel"]};
	Relations.Add(new DataRelation("finlevelincomesetup",cPar,cChild,false));

	cPar = new []{incomephase1.Columns["nphase"]};
	cChild = new []{config.Columns["incomephase"]};
	Relations.Add(new DataRelation("incomephaseincomesetup",cPar,cChild,false));

	cPar = new []{incomephase.Columns["nphase"]};
	cChild = new []{config.Columns["assessmentphasecode"]};
	Relations.Add(new DataRelation("incomephasefinsetup",cPar,cChild,false));

	cPar = new []{expensephase1.Columns["nphase"]};
	cChild = new []{config.Columns["appropriationphasecode"]};
	Relations.Add(new DataRelation("expensephasefinsetup",cPar,cChild,false));

	cPar = new []{finlevel.Columns["ayear"], finlevel.Columns["nlevel"]};
	cChild = new []{config.Columns["ayear"], config.Columns["payment_finlevel"]};
	Relations.Add(new DataRelation("finlevelexpensesetup",cPar,cChild,false));

	cPar = new []{sortingkind1.Columns["idsorkind"]};
	cChild = new []{config.Columns["idsortingkind1"]};
	Relations.Add(new DataRelation("sortingkindexpensesetup",cPar,cChild,false));

	cPar = new []{sortingkind2.Columns["idsorkind"]};
	cChild = new []{config.Columns["idsortingkind2"]};
	Relations.Add(new DataRelation("sortingkind2expensesetup",cPar,cChild,false));

	cPar = new []{sortingkind3.Columns["idsorkind"]};
	cChild = new []{config.Columns["idsortingkind3"]};
	Relations.Add(new DataRelation("sortingkind3expensesetup",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{config.Columns["idregauto"]};
	Relations.Add(new DataRelation("registryexpensesetup",cPar,cChild,false));

	cPar = new []{expensephase.Columns["nphase"]};
	cChild = new []{config.Columns["expensephase"]};
	Relations.Add(new DataRelation("expensephaseexpensesetup",cPar,cChild,false));

	cPar = new []{account_ivapayment.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_ivapayment"]};
	Relations.Add(new DataRelation("account_ivapaymententrysetup",cPar,cChild,false));

	cPar = new []{account_supplier.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_supplier"]};
	Relations.Add(new DataRelation("account_supplierentrysetup",cPar,cChild,false));

	cPar = new []{account_ivarefund.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_ivarefund"]};
	Relations.Add(new DataRelation("account_ivarefundentrysetup",cPar,cChild,false));

	cPar = new []{account_customer.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_customer"]};
	Relations.Add(new DataRelation("account_customerentrysetup",cPar,cChild,false));

	cPar = new []{account_deferredcost.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_deferredcost"]};
	Relations.Add(new DataRelation("account_deferredcostentrysetup",cPar,cChild,false));

	cPar = new []{account_deferredrevenue.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_deferredrevenue"]};
	Relations.Add(new DataRelation("account_deferredrevenueentrysetup",cPar,cChild,false));

	cPar = new []{account_accruedcost.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_accruedcost"]};
	Relations.Add(new DataRelation("account_accruedcostentrysetup",cPar,cChild,false));

	cPar = new []{account_accruedrevenue.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_accruedrevenue"]};
	Relations.Add(new DataRelation("account_accruedrevenueentrysetup",cPar,cChild,false));

	cPar = new []{account_pat.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_patrimony"]};
	Relations.Add(new DataRelation("account_patentrysetup",cPar,cChild,false));

	cPar = new []{bilanciorimborso.Columns["idfin"]};
	cChild = new []{config.Columns["idfinivarefund"]};
	Relations.Add(new DataRelation("bilanciorimborsoinvoicesetup",cPar,cChild,false));

	cPar = new []{bilancioversamento.Columns["idfin"]};
	cChild = new []{config.Columns["idfinivapayment"]};
	Relations.Add(new DataRelation("bilancioversamentoinvoicesetup",cPar,cChild,false));

	cPar = new []{paymethodabi.Columns["idpaymethod"]};
	cChild = new []{config.Columns["idpaymethodabi"]};
	Relations.Add(new DataRelation("paymethodabi_config",cPar,cChild,false));

	cPar = new []{paymethodnoabi.Columns["idpaymethod"]};
	cChild = new []{config.Columns["idpaymethodnoabi"]};
	Relations.Add(new DataRelation("paymethodnoabi_config",cPar,cChild,false));

	cPar = new []{account_unabatable_rimborso.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_unabatable_refund"]};
	Relations.Add(new DataRelation("account_unabatable_rimborso_config",cPar,cChild,false));

	cPar = new []{account_unabatable_versamento.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_unabatable"]};
	Relations.Add(new DataRelation("account_unabatableentrysetup",cPar,cChild,false));

	cPar = new []{account_mainunabatable_versamento.Columns["idacc"]};
	cChild = new []{config.Columns["mainidacc_unabatable"]};
	Relations.Add(new DataRelation("FK_account_mainunabatable_versamento_config",cPar,cChild,false));

	cPar = new []{account_mainunabatable_rimborso.Columns["idacc"]};
	cChild = new []{config.Columns["mainidacc_unabatable_refund"]};
	Relations.Add(new DataRelation("FK_account_mainunabatable_rimborso_config",cPar,cChild,false));

	cPar = new []{account_mainivarefund.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivarefund"]};
	Relations.Add(new DataRelation("FK_account_mainivarefund_config",cPar,cChild,false));

	cPar = new []{account_mainivarefund_internal.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivarefund_internal"]};
	Relations.Add(new DataRelation("FK_account_mainivarefund_internal_config",cPar,cChild,false));

	cPar = new []{account_mainivapayment.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivapayment"]};
	Relations.Add(new DataRelation("FK_account_mainivapayment_config",cPar,cChild,false));

	cPar = new []{account_mainivapayment_internal.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivapayment_internal"]};
	Relations.Add(new DataRelation("FK_account_mainivapayment_internal_config",cPar,cChild,false));

	cPar = new []{account_mainivapayment_internal12.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivapayment_internal12"]};
	Relations.Add(new DataRelation("FK_account_mainivapayment_internal12_config",cPar,cChild,false));

	cPar = new []{account_mainivapayment12.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivapayment12"]};
	Relations.Add(new DataRelation("FK_account_mainivapayment12_config",cPar,cChild,false));

	cPar = new []{account_mainivarefund_internal12.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivarefund_internal12"]};
	Relations.Add(new DataRelation("FK_account_mainivarefund_internal12_config",cPar,cChild,false));

	cPar = new []{account_ivapayment12.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_ivapayment12"]};
	Relations.Add(new DataRelation("FK_account_ivapayment12_config",cPar,cChild,false));

	cPar = new []{account_mainivarefund12.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_mainivarefund12"]};
	Relations.Add(new DataRelation("FK_account_mainivarefund12_config",cPar,cChild,false));

	cPar = new []{creddebversamento12.Columns["idreg"]};
	cChild = new []{config.Columns["paymentagency12"]};
	Relations.Add(new DataRelation("FK_creddebversamento12 _config",cPar,cChild,false));

	cPar = new []{creddebrimborso12.Columns["idreg"]};
	cChild = new []{config.Columns["refundagency12"]};
	Relations.Add(new DataRelation("FK_creddebrimborso12_config",cPar,cChild,false));

	cPar = new []{account_ivarefund12.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_ivarefund12"]};
	Relations.Add(new DataRelation("FK_account_ivarefund12_config",cPar,cChild,false));

	cPar = new []{mainbilanciorimborso12.Columns["idfin"]};
	cChild = new []{config.Columns["mainidfinivarefund12"]};
	Relations.Add(new DataRelation("FK_mainbilanciorimborso12_config1",cPar,cChild,false));

	cPar = new []{mainbilancioversamento12.Columns["idfin"]};
	cChild = new []{config.Columns["mainidfinivapayment12"]};
	Relations.Add(new DataRelation("FK_mainbilancioversamento12_config1",cPar,cChild,false));

	cPar = new []{maincreddebrimborso12.Columns["idreg"]};
	cChild = new []{config.Columns["mainrefundagency12"]};
	Relations.Add(new DataRelation("FK_maincreddebrimborso12_config",cPar,cChild,false));

	cPar = new []{maincreddebversamento12.Columns["idreg"]};
	cChild = new []{config.Columns["mainpaymentagency12"]};
	Relations.Add(new DataRelation("FK_maincreddebversamento12_config",cPar,cChild,false));

	cPar = new []{bilancioversamento12.Columns["idfin"]};
	cChild = new []{config.Columns["idfinivapayment12"]};
	Relations.Add(new DataRelation("FK_mainbilancioversamento12_config",cPar,cChild,false));

	cPar = new []{bilanciorimborso12.Columns["idfin"]};
	cChild = new []{config.Columns["idfinivarefund12"]};
	Relations.Add(new DataRelation("FK_mainbilanciorimborso12_config",cPar,cChild,false));

	cPar = new []{registry_csa.Columns["idreg"]};
	cChild = new []{config.Columns["idreg_csa"]};
	Relations.Add(new DataRelation("registry_csa_config",cPar,cChild,false));

	cPar = new []{account_invoicetoreceive.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_invoicetoreceive"]};
	Relations.Add(new DataRelation("account_invoicetoreceive_config",cPar,cChild,false));

	cPar = new []{account_invoicetoemit.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_invoicetoemit"]};
	Relations.Add(new DataRelation("account_invoicetoemit_config",cPar,cChild,false));

	cPar = new []{account_unabatable_split.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_unabatable_split"]};
	Relations.Add(new DataRelation("account_unabatable_split_config",cPar,cChild,false));

	cPar = new []{account_split_ivapayment.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_ivapaymentsplit"]};
	Relations.Add(new DataRelation("account_split_ivapayment_config",cPar,cChild,false));

	cPar = new []{mainbilancioversamentosplit.Columns["idfin"]};
	cChild = new []{config.Columns["idfinivapaymentsplit"]};
	Relations.Add(new DataRelation("mainbilancioversamentosplit_config",cPar,cChild,false));

	cPar = new []{maincreddebversamentosplit.Columns["idreg"]};
	cChild = new []{config.Columns["paymentagencysplit"]};
	Relations.Add(new DataRelation("maincreddebversamentosplit_config",cPar,cChild,false));

	cPar = new []{account_previous_economic_result.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_previous_economic_result"]};
	Relations.Add(new DataRelation("account_previous_economic_result_config",cPar,cChild,false));

	cPar = new []{account_economic_result.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_economic_result"]};
	Relations.Add(new DataRelation("account_economic_result_config",cPar,cChild,false));

	cPar = new []{account_bankpaydoc.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_bankpaydoc"]};
	Relations.Add(new DataRelation("account_bankpaydoc_config",cPar,cChild,false));

	cPar = new []{account_bankprodoc.Columns["idacc"]};
	cChild = new []{config.Columns["idacc_bankprodoc"]};
	Relations.Add(new DataRelation("account_bankprodoc_config",cPar,cChild,false));

	cPar = new []{accmotiveapplied_assetrevenue.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_assetrevenue"]};
	Relations.Add(new DataRelation("accmotiveapplied_assetrevenue_config",cPar,cChild,false));

	cPar = new []{accmotiveapplied_prorata_cost.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_prorata_cost"]};
	Relations.Add(new DataRelation("accmotiveapplied_prorata_cost_config",cPar,cChild,false));

	cPar = new []{accmotiveapplied_prorata_revenue.Columns["idaccmotive"]};
	cChild = new []{config.Columns["idaccmotive_prorata_revenue"]};
	Relations.Add(new DataRelation("accmotiveapplied_prorata_revenue_config",cPar,cChild,false));

	cPar = new []{sorting_siopeivasplitexp.Columns["idsor"]};
	cChild = new []{config.Columns["idsor_siopeivasplitexp"]};
	Relations.Add(new DataRelation("sorting_siopeivasplitexp_config",cPar,cChild,false));

	cPar = new []{sorting_siopeiva12exp.Columns["idsor"]};
	cChild = new []{config.Columns["idsor_siopeiva12exp"]};
	Relations.Add(new DataRelation("sorting_siopeiva12exp_config",cPar,cChild,false));

	cPar = new []{sorting_siopeivaexp.Columns["idsor"]};
	cChild = new []{config.Columns["idsor_siopeivaexp"]};
	Relations.Add(new DataRelation("sorting_siopeivaexp_config",cPar,cChild,false));

	cPar = new []{sorting_siopeiva12inc.Columns["idsor"]};
	cChild = new []{config.Columns["idsor_siopeiva12inc"]};
	Relations.Add(new DataRelation("sorting_siopeiva12inc_config",cPar,cChild,false));

	cPar = new []{sorting_siopeivainc.Columns["idsor"]};
	cChild = new []{config.Columns["idsor_siopeivainc"]};
	Relations.Add(new DataRelation("sorting_siopeivainc_config",cPar,cChild,false));

	cPar = new []{chargehandling.Columns["idchargehandling"]};
	cChild = new []{config.Columns["csa_idchargehandling"]};
	Relations.Add(new DataRelation("chargehandling_config",cPar,cChild,false));

	#endregion

}
}
}
