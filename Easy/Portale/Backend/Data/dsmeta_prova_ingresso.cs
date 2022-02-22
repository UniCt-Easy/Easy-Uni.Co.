
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
[System.Xml.Serialization.XmlRoot("dsmeta_prova_ingresso"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_prova_ingresso: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentoesito 		=> (MetaTable)Tables["sostenimentoesito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias2 		=> (MetaTable)Tables["registry_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable edificio 		=> (MetaTable)Tables["edificio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aulakind 		=> (MetaTable)Tables["aulakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura_alias1 		=> (MetaTable)Tables["struttura_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aula 		=> (MetaTable)Tables["aula"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provaaula 		=> (MetaTable)Tables["provaaula"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istituti 		=> (MetaTable)Tables["registry_istituti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale 		=> (MetaTable)Tables["classconsorsuale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_docenti 		=> (MetaTable)Tables["registry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commissregistry_docenti 		=> (MetaTable)Tables["commissregistry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable commiss 		=> (MetaTable)Tables["commiss"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable valutazionekind 		=> (MetaTable)Tables["valutazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable questionariodefaultview 		=> (MetaTable)Tables["questionariodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_prova_ingresso(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_prova_ingresso (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_prova_ingresso";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_prova_ingresso.xsd";

	#region create DataTables
	//////////////////// SOSTENIMENTOESITO /////////////////////////////////
	var tsostenimentoesito= new MetaTable("sostenimentoesito");
	tsostenimentoesito.defineColumn("active", typeof(string),false);
	tsostenimentoesito.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimentoesito.defineColumn("title", typeof(string),false);
	Tables.Add(tsostenimentoesito);
	tsostenimentoesito.defineKey("idsostenimentoesito");

	//////////////////// REGISTRY_ALIAS2 /////////////////////////////////
	var tregistry_alias2= new MetaTable("registry_alias2");
	tregistry_alias2.defineColumn("active", typeof(string),false);
	tregistry_alias2.defineColumn("idreg", typeof(int),false);
	tregistry_alias2.defineColumn("title", typeof(string),false);
	tregistry_alias2.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias2);
	tregistry_alias2.defineKey("idreg");

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
	tsostenimento.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento.defineColumn("iddidprog", typeof(int),false);
	tsostenimento.defineColumn("idiscrizione", typeof(int));
	tsostenimento.defineColumn("idprova", typeof(int),false);
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
	tsostenimento.defineColumn("!idreg_registry_title", typeof(string));
	tsostenimento.defineColumn("!idsostenimentoesito_sostenimentoesito_title", typeof(string));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idcorsostudio", "iddidprog", "idprova", "idreg", "idsostenimento");

	//////////////////// EDIFICIO /////////////////////////////////
	var tedificio= new MetaTable("edificio");
	tedificio.defineColumn("idedificio", typeof(int),false);
	tedificio.defineColumn("idsede", typeof(int),false);
	tedificio.defineColumn("title", typeof(string));
	Tables.Add(tedificio);
	tedificio.defineKey("idedificio", "idsede");

	//////////////////// AULAKIND /////////////////////////////////
	var taulakind= new MetaTable("aulakind");
	taulakind.defineColumn("active", typeof(string),false);
	taulakind.defineColumn("idaulakind", typeof(int),false);
	taulakind.defineColumn("title", typeof(string),false);
	Tables.Add(taulakind);
	taulakind.defineKey("idaulakind");

	//////////////////// STRUTTURA_ALIAS1 /////////////////////////////////
	var tstruttura_alias1= new MetaTable("struttura_alias1");
	tstruttura_alias1.defineColumn("codice", typeof(string));
	tstruttura_alias1.defineColumn("codiceipa", typeof(string));
	tstruttura_alias1.defineColumn("ct", typeof(DateTime),false);
	tstruttura_alias1.defineColumn("cu", typeof(string),false);
	tstruttura_alias1.defineColumn("email", typeof(string));
	tstruttura_alias1.defineColumn("fax", typeof(string));
	tstruttura_alias1.defineColumn("idaoo", typeof(int));
	tstruttura_alias1.defineColumn("idreg", typeof(int));
	tstruttura_alias1.defineColumn("idsede", typeof(int),false);
	tstruttura_alias1.defineColumn("idstruttura", typeof(int),false);
	tstruttura_alias1.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura_alias1.defineColumn("idupb", typeof(string));
	tstruttura_alias1.defineColumn("lt", typeof(DateTime),false);
	tstruttura_alias1.defineColumn("lu", typeof(string),false);
	tstruttura_alias1.defineColumn("paridstruttura", typeof(int));
	tstruttura_alias1.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura_alias1.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura_alias1.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura_alias1.defineColumn("pesoproguo", typeof(decimal));
	tstruttura_alias1.defineColumn("telefono", typeof(string));
	tstruttura_alias1.defineColumn("title", typeof(string));
	tstruttura_alias1.defineColumn("title_en", typeof(string));
	tstruttura_alias1.ExtendedProperties["TableForReading"]="struttura";
	Tables.Add(tstruttura_alias1);
	tstruttura_alias1.defineKey("idstruttura");

	//////////////////// AULA /////////////////////////////////
	var taula= new MetaTable("aula");
	taula.defineColumn("address", typeof(string));
	taula.defineColumn("cap", typeof(string));
	taula.defineColumn("capienza", typeof(int));
	taula.defineColumn("capienzadis", typeof(int));
	taula.defineColumn("code", typeof(string));
	taula.defineColumn("ct", typeof(DateTime),false);
	taula.defineColumn("cu", typeof(string),false);
	taula.defineColumn("dotazioni", typeof(string));
	taula.defineColumn("idaula", typeof(int),false);
	taula.defineColumn("idaulakind", typeof(int));
	taula.defineColumn("idcity", typeof(int));
	taula.defineColumn("idedificio", typeof(int),false);
	taula.defineColumn("idnation", typeof(int));
	taula.defineColumn("idsede", typeof(int),false);
	taula.defineColumn("idstruttura", typeof(int));
	taula.defineColumn("latitude", typeof(decimal));
	taula.defineColumn("location", typeof(string));
	taula.defineColumn("longitude", typeof(decimal));
	taula.defineColumn("lt", typeof(DateTime),false);
	taula.defineColumn("lu", typeof(string),false);
	taula.defineColumn("title", typeof(string));
	Tables.Add(taula);
	taula.defineKey("idaula", "idedificio", "idsede");

	//////////////////// PROVAAULA /////////////////////////////////
	var tprovaaula= new MetaTable("provaaula");
	tprovaaula.defineColumn("ct", typeof(DateTime),false);
	tprovaaula.defineColumn("cu", typeof(string),false);
	tprovaaula.defineColumn("idappello", typeof(int));
	tprovaaula.defineColumn("idaula", typeof(int),false);
	tprovaaula.defineColumn("idcorsostudio", typeof(int),false);
	tprovaaula.defineColumn("iddidprog", typeof(int),false);
	tprovaaula.defineColumn("idedificio", typeof(int),false);
	tprovaaula.defineColumn("idprova", typeof(int),false);
	tprovaaula.defineColumn("idsede", typeof(int),false);
	tprovaaula.defineColumn("lt", typeof(DateTime),false);
	tprovaaula.defineColumn("lu", typeof(string),false);
	tprovaaula.defineColumn("!idaula_aula_title", typeof(string));
	tprovaaula.defineColumn("!idaula_aula_code", typeof(string));
	tprovaaula.defineColumn("!idaula_edificio_title", typeof(string));
	tprovaaula.defineColumn("!idaula_struttura_alias1_title", typeof(string));
	tprovaaula.defineColumn("!idaula_struttura_alias1_strutturakind_title", typeof(string));
	tprovaaula.defineColumn("!idaula_aula_capienza", typeof(int));
	tprovaaula.defineColumn("!idaula_aula_capienzadis", typeof(int));
	tprovaaula.defineColumn("!idaula_aulakind_title", typeof(string));
	Tables.Add(tprovaaula);
	tprovaaula.defineKey("idaula", "idcorsostudio", "iddidprog", "idedificio", "idprova", "idsede");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
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
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int),false);
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
	tregistry.defineColumn("surname", typeof(string),false);
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("annotation", typeof(string));
	tregistry_alias1.defineColumn("authorization_free", typeof(string));
	tregistry_alias1.defineColumn("badgecode", typeof(string));
	tregistry_alias1.defineColumn("birthdate", typeof(DateTime));
	tregistry_alias1.defineColumn("ccp", typeof(string));
	tregistry_alias1.defineColumn("cf", typeof(string));
	tregistry_alias1.defineColumn("ct", typeof(DateTime),false);
	tregistry_alias1.defineColumn("cu", typeof(string),false);
	tregistry_alias1.defineColumn("email_fe", typeof(string));
	tregistry_alias1.defineColumn("extension", typeof(string));
	tregistry_alias1.defineColumn("extmatricula", typeof(string));
	tregistry_alias1.defineColumn("flag_pa", typeof(string));
	tregistry_alias1.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry_alias1.defineColumn("foreigncf", typeof(string));
	tregistry_alias1.defineColumn("forename", typeof(string));
	tregistry_alias1.defineColumn("gender", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias1.defineColumn("idcategory", typeof(string));
	tregistry_alias1.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias1.defineColumn("idcity", typeof(int));
	tregistry_alias1.defineColumn("idexternal", typeof(int));
	tregistry_alias1.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias1.defineColumn("idnation", typeof(int));
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("idregistryclass", typeof(string));
	tregistry_alias1.defineColumn("idregistrykind", typeof(int));
	tregistry_alias1.defineColumn("idtitle", typeof(string));
	tregistry_alias1.defineColumn("ipa_fe", typeof(string));
	tregistry_alias1.defineColumn("ipa_perlapa", typeof(string));
	tregistry_alias1.defineColumn("location", typeof(string));
	tregistry_alias1.defineColumn("lt", typeof(DateTime),false);
	tregistry_alias1.defineColumn("lu", typeof(string),false);
	tregistry_alias1.defineColumn("maritalsurname", typeof(string));
	tregistry_alias1.defineColumn("multi_cf", typeof(string));
	tregistry_alias1.defineColumn("p_iva", typeof(string));
	tregistry_alias1.defineColumn("pec_fe", typeof(string));
	tregistry_alias1.defineColumn("residence", typeof(int),false);
	tregistry_alias1.defineColumn("rtf", typeof(Byte[]));
	tregistry_alias1.defineColumn("sdi_defrifamm", typeof(string));
	tregistry_alias1.defineColumn("sdi_norifamm", typeof(string));
	tregistry_alias1.defineColumn("surname", typeof(string));
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.defineColumn("toredirect", typeof(int));
	tregistry_alias1.defineColumn("txt", typeof(string));
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// REGISTRY_ISTITUTI /////////////////////////////////
	var tregistry_istituti= new MetaTable("registry_istituti");
	tregistry_istituti.defineColumn("codicemiur", typeof(string));
	tregistry_istituti.defineColumn("codiceustat", typeof(string));
	tregistry_istituti.defineColumn("comune", typeof(string));
	tregistry_istituti.defineColumn("ct", typeof(DateTime));
	tregistry_istituti.defineColumn("cu", typeof(string),false);
	tregistry_istituti.defineColumn("idistitutokind", typeof(int),false);
	tregistry_istituti.defineColumn("idistitutoustat", typeof(int));
	tregistry_istituti.defineColumn("idreg", typeof(int),false);
	tregistry_istituti.defineColumn("lt", typeof(DateTime),false);
	tregistry_istituti.defineColumn("lu", typeof(string),false);
	tregistry_istituti.defineColumn("nome", typeof(string));
	tregistry_istituti.defineColumn("sortcode", typeof(int));
	tregistry_istituti.defineColumn("title", typeof(string));
	tregistry_istituti.defineColumn("title_en", typeof(string));
	Tables.Add(tregistry_istituti);
	tregistry_istituti.defineKey("idreg");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// CLASSCONSORSUALE /////////////////////////////////
	var tclassconsorsuale= new MetaTable("classconsorsuale");
	tclassconsorsuale.defineColumn("active", typeof(string),false);
	tclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale.defineColumn("title", typeof(string),false);
	Tables.Add(tclassconsorsuale);
	tclassconsorsuale.defineKey("idclassconsorsuale");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("codice", typeof(string));
	tstruttura.defineColumn("codiceipa", typeof(string));
	tstruttura.defineColumn("ct", typeof(DateTime),false);
	tstruttura.defineColumn("cu", typeof(string),false);
	tstruttura.defineColumn("email", typeof(string));
	tstruttura.defineColumn("fax", typeof(string));
	tstruttura.defineColumn("idaoo", typeof(int));
	tstruttura.defineColumn("idreg", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string));
	tstruttura.defineColumn("lt", typeof(DateTime),false);
	tstruttura.defineColumn("lu", typeof(string),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura.defineColumn("pesoproguo", typeof(decimal));
	tstruttura.defineColumn("telefono", typeof(string));
	tstruttura.defineColumn("title", typeof(string));
	tstruttura.defineColumn("title_en", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// REGISTRY_DOCENTI /////////////////////////////////
	var tregistry_docenti= new MetaTable("registry_docenti");
	tregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tregistry_docenti.defineColumn("cu", typeof(string),false);
	tregistry_docenti.defineColumn("cv", typeof(string));
	tregistry_docenti.defineColumn("idclassconsorsuale", typeof(int));
	tregistry_docenti.defineColumn("idcontrattokind", typeof(int));
	tregistry_docenti.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("idreg", typeof(int),false);
	tregistry_docenti.defineColumn("idreg_istituti", typeof(int));
	tregistry_docenti.defineColumn("idsasd", typeof(int));
	tregistry_docenti.defineColumn("idstruttura", typeof(int));
	tregistry_docenti.defineColumn("indicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tregistry_docenti.defineColumn("lu", typeof(string),false);
	tregistry_docenti.defineColumn("matricola", typeof(string));
	tregistry_docenti.defineColumn("ricevimento", typeof(string));
	tregistry_docenti.defineColumn("soggiorno", typeof(string));
	Tables.Add(tregistry_docenti);
	tregistry_docenti.defineKey("idreg");

	//////////////////// COMMISSREGISTRY_DOCENTI /////////////////////////////////
	var tcommissregistry_docenti= new MetaTable("commissregistry_docenti");
	tcommissregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("cu", typeof(string),false);
	tcommissregistry_docenti.defineColumn("idappello", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcommiss", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idcorsostudio", typeof(int),false);
	tcommissregistry_docenti.defineColumn("iddidprog", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idprova", typeof(int),false);
	tcommissregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tcommissregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tcommissregistry_docenti.defineColumn("lu", typeof(string),false);
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_cf", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_p_iva", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_active", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_docenti_matricola", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_sasd_codice", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_sasd_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_struttura_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_struttura_strutturakind_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_registry_alias1_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_classconsorsuale_title", typeof(string));
	tcommissregistry_docenti.defineColumn("!idreg_docenti_contrattokind_title", typeof(string));
	Tables.Add(tcommissregistry_docenti);
	tcommissregistry_docenti.defineKey("idcommiss", "idcorsostudio", "iddidprog", "idprova", "idreg_docenti");

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

	//////////////////// COMMISS /////////////////////////////////
	var tcommiss= new MetaTable("commiss");
	tcommiss.defineColumn("ct", typeof(DateTime),false);
	tcommiss.defineColumn("cu", typeof(string),false);
	tcommiss.defineColumn("idappello", typeof(int));
	tcommiss.defineColumn("idcommiss", typeof(int),false);
	tcommiss.defineColumn("idcorsostudio", typeof(int),false);
	tcommiss.defineColumn("iddidprog", typeof(int),false);
	tcommiss.defineColumn("idprova", typeof(int),false);
	tcommiss.defineColumn("idreg_docenti", typeof(int),false);
	tcommiss.defineColumn("lt", typeof(DateTime),false);
	tcommiss.defineColumn("lu", typeof(string),false);
	Tables.Add(tcommiss);
	tcommiss.defineKey("idcommiss", "idcorsostudio", "iddidprog", "idprova");

	//////////////////// VALUTAZIONEKIND /////////////////////////////////
	var tvalutazionekind= new MetaTable("valutazionekind");
	tvalutazionekind.defineColumn("active", typeof(string),false);
	tvalutazionekind.defineColumn("idvalutazionekind", typeof(int),false);
	tvalutazionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tvalutazionekind);
	tvalutazionekind.defineKey("idvalutazionekind");

	//////////////////// QUESTIONARIODEFAULTVIEW /////////////////////////////////
	var tquestionariodefaultview= new MetaTable("questionariodefaultview");
	tquestionariodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tquestionariodefaultview.defineColumn("idquestionario", typeof(int),false);
	Tables.Add(tquestionariodefaultview);
	tquestionariodefaultview.defineKey("idquestionario");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("ct", typeof(DateTime),false);
	tprova.defineColumn("cu", typeof(string),false);
	tprova.defineColumn("idappello", typeof(int));
	tprova.defineColumn("idattivform", typeof(int));
	tprova.defineColumn("idcorsostudio", typeof(int),false);
	tprova.defineColumn("iddidprog", typeof(int),false);
	tprova.defineColumn("idprova", typeof(int),false);
	tprova.defineColumn("idquestionario", typeof(int));
	tprova.defineColumn("idvalutazionekind", typeof(int));
	tprova.defineColumn("lt", typeof(DateTime),false);
	tprova.defineColumn("lu", typeof(string),false);
	tprova.defineColumn("programma", typeof(string));
	tprova.defineColumn("start", typeof(DateTime),false);
	tprova.defineColumn("stop", typeof(DateTime),false);
	tprova.defineColumn("title", typeof(string),false);
	Tables.Add(tprova);
	tprova.defineKey("idcorsostudio", "iddidprog", "idprova");

	#endregion


	#region DataRelation creation
	var cPar = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"], prova.Columns["idprova"]};
	var cChild = new []{sostenimento.Columns["idcorsostudio"], sostenimento.Columns["iddidprog"], sostenimento.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_sostenimento_prova_idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{sostenimentoesito.Columns["idsostenimentoesito"]};
	cChild = new []{sostenimento.Columns["idsostenimentoesito"]};
	Relations.Add(new DataRelation("FK_sostenimento_sostenimentoesito_idsostenimentoesito",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_registry_alias2_idreg",cPar,cChild,false));

	cPar = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"], prova.Columns["idprova"]};
	cChild = new []{provaaula.Columns["idcorsostudio"], provaaula.Columns["iddidprog"], provaaula.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_provaaula_prova_idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{aula.Columns["idaula"]};
	cChild = new []{provaaula.Columns["idaula"]};
	Relations.Add(new DataRelation("FK_provaaula_aula_idaula",cPar,cChild,false));

	cPar = new []{struttura_alias1.Columns["idstruttura"]};
	cChild = new []{aula.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_aula_struttura_alias1_idstruttura",cPar,cChild,false));

	cPar = new []{edificio.Columns["idedificio"]};
	cChild = new []{aula.Columns["idedificio"]};
	Relations.Add(new DataRelation("FK_aula_edificio_idedificio",cPar,cChild,false));

	cPar = new []{aulakind.Columns["idaulakind"]};
	cChild = new []{aula.Columns["idaulakind"]};
	Relations.Add(new DataRelation("FK_aula_aulakind_idaulakind",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura_alias1.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_alias1_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{prova.Columns["idcorsostudio"], prova.Columns["iddidprog"], prova.Columns["idprova"]};
	cChild = new []{commiss.Columns["idcorsostudio"], commiss.Columns["iddidprog"], commiss.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commiss_prova_idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{commiss.Columns["idcommiss"], commiss.Columns["idcorsostudio"], commiss.Columns["iddidprog"], commiss.Columns["idprova"]};
	cChild = new []{commissregistry_docenti.Columns["idcommiss"], commissregistry_docenti.Columns["idcorsostudio"], commissregistry_docenti.Columns["iddidprog"], commissregistry_docenti.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_commiss_idcommiss-idcorsostudio-iddidprog-idprova",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{commissregistry_docenti.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_commissregistry_docenti_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_docenti_registry_idreg",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{registry_docenti.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_registry_docenti_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{registry_docenti.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_registry_docenti_sasd_idsasd",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_registry_docenti_registry_alias1_idreg_istituti",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_istituti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istituti_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{registry_docenti.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_registry_docenti_contrattokind_idcontrattokind",cPar,cChild,false));

	cPar = new []{classconsorsuale.Columns["idclassconsorsuale"]};
	cChild = new []{registry_docenti.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_registry_docenti_classconsorsuale_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{commiss.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_commiss_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{valutazionekind.Columns["idvalutazionekind"]};
	cChild = new []{prova.Columns["idvalutazionekind"]};
	Relations.Add(new DataRelation("FK_prova_valutazionekind_idvalutazionekind",cPar,cChild,false));

	cPar = new []{questionariodefaultview.Columns["idquestionario"]};
	cChild = new []{prova.Columns["idquestionario"]};
	Relations.Add(new DataRelation("FK_prova_questionariodefaultview_idquestionario",cPar,cChild,false));

	#endregion

}
}
}
