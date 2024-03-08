
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_rimb_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_istanza_rimb_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debito 		=> (MetaTable)Tables["debito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable credito 		=> (MetaTable)Tables["credito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable creditoistanza_rimb 		=> (MetaTable)Tables["creditoistanza_rimb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_rimb 		=> (MetaTable)Tables["istanza_rimb"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_rimb_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_rimb_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_rimb_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_rimb_seg.xsd";

	#region create DataTables
	//////////////////// DEBITO /////////////////////////////////
	var tdebito= new MetaTable("debito");
	tdebito.defineColumn("codicebollettino", typeof(string));
	tdebito.defineColumn("codicemav", typeof(string));
	tdebito.defineColumn("ct", typeof(DateTime),false);
	tdebito.defineColumn("cu", typeof(string),false);
	tdebito.defineColumn("iddebito", typeof(int),false);
	tdebito.defineColumn("idiscrizione", typeof(int));
	tdebito.defineColumn("idistanza", typeof(int));
	tdebito.defineColumn("idnullaosta", typeof(int));
	tdebito.defineColumn("idreg", typeof(int),false);
	tdebito.defineColumn("idtassaconf", typeof(int));
	tdebito.defineColumn("IUV", typeof(string));
	tdebito.defineColumn("lt", typeof(DateTime),false);
	tdebito.defineColumn("lu", typeof(string),false);
	tdebito.defineColumn("scadenza", typeof(DateTime));
	tdebito.defineColumn("title", typeof(string));
	Tables.Add(tdebito);
	tdebito.defineKey("iddebito", "idreg");

	//////////////////// CREDITO /////////////////////////////////
	var tcredito= new MetaTable("credito");
	tcredito.defineColumn("autorizzato", typeof(string));
	tcredito.defineColumn("ct", typeof(DateTime),false);
	tcredito.defineColumn("cu", typeof(string),false);
	tcredito.defineColumn("idcredito", typeof(int),false);
	tcredito.defineColumn("iddebito", typeof(int),false);
	tcredito.defineColumn("idpagamento", typeof(int),false);
	tcredito.defineColumn("idreg", typeof(int),false);
	tcredito.defineColumn("lt", typeof(DateTime),false);
	tcredito.defineColumn("lu", typeof(string),false);
	Tables.Add(tcredito);
	tcredito.defineKey("idcredito", "iddebito", "idpagamento", "idreg");

	//////////////////// CREDITOISTANZA_RIMB /////////////////////////////////
	var tcreditoistanza_rimb= new MetaTable("creditoistanza_rimb");
	tcreditoistanza_rimb.defineColumn("ct", typeof(DateTime),false);
	tcreditoistanza_rimb.defineColumn("cu", typeof(string),false);
	tcreditoistanza_rimb.defineColumn("idcredito", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("iddebito", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("idistanza", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("idpagamento", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("idreg", typeof(int),false);
	tcreditoistanza_rimb.defineColumn("lt", typeof(DateTime),false);
	tcreditoistanza_rimb.defineColumn("lu", typeof(string),false);
	tcreditoistanza_rimb.defineColumn("!iddebito_debito_title", typeof(string));
	tcreditoistanza_rimb.defineColumn("!iddebito_debito_scadenza", typeof(DateTime));
	tcreditoistanza_rimb.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcreditoistanza_rimb);
	tcreditoistanza_rimb.defineKey("idcredito", "iddebito", "idistanza", "idpagamento", "idreg");

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

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_idsede", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idiscrizione");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
	tdidprogdefaultview.defineColumn("areadidattica_title", typeof(string));
	tdidprogdefaultview.defineColumn("convenzione_title", typeof(string));
	tdidprogdefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tdidprogdefaultview.defineColumn("corsostudio_title", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_annosolare", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_attribdebiti", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_ciclo", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_codice", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_codicemiur", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_dataconsmaxiscr", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_freqobbl", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_iddidprognumchiusokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_iddidprogsuddannokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_iderogazkind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_idsede", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_idtitolokind", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_immatoltreauth", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_modaccesso", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_modaccesso_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_obbformativi", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_obbformativi_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_preimmatoltreauth", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_progesamamm", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_prospoccupaz", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_provafinaledesc", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_regolamentotax", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_regolamentotaxurl", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_startiscrizioni", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_stopiscrizioni", typeof(DateTime));
	tdidprogdefaultview.defineColumn("didprog_title_en", typeof(string));
	tdidprogdefaultview.defineColumn("didprog_utenzasost", typeof(int));
	tdidprogdefaultview.defineColumn("didprog_website", typeof(string));
	tdidprogdefaultview.defineColumn("didprognumchiusokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("didprogsuddannokind_title", typeof(string));
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("erogazkind_title", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlang_lang", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlang2_lang", typeof(string));
	tdidprogdefaultview.defineColumn("geo_nationlangvis_lang", typeof(string));
	tdidprogdefaultview.defineColumn("graduatoria_title", typeof(string));
	tdidprogdefaultview.defineColumn("idareadidattica", typeof(int));
	tdidprogdefaultview.defineColumn("idconvenzione", typeof(int));
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogdefaultview.defineColumn("idgraduatoria", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang2", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_langvis", typeof(int));
	tdidprogdefaultview.defineColumn("idreg_docenti", typeof(int));
	tdidprogdefaultview.defineColumn("idsessione", typeof(int));
	tdidprogdefaultview.defineColumn("registrydocenti_title", typeof(string));
	tdidprogdefaultview.defineColumn("sede_title", typeof(string));
	tdidprogdefaultview.defineColumn("sessione_idsessionekind", typeof(int));
	tdidprogdefaultview.defineColumn("sessione_start", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessione_stop", typeof(DateTime));
	tdidprogdefaultview.defineColumn("sessionekind_title", typeof(string));
	tdidprogdefaultview.defineColumn("title", typeof(string));
	tdidprogdefaultview.defineColumn("titolokind_title", typeof(string));
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("iddidprog");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("registry_active", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISTANZA /////////////////////////////////
	var tistanza= new MetaTable("istanza");
	tistanza.defineColumn("aa", typeof(string),false);
	tistanza.defineColumn("ct", typeof(DateTime),false);
	tistanza.defineColumn("cu", typeof(string),false);
	tistanza.defineColumn("data", typeof(DateTime),false);
	tistanza.defineColumn("extension", typeof(string));
	tistanza.defineColumn("idcorsostudio", typeof(int));
	tistanza.defineColumn("iddidprog", typeof(int));
	tistanza.defineColumn("idiscrizione", typeof(int));
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int));
	tistanza.defineColumn("lt", typeof(DateTime),false);
	tistanza.defineColumn("lu", typeof(string),false);
	tistanza.defineColumn("paridistanza", typeof(int));
	tistanza.defineColumn("protanno", typeof(int),false);
	tistanza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tistanza);
	tistanza.defineKey("idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_RIMB /////////////////////////////////
	var tistanza_rimb= new MetaTable("istanza_rimb");
	tistanza_rimb.defineColumn("ct", typeof(DateTime));
	tistanza_rimb.defineColumn("cu", typeof(string));
	tistanza_rimb.defineColumn("idistanza", typeof(int),false);
	tistanza_rimb.defineColumn("idistanzakind", typeof(int),false);
	tistanza_rimb.defineColumn("idreg", typeof(int),false);
	tistanza_rimb.defineColumn("lt", typeof(DateTime));
	tistanza_rimb.defineColumn("lu", typeof(string));
	Tables.Add(tistanza_rimb);
	tistanza_rimb.defineKey("idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{creditoistanza_rimb.Columns["idistanza"], creditoistanza_rimb.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_creditoistanza_rimb_istanza_idistanza-idreg",cPar,cChild,false));

	cPar = new []{debito.Columns["iddebito"]};
	cChild = new []{creditoistanza_rimb.Columns["iddebito"]};
	Relations.Add(new DataRelation("FK_creditoistanza_rimb_debito_iddebito",cPar,cChild,false));

	cPar = new []{credito.Columns["idcredito"]};
	cChild = new []{creditoistanza_rimb.Columns["idcredito"]};
	Relations.Add(new DataRelation("FK_creditoistanza_rimb_credito_idcredito",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_rimb.Columns["idistanza"], istanza_rimb.Columns["idistanzakind"], istanza_rimb.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_rimb_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	#endregion

}
}
}
