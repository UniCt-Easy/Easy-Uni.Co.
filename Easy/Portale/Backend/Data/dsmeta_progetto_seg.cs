
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_progetto_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progetto_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcontratti 		=> (MetaTable)Tables["getcontratti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettofinanziamento 		=> (MetaTable)Tables["progettofinanziamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable currency 		=> (MetaTable)Tables["currency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable duratakinddefaultview 		=> (MetaTable)Tables["duratakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable partnerkinddefaultview 		=> (MetaTable)Tables["partnerkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaziendeview_alias1 		=> (MetaTable)Tables["registryaziendeview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokindsegview 		=> (MetaTable)Tables["progettokindsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strumentofindefaultview 		=> (MetaTable)Tables["strumentofindefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfinbandosegview 		=> (MetaTable)Tables["registryprogfinbandosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfinsegview 		=> (MetaTable)Tables["registryprogfinsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getprogettocostoview 		=> (MetaTable)Tables["getprogettocostoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettorp 		=> (MetaTable)Tables["progettorp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoproroga 		=> (MetaTable)Tables["progettoproroga"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable settoreerc 		=> (MetaTable)Tables["settoreerc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettosettoreerc 		=> (MetaTable)Tables["progettosettoreerc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaziendeview 		=> (MetaTable)Tables["registryaziendeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclass 		=> (MetaTable)Tables["registryclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable numerodip 		=> (MetaTable)Tables["numerodip"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable naturagiur 		=> (MetaTable)Tables["naturagiur"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nace 		=> (MetaTable)Tables["nace"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ateco 		=> (MetaTable)Tables["ateco"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_aziende 		=> (MetaTable)Tables["registry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable partnerkind 		=> (MetaTable)Tables["partnerkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoregistry_aziende 		=> (MetaTable)Tables["progettoregistry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoattach 		=> (MetaTable)Tables["progettoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotesto 		=> (MetaTable)Tables["progettotesto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoricavo 		=> (MetaTable)Tables["progettoricavo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettobudgetvariazione 		=> (MetaTable)Tables["progettobudgetvariazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettocosto 		=> (MetaTable)Tables["progettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage_alias2 		=> (MetaTable)Tables["workpackage_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto_alias2 		=> (MetaTable)Tables["progettotipocosto_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettobudget 		=> (MetaTable)Tables["progettobudget"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiaryora 		=> (MetaTable)Tables["assetdiaryora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetdiary 		=> (MetaTable)Tables["assetdiary"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackageupb 		=> (MetaTable)Tables["workpackageupb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoitineration 		=> (MetaTable)Tables["rendicontattivitaprogettoitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoyear 		=> (MetaTable)Tables["rendicontattivitaprogettoyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage 		=> (MetaTable)Tables["workpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudrmembro 		=> (MetaTable)Tables["progettoudrmembro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudr 		=> (MetaTable)Tables["progettoudr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventory 		=> (MetaTable)Tables["inventory"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inventorytree 		=> (MetaTable)Tables["inventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assetacquire 		=> (MetaTable)Tables["assetacquire"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable asset 		=> (MetaTable)Tables["asset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoasset 		=> (MetaTable)Tables["progettoasset"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettostatuskinddefaultview 		=> (MetaTable)Tables["progettostatuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavocontrattokind 		=> (MetaTable)Tables["progettotiporicavocontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotiporicavoaccmotive 		=> (MetaTable)Tables["progettotiporicavoaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostotax 		=> (MetaTable)Tables["progettotipocostotax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostoinventorytree 		=> (MetaTable)Tables["progettotipocostoinventorytree"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostocontrattokind 		=> (MetaTable)Tables["progettotipocostocontrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostoaccmotive 		=> (MetaTable)Tables["progettotipocostoaccmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocosto 		=> (MetaTable)Tables["progettotipocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progetto_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progetto_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progetto_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progetto_seg.xsd";

	#region create DataTables
	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("!budgetcalcolato", typeof(decimal));
	tsal.defineColumn("budget", typeof(decimal));
	tsal.defineColumn("datablocco", typeof(DateTime));
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// GETCONTRATTI /////////////////////////////////
	var tgetcontratti= new MetaTable("getcontratti");
	tgetcontratti.defineColumn("costolordoannuo", typeof(decimal),false);
	tgetcontratti.defineColumn("costomese", typeof(decimal));
	tgetcontratti.defineColumn("costoora", typeof(decimal));
	tgetcontratti.defineColumn("idcontratto", typeof(int),false);
	tgetcontratti.defineColumn("idcontrattokind", typeof(int),false);
	tgetcontratti.defineColumn("idinquadramento", typeof(int));
	tgetcontratti.defineColumn("idreg", typeof(int),false);
	tgetcontratti.defineColumn("oremax", typeof(int));
	tgetcontratti.defineColumn("oremaxdida", typeof(int));
	tgetcontratti.defineColumn("oremaxgg", typeof(int));
	tgetcontratti.defineColumn("oremindida", typeof(int));
	tgetcontratti.defineColumn("parttime", typeof(decimal));
	tgetcontratti.defineColumn("scatto", typeof(int));
	tgetcontratti.defineColumn("start", typeof(DateTime),false);
	tgetcontratti.defineColumn("stop", typeof(DateTime));
	tgetcontratti.defineColumn("tempdef", typeof(string),false);
	tgetcontratti.defineColumn("title", typeof(string),false);
	tgetcontratti.defineColumn("totale_inquadramento", typeof(decimal));
	tgetcontratti.defineColumn("totale_stipendioannuo", typeof(decimal));
	tgetcontratti.defineColumn("totale_tabellastipendiale", typeof(decimal));
	tgetcontratti.defineColumn("totale_tipologiacontrattuale", typeof(decimal));
	Tables.Add(tgetcontratti);
	tgetcontratti.defineKey("idcontratto");

	//////////////////// PROGETTOFINANZIAMENTO /////////////////////////////////
	var tprogettofinanziamento= new MetaTable("progettofinanziamento");
	tprogettofinanziamento.defineColumn("contributo", typeof(decimal));
	tprogettofinanziamento.defineColumn("contributoente", typeof(decimal));
	tprogettofinanziamento.defineColumn("ct", typeof(DateTime),false);
	tprogettofinanziamento.defineColumn("cu", typeof(string),false);
	tprogettofinanziamento.defineColumn("data", typeof(DateTime));
	tprogettofinanziamento.defineColumn("idprogetto", typeof(int),false);
	tprogettofinanziamento.defineColumn("idprogettofinanziamento", typeof(int),false);
	tprogettofinanziamento.defineColumn("lt", typeof(DateTime),false);
	tprogettofinanziamento.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettofinanziamento);
	tprogettofinanziamento.defineKey("idprogetto", "idprogettofinanziamento");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudiodefaultview.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudiodefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new MetaTable("currency");
	tcurrency.defineColumn("codecurrency", typeof(string));
	tcurrency.defineColumn("idcurrency", typeof(int),false);
	Tables.Add(tcurrency);
	tcurrency.defineKey("idcurrency");

	//////////////////// DURATAKINDDEFAULTVIEW /////////////////////////////////
	var tduratakinddefaultview= new MetaTable("duratakinddefaultview");
	tduratakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tduratakinddefaultview.defineColumn("duratakind_active", typeof(string));
	tduratakinddefaultview.defineColumn("idduratakind", typeof(int),false);
	Tables.Add(tduratakinddefaultview);
	tduratakinddefaultview.defineKey("idduratakind");

	//////////////////// PARTNERKINDDEFAULTVIEW /////////////////////////////////
	var tpartnerkinddefaultview= new MetaTable("partnerkinddefaultview");
	tpartnerkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpartnerkinddefaultview.defineColumn("idpartnerkind", typeof(int),false);
	tpartnerkinddefaultview.defineColumn("partnerkind_active", typeof(string));
	Tables.Add(tpartnerkinddefaultview);
	tpartnerkinddefaultview.defineKey("idpartnerkind");

	//////////////////// REGISTRYAZIENDEVIEW_ALIAS1 /////////////////////////////////
	var tregistryaziendeview_alias1= new MetaTable("registryaziendeview_alias1");
	tregistryaziendeview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tregistryaziendeview_alias1.defineColumn("idateco", typeof(int));
	tregistryaziendeview_alias1.defineColumn("idcategory", typeof(string));
	tregistryaziendeview_alias1.defineColumn("idcity", typeof(int));
	tregistryaziendeview_alias1.defineColumn("idnace", typeof(string));
	tregistryaziendeview_alias1.defineColumn("idnation", typeof(int));
	tregistryaziendeview_alias1.defineColumn("idnaturagiur", typeof(int));
	tregistryaziendeview_alias1.defineColumn("idnumerodip", typeof(int));
	tregistryaziendeview_alias1.defineColumn("idreg", typeof(int),false);
	tregistryaziendeview_alias1.defineColumn("idregistryclass", typeof(string));
	tregistryaziendeview_alias1.defineColumn("registry_active", typeof(string));
	tregistryaziendeview_alias1.defineColumn("residence", typeof(int),false);
	tregistryaziendeview_alias1.ExtendedProperties["TableForReading"]="registryaziendeview";
	Tables.Add(tregistryaziendeview_alias1);
	tregistryaziendeview_alias1.defineKey("idreg");

	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("idcity", typeof(int));
	tregistrydocentiview.defineColumn("idclassconsorsuale", typeof(int));
	tregistrydocentiview.defineColumn("idnation", typeof(int));
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("idreg_istituti", typeof(int));
	tregistrydocentiview.defineColumn("idregistryclass", typeof(string));
	tregistrydocentiview.defineColumn("idsasd", typeof(int));
	tregistrydocentiview.defineColumn("idstruttura", typeof(int));
	tregistrydocentiview.defineColumn("idtitle", typeof(string));
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// REGISTRYAMMINISTRATIVIVIEW /////////////////////////////////
	var tregistryamministrativiview= new MetaTable("registryamministrativiview");
	tregistryamministrativiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryamministrativiview.defineColumn("idcity", typeof(int));
	tregistryamministrativiview.defineColumn("idnation", typeof(int));
	tregistryamministrativiview.defineColumn("idreg", typeof(int),false);
	tregistryamministrativiview.defineColumn("idtitle", typeof(string));
	tregistryamministrativiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryamministrativiview);
	tregistryamministrativiview.defineKey("idreg");

	//////////////////// PROGETTOKINDSEGVIEW /////////////////////////////////
	var tprogettokindsegview= new MetaTable("progettokindsegview");
	tprogettokindsegview.defineColumn("dropdown_title", typeof(string),false);
	tprogettokindsegview.defineColumn("idprogettokind", typeof(int),false);
	tprogettokindsegview.defineColumn("progettoactivitykind_title", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_ct", typeof(DateTime));
	tprogettokindsegview.defineColumn("progettokind_cu", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_description", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_idcorsostudio", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_idprogettoactivitykind", typeof(int));
	tprogettokindsegview.defineColumn("progettokind_lt", typeof(DateTime));
	tprogettokindsegview.defineColumn("progettokind_lu", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_oredivisionecostostipendio", typeof(int));
	tprogettokindsegview.defineColumn("progettokind_stipendioannoprec", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_stipendiocomericavo", typeof(string));
	tprogettokindsegview.defineColumn("title", typeof(string));
	Tables.Add(tprogettokindsegview);
	tprogettokindsegview.defineKey("idprogettokind");

	//////////////////// STRUMENTOFINDEFAULTVIEW /////////////////////////////////
	var tstrumentofindefaultview= new MetaTable("strumentofindefaultview");
	tstrumentofindefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrumentofindefaultview.defineColumn("idstrumentofin", typeof(int),false);
	tstrumentofindefaultview.defineColumn("strumentofin_active", typeof(string));
	Tables.Add(tstrumentofindefaultview);
	tstrumentofindefaultview.defineKey("idstrumentofin");

	//////////////////// REGISTRYPROGFINBANDOSEGVIEW /////////////////////////////////
	var tregistryprogfinbandosegview= new MetaTable("registryprogfinbandosegview");
	tregistryprogfinbandosegview.defineColumn("dropdown_title", typeof(string),false);
	tregistryprogfinbandosegview.defineColumn("idreg", typeof(int),false);
	tregistryprogfinbandosegview.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfinbandosegview.defineColumn("idregistryprogfinbando", typeof(int),false);
	Tables.Add(tregistryprogfinbandosegview);
	tregistryprogfinbandosegview.defineKey("idreg", "idregistryprogfin", "idregistryprogfinbando");

	//////////////////// REGISTRYPROGFINSEGVIEW /////////////////////////////////
	var tregistryprogfinsegview= new MetaTable("registryprogfinsegview");
	tregistryprogfinsegview.defineColumn("dropdown_title", typeof(string),false);
	tregistryprogfinsegview.defineColumn("idreg", typeof(int),false);
	tregistryprogfinsegview.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_code", typeof(string));
	tregistryprogfinsegview.defineColumn("registryprogfin_ct", typeof(DateTime),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_cu", typeof(string),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_description", typeof(string));
	tregistryprogfinsegview.defineColumn("registryprogfin_lt", typeof(DateTime),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_lu", typeof(string),false);
	tregistryprogfinsegview.defineColumn("title", typeof(string));
	Tables.Add(tregistryprogfinsegview);
	tregistryprogfinsegview.defineKey("idreg", "idregistryprogfin");

	//////////////////// GETPROGETTOCOSTOVIEW /////////////////////////////////
	var tgetprogettocostoview= new MetaTable("getprogettocostoview");
	tgetprogettocostoview.defineColumn("adate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("ammissibilita", typeof(decimal));
	tgetprogettocostoview.defineColumn("amount", typeof(decimal));
	tgetprogettocostoview.defineColumn("cf", typeof(string));
	tgetprogettocostoview.defineColumn("contrattokind_title", typeof(string));
	tgetprogettocostoview.defineColumn("description", typeof(string));
	tgetprogettocostoview.defineColumn("doc", typeof(string));
	tgetprogettocostoview.defineColumn("docdate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("idgetprogettocostoview", typeof(int),false);
	tgetprogettocostoview.defineColumn("idprogetto", typeof(int),false);
	tgetprogettocostoview.defineColumn("nmov", typeof(int));
	tgetprogettocostoview.defineColumn("noperation", typeof(int));
	tgetprogettocostoview.defineColumn("p_iva", typeof(string));
	tgetprogettocostoview.defineColumn("payment_adate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("pettycash_description", typeof(string));
	tgetprogettocostoview.defineColumn("pettycash_pettycode", typeof(string));
	tgetprogettocostoview.defineColumn("progettotipocosto_title", typeof(string));
	tgetprogettocostoview.defineColumn("raggruppamento", typeof(string));
	tgetprogettocostoview.defineColumn("registry_title", typeof(string));
	tgetprogettocostoview.defineColumn("rendicontattivitaprogetto_description", typeof(string));
	tgetprogettocostoview.defineColumn("transactiondate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("transmissiondate", typeof(DateTime));
	tgetprogettocostoview.defineColumn("workpackage_title", typeof(string));
	tgetprogettocostoview.defineColumn("ymov", typeof(int));
	tgetprogettocostoview.defineColumn("yoperation", typeof(int));
	tgetprogettocostoview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tgetprogettocostoview);
	tgetprogettocostoview.defineKey("idgetprogettocostoview", "idprogetto");

	//////////////////// PROGETTORP /////////////////////////////////
	var tprogettorp= new MetaTable("progettorp");
	tprogettorp.defineColumn("datefilter", typeof(string));
	tprogettorp.defineColumn("idprogetto", typeof(int),false);
	tprogettorp.defineColumn("idprogettorp", typeof(int),false);
	tprogettorp.defineColumn("start", typeof(DateTime));
	tprogettorp.defineColumn("stop", typeof(DateTime));
	Tables.Add(tprogettorp);
	tprogettorp.defineKey("idprogetto", "idprogettorp");

	//////////////////// PROGETTOPROROGA /////////////////////////////////
	var tprogettoproroga= new MetaTable("progettoproroga");
	tprogettoproroga.defineColumn("ct", typeof(DateTime),false);
	tprogettoproroga.defineColumn("cu", typeof(string),false);
	tprogettoproroga.defineColumn("idprogetto", typeof(int),false);
	tprogettoproroga.defineColumn("idprogettoproroga", typeof(int),false);
	tprogettoproroga.defineColumn("lt", typeof(DateTime),false);
	tprogettoproroga.defineColumn("lu", typeof(string),false);
	tprogettoproroga.defineColumn("motivazioni", typeof(string));
	tprogettoproroga.defineColumn("proroga", typeof(DateTime));
	Tables.Add(tprogettoproroga);
	tprogettoproroga.defineKey("idprogetto", "idprogettoproroga");

	//////////////////// SETTOREERC /////////////////////////////////
	var tsettoreerc= new MetaTable("settoreerc");
	tsettoreerc.defineColumn("active", typeof(string));
	tsettoreerc.defineColumn("ct", typeof(DateTime));
	tsettoreerc.defineColumn("cu", typeof(string));
	tsettoreerc.defineColumn("description", typeof(string));
	tsettoreerc.defineColumn("idsettoreerc", typeof(int),false);
	tsettoreerc.defineColumn("lt", typeof(DateTime));
	tsettoreerc.defineColumn("lu", typeof(string));
	tsettoreerc.defineColumn("sortcode", typeof(int));
	tsettoreerc.defineColumn("title", typeof(string));
	Tables.Add(tsettoreerc);
	tsettoreerc.defineKey("idsettoreerc");

	//////////////////// PROGETTOSETTOREERC /////////////////////////////////
	var tprogettosettoreerc= new MetaTable("progettosettoreerc");
	tprogettosettoreerc.defineColumn("ct", typeof(DateTime),false);
	tprogettosettoreerc.defineColumn("cu", typeof(string),false);
	tprogettosettoreerc.defineColumn("idprogetto", typeof(int),false);
	tprogettosettoreerc.defineColumn("idsettoreerc", typeof(int),false);
	tprogettosettoreerc.defineColumn("lt", typeof(DateTime),false);
	tprogettosettoreerc.defineColumn("lu", typeof(string),false);
	tprogettosettoreerc.defineColumn("!idsettoreerc_settoreerc_title", typeof(string));
	Tables.Add(tprogettosettoreerc);
	tprogettosettoreerc.defineKey("idprogetto", "idsettoreerc");

	//////////////////// REGISTRYAZIENDEVIEW /////////////////////////////////
	var tregistryaziendeview= new MetaTable("registryaziendeview");
	tregistryaziendeview.defineColumn("dropdown_title", typeof(string),false);
	tregistryaziendeview.defineColumn("idateco", typeof(int));
	tregistryaziendeview.defineColumn("idcategory", typeof(string));
	tregistryaziendeview.defineColumn("idcity", typeof(int));
	tregistryaziendeview.defineColumn("idnace", typeof(string));
	tregistryaziendeview.defineColumn("idnation", typeof(int));
	tregistryaziendeview.defineColumn("idnaturagiur", typeof(int));
	tregistryaziendeview.defineColumn("idnumerodip", typeof(int));
	tregistryaziendeview.defineColumn("idreg", typeof(int),false);
	tregistryaziendeview.defineColumn("idregistryclass", typeof(string));
	tregistryaziendeview.defineColumn("registry_active", typeof(string));
	tregistryaziendeview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistryaziendeview);
	tregistryaziendeview.defineKey("idreg");

	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new MetaTable("registryclass");
	tregistryclass.defineColumn("active", typeof(string));
	tregistryclass.defineColumn("description", typeof(string),false);
	tregistryclass.defineColumn("idregistryclass", typeof(string),false);
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("gender", typeof(string));
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("surname", typeof(string));
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// NUMERODIP /////////////////////////////////
	var tnumerodip= new MetaTable("numerodip");
	tnumerodip.defineColumn("active", typeof(string),false);
	tnumerodip.defineColumn("idnumerodip", typeof(int),false);
	tnumerodip.defineColumn("title", typeof(string),false);
	Tables.Add(tnumerodip);
	tnumerodip.defineKey("idnumerodip");

	//////////////////// NATURAGIUR /////////////////////////////////
	var tnaturagiur= new MetaTable("naturagiur");
	tnaturagiur.defineColumn("active", typeof(string),false);
	tnaturagiur.defineColumn("idnaturagiur", typeof(int),false);
	tnaturagiur.defineColumn("title", typeof(string),false);
	Tables.Add(tnaturagiur);
	tnaturagiur.defineKey("idnaturagiur");

	//////////////////// NACE /////////////////////////////////
	var tnace= new MetaTable("nace");
	tnace.defineColumn("activity", typeof(string),false);
	tnace.defineColumn("idnace", typeof(string),false);
	Tables.Add(tnace);
	tnace.defineKey("idnace");

	//////////////////// ATECO /////////////////////////////////
	var tateco= new MetaTable("ateco");
	tateco.defineColumn("codice", typeof(string));
	tateco.defineColumn("idateco", typeof(int),false);
	tateco.defineColumn("title", typeof(string));
	Tables.Add(tateco);
	tateco.defineKey("idateco");

	//////////////////// REGISTRY_AZIENDE /////////////////////////////////
	var tregistry_aziende= new MetaTable("registry_aziende");
	tregistry_aziende.defineColumn("ct", typeof(DateTime),false);
	tregistry_aziende.defineColumn("cu", typeof(string),false);
	tregistry_aziende.defineColumn("idateco", typeof(int));
	tregistry_aziende.defineColumn("idnace", typeof(string));
	tregistry_aziende.defineColumn("idnaturagiur", typeof(int));
	tregistry_aziende.defineColumn("idnumerodip", typeof(int));
	tregistry_aziende.defineColumn("idreg", typeof(int),false);
	tregistry_aziende.defineColumn("lt", typeof(DateTime),false);
	tregistry_aziende.defineColumn("lu", typeof(string),false);
	tregistry_aziende.defineColumn("pic", typeof(string));
	tregistry_aziende.defineColumn("title_en", typeof(string));
	tregistry_aziende.defineColumn("txt_en", typeof(string));
	Tables.Add(tregistry_aziende);
	tregistry_aziende.defineKey("idreg");

	//////////////////// PARTNERKIND /////////////////////////////////
	var tpartnerkind= new MetaTable("partnerkind");
	tpartnerkind.defineColumn("active", typeof(string));
	tpartnerkind.defineColumn("idpartnerkind", typeof(int),false);
	tpartnerkind.defineColumn("title", typeof(string));
	Tables.Add(tpartnerkind);
	tpartnerkind.defineKey("idpartnerkind");

	//////////////////// PROGETTOREGISTRY_AZIENDE /////////////////////////////////
	var tprogettoregistry_aziende= new MetaTable("progettoregistry_aziende");
	tprogettoregistry_aziende.defineColumn("ct", typeof(DateTime),false);
	tprogettoregistry_aziende.defineColumn("cu", typeof(string),false);
	tprogettoregistry_aziende.defineColumn("idpartnerkind", typeof(int));
	tprogettoregistry_aziende.defineColumn("idprogetto", typeof(int),false);
	tprogettoregistry_aziende.defineColumn("idreg_aziende", typeof(int),false);
	tprogettoregistry_aziende.defineColumn("lt", typeof(DateTime),false);
	tprogettoregistry_aziende.defineColumn("lu", typeof(string),false);
	tprogettoregistry_aziende.defineColumn("!idpartnerkind_partnerkind_title", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_registry_title", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_registryclass_description", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_registry_cf", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_registry_p_iva", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_registry_active", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_geo_nation_title", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_registry_flag_pa", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_ateco_codice", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_ateco_title", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_naturagiur_title", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_numerodip_title", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_nace_idnace", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_nace_activity", typeof(string));
	tprogettoregistry_aziende.defineColumn("!idreg_aziende_registry_aziende_pic", typeof(string));
	Tables.Add(tprogettoregistry_aziende);
	tprogettoregistry_aziende.defineKey("idprogetto", "idreg_aziende");

	//////////////////// PROGETTOATTACH /////////////////////////////////
	var tprogettoattach= new MetaTable("progettoattach");
	tprogettoattach.defineColumn("ct", typeof(DateTime),false);
	tprogettoattach.defineColumn("cu", typeof(string),false);
	tprogettoattach.defineColumn("idattach", typeof(int));
	tprogettoattach.defineColumn("idprogetto", typeof(int),false);
	tprogettoattach.defineColumn("idprogettoattach", typeof(int),false);
	tprogettoattach.defineColumn("lt", typeof(DateTime),false);
	tprogettoattach.defineColumn("lu", typeof(string),false);
	tprogettoattach.defineColumn("title", typeof(string));
	Tables.Add(tprogettoattach);
	tprogettoattach.defineKey("idprogetto", "idprogettoattach");

	//////////////////// PROGETTOTESTO /////////////////////////////////
	var tprogettotesto= new MetaTable("progettotesto");
	tprogettotesto.defineColumn("ct", typeof(DateTime));
	tprogettotesto.defineColumn("cu", typeof(string));
	tprogettotesto.defineColumn("description", typeof(string));
	tprogettotesto.defineColumn("idprogetto", typeof(int),false);
	tprogettotesto.defineColumn("idprogettotesto", typeof(int),false);
	tprogettotesto.defineColumn("lt", typeof(DateTime));
	tprogettotesto.defineColumn("lu", typeof(string));
	tprogettotesto.defineColumn("sortcode", typeof(int));
	tprogettotesto.defineColumn("title", typeof(string));
	Tables.Add(tprogettotesto);
	tprogettotesto.defineKey("idprogetto", "idprogettotesto");

	//////////////////// PROGETTORICAVO /////////////////////////////////
	var tprogettoricavo= new MetaTable("progettoricavo");
	tprogettoricavo.defineColumn("amount", typeof(decimal));
	tprogettoricavo.defineColumn("ct", typeof(DateTime),false);
	tprogettoricavo.defineColumn("cu", typeof(string),false);
	tprogettoricavo.defineColumn("doc", typeof(string));
	tprogettoricavo.defineColumn("docdate", typeof(DateTime));
	tprogettoricavo.defineColumn("idcontrattokind", typeof(int));
	tprogettoricavo.defineColumn("idinc", typeof(int));
	tprogettoricavo.defineColumn("idprogetto", typeof(int),false);
	tprogettoricavo.defineColumn("idprogettoricavo", typeof(int),false);
	tprogettoricavo.defineColumn("idprogettotipocosto", typeof(int));
	tprogettoricavo.defineColumn("idrelated", typeof(string));
	tprogettoricavo.defineColumn("idrendicontattivitaprogetto", typeof(int));
	tprogettoricavo.defineColumn("idsal", typeof(int));
	tprogettoricavo.defineColumn("idworkpackage", typeof(int));
	tprogettoricavo.defineColumn("lt", typeof(DateTime),false);
	tprogettoricavo.defineColumn("lu", typeof(string),false);
	tprogettoricavo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettoricavo);
	tprogettoricavo.defineKey("idprogetto", "idprogettoricavo");

	//////////////////// PROGETTOBUDGETVARIAZIONE /////////////////////////////////
	var tprogettobudgetvariazione= new MetaTable("progettobudgetvariazione");
	tprogettobudgetvariazione.defineColumn("ct", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("cu", typeof(string));
	tprogettobudgetvariazione.defineColumn("data", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("idaccmotive", typeof(string));
	tprogettobudgetvariazione.defineColumn("idprogetto", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idprogettobudget", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idprogettobudgetvariazione", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idupb", typeof(string));
	tprogettobudgetvariazione.defineColumn("lt", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("lu", typeof(string));
	tprogettobudgetvariazione.defineColumn("newamount", typeof(decimal));
	tprogettobudgetvariazione.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettobudgetvariazione);
	tprogettobudgetvariazione.defineKey("idprogetto", "idprogettobudget", "idprogettobudgetvariazione");

	//////////////////// PROGETTOCOSTO /////////////////////////////////
	var tprogettocosto= new MetaTable("progettocosto");
	tprogettocosto.defineColumn("amount", typeof(decimal));
	tprogettocosto.defineColumn("ct", typeof(DateTime));
	tprogettocosto.defineColumn("cu", typeof(string));
	tprogettocosto.defineColumn("doc", typeof(string));
	tprogettocosto.defineColumn("docdate", typeof(DateTime));
	tprogettocosto.defineColumn("idcontrattokind", typeof(int));
	tprogettocosto.defineColumn("idexp", typeof(int));
	tprogettocosto.defineColumn("idpettycash", typeof(int));
	tprogettocosto.defineColumn("idprogetto", typeof(int),false);
	tprogettocosto.defineColumn("idprogettocosto", typeof(int),false);
	tprogettocosto.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettocosto.defineColumn("idrelated", typeof(string));
	tprogettocosto.defineColumn("idrendicontattivitaprogetto", typeof(int));
	tprogettocosto.defineColumn("idsal", typeof(int));
	tprogettocosto.defineColumn("idworkpackage", typeof(int),false);
	tprogettocosto.defineColumn("lt", typeof(DateTime));
	tprogettocosto.defineColumn("lu", typeof(string));
	tprogettocosto.defineColumn("noperation", typeof(int));
	tprogettocosto.defineColumn("yoperation", typeof(int));
	tprogettocosto.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tprogettocosto);
	tprogettocosto.defineKey("idprogetto", "idprogettocosto", "idprogettotipocosto", "idworkpackage");

	//////////////////// WORKPACKAGE_ALIAS2 /////////////////////////////////
	var tworkpackage_alias2= new MetaTable("workpackage_alias2");
	tworkpackage_alias2.defineColumn("idprogetto", typeof(int),false);
	tworkpackage_alias2.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage_alias2.defineColumn("raggruppamento", typeof(string));
	tworkpackage_alias2.defineColumn("title", typeof(string));
	tworkpackage_alias2.ExtendedProperties["TableForReading"]="workpackage";
	Tables.Add(tworkpackage_alias2);
	tworkpackage_alias2.defineKey("idprogetto", "idworkpackage");

	//////////////////// PROGETTOTIPOCOSTO_ALIAS2 /////////////////////////////////
	var tprogettotipocosto_alias2= new MetaTable("progettotipocosto_alias2");
	tprogettotipocosto_alias2.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocosto_alias2.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocosto_alias2.defineColumn("title", typeof(string));
	tprogettotipocosto_alias2.ExtendedProperties["TableForReading"]="progettotipocosto";
	Tables.Add(tprogettotipocosto_alias2);
	tprogettotipocosto_alias2.defineKey("idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOBUDGET /////////////////////////////////
	var tprogettobudget= new MetaTable("progettobudget");
	tprogettobudget.defineColumn("!budgetvariazione", typeof(decimal));
	tprogettobudget.defineColumn("!ricaviincassati", typeof(decimal));
	tprogettobudget.defineColumn("!ricavinonincassati", typeof(decimal));
	tprogettobudget.defineColumn("!spese", typeof(decimal));
	tprogettobudget.defineColumn("budget", typeof(decimal));
	tprogettobudget.defineColumn("ct", typeof(DateTime));
	tprogettobudget.defineColumn("cu", typeof(string));
	tprogettobudget.defineColumn("idprogetto", typeof(int),false);
	tprogettobudget.defineColumn("idprogettobudget", typeof(int),false);
	tprogettobudget.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettobudget.defineColumn("idworkpackage", typeof(int),false);
	tprogettobudget.defineColumn("lt", typeof(DateTime));
	tprogettobudget.defineColumn("lu", typeof(string));
	tprogettobudget.defineColumn("sortcode", typeof(int));
	tprogettobudget.defineColumn("!idprogettotipocosto_progettotipocosto_title", typeof(string));
	tprogettobudget.defineColumn("!idworkpackage_workpackage_raggruppamento", typeof(string));
	tprogettobudget.defineColumn("!idworkpackage_workpackage_title", typeof(string));
	Tables.Add(tprogettobudget);
	tprogettobudget.defineKey("idprogetto", "idprogettobudget", "idprogettotipocosto", "idworkpackage");

	//////////////////// ASSETDIARYORA /////////////////////////////////
	var tassetdiaryora= new MetaTable("assetdiaryora");
	tassetdiaryora.defineColumn("!title", typeof(string));
	tassetdiaryora.defineColumn("amount", typeof(decimal));
	tassetdiaryora.defineColumn("ct", typeof(DateTime),false);
	tassetdiaryora.defineColumn("cu", typeof(string),false);
	tassetdiaryora.defineColumn("idassetdiary", typeof(int),false);
	tassetdiaryora.defineColumn("idassetdiaryora", typeof(int),false);
	tassetdiaryora.defineColumn("idsal", typeof(int));
	tassetdiaryora.defineColumn("idworkpackage", typeof(int),false);
	tassetdiaryora.defineColumn("lt", typeof(DateTime),false);
	tassetdiaryora.defineColumn("lu", typeof(string),false);
	tassetdiaryora.defineColumn("start", typeof(DateTime));
	tassetdiaryora.defineColumn("stop", typeof(DateTime));
	Tables.Add(tassetdiaryora);
	tassetdiaryora.defineKey("idassetdiary", "idassetdiaryora", "idworkpackage");

	//////////////////// ASSETDIARY /////////////////////////////////
	var tassetdiary= new MetaTable("assetdiary");
	tassetdiary.defineColumn("!amount", typeof(string));
	tassetdiary.defineColumn("ct", typeof(DateTime),false);
	tassetdiary.defineColumn("cu", typeof(string),false);
	tassetdiary.defineColumn("idasset", typeof(int),false);
	tassetdiary.defineColumn("idassetdiary", typeof(int),false);
	tassetdiary.defineColumn("idpiece", typeof(int));
	tassetdiary.defineColumn("idprogetto", typeof(int),false);
	tassetdiary.defineColumn("idreg", typeof(int),false);
	tassetdiary.defineColumn("idworkpackage", typeof(int),false);
	tassetdiary.defineColumn("lt", typeof(DateTime),false);
	tassetdiary.defineColumn("lu", typeof(string),false);
	tassetdiary.defineColumn("orepreventivate", typeof(int));
	tassetdiary.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tassetdiary);
	tassetdiary.defineKey("idassetdiary", "idworkpackage");

	//////////////////// WORKPACKAGEUPB /////////////////////////////////
	var tworkpackageupb= new MetaTable("workpackageupb");
	tworkpackageupb.defineColumn("ct", typeof(DateTime),false);
	tworkpackageupb.defineColumn("cu", typeof(string),false);
	tworkpackageupb.defineColumn("idprogetto", typeof(int),false);
	tworkpackageupb.defineColumn("idupb", typeof(string),false);
	tworkpackageupb.defineColumn("idworkpackage", typeof(int),false);
	tworkpackageupb.defineColumn("lt", typeof(DateTime),false);
	tworkpackageupb.defineColumn("lu", typeof(string),false);
	Tables.Add(tworkpackageupb);
	tworkpackageupb.defineKey("idprogetto", "idupb", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOITINERATION /////////////////////////////////
	var trendicontattivitaprogettoitineration= new MetaTable("rendicontattivitaprogettoitineration");
	trendicontattivitaprogettoitineration.defineColumn("iditineration", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idworkpackage", typeof(int),false);
	Tables.Add(trendicontattivitaprogettoitineration);
	trendicontattivitaprogettoitineration.defineKey("iditineration", "idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOYEAR /////////////////////////////////
	var trendicontattivitaprogettoyear= new MetaTable("rendicontattivitaprogettoyear");
	trendicontattivitaprogettoyear.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idrendicontattivitaprogettoyear", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("ore", typeof(int));
	trendicontattivitaprogettoyear.defineColumn("year", typeof(int));
	Tables.Add(trendicontattivitaprogettoyear);
	trendicontattivitaprogettoyear.defineKey("idprogetto", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoyear", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	trendicontattivitaprogettoora.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// RENDICONTATTIVITAPROGETTO /////////////////////////////////
	var trendicontattivitaprogetto= new MetaTable("rendicontattivitaprogetto");
	trendicontattivitaprogetto.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("description", typeof(string));
	trendicontattivitaprogetto.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("stop", typeof(DateTime));
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("acronimo", typeof(string));
	tworkpackage.defineColumn("ct", typeof(DateTime),false);
	tworkpackage.defineColumn("cu", typeof(string),false);
	tworkpackage.defineColumn("description", typeof(string));
	tworkpackage.defineColumn("idprogetto", typeof(int),false);
	tworkpackage.defineColumn("idstruttura", typeof(int));
	tworkpackage.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage.defineColumn("lt", typeof(DateTime),false);
	tworkpackage.defineColumn("lu", typeof(string),false);
	tworkpackage.defineColumn("raggruppamento", typeof(string));
	tworkpackage.defineColumn("start", typeof(DateTime));
	tworkpackage.defineColumn("stop", typeof(DateTime));
	tworkpackage.defineColumn("title", typeof(string));
	tworkpackage.defineColumn("!idstruttura_struttura_title", typeof(string));
	tworkpackage.defineColumn("!idstruttura_struttura_idstrutturakind_title", typeof(string));
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	//////////////////// PROGETTOUDRMEMBRO /////////////////////////////////
	var tprogettoudrmembro= new MetaTable("progettoudrmembro");
	tprogettoudrmembro.defineColumn("!orerendicontate", typeof(int));
	tprogettoudrmembro.defineColumn("costoorario", typeof(decimal));
	tprogettoudrmembro.defineColumn("ct", typeof(DateTime));
	tprogettoudrmembro.defineColumn("cu", typeof(string));
	tprogettoudrmembro.defineColumn("idprogetto", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudr", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudrmembro", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudrmembrokind", typeof(int));
	tprogettoudrmembro.defineColumn("idreg", typeof(int),false);
	tprogettoudrmembro.defineColumn("impegno", typeof(decimal));
	tprogettoudrmembro.defineColumn("lt", typeof(DateTime));
	tprogettoudrmembro.defineColumn("lu", typeof(string));
	tprogettoudrmembro.defineColumn("orepreventivate", typeof(int));
	tprogettoudrmembro.defineColumn("ricavoorario", typeof(decimal));
	Tables.Add(tprogettoudrmembro);
	tprogettoudrmembro.defineKey("idprogetto", "idprogettoudr", "idprogettoudrmembro");

	//////////////////// PROGETTOUDR /////////////////////////////////
	var tprogettoudr= new MetaTable("progettoudr");
	tprogettoudr.defineColumn("!budgetore", typeof(decimal));
	tprogettoudr.defineColumn("assegniricerca", typeof(int));
	tprogettoudr.defineColumn("borsedottorati", typeof(int));
	tprogettoudr.defineColumn("budget", typeof(decimal));
	tprogettoudr.defineColumn("contrattirtd", typeof(int));
	tprogettoudr.defineColumn("contributo", typeof(decimal));
	tprogettoudr.defineColumn("ct", typeof(DateTime));
	tprogettoudr.defineColumn("cu", typeof(string));
	tprogettoudr.defineColumn("description", typeof(string));
	tprogettoudr.defineColumn("idprogetto", typeof(int),false);
	tprogettoudr.defineColumn("idprogettoudr", typeof(int),false);
	tprogettoudr.defineColumn("impegnototale", typeof(decimal));
	tprogettoudr.defineColumn("impegnototaleore", typeof(int));
	tprogettoudr.defineColumn("lt", typeof(DateTime));
	tprogettoudr.defineColumn("lu", typeof(string));
	tprogettoudr.defineColumn("title", typeof(string));
	Tables.Add(tprogettoudr);
	tprogettoudr.defineKey("idprogetto", "idprogettoudr");

	//////////////////// INVENTORY /////////////////////////////////
	var tinventory= new MetaTable("inventory");
	tinventory.defineColumn("active", typeof(string));
	tinventory.defineColumn("description", typeof(string),false);
	tinventory.defineColumn("idinventory", typeof(int),false);
	Tables.Add(tinventory);
	tinventory.defineKey("idinventory");

	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("codeupb", typeof(string),false);
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("title", typeof(string),false);
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// INVENTORYTREE /////////////////////////////////
	var tinventorytree= new MetaTable("inventorytree");
	tinventorytree.defineColumn("codeinv", typeof(string),false);
	tinventorytree.defineColumn("description", typeof(string),false);
	tinventorytree.defineColumn("idinv", typeof(int),false);
	Tables.Add(tinventorytree);
	tinventorytree.defineKey("idinv");

	//////////////////// ASSETACQUIRE /////////////////////////////////
	var tassetacquire= new MetaTable("assetacquire");
	tassetacquire.defineColumn("abatable", typeof(decimal));
	tassetacquire.defineColumn("adate", typeof(DateTime),false);
	tassetacquire.defineColumn("ct", typeof(DateTime),false);
	tassetacquire.defineColumn("cu", typeof(string),false);
	tassetacquire.defineColumn("description", typeof(string),false);
	tassetacquire.defineColumn("discount", typeof(decimal));
	tassetacquire.defineColumn("flag", typeof(int),false);
	tassetacquire.defineColumn("historicalvalue", typeof(decimal));
	tassetacquire.defineColumn("idassetload", typeof(int));
	tassetacquire.defineColumn("idinv", typeof(int),false);
	tassetacquire.defineColumn("idinventory", typeof(int),false);
	tassetacquire.defineColumn("idinvkind", typeof(int));
	tassetacquire.defineColumn("idlist", typeof(int));
	tassetacquire.defineColumn("idmankind", typeof(string));
	tassetacquire.defineColumn("idmot", typeof(int),false);
	tassetacquire.defineColumn("idreg", typeof(int));
	tassetacquire.defineColumn("idsor1", typeof(int));
	tassetacquire.defineColumn("idsor2", typeof(int));
	tassetacquire.defineColumn("idsor3", typeof(int));
	tassetacquire.defineColumn("idupb", typeof(string));
	tassetacquire.defineColumn("invrownum", typeof(int));
	tassetacquire.defineColumn("lt", typeof(DateTime),false);
	tassetacquire.defineColumn("lu", typeof(string),false);
	tassetacquire.defineColumn("nassetacquire", typeof(int),false);
	tassetacquire.defineColumn("ninv", typeof(int));
	tassetacquire.defineColumn("nman", typeof(int));
	tassetacquire.defineColumn("number", typeof(int),false);
	tassetacquire.defineColumn("rownum", typeof(int));
	tassetacquire.defineColumn("rtf", typeof(Byte[]));
	tassetacquire.defineColumn("startnumber", typeof(int));
	tassetacquire.defineColumn("tax", typeof(decimal));
	tassetacquire.defineColumn("taxable", typeof(decimal));
	tassetacquire.defineColumn("taxrate", typeof(decimal));
	tassetacquire.defineColumn("transmitted", typeof(string));
	tassetacquire.defineColumn("txt", typeof(string));
	tassetacquire.defineColumn("yinv", typeof(int));
	tassetacquire.defineColumn("yman", typeof(int));
	Tables.Add(tassetacquire);
	tassetacquire.defineKey("nassetacquire");

	//////////////////// ASSET /////////////////////////////////
	var tasset= new MetaTable("asset");
	tasset.defineColumn("amortizationquota", typeof(decimal));
	tasset.defineColumn("ct", typeof(DateTime),false);
	tasset.defineColumn("cu", typeof(string),false);
	tasset.defineColumn("flag", typeof(int),false);
	tasset.defineColumn("idasset", typeof(int),false);
	tasset.defineColumn("idasset_prev", typeof(int));
	tasset.defineColumn("idassetunload", typeof(int));
	tasset.defineColumn("idcurrlocation", typeof(int));
	tasset.defineColumn("idcurrman", typeof(int));
	tasset.defineColumn("idcurrsubman", typeof(int));
	tasset.defineColumn("idinventory", typeof(int));
	tasset.defineColumn("idinventoryamortization", typeof(int));
	tasset.defineColumn("idpiece", typeof(int),false);
	tasset.defineColumn("idpiece_prev", typeof(int));
	tasset.defineColumn("lifestart", typeof(DateTime));
	tasset.defineColumn("lt", typeof(DateTime),false);
	tasset.defineColumn("lu", typeof(string),false);
	tasset.defineColumn("multifield", typeof(string));
	tasset.defineColumn("nassetacquire", typeof(int));
	tasset.defineColumn("ninventory", typeof(int));
	tasset.defineColumn("rfid", typeof(string));
	tasset.defineColumn("rtf", typeof(Byte[]));
	tasset.defineColumn("transmitted", typeof(string));
	tasset.defineColumn("txt", typeof(string));
	Tables.Add(tasset);
	tasset.defineKey("idasset", "idpiece");

	//////////////////// PROGETTOASSET /////////////////////////////////
	var tprogettoasset= new MetaTable("progettoasset");
	tprogettoasset.defineColumn("!altreupb", typeof(string));
	tprogettoasset.defineColumn("!ammortamento", typeof(string));
	tprogettoasset.defineColumn("aggiunta", typeof(string));
	tprogettoasset.defineColumn("ammortamentopreventivato", typeof(decimal));
	tprogettoasset.defineColumn("costoorario", typeof(decimal));
	tprogettoasset.defineColumn("ct", typeof(DateTime),false);
	tprogettoasset.defineColumn("cu", typeof(string),false);
	tprogettoasset.defineColumn("descammortamentopreventivato", typeof(string));
	tprogettoasset.defineColumn("idasset", typeof(int),false);
	tprogettoasset.defineColumn("idpiece", typeof(int),false);
	tprogettoasset.defineColumn("idprogetto", typeof(int),false);
	tprogettoasset.defineColumn("lt", typeof(DateTime),false);
	tprogettoasset.defineColumn("lu", typeof(string),false);
	tprogettoasset.defineColumn("start", typeof(DateTime));
	tprogettoasset.defineColumn("stop", typeof(DateTime));
	tprogettoasset.defineColumn("!idasset-idpiece_inventory_description", typeof(string));
	tprogettoasset.defineColumn("!idasset-idpiece_asset_ninventory", typeof(int));
	tprogettoasset.defineColumn("!idasset-idpiece_assetacquire_description", typeof(string));
	tprogettoasset.defineColumn("!idasset-idpiece_assetacquire_inventorytree_codeinv", typeof(string));
	tprogettoasset.defineColumn("!idasset-idpiece_assetacquire_inventorytree_description", typeof(string));
	tprogettoasset.defineColumn("!idasset-idpiece_assetacquire_upb_title", typeof(string));
	tprogettoasset.defineColumn("!idasset-idpiece_asset_rfid", typeof(string));
	tprogettoasset.defineColumn("!idasset-idpiece_asset_lifestart", typeof(DateTime));
	Tables.Add(tprogettoasset);
	tprogettoasset.defineKey("idasset", "idpiece", "idprogetto");

	//////////////////// PROGETTOSTATUSKINDDEFAULTVIEW /////////////////////////////////
	var tprogettostatuskinddefaultview= new MetaTable("progettostatuskinddefaultview");
	tprogettostatuskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributo", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributoente", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributoenterichiesto", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributorichiesto", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_ct", typeof(DateTime),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_cu", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_lt", typeof(DateTime),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_lu", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_sortcode", typeof(int),false);
	tprogettostatuskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tprogettostatuskinddefaultview);
	tprogettostatuskinddefaultview.defineKey("idprogettostatuskind");

	//////////////////// PROGETTOTIPORICAVOCONTRATTOKIND /////////////////////////////////
	var tprogettotiporicavocontrattokind= new MetaTable("progettotiporicavocontrattokind");
	tprogettotiporicavocontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavocontrattokind.defineColumn("cu", typeof(string));
	tprogettotiporicavocontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("idprogetto", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotiporicavocontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavocontrattokind);
	tprogettotiporicavocontrattokind.defineKey("idcontrattokind", "idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOTIPORICAVOACCMOTIVE /////////////////////////////////
	var tprogettotiporicavoaccmotive= new MetaTable("progettotiporicavoaccmotive");
	tprogettotiporicavoaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotiporicavoaccmotive.defineColumn("cu", typeof(string));
	tprogettotiporicavoaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotiporicavoaccmotive.defineColumn("idprogetto", typeof(int),false);
	tprogettotiporicavoaccmotive.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotiporicavoaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotiporicavoaccmotive.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotiporicavoaccmotive);
	tprogettotiporicavoaccmotive.defineKey("idaccmotive", "idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOTIPOCOSTOTAX /////////////////////////////////
	var tprogettotipocostotax= new MetaTable("progettotipocostotax");
	tprogettotipocostotax.defineColumn("ct", typeof(DateTime));
	tprogettotipocostotax.defineColumn("cu", typeof(string));
	tprogettotipocostotax.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostotax.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostotax.defineColumn("lt", typeof(DateTime));
	tprogettotipocostotax.defineColumn("lu", typeof(string));
	tprogettotipocostotax.defineColumn("taxcode", typeof(int),false);
	Tables.Add(tprogettotipocostotax);
	tprogettotipocostotax.defineKey("idprogetto", "idprogettotipocosto", "taxcode");

	//////////////////// PROGETTOTIPOCOSTOINVENTORYTREE /////////////////////////////////
	var tprogettotipocostoinventorytree= new MetaTable("progettotipocostoinventorytree");
	tprogettotipocostoinventorytree.defineColumn("ct", typeof(DateTime));
	tprogettotipocostoinventorytree.defineColumn("cu", typeof(string));
	tprogettotipocostoinventorytree.defineColumn("idinv", typeof(int),false);
	tprogettotipocostoinventorytree.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostoinventorytree.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostoinventorytree.defineColumn("lt", typeof(DateTime));
	tprogettotipocostoinventorytree.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostoinventorytree);
	tprogettotipocostoinventorytree.defineKey("idinv", "idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOTIPOCOSTOCONTRATTOKIND /////////////////////////////////
	var tprogettotipocostocontrattokind= new MetaTable("progettotipocostocontrattokind");
	tprogettotipocostocontrattokind.defineColumn("ct", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("cu", typeof(string));
	tprogettotipocostocontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostocontrattokind.defineColumn("lt", typeof(DateTime));
	tprogettotipocostocontrattokind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostocontrattokind);
	tprogettotipocostocontrattokind.defineKey("idcontrattokind", "idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOTIPOCOSTOACCMOTIVE /////////////////////////////////
	var tprogettotipocostoaccmotive= new MetaTable("progettotipocostoaccmotive");
	tprogettotipocostoaccmotive.defineColumn("ct", typeof(DateTime));
	tprogettotipocostoaccmotive.defineColumn("cu", typeof(string));
	tprogettotipocostoaccmotive.defineColumn("idaccmotive", typeof(string),false);
	tprogettotipocostoaccmotive.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocostoaccmotive.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocostoaccmotive.defineColumn("lt", typeof(DateTime));
	tprogettotipocostoaccmotive.defineColumn("lu", typeof(string));
	Tables.Add(tprogettotipocostoaccmotive);
	tprogettotipocostoaccmotive.defineKey("idaccmotive", "idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTOTIPOCOSTO /////////////////////////////////
	var tprogettotipocosto= new MetaTable("progettotipocosto");
	tprogettotipocosto.defineColumn("ammissibilita", typeof(decimal));
	tprogettotipocosto.defineColumn("budgetrichiesto", typeof(decimal));
	tprogettotipocosto.defineColumn("ct", typeof(DateTime));
	tprogettotipocosto.defineColumn("cu", typeof(string));
	tprogettotipocosto.defineColumn("idprogetto", typeof(int),false);
	tprogettotipocosto.defineColumn("idprogettotipocosto", typeof(int),false);
	tprogettotipocosto.defineColumn("idprogettotipocostokind", typeof(int));
	tprogettotipocosto.defineColumn("lt", typeof(DateTime));
	tprogettotipocosto.defineColumn("lu", typeof(string));
	tprogettotipocosto.defineColumn("sortcode", typeof(int));
	tprogettotipocosto.defineColumn("title", typeof(string));
	Tables.Add(tprogettotipocosto);
	tprogettotipocosto.defineKey("idprogetto", "idprogettotipocosto");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("!altreupb", typeof(string));
	tprogetto.defineColumn("!filtraAsset", typeof(string));
	tprogetto.defineColumn("bandoriferimentotxt", typeof(string));
	tprogetto.defineColumn("budget", typeof(decimal));
	tprogetto.defineColumn("budgetcalcolato", typeof(decimal));
	tprogetto.defineColumn("budgetcalcolatodate", typeof(DateTime));
	tprogetto.defineColumn("capofilatxt", typeof(string));
	tprogetto.defineColumn("codiceidentificativo", typeof(string));
	tprogetto.defineColumn("contributo", typeof(decimal));
	tprogetto.defineColumn("contributoente", typeof(decimal));
	tprogetto.defineColumn("contributoenterichiesto", typeof(decimal));
	tprogetto.defineColumn("contributorichiesto", typeof(decimal));
	tprogetto.defineColumn("ct", typeof(DateTime),false);
	tprogetto.defineColumn("cu", typeof(string),false);
	tprogetto.defineColumn("cup", typeof(string));
	tprogetto.defineColumn("data", typeof(DateTime));
	tprogetto.defineColumn("datacontabile", typeof(DateTime));
	tprogetto.defineColumn("dataesito", typeof(DateTime));
	tprogetto.defineColumn("description", typeof(string));
	tprogetto.defineColumn("durata", typeof(int));
	tprogetto.defineColumn("finanziamento", typeof(string));
	tprogetto.defineColumn("finanziatoretxt", typeof(string));
	tprogetto.defineColumn("idcorsostudio", typeof(int));
	tprogetto.defineColumn("idcurrency", typeof(int));
	tprogetto.defineColumn("idduratakind", typeof(int));
	tprogetto.defineColumn("idpartnerkind", typeof(int));
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("idprogettokind", typeof(int));
	tprogetto.defineColumn("idprogettostatuskind", typeof(int));
	tprogetto.defineColumn("idreg", typeof(int));
	tprogetto.defineColumn("idreg_amm", typeof(int));
	tprogetto.defineColumn("idreg_aziende", typeof(int));
	tprogetto.defineColumn("idreg_aziende_fin", typeof(int));
	tprogetto.defineColumn("idregistryprogfin", typeof(int));
	tprogetto.defineColumn("idregistryprogfinbando", typeof(int));
	tprogetto.defineColumn("idstrumentofin", typeof(int));
	tprogetto.defineColumn("lt", typeof(DateTime),false);
	tprogetto.defineColumn("lu", typeof(string),false);
	tprogetto.defineColumn("progfinanziamentotxt", typeof(string));
	tprogetto.defineColumn("start", typeof(DateTime));
	tprogetto.defineColumn("stop", typeof(DateTime));
	tprogetto.defineColumn("title", typeof(string));
	tprogetto.defineColumn("title_en", typeof(string));
	tprogetto.defineColumn("titolobreve", typeof(string));
	tprogetto.defineColumn("totalbudget", typeof(decimal));
	tprogetto.defineColumn("totalcontributo", typeof(decimal));
	tprogetto.defineColumn("url", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	#endregion


	#region DataRelation creation
	var cPar = new []{progetto.Columns["idprogetto"]};
	var cChild = new []{progettofinanziamento.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettofinanziamento_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{progetto.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_progetto_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{currency.Columns["idcurrency"]};
	cChild = new []{progetto.Columns["idcurrency"]};
	Relations.Add(new DataRelation("FK_progetto_currency_idcurrency",cPar,cChild,false));

	cPar = new []{duratakinddefaultview.Columns["idduratakind"]};
	cChild = new []{progetto.Columns["idduratakind"]};
	Relations.Add(new DataRelation("FK_progetto_duratakinddefaultview_idduratakind",cPar,cChild,false));

	cPar = new []{partnerkinddefaultview.Columns["idpartnerkind"]};
	cChild = new []{progetto.Columns["idpartnerkind"]};
	Relations.Add(new DataRelation("FK_progetto_partnerkinddefaultview_idpartnerkind",cPar,cChild,false));

	cPar = new []{registryaziendeview_alias1.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_progetto_registryaziendeview_alias1_idreg_aziende",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progetto_registrydocentiview_idreg",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg_amm"]};
	Relations.Add(new DataRelation("FK_progetto_registryamministrativiview_idreg_amm",cPar,cChild,false));

	cPar = new []{progettokindsegview.Columns["idprogettokind"]};
	cChild = new []{progetto.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progetto_progettokindsegview_idprogettokind",cPar,cChild,false));

	cPar = new []{strumentofindefaultview.Columns["idstrumentofin"]};
	cChild = new []{progetto.Columns["idstrumentofin"]};
	Relations.Add(new DataRelation("FK_progetto_strumentofindefaultview_idstrumentofin",cPar,cChild,false));

	cPar = new []{registryprogfinbandosegview.Columns["idregistryprogfinbando"]};
	cChild = new []{progetto.Columns["idregistryprogfinbando"]};
	Relations.Add(new DataRelation("FK_progetto_registryprogfinbandosegview_idregistryprogfinbando",cPar,cChild,false));

	cPar = new []{registryprogfinsegview.Columns["idregistryprogfin"]};
	cChild = new []{registryprogfinbandosegview.Columns["idregistryprogfin"]};
	Relations.Add(new DataRelation("FK_registryprogfinbandosegview_registryprogfinsegview_idregistryprogfin",cPar,cChild,false));

	cPar = new []{registryprogfinsegview.Columns["idregistryprogfin"]};
	cChild = new []{progetto.Columns["idregistryprogfin"]};
	Relations.Add(new DataRelation("FK_progetto_registryprogfinsegview_idregistryprogfin",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettorp.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettorp_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{progettorp.Columns["idprogetto"]};
	cChild = new []{getprogettocostoview.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_getprogettocostoview_progettorp_idprogetto",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettoproroga.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettoproroga_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettosettoreerc.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettosettoreerc_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{settoreerc.Columns["idsettoreerc"]};
	cChild = new []{progettosettoreerc.Columns["idsettoreerc"]};
	Relations.Add(new DataRelation("FK_progettosettoreerc_settoreerc_idsettoreerc",cPar,cChild,false));

	cPar = new []{registryaziendeview.Columns["idreg"]};
	cChild = new []{progetto.Columns["idreg_aziende_fin"]};
	Relations.Add(new DataRelation("FK_progetto_registryaziendeview_idreg_aziende_fin",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettoregistry_aziende.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettoregistry_aziende_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{progettoregistry_aziende.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_progettoregistry_aziende_registry_idreg_aziende",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_aziende.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_aziende_registry_idreg",cPar,cChild,false));

	cPar = new []{registryclass.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclass_idregistryclass",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{numerodip.Columns["idnumerodip"]};
	cChild = new []{registry_aziende.Columns["idnumerodip"]};
	Relations.Add(new DataRelation("FK_registry_aziende_numerodip_idnumerodip",cPar,cChild,false));

	cPar = new []{naturagiur.Columns["idnaturagiur"]};
	cChild = new []{registry_aziende.Columns["idnaturagiur"]};
	Relations.Add(new DataRelation("FK_registry_aziende_naturagiur_idnaturagiur",cPar,cChild,false));

	cPar = new []{nace.Columns["idnace"]};
	cChild = new []{registry_aziende.Columns["idnace"]};
	Relations.Add(new DataRelation("FK_registry_aziende_nace_idnace",cPar,cChild,false));

	cPar = new []{ateco.Columns["idateco"]};
	cChild = new []{registry_aziende.Columns["idateco"]};
	Relations.Add(new DataRelation("FK_registry_aziende_ateco_idateco",cPar,cChild,false));

	cPar = new []{partnerkind.Columns["idpartnerkind"]};
	cChild = new []{progettoregistry_aziende.Columns["idpartnerkind"]};
	Relations.Add(new DataRelation("FK_progettoregistry_aziende_partnerkind_idpartnerkind",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettoattach.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettoattach_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettotesto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotesto_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettobudget.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettobudget_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{progettobudget.Columns["idprogetto"], progettobudget.Columns["idprogettotipocosto"], progettobudget.Columns["idworkpackage"]};
	cChild = new []{progettoricavo.Columns["idprogetto"], progettoricavo.Columns["idprogettotipocosto"], progettoricavo.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettoricavo_progettobudget_idprogetto-idprogettotipocosto-idworkpackage",cPar,cChild,false));

	cPar = new []{progettobudget.Columns["idprogetto"], progettobudget.Columns["idprogettobudget"]};
	cChild = new []{progettobudgetvariazione.Columns["idprogetto"], progettobudgetvariazione.Columns["idprogettobudget"]};
	Relations.Add(new DataRelation("FK_progettobudgetvariazione_progettobudget_idprogetto-idprogettobudget",cPar,cChild,false));

	cPar = new []{progettobudget.Columns["idprogetto"], progettobudget.Columns["idprogettotipocosto"], progettobudget.Columns["idworkpackage"]};
	cChild = new []{progettocosto.Columns["idprogetto"], progettocosto.Columns["idprogettotipocosto"], progettocosto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettocosto_progettobudget_idprogetto-idprogettotipocosto-idworkpackage",cPar,cChild,false));

	cPar = new []{workpackage_alias2.Columns["idworkpackage"]};
	cChild = new []{progettobudget.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_progettobudget_workpackage_alias2_idworkpackage",cPar,cChild,false));

	cPar = new []{progettotipocosto_alias2.Columns["idprogettotipocosto"]};
	cChild = new []{progettobudget.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettobudget_progettotipocosto_alias2_idprogettotipocosto",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{workpackage.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_workpackage_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	cChild = new []{assetdiary.Columns["idprogetto"], assetdiary.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiary_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{assetdiary.Columns["idassetdiary"], assetdiary.Columns["idworkpackage"]};
	cChild = new []{assetdiaryora.Columns["idassetdiary"], assetdiaryora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_assetdiaryora_assetdiary_idassetdiary-idworkpackage",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	cChild = new []{workpackageupb.Columns["idprogetto"], workpackageupb.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_workpackageupb_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idprogetto"], workpackage.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_workpackage_idprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoitineration.Columns["idprogetto"], rendicontattivitaprogettoitineration.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoitineration.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_rendicontattivitaprogetto_idprogetto-idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoyear.Columns["idprogetto"], rendicontattivitaprogettoyear.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoyear.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoyear_rendicontattivitaprogetto_idprogetto-idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{workpackage.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_workpackage_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettoudr.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettoudr_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{progettoudr.Columns["idprogetto"], progettoudr.Columns["idprogettoudr"]};
	cChild = new []{progettoudrmembro.Columns["idprogetto"], progettoudrmembro.Columns["idprogettoudr"]};
	Relations.Add(new DataRelation("FK_progettoudrmembro_progettoudr_idprogetto-idprogettoudr",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettoasset.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettoasset_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{asset.Columns["idasset"], asset.Columns["idpiece"]};
	cChild = new []{progettoasset.Columns["idasset"], progettoasset.Columns["idpiece"]};
	Relations.Add(new DataRelation("FK_progettoasset_asset_idasset-idpiece",cPar,cChild,false));

	cPar = new []{assetacquire.Columns["nassetacquire"]};
	cChild = new []{asset.Columns["nassetacquire"]};
	Relations.Add(new DataRelation("FK_asset_assetacquire_nassetacquire",cPar,cChild,false));

	cPar = new []{inventory.Columns["idinventory"]};
	cChild = new []{asset.Columns["idinventory"]};
	Relations.Add(new DataRelation("FK_asset_inventory_idinventory",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{assetacquire.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_assetacquire_upb_idupb",cPar,cChild,false));

	cPar = new []{inventorytree.Columns["idinv"]};
	cChild = new []{assetacquire.Columns["idinv"]};
	Relations.Add(new DataRelation("FK_assetacquire_inventorytree_idinv",cPar,cChild,false));

	cPar = new []{progettostatuskinddefaultview.Columns["idprogettostatuskind"]};
	cChild = new []{progetto.Columns["idprogettostatuskind"]};
	Relations.Add(new DataRelation("FK_progetto_progettostatuskinddefaultview_idprogettostatuskind",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{progettotipocosto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_progettotipocosto_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotiporicavocontrattokind.Columns["idprogetto"], progettotiporicavocontrattokind.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotiporicavocontrattokind_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotiporicavoaccmotive.Columns["idprogetto"], progettotiporicavoaccmotive.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotiporicavoaccmotive_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostotax.Columns["idprogetto"], progettotipocostotax.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostotax_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostoinventorytree.Columns["idprogetto"], progettotipocostoinventorytree.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostoinventorytree_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostocontrattokind.Columns["idprogetto"], progettotipocostocontrattokind.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostocontrattokind_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	cPar = new []{progettotipocosto.Columns["idprogetto"], progettotipocosto.Columns["idprogettotipocosto"]};
	cChild = new []{progettotipocostoaccmotive.Columns["idprogetto"], progettotipocostoaccmotive.Columns["idprogettotipocosto"]};
	Relations.Add(new DataRelation("FK_progettotipocostoaccmotive_progettotipocosto_idprogetto-idprogettotipocosto",cPar,cChild,false));

	#endregion

}
}
}
