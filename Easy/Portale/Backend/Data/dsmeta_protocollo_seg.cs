
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
[System.Xml.Serialization.XmlRoot("dsmeta_protocollo_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_protocollo_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego 		=> (MetaTable)Tables["diniego"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioprogetto 		=> (MetaTable)Tables["tirocinioprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable decadenza 		=> (MetaTable)Tables["decadenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneanno 		=> (MetaTable)Tables["iscrizioneanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable delibera 		=> (MetaTable)Tables["delibera"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodocelement 		=> (MetaTable)Tables["protocollodocelement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollorifkind 		=> (MetaTable)Tables["protocollorifkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodoc 		=> (MetaTable)Tables["protocollodoc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodestinatario 		=> (MetaTable)Tables["protocollodestinatario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoodefaultview 		=> (MetaTable)Tables["aoodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollo 		=> (MetaTable)Tables["protocollo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_protocollo_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_protocollo_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_protocollo_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_protocollo_seg.xsd";

	#region create DataTables
	//////////////////// DINIEGO /////////////////////////////////
	var tdiniego= new MetaTable("diniego");
	tdiniego.defineColumn("ct", typeof(DateTime),false);
	tdiniego.defineColumn("cu", typeof(string),false);
	tdiniego.defineColumn("data", typeof(DateTime),false);
	tdiniego.defineColumn("idcorsostudio", typeof(int));
	tdiniego.defineColumn("iddidprog", typeof(int));
	tdiniego.defineColumn("iddiniego", typeof(int),false);
	tdiniego.defineColumn("idiscrizione", typeof(int));
	tdiniego.defineColumn("idistanza", typeof(int),false);
	tdiniego.defineColumn("idistanzakind", typeof(int),false);
	tdiniego.defineColumn("idreg", typeof(int),false);
	tdiniego.defineColumn("lt", typeof(DateTime),false);
	tdiniego.defineColumn("lu", typeof(string),false);
	tdiniego.defineColumn("protanno", typeof(int));
	tdiniego.defineColumn("protnumero", typeof(int));
	Tables.Add(tdiniego);
	tdiniego.defineKey("iddiniego", "idistanza", "idistanzakind", "idreg");

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

	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("ct", typeof(DateTime),false);
	tnullaosta.defineColumn("cu", typeof(string),false);
	tnullaosta.defineColumn("data", typeof(DateTime),false);
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idcorsostudio", typeof(int));
	tnullaosta.defineColumn("iddidprog", typeof(int));
	tnullaosta.defineColumn("idiscrizione", typeof(int));
	tnullaosta.defineColumn("idistanza", typeof(int),false);
	tnullaosta.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta.defineColumn("idreg", typeof(int),false);
	tnullaosta.defineColumn("lt", typeof(DateTime),false);
	tnullaosta.defineColumn("lu", typeof(string),false);
	tnullaosta.defineColumn("protanno", typeof(int));
	tnullaosta.defineColumn("protnumero", typeof(int));
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// TIROCINIOPROGETTO /////////////////////////////////
	var ttirocinioprogetto= new MetaTable("tirocinioprogetto");
	ttirocinioprogetto.defineColumn("competenze", typeof(string));
	ttirocinioprogetto.defineColumn("ct", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("cu", typeof(string),false);
	ttirocinioprogetto.defineColumn("datafineeffettiva", typeof(DateTime));
	ttirocinioprogetto.defineColumn("datafineprevista", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("datainizioeffettiva", typeof(DateTime));
	ttirocinioprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("dataverbale", typeof(DateTime));
	ttirocinioprogetto.defineColumn("description", typeof(string),false);
	ttirocinioprogetto.defineColumn("description_en", typeof(string));
	ttirocinioprogetto.defineColumn("idaoo", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_docenti", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioprogetto.defineColumn("idsede", typeof(int));
	ttirocinioprogetto.defineColumn("idstruttura", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirociniostato", typeof(int),false);
	ttirocinioprogetto.defineColumn("lt", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("lu", typeof(string),false);
	ttirocinioprogetto.defineColumn("ore", typeof(int),false);
	ttirocinioprogetto.defineColumn("protanno", typeof(int));
	ttirocinioprogetto.defineColumn("protnumero", typeof(int));
	ttirocinioprogetto.defineColumn("tempiaccesso", typeof(string));
	ttirocinioprogetto.defineColumn("title", typeof(string),false);
	ttirocinioprogetto.defineColumn("title_en", typeof(string));
	Tables.Add(ttirocinioprogetto);
	ttirocinioprogetto.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// DECADENZA /////////////////////////////////
	var tdecadenza= new MetaTable("decadenza");
	tdecadenza.defineColumn("aa", typeof(string),false);
	tdecadenza.defineColumn("ct", typeof(DateTime),false);
	tdecadenza.defineColumn("cu", typeof(string),false);
	tdecadenza.defineColumn("data", typeof(DateTime),false);
	tdecadenza.defineColumn("iddecadenza", typeof(int),false);
	tdecadenza.defineColumn("idiscrizione", typeof(int),false);
	tdecadenza.defineColumn("idreg_studenti", typeof(int),false);
	tdecadenza.defineColumn("lt", typeof(DateTime),false);
	tdecadenza.defineColumn("lu", typeof(string),false);
	tdecadenza.defineColumn("protanno", typeof(int),false);
	tdecadenza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tdecadenza);
	tdecadenza.defineKey("iddecadenza", "idiscrizione", "idreg_studenti");

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

	//////////////////// ISCRIZIONEANNO /////////////////////////////////
	var tiscrizioneanno= new MetaTable("iscrizioneanno");
	tiscrizioneanno.defineColumn("aa", typeof(string),false);
	tiscrizioneanno.defineColumn("anno", typeof(int),false);
	tiscrizioneanno.defineColumn("annofc", typeof(int));
	tiscrizioneanno.defineColumn("ct", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("cu", typeof(string),false);
	tiscrizioneanno.defineColumn("data", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprogori", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizioneanno", typeof(int),false);
	tiscrizioneanno.defineColumn("idreg", typeof(int),false);
	tiscrizioneanno.defineColumn("lt", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("lu", typeof(string),false);
	tiscrizioneanno.defineColumn("protanno", typeof(int));
	tiscrizioneanno.defineColumn("protnumero", typeof(int));
	Tables.Add(tiscrizioneanno);
	tiscrizioneanno.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idiscrizioneanno", "idreg");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("ct", typeof(DateTime),false);
	tdichiar.defineColumn("cu", typeof(string),false);
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("extension", typeof(string));
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	tdichiar.defineColumn("lt", typeof(DateTime),false);
	tdichiar.defineColumn("lu", typeof(string),false);
	tdichiar.defineColumn("protanno", typeof(int));
	tdichiar.defineColumn("protnumero", typeof(int));
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int));
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int));
	tsostenimento.defineColumn("iddidprog", typeof(int));
	tsostenimento.defineColumn("idiscrizione", typeof(int));
	tsostenimento.defineColumn("idprova", typeof(int));
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento.defineColumn("idtitolostudio", typeof(int));
	tsostenimento.defineColumn("insecod", typeof(string));
	tsostenimento.defineColumn("insedesc", typeof(string));
	tsostenimento.defineColumn("livello", typeof(string));
	tsostenimento.defineColumn("lt", typeof(DateTime),false);
	tsostenimento.defineColumn("lu", typeof(string),false);
	tsostenimento.defineColumn("paridsostenimento", typeof(int));
	tsostenimento.defineColumn("protanno", typeof(int));
	tsostenimento.defineColumn("protnumero", typeof(int));
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idreg", "idsostenimento");

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

	//////////////////// PROTOCOLLODOCELEMENT /////////////////////////////////
	var tprotocollodocelement= new MetaTable("protocollodocelement");
	tprotocollodocelement.defineColumn("ct", typeof(DateTime));
	tprotocollodocelement.defineColumn("cu", typeof(string));
	tprotocollodocelement.defineColumn("idprotocollodoc", typeof(int),false);
	tprotocollodocelement.defineColumn("idprotocollodocelement", typeof(int),false);
	tprotocollodocelement.defineColumn("idprotocollodocelement_primo", typeof(int),false);
	tprotocollodocelement.defineColumn("idprotocollodockind", typeof(int),false);
	tprotocollodocelement.defineColumn("lt", typeof(DateTime));
	tprotocollodocelement.defineColumn("lu", typeof(string));
	tprotocollodocelement.defineColumn("oggetto", typeof(string),false);
	tprotocollodocelement.defineColumn("protanno", typeof(int),false);
	tprotocollodocelement.defineColumn("protnumero", typeof(int),false);
	tprotocollodocelement.defineColumn("telematicocolloc", typeof(string));
	tprotocollodocelement.defineColumn("telematicohash", typeof(Byte[]));
	Tables.Add(tprotocollodocelement);
	tprotocollodocelement.defineKey("idprotocollodoc", "idprotocollodocelement", "protanno", "protnumero");

	//////////////////// PROTOCOLLORIFKIND /////////////////////////////////
	var tprotocollorifkind= new MetaTable("protocollorifkind");
	tprotocollorifkind.defineColumn("idprotocollorifkind", typeof(int),false);
	tprotocollorifkind.defineColumn("title", typeof(string),false);
	Tables.Add(tprotocollorifkind);
	tprotocollorifkind.defineKey("idprotocollorifkind");

	//////////////////// PROTOCOLLODOC /////////////////////////////////
	var tprotocollodoc= new MetaTable("protocollodoc");
	tprotocollodoc.defineColumn("ct", typeof(DateTime));
	tprotocollodoc.defineColumn("cu", typeof(string));
	tprotocollodoc.defineColumn("filename", typeof(string));
	tprotocollodoc.defineColumn("idattach", typeof(int));
	tprotocollodoc.defineColumn("idmimetype", typeof(int));
	tprotocollodoc.defineColumn("idprotocollodoc", typeof(int),false);
	tprotocollodoc.defineColumn("idprotocollorifkind", typeof(int),false);
	tprotocollodoc.defineColumn("lt", typeof(DateTime));
	tprotocollodoc.defineColumn("lu", typeof(string));
	tprotocollodoc.defineColumn("protanno", typeof(int),false);
	tprotocollodoc.defineColumn("protnumero", typeof(int),false);
	tprotocollodoc.defineColumn("!idprotocollorifkind_protocollorifkind_title", typeof(string));
	Tables.Add(tprotocollodoc);
	tprotocollodoc.defineKey("idprotocollodoc", "protanno", "protnumero");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// PROTOCOLLODESTINATARIO /////////////////////////////////
	var tprotocollodestinatario= new MetaTable("protocollodestinatario");
	tprotocollodestinatario.defineColumn("ct", typeof(DateTime));
	tprotocollodestinatario.defineColumn("cu", typeof(string));
	tprotocollodestinatario.defineColumn("destcodiceaoo", typeof(string));
	tprotocollodestinatario.defineColumn("destidamm", typeof(string));
	tprotocollodestinatario.defineColumn("destmail", typeof(string));
	tprotocollodestinatario.defineColumn("idprotocollodestinatario", typeof(int),false);
	tprotocollodestinatario.defineColumn("idreg_dest", typeof(int));
	tprotocollodestinatario.defineColumn("lt", typeof(DateTime));
	tprotocollodestinatario.defineColumn("lu", typeof(string));
	tprotocollodestinatario.defineColumn("protanno", typeof(int),false);
	tprotocollodestinatario.defineColumn("protnumero", typeof(int),false);
	tprotocollodestinatario.defineColumn("!idreg_dest_registry_title", typeof(string));
	Tables.Add(tprotocollodestinatario);
	tprotocollodestinatario.defineKey("idprotocollodestinatario", "protanno", "protnumero");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcity", typeof(int));
	tregistrydefaultview.defineColumn("idnation", typeof(int));
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
	tregistrydefaultview.defineColumn("idtitle", typeof(string));
	tregistrydefaultview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// AOODEFAULTVIEW /////////////////////////////////
	var taoodefaultview= new MetaTable("aoodefaultview");
	taoodefaultview.defineColumn("dropdown_title", typeof(string),false);
	taoodefaultview.defineColumn("idaoo", typeof(int),false);
	taoodefaultview.defineColumn("idsede", typeof(int));
	Tables.Add(taoodefaultview);
	taoodefaultview.defineKey("idaoo");

	//////////////////// PROTOCOLLO /////////////////////////////////
	var tprotocollo= new MetaTable("protocollo");
	tprotocollo.defineColumn("annullato", typeof(string),false);
	tprotocollo.defineColumn("codiceammipa", typeof(string),false);
	tprotocollo.defineColumn("codiceregistro", typeof(string),false);
	tprotocollo.defineColumn("ct", typeof(DateTime));
	tprotocollo.defineColumn("cu", typeof(string));
	tprotocollo.defineColumn("dataannullamento", typeof(DateTime));
	tprotocollo.defineColumn("idaoo", typeof(int),false);
	tprotocollo.defineColumn("idreg_origine", typeof(int));
	tprotocollo.defineColumn("lt", typeof(DateTime));
	tprotocollo.defineColumn("lu", typeof(string));
	tprotocollo.defineColumn("oggetto", typeof(string),false);
	tprotocollo.defineColumn("originecodiceaoo", typeof(string));
	tprotocollo.defineColumn("origineidamm", typeof(string));
	tprotocollo.defineColumn("originemail", typeof(string));
	tprotocollo.defineColumn("protanno", typeof(int),false);
	tprotocollo.defineColumn("protdata", typeof(DateTime),false);
	tprotocollo.defineColumn("protnumero", typeof(int),false);
	tprotocollo.defineColumn("testo", typeof(string));
	Tables.Add(tprotocollo);
	tprotocollo.defineKey("protanno", "protnumero");

	#endregion


	#region DataRelation creation
	var cPar = new []{protocollo.Columns["protanno"], protocollo.Columns["protnumero"]};
	var cChild = new []{protocollodoc.Columns["protanno"], protocollodoc.Columns["protnumero"]};
	Relations.Add(new DataRelation("FK_protocollodoc_protocollo_protanno-protnumero",cPar,cChild,false));

	cPar = new []{protocollodoc.Columns["idprotocollodoc"], protocollodoc.Columns["protanno"], protocollodoc.Columns["protnumero"]};
	cChild = new []{protocollodocelement.Columns["idprotocollodoc"], protocollodocelement.Columns["protanno"], protocollodocelement.Columns["protnumero"]};
	Relations.Add(new DataRelation("FK_protocollodocelement_protocollodoc_idprotocollodoc-protanno-protnumero",cPar,cChild,false));

	cPar = new []{protocollorifkind.Columns["idprotocollorifkind"]};
	cChild = new []{protocollodoc.Columns["idprotocollorifkind"]};
	Relations.Add(new DataRelation("FK_protocollodoc_protocollorifkind_idprotocollorifkind",cPar,cChild,false));

	cPar = new []{protocollo.Columns["protanno"], protocollo.Columns["protnumero"]};
	cChild = new []{protocollodestinatario.Columns["protanno"], protocollodestinatario.Columns["protnumero"]};
	Relations.Add(new DataRelation("FK_protocollodestinatario_protocollo_protanno-protnumero",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{protocollodestinatario.Columns["idreg_dest"]};
	Relations.Add(new DataRelation("FK_protocollodestinatario_registry_idreg_dest",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{protocollo.Columns["idreg_origine"]};
	Relations.Add(new DataRelation("FK_protocollo_registrydefaultview_idreg_origine",cPar,cChild,false));

	cPar = new []{aoodefaultview.Columns["idaoo"]};
	cChild = new []{protocollo.Columns["idaoo"]};
	Relations.Add(new DataRelation("FK_protocollo_aoodefaultview_idaoo",cPar,cChild,false));

	#endregion

}
}
}
