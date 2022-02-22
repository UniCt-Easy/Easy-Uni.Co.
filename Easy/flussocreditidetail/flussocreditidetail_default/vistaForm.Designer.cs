
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using meta_estimatekind;
using meta_flussocreditidetail;
using meta_invoicekind;
using meta_accmotiveapplied;
using meta_upb;
using meta_sorting;
using meta_ivakind;
using meta_list;
using meta_flussocrediti;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace flussocreditidetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind 		=> (estimatekindTable)Tables["estimatekind"];

	///<summary>
	///Dettaglio flusso crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditidetailTable flussocreditidetail 		=> (flussocreditidetailTable)Tables["flussocreditidetail"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public invoicekindTable invoicekind 		=> (invoicekindTable)Tables["invoicekind"];

	///<summary>
	///Causali finanziarie (gerarchia)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive_income 		=> (MetaTable)Tables["finmotive_income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_credit 		=> (accmotiveappliedTable)Tables["accmotiveapplied_credit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_revenue 		=> (accmotiveappliedTable)Tables["accmotiveapplied_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_undotax 		=> (accmotiveappliedTable)Tables["accmotiveapplied_undotax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied_undotaxpost 		=> (accmotiveappliedTable)Tables["accmotiveapplied_undotaxpost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymainview 		=> (MetaTable)Tables["registrymainview"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

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
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public ivakindTable ivakind 		=> (ivakindTable)Tables["ivakind"];

	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public listTable list 		=> (listTable)Tables["list"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb_iva 		=> (MetaTable)Tables["upb_iva"];

	///<summary>
	///Crediti da comunicare al nodo pagamenti o simili, anche usata per i crediti che ci vengono comunicati dalle segreterie studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditiTable flussocrediti 		=> (flussocreditiTable)Tables["flussocrediti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive_iva_income 		=> (MetaTable)Tables["finmotive_iva_income"];

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
	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new estimatekindTable();
	testimatekind.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","linktoinvoice","multireg","deltaamount","deltapercentage","flag_autodocnumbering","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","idivakind_forced","flag");
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	//////////////////// FLUSSOCREDITIDETAIL /////////////////////////////////
	var tflussocreditidetail= new flussocreditidetailTable();
	tflussocreditidetail.addBaseColumns("idflusso","iddetail","cu","ct","lu","lt","importoversamento","idestimkind","yestim","nestim","rownum","idinvkind","yinv","ninv","invrownum","competencystart","competencystop","description","idaccmotivecredit","idaccmotiverevenue","idaccmotiveundotax","idaccmotiveundotaxpost","idfinmotive","idreg","iduniqueformcode","idupb","nform","stop","expirationdate","cf","iuv","annulment","idunivoco","codiceavviso","idsor1","idsor2","idsor3","tax","barcodevalue","barcodeimage","qrcodevalue","qrcodeimage","idivakind","number","p_iva","annotations","idlist","idupb_iva","flag","codicetassonomia","flag_showcase","idfinmotive_iva");
	Tables.Add(tflussocreditidetail);
	tflussocreditidetail.defineKey("idflusso", "iddetail");

	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new invoicekindTable();
	tinvoicekind.addBaseColumns("ct","cu","description","lt","lu","codeinvkind","idinvkind","flag","flag_autodocnumbering","formatstring","active","idinvkind_auto","printingcode","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","notes1","notes2","notes3","ipa_fe","riferimento_amministrazione","enable_fe");
	Tables.Add(tinvoicekind);
	tinvoicekind.defineKey("idinvkind");

	//////////////////// FINMOTIVE_INCOME /////////////////////////////////
	var tfinmotive_income= new MetaTable("finmotive_income");
	tfinmotive_income.defineColumn("idfinmotive", typeof(string),false);
	tfinmotive_income.defineColumn("active", typeof(string),false);
	tfinmotive_income.defineColumn("codemotive", typeof(string),false);
	tfinmotive_income.defineColumn("paridfinmotive", typeof(string));
	tfinmotive_income.defineColumn("title", typeof(string),false);
	tfinmotive_income.defineColumn("lt", typeof(DateTime));
	tfinmotive_income.defineColumn("lu", typeof(string));
	tfinmotive_income.defineColumn("ct", typeof(DateTime));
	tfinmotive_income.defineColumn("cu", typeof(string));
	tfinmotive_income.ExtendedProperties["TableForReading"]="finmotive";
	Tables.Add(tfinmotive_income);
	tfinmotive_income.defineKey("idfinmotive");

	//////////////////// ACCMOTIVEAPPLIED_CREDIT /////////////////////////////////
	var taccmotiveapplied_credit= new accmotiveappliedTable();
	taccmotiveapplied_credit.TableName = "accmotiveapplied_credit";
	taccmotiveapplied_credit.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep","expensekind");
	taccmotiveapplied_credit.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_credit);
	taccmotiveapplied_credit.defineKey("idepoperation", "idaccmotive");

	//////////////////// ACCMOTIVEAPPLIED_REVENUE /////////////////////////////////
	var taccmotiveapplied_revenue= new accmotiveappliedTable();
	taccmotiveapplied_revenue.TableName = "accmotiveapplied_revenue";
	taccmotiveapplied_revenue.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep","expensekind");
	taccmotiveapplied_revenue.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_revenue);
	taccmotiveapplied_revenue.defineKey("idaccmotive", "idepoperation");

	//////////////////// ACCMOTIVEAPPLIED_UNDOTAX /////////////////////////////////
	var taccmotiveapplied_undotax= new accmotiveappliedTable();
	taccmotiveapplied_undotax.TableName = "accmotiveapplied_undotax";
	taccmotiveapplied_undotax.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep","expensekind");
	taccmotiveapplied_undotax.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_undotax);
	taccmotiveapplied_undotax.defineKey("idaccmotive", "idepoperation");

	//////////////////// ACCMOTIVEAPPLIED_UNDOTAXPOST /////////////////////////////////
	var taccmotiveapplied_undotaxpost= new accmotiveappliedTable();
	taccmotiveapplied_undotaxpost.TableName = "accmotiveapplied_undotaxpost";
	taccmotiveapplied_undotaxpost.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagamm","flagdep","expensekind");
	taccmotiveapplied_undotaxpost.ExtendedProperties["TableForReading"]="accmotiveapplied";
	Tables.Add(taccmotiveapplied_undotaxpost);
	taccmotiveapplied_undotaxpost.defineKey("idaccmotive", "idepoperation");

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
	tregistrymainview.defineColumn("coderesidence", typeof(string));
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
	tregistrymainview.defineColumn("idregistrykind", typeof(int));
	tregistrymainview.defineColumn("sortcode", typeof(string));
	tregistrymainview.defineColumn("registrykind", typeof(string));
	tregistrymainview.defineColumn("human", typeof(string));
	tregistrymainview.defineColumn("active", typeof(string),false);
	tregistrymainview.defineColumn("badgecode", typeof(string));
	tregistrymainview.defineColumn("maritalsurname", typeof(string));
	tregistrymainview.defineColumn("idcategory", typeof(string));
	tregistrymainview.defineColumn("category", typeof(string));
	tregistrymainview.defineColumn("extmatricula", typeof(string));
	tregistrymainview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrymainview.defineColumn("cu", typeof(string),false);
	tregistrymainview.defineColumn("ct", typeof(DateTime),false);
	tregistrymainview.defineColumn("lu", typeof(string),false);
	tregistrymainview.defineColumn("lt", typeof(DateTime),false);
	tregistrymainview.defineColumn("location", typeof(string));
	tregistrymainview.defineColumn("idnation", typeof(int));
	tregistrymainview.defineColumn("nation", typeof(string));
	tregistrymainview.defineColumn("authorization_free", typeof(string));
	tregistrymainview.defineColumn("multi_cf", typeof(string));
	tregistrymainview.defineColumn("toredirect", typeof(int));
	tregistrymainview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrymainview.defineColumn("codemotivedebit", typeof(string));
	tregistrymainview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrymainview.defineColumn("codemotivecredit", typeof(string));
	tregistrymainview.defineColumn("ccp", typeof(string));
	tregistrymainview.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistrymainview.defineColumn("ipa_fe", typeof(string));
	tregistrymainview.defineColumn("flag_pa", typeof(string));
	tregistrymainview.defineColumn("sdi_norifamm", typeof(string));
	tregistrymainview.defineColumn("sdi_defrifamm", typeof(string));
	Tables.Add(tregistrymainview);
	tregistrymainview.defineKey("idreg");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode","idepupbkind");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new sortingTable();
	tsorting3.TableName = "sorting3";
	tsorting3.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting3.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new sortingTable();
	tsorting1.TableName = "sorting1";
	tsorting1.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting1.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new sortingTable();
	tsorting2.TableName = "sorting2";
	tsorting2.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop","email");
	tsorting2.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new ivakindTable();
	tivakind.addBaseColumns("ct","cu","description","lt","lu","rate","unabatabilitypercentage","active","idivataxablekind","idivakind","codeivakind","flag","annotations","idfenature");
	Tables.Add(tivakind);
	tivakind.defineKey("idivakind");

	//////////////////// LIST /////////////////////////////////
	var tlist= new listTable();
	tlist.addBaseColumns("idlist","description","intcode","intbarcode","extcode","extbarcode","validitystop","active","idpackage","idunit","unitsforpackage","has_expiry","cu","ct","lu","lt","idlistclass","pic","picext","nmin","ntoreorder","tounload","timesupply","nmaxorder","price","insinfo","descrforuser");
	Tables.Add(tlist);
	tlist.defineKey("idlist");

	//////////////////// UPB_IVA /////////////////////////////////
	var tupb_iva= new MetaTable("upb_iva");
	tupb_iva.defineColumn("idupb", typeof(string),false);
	tupb_iva.defineColumn("active", typeof(string));
	tupb_iva.defineColumn("assured", typeof(string));
	tupb_iva.defineColumn("codeupb", typeof(string),false);
	tupb_iva.defineColumn("ct", typeof(DateTime),false);
	tupb_iva.defineColumn("cu", typeof(string),false);
	tupb_iva.defineColumn("expiration", typeof(DateTime));
	tupb_iva.defineColumn("granted", typeof(decimal));
	tupb_iva.defineColumn("lt", typeof(DateTime),false);
	tupb_iva.defineColumn("lu", typeof(string),false);
	tupb_iva.defineColumn("paridupb", typeof(string));
	tupb_iva.defineColumn("previousappropriation", typeof(decimal));
	tupb_iva.defineColumn("previousassessment", typeof(decimal));
	tupb_iva.defineColumn("printingorder", typeof(string),false);
	tupb_iva.defineColumn("requested", typeof(decimal));
	tupb_iva.defineColumn("rtf", typeof(Byte[]));
	tupb_iva.defineColumn("title", typeof(string),false);
	tupb_iva.defineColumn("txt", typeof(string));
	tupb_iva.defineColumn("idman", typeof(int));
	tupb_iva.defineColumn("idunderwriter", typeof(int));
	tupb_iva.defineColumn("cupcode", typeof(string));
	tupb_iva.defineColumn("idsor01", typeof(int));
	tupb_iva.defineColumn("idsor02", typeof(int));
	tupb_iva.defineColumn("idsor03", typeof(int));
	tupb_iva.defineColumn("idsor04", typeof(int));
	tupb_iva.defineColumn("idsor05", typeof(int));
	tupb_iva.defineColumn("flagactivity", typeof(short));
	tupb_iva.defineColumn("flagkind", typeof(byte));
	tupb_iva.defineColumn("newcodeupb", typeof(string));
	tupb_iva.defineColumn("idtreasurer", typeof(int));
	tupb_iva.defineColumn("start", typeof(DateTime));
	tupb_iva.defineColumn("stop", typeof(DateTime));
	tupb_iva.defineColumn("cigcode", typeof(string));
	tupb_iva.defineColumn("idepupbkind", typeof(int));
	tupb_iva.defineColumn("flag", typeof(int));
	Tables.Add(tupb_iva);
	tupb_iva.defineKey("idupb");

	//////////////////// FLUSSOCREDITI /////////////////////////////////
	var tflussocrediti= new flussocreditiTable();
	tflussocrediti.addBaseColumns("idflusso","cu","ct","lu","lt","datacreazioneflusso","flusso","istransmitted","idsor01","idsor02","idsor03","idsor04","idsor05","filename","progday","docdate","idestimkind");
	Tables.Add(tflussocrediti);
	tflussocrediti.defineKey("idflusso");

	//////////////////// FINMOTIVE_IVA_INCOME /////////////////////////////////
	var tfinmotive_iva_income= new MetaTable("finmotive_iva_income");
	tfinmotive_iva_income.defineColumn("idfinmotive", typeof(string),false);
	tfinmotive_iva_income.defineColumn("active", typeof(string),false);
	tfinmotive_iva_income.defineColumn("codemotive", typeof(string),false);
	tfinmotive_iva_income.defineColumn("paridfinmotive", typeof(string));
	tfinmotive_iva_income.defineColumn("title", typeof(string),false);
	tfinmotive_iva_income.defineColumn("lt", typeof(DateTime));
	tfinmotive_iva_income.defineColumn("lu", typeof(string));
	tfinmotive_iva_income.defineColumn("ct", typeof(DateTime));
	tfinmotive_iva_income.defineColumn("cu", typeof(string));
	Tables.Add(tfinmotive_iva_income);
	tfinmotive_iva_income.defineKey("idfinmotive");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_upb_flussocreditidetail","upb","flussocreditidetail","idupb");
	this.defineRelation("FK_registrymainview_flussocreditidetail","registrymainview","flussocreditidetail","idreg");
	var cPar = new []{accmotiveapplied_undotaxpost.Columns["idaccmotive"]};
	var cChild = new []{flussocreditidetail.Columns["idaccmotiveundotaxpost"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_undotaxpost_flussocreditidetail",cPar,cChild,false));

	cPar = new []{accmotiveapplied_undotax.Columns["idaccmotive"]};
	cChild = new []{flussocreditidetail.Columns["idaccmotiveundotax"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_undotax_flussocreditidetail",cPar,cChild,false));

	cPar = new []{accmotiveapplied_revenue.Columns["idaccmotive"]};
	cChild = new []{flussocreditidetail.Columns["idaccmotiverevenue"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_revenue_flussocreditidetail",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{flussocreditidetail.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_credit_flussocreditidetail",cPar,cChild,false));

	this.defineRelation("FK_finmotive_income_flussocreditidetail","finmotive_income","flussocreditidetail","idfinmotive");
	this.defineRelation("FK_invoicekind_flussocreditidetail","invoicekind","flussocreditidetail","idinvkind");
	this.defineRelation("FK_estimatekind_flussocreditidetail","estimatekind","flussocreditidetail","idestimkind");
	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{flussocreditidetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_flussocreditidetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{flussocreditidetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_flussocreditidetail",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{flussocreditidetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_flussocreditidetail",cPar,cChild,false));

	this.defineRelation("ivakind_flussocreditidetail","ivakind","flussocreditidetail","idivakind");
	this.defineRelation("list_flussocreditidetail","list","flussocreditidetail","idlist");
	cPar = new []{upb_iva.Columns["idupb"]};
	cChild = new []{flussocreditidetail.Columns["idupb_iva"]};
	Relations.Add(new DataRelation("upb_iva_flussocreditidetail",cPar,cChild,false));

	this.defineRelation("flussocrediti_flussocreditidetail","flussocrediti","flussocreditidetail","idflusso");
	cPar = new []{finmotive_iva_income.Columns["idfinmotive"]};
	cChild = new []{flussocreditidetail.Columns["idfinmotive_iva"]};
	Relations.Add(new DataRelation("finmotive_iva_income_flussocreditidetail",cPar,cChild,false));

	#endregion

}
}
}
