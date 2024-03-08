
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_delibera_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_delibera_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias2 		=> (MetaTable)Tables["statuskind_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzakind_alias1 		=> (MetaTable)Tables["istanzakind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable deliberapratica 		=> (MetaTable)Tables["deliberapratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias1 		=> (MetaTable)Tables["statuskind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_studenti 		=> (MetaTable)Tables["registry_studenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzakind 		=> (MetaTable)Tables["istanzakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias14 		=> (MetaTable)Tables["istanza_alias14"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable deliberaistanza 		=> (MetaTable)Tables["deliberaistanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable delibera 		=> (MetaTable)Tables["delibera"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_delibera_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_delibera_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_delibera_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_delibera_seg.xsd";

	#region create DataTables
	//////////////////// STATUSKIND_ALIAS2 /////////////////////////////////
	var tstatuskind_alias2= new MetaTable("statuskind_alias2");
	tstatuskind_alias2.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias2.defineColumn("title", typeof(string),false);
	tstatuskind_alias2.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias2);
	tstatuskind_alias2.defineKey("idstatuskind");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// ISTANZAKIND_ALIAS1 /////////////////////////////////
	var tistanzakind_alias1= new MetaTable("istanzakind_alias1");
	tistanzakind_alias1.defineColumn("active", typeof(string),false);
	tistanzakind_alias1.defineColumn("idistanzakind", typeof(int),false);
	tistanzakind_alias1.defineColumn("title", typeof(string),false);
	tistanzakind_alias1.ExtendedProperties["TableForReading"]="istanzakind";
	Tables.Add(tistanzakind_alias1);
	tistanzakind_alias1.defineKey("idistanzakind");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("ct", typeof(DateTime),false);
	tiscrizione.defineColumn("cu", typeof(string),false);
	tiscrizione.defineColumn("data", typeof(DateTime));
	tiscrizione.defineColumn("idcorsostudio", typeof(int));
	tiscrizione.defineColumn("iddidprog", typeof(int));
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	tiscrizione.defineColumn("lt", typeof(DateTime),false);
	tiscrizione.defineColumn("lu", typeof(string),false);
	tiscrizione.defineColumn("matricola", typeof(string));
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idiscrizione", "idreg");

	//////////////////// PRATICA /////////////////////////////////
	var tpratica= new MetaTable("pratica");
	tpratica.defineColumn("ct", typeof(DateTime),false);
	tpratica.defineColumn("cu", typeof(string),false);
	tpratica.defineColumn("idcorsostudio", typeof(int),false);
	tpratica.defineColumn("iddichiar", typeof(int));
	tpratica.defineColumn("iddidprog", typeof(int),false);
	tpratica.defineColumn("idiscrizione", typeof(int),false);
	tpratica.defineColumn("idiscrizione_from", typeof(int));
	tpratica.defineColumn("idistanza", typeof(int),false);
	tpratica.defineColumn("idistanzakind", typeof(int),false);
	tpratica.defineColumn("idpratica", typeof(int),false);
	tpratica.defineColumn("idreg", typeof(int),false);
	tpratica.defineColumn("idstatuskind", typeof(int),false);
	tpratica.defineColumn("idtitolostudio", typeof(int));
	tpratica.defineColumn("lt", typeof(DateTime),false);
	tpratica.defineColumn("lu", typeof(string),false);
	tpratica.defineColumn("protanno", typeof(int));
	tpratica.defineColumn("protnumero", typeof(int));
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// DELIBERAPRATICA /////////////////////////////////
	var tdeliberapratica= new MetaTable("deliberapratica");
	tdeliberapratica.defineColumn("ct", typeof(DateTime),false);
	tdeliberapratica.defineColumn("cu", typeof(string),false);
	tdeliberapratica.defineColumn("idcorsostudio", typeof(int),false);
	tdeliberapratica.defineColumn("iddelibera", typeof(int),false);
	tdeliberapratica.defineColumn("iddidprog", typeof(int),false);
	tdeliberapratica.defineColumn("idiscrizione", typeof(int),false);
	tdeliberapratica.defineColumn("idistanza", typeof(int),false);
	tdeliberapratica.defineColumn("idistanzakind", typeof(int),false);
	tdeliberapratica.defineColumn("idpratica", typeof(int),false);
	tdeliberapratica.defineColumn("idreg", typeof(int),false);
	tdeliberapratica.defineColumn("lt", typeof(DateTime),false);
	tdeliberapratica.defineColumn("lu", typeof(string),false);
	tdeliberapratica.defineColumn("!idpratica_registry_alias1_title", typeof(string));
	tdeliberapratica.defineColumn("!idpratica_iscrizione_anno", typeof(int));
	tdeliberapratica.defineColumn("!idpratica_iscrizione_didprog_title", typeof(string));
	tdeliberapratica.defineColumn("!idpratica_iscrizione_didprog_aa", typeof(string));
	tdeliberapratica.defineColumn("!idpratica_iscrizione_didprog_idsede", typeof(int));
	tdeliberapratica.defineColumn("!idpratica_iscrizione_annoaccademico_alias1_aa", typeof(string));
	tdeliberapratica.defineColumn("!idpratica_istanzakind_alias1_title", typeof(string));
	tdeliberapratica.defineColumn("!idpratica_statuskind_alias2_title", typeof(string));
	tdeliberapratica.defineColumn("!idpratica_pratica_protnumero", typeof(int));
	tdeliberapratica.defineColumn("!idpratica_pratica_protanno", typeof(int));
	Tables.Add(tdeliberapratica);
	tdeliberapratica.defineKey("idcorsostudio", "iddelibera", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// STATUSKIND_ALIAS1 /////////////////////////////////
	var tstatuskind_alias1= new MetaTable("statuskind_alias1");
	tstatuskind_alias1.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias1.defineColumn("title", typeof(string),false);
	tstatuskind_alias1.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias1);
	tstatuskind_alias1.defineKey("idstatuskind");

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

	//////////////////// REGISTRY_STUDENTI /////////////////////////////////
	var tregistry_studenti= new MetaTable("registry_studenti");
	tregistry_studenti.defineColumn("authinps", typeof(string),false);
	tregistry_studenti.defineColumn("ct", typeof(DateTime),false);
	tregistry_studenti.defineColumn("cu", typeof(string),false);
	tregistry_studenti.defineColumn("idreg", typeof(int),false);
	tregistry_studenti.defineColumn("idstuddirittokind", typeof(int));
	tregistry_studenti.defineColumn("idstudprenotkind", typeof(int),false);
	tregistry_studenti.defineColumn("lt", typeof(DateTime),false);
	tregistry_studenti.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistry_studenti);
	tregistry_studenti.defineKey("idreg");

	//////////////////// ISTANZAKIND /////////////////////////////////
	var tistanzakind= new MetaTable("istanzakind");
	tistanzakind.defineColumn("active", typeof(string),false);
	tistanzakind.defineColumn("idistanzakind", typeof(int),false);
	tistanzakind.defineColumn("title", typeof(string),false);
	Tables.Add(tistanzakind);
	tistanzakind.defineKey("idistanzakind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISTANZA_ALIAS14 /////////////////////////////////
	var tistanza_alias14= new MetaTable("istanza_alias14");
	tistanza_alias14.defineColumn("aa", typeof(string),false);
	tistanza_alias14.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias14.defineColumn("cu", typeof(string),false);
	tistanza_alias14.defineColumn("data", typeof(DateTime),false);
	tistanza_alias14.defineColumn("extension", typeof(string));
	tistanza_alias14.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias14.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias14.defineColumn("idiscrizione", typeof(int));
	tistanza_alias14.defineColumn("idistanza", typeof(int),false);
	tistanza_alias14.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias14.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias14.defineColumn("idstatuskind", typeof(int));
	tistanza_alias14.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias14.defineColumn("lu", typeof(string),false);
	tistanza_alias14.defineColumn("paridistanza", typeof(int),false);
	tistanza_alias14.defineColumn("protanno", typeof(int),false);
	tistanza_alias14.defineColumn("protnumero", typeof(int),false);
	tistanza_alias14.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias14);
	tistanza_alias14.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti", "paridistanza");

	//////////////////// DELIBERAISTANZA /////////////////////////////////
	var tdeliberaistanza= new MetaTable("deliberaistanza");
	tdeliberaistanza.defineColumn("ct", typeof(DateTime),false);
	tdeliberaistanza.defineColumn("cu", typeof(string),false);
	tdeliberaistanza.defineColumn("iddelibera", typeof(int),false);
	tdeliberaistanza.defineColumn("idistanza", typeof(int),false);
	tdeliberaistanza.defineColumn("idistanzakind", typeof(int),false);
	tdeliberaistanza.defineColumn("idreg_studenti", typeof(int),false);
	tdeliberaistanza.defineColumn("lt", typeof(DateTime),false);
	tdeliberaistanza.defineColumn("lu", typeof(string),false);
	tdeliberaistanza.defineColumn("!idistanza_registry_title", typeof(string));
	tdeliberaistanza.defineColumn("!idistanza_annoaccademico_aa", typeof(string));
	tdeliberaistanza.defineColumn("!idistanza_istanza_alias14_data", typeof(DateTime));
	tdeliberaistanza.defineColumn("!idistanza_istanzakind_title", typeof(string));
	tdeliberaistanza.defineColumn("!idistanza_statuskind_alias1_title", typeof(string));
	tdeliberaistanza.defineColumn("!idistanza_istanza_alias14_protanno", typeof(int));
	tdeliberaistanza.defineColumn("!idistanza_istanza_alias14_protnumero", typeof(int));
	Tables.Add(tdeliberaistanza);
	tdeliberaistanza.defineKey("iddelibera", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("ct", typeof(DateTime),false);
	tstatuskind.defineColumn("cu", typeof(string),false);
	tstatuskind.defineColumn("delibera", typeof(string),false);
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("istanze", typeof(string),false);
	tstatuskind.defineColumn("istanzedelibera", typeof(string),false);
	tstatuskind.defineColumn("lt", typeof(DateTime),false);
	tstatuskind.defineColumn("lu", typeof(string),false);
	tstatuskind.defineColumn("pratica", typeof(string),false);
	tstatuskind.defineColumn("sortcode", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

	//////////////////// DELIBERA /////////////////////////////////
	var tdelibera= new MetaTable("delibera");
	tdelibera.defineColumn("ct", typeof(DateTime),false);
	tdelibera.defineColumn("cu", typeof(string),false);
	tdelibera.defineColumn("data", typeof(DateTime),false);
	tdelibera.defineColumn("iddelibera", typeof(int),false);
	tdelibera.defineColumn("idstatuskind", typeof(int));
	tdelibera.defineColumn("idstruttura", typeof(int));
	tdelibera.defineColumn("lt", typeof(DateTime),false);
	tdelibera.defineColumn("lu", typeof(string),false);
	tdelibera.defineColumn("oggetto", typeof(string));
	tdelibera.defineColumn("protanno", typeof(int));
	tdelibera.defineColumn("protnumero", typeof(int));
	tdelibera.defineColumn("testo", typeof(string));
	Tables.Add(tdelibera);
	tdelibera.defineKey("iddelibera");

	#endregion


	#region DataRelation creation
	var cPar = new []{delibera.Columns["iddelibera"]};
	var cChild = new []{deliberapratica.Columns["iddelibera"]};
	Relations.Add(new DataRelation("FK_deliberapratica_delibera_iddelibera",cPar,cChild,false));

	cPar = new []{pratica.Columns["idpratica"]};
	cChild = new []{deliberapratica.Columns["idpratica"]};
	Relations.Add(new DataRelation("FK_deliberapratica_pratica_idpratica",cPar,cChild,false));

	cPar = new []{statuskind_alias2.Columns["idstatuskind"]};
	cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskind_alias2_idstatuskind",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{pratica.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{istanzakind_alias1.Columns["idistanzakind"]};
	cChild = new []{pratica.Columns["idistanzakind"]};
	Relations.Add(new DataRelation("FK_pratica_istanzakind_alias1_idistanzakind",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizione_idiscrizione",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{delibera.Columns["iddelibera"]};
	cChild = new []{deliberaistanza.Columns["iddelibera"]};
	Relations.Add(new DataRelation("FK_deliberaistanza_delibera_iddelibera",cPar,cChild,false));

	cPar = new []{istanza_alias14.Columns["idistanza"]};
	cChild = new []{deliberaistanza.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_deliberaistanza_istanza_alias14_idistanza",cPar,cChild,false));

	cPar = new []{statuskind_alias1.Columns["idstatuskind"]};
	cChild = new []{istanza_alias14.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_statuskind_alias1_idstatuskind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{istanza_alias14.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_registry_idreg_studenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_studenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_studenti_registry_idreg",cPar,cChild,false));

	cPar = new []{istanzakind.Columns["idistanzakind"]};
	cChild = new []{istanza_alias14.Columns["idistanzakind"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_istanzakind_idistanzakind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza_alias14.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{delibera.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_delibera_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{delibera.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_delibera_statuskind_idstatuskind",cPar,cChild,false));

	#endregion

}
}
}
