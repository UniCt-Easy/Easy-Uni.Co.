
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
[System.Xml.Serialization.XmlRoot("dsmeta_tirocinioproposto_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tirocinioproposto_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioappr 		=> (MetaTable)Tables["tirocinioappr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioinvioazienda 		=> (MetaTable)Tables["tirocinioinvioazienda"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniorelazione 		=> (MetaTable)Tables["tirociniorelazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniodiario 		=> (MetaTable)Tables["tirociniodiario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioprogetto 		=> (MetaTable)Tables["tirocinioprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniocandidaturakind 		=> (MetaTable)Tables["tirociniocandidaturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_studenti 		=> (MetaTable)Tables["registry_studenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_docenti 		=> (MetaTable)Tables["registry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniocandidatura 		=> (MetaTable)Tables["tirociniocandidatura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoodefaultview 		=> (MetaTable)Tables["aoodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioproposto 		=> (MetaTable)Tables["tirocinioproposto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tirocinioproposto_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tirocinioproposto_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tirocinioproposto_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tirocinioproposto_seg.xsd";

	#region create DataTables
	//////////////////// TIROCINIOAPPR /////////////////////////////////
	var ttirocinioappr= new MetaTable("tirocinioappr");
	ttirocinioappr.defineColumn("approvazione", typeof(string));
	ttirocinioappr.defineColumn("ct", typeof(DateTime),false);
	ttirocinioappr.defineColumn("cu", typeof(string),false);
	ttirocinioappr.defineColumn("dataora", typeof(DateTime));
	ttirocinioappr.defineColumn("idreg_docenti", typeof(int));
	ttirocinioappr.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioappr.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioappr", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioapprkind", typeof(int));
	ttirocinioappr.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioappr.defineColumn("lt", typeof(DateTime),false);
	ttirocinioappr.defineColumn("lu", typeof(string),false);
	Tables.Add(ttirocinioappr);
	ttirocinioappr.defineKey("idreg_referente", "idreg_studenti", "idtirocinioappr", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// TIROCINIOINVIOAZIENDA /////////////////////////////////
	var ttirocinioinvioazienda= new MetaTable("tirocinioinvioazienda");
	ttirocinioinvioazienda.defineColumn("ct", typeof(DateTime),false);
	ttirocinioinvioazienda.defineColumn("cu", typeof(string),false);
	ttirocinioinvioazienda.defineColumn("dataora", typeof(DateTime));
	ttirocinioinvioazienda.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioinvioazienda", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("lt", typeof(DateTime),false);
	ttirocinioinvioazienda.defineColumn("lu", typeof(string),false);
	Tables.Add(ttirocinioinvioazienda);
	ttirocinioinvioazienda.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioinvioazienda", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// TIROCINIORELAZIONE /////////////////////////////////
	var ttirociniorelazione= new MetaTable("tirociniorelazione");
	ttirociniorelazione.defineColumn("attivitasvolta", typeof(string));
	ttirociniorelazione.defineColumn("autovalutazione", typeof(string));
	ttirociniorelazione.defineColumn("competenze", typeof(string));
	ttirociniorelazione.defineColumn("conclusioni", typeof(string));
	ttirociniorelazione.defineColumn("considerazioni", typeof(string));
	ttirociniorelazione.defineColumn("ct", typeof(DateTime));
	ttirociniorelazione.defineColumn("cu", typeof(string));
	ttirociniorelazione.defineColumn("descrazienda", typeof(string));
	ttirociniorelazione.defineColumn("idreg_referente", typeof(int),false);
	ttirociniorelazione.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirociniorelazione", typeof(int),false);
	ttirociniorelazione.defineColumn("introduzione", typeof(string));
	ttirociniorelazione.defineColumn("lt", typeof(DateTime));
	ttirociniorelazione.defineColumn("lu", typeof(string));
	Tables.Add(ttirociniorelazione);
	ttirociniorelazione.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto", "idtirociniorelazione");

	//////////////////// TIROCINIODIARIO /////////////////////////////////
	var ttirociniodiario= new MetaTable("tirociniodiario");
	ttirociniodiario.defineColumn("ct", typeof(DateTime),false);
	ttirociniodiario.defineColumn("cu", typeof(string),false);
	ttirociniodiario.defineColumn("data", typeof(DateTime));
	ttirociniodiario.defineColumn("description", typeof(string));
	ttirociniodiario.defineColumn("idreg_referente", typeof(int),false);
	ttirociniodiario.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniodiario.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniodiario.defineColumn("idtirociniodiario", typeof(int),false);
	ttirociniodiario.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirociniodiario.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniodiario.defineColumn("lt", typeof(DateTime),false);
	ttirociniodiario.defineColumn("lu", typeof(string),false);
	ttirociniodiario.defineColumn("ore", typeof(int));
	Tables.Add(ttirociniodiario);
	ttirociniodiario.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirociniodiario", "idtirocinioprogetto", "idtirocinioproposto");

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

	//////////////////// TIROCINIOCANDIDATURAKIND /////////////////////////////////
	var ttirociniocandidaturakind= new MetaTable("tirociniocandidaturakind");
	ttirociniocandidaturakind.defineColumn("active", typeof(string),false);
	ttirociniocandidaturakind.defineColumn("idtirociniocandidaturakind", typeof(int),false);
	ttirociniocandidaturakind.defineColumn("title", typeof(string),false);
	Tables.Add(ttirociniocandidaturakind);
	ttirociniocandidaturakind.defineKey("idtirociniocandidaturakind");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("annotation", typeof(string));
	tregistry_alias1.defineColumn("authorization_free", typeof(string));
	tregistry_alias1.defineColumn("badgecode", typeof(string));
	tregistry_alias1.defineColumn("birthdate", typeof(DateTime),false);
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
	tregistry_alias1.defineColumn("forename", typeof(string),false);
	tregistry_alias1.defineColumn("gender", typeof(string),false);
	tregistry_alias1.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias1.defineColumn("idcategory", typeof(string));
	tregistry_alias1.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias1.defineColumn("idcity", typeof(int),false);
	tregistry_alias1.defineColumn("idexternal", typeof(int));
	tregistry_alias1.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias1.defineColumn("idnation", typeof(int),false);
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
	tregistry_alias1.defineColumn("surname", typeof(string),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.defineColumn("toredirect", typeof(int));
	tregistry_alias1.defineColumn("txt", typeof(string));
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

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

	//////////////////// TIROCINIOCANDIDATURA /////////////////////////////////
	var ttirociniocandidatura= new MetaTable("tirociniocandidatura");
	ttirociniocandidatura.defineColumn("ct", typeof(DateTime),false);
	ttirociniocandidatura.defineColumn("cu", typeof(string),false);
	ttirociniocandidatura.defineColumn("data", typeof(DateTime));
	ttirociniocandidatura.defineColumn("idreg_docenti", typeof(int));
	ttirociniocandidatura.defineColumn("idreg_referente", typeof(int),false);
	ttirociniocandidatura.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniocandidatura.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniocandidatura.defineColumn("idtirociniocandidaturakind", typeof(int),false);
	ttirociniocandidatura.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniocandidatura.defineColumn("lt", typeof(DateTime),false);
	ttirociniocandidatura.defineColumn("lu", typeof(string),false);
	ttirociniocandidatura.defineColumn("!idreg_docenti_registry_docenti_title", typeof(string));
	ttirociniocandidatura.defineColumn("!idreg_studenti_registry_studenti_title", typeof(string));
	ttirociniocandidatura.defineColumn("!idtirociniocandidaturakind_tirociniocandidaturakind_title", typeof(string));
	Tables.Add(ttirociniocandidatura);
	ttirociniocandidatura.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioproposto");

	//////////////////// AOODEFAULTVIEW /////////////////////////////////
	var taoodefaultview= new MetaTable("aoodefaultview");
	taoodefaultview.defineColumn("dropdown_title", typeof(string),false);
	taoodefaultview.defineColumn("idaoo", typeof(int),false);
	Tables.Add(taoodefaultview);
	taoodefaultview.defineKey("idaoo");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// TIROCINIOPROPOSTO /////////////////////////////////
	var ttirocinioproposto= new MetaTable("tirocinioproposto");
	ttirocinioproposto.defineColumn("ct", typeof(DateTime),false);
	ttirocinioproposto.defineColumn("cu", typeof(string),false);
	ttirocinioproposto.defineColumn("description", typeof(string));
	ttirocinioproposto.defineColumn("description_en", typeof(string));
	ttirocinioproposto.defineColumn("idaoo", typeof(int),false);
	ttirocinioproposto.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioproposto.defineColumn("idstruttura", typeof(int),false);
	ttirocinioproposto.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioproposto.defineColumn("lt", typeof(DateTime),false);
	ttirocinioproposto.defineColumn("lu", typeof(string),false);
	ttirocinioproposto.defineColumn("ore", typeof(int),false);
	ttirocinioproposto.defineColumn("title", typeof(string),false);
	ttirocinioproposto.defineColumn("title_en", typeof(string));
	Tables.Add(ttirocinioproposto);
	ttirocinioproposto.defineKey("idreg_referente", "idtirocinioproposto");

	#endregion


	#region DataRelation creation
	var cPar = new []{tirocinioproposto.Columns["idreg_referente"], tirocinioproposto.Columns["idtirocinioproposto"]};
	var cChild = new []{tirociniocandidatura.Columns["idreg_referente"], tirociniocandidatura.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirociniocandidatura_tirocinioproposto_idreg_referente-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirociniocandidatura.Columns["idreg_referente"], tirociniocandidatura.Columns["idreg_studenti"], tirociniocandidatura.Columns["idtirociniocandidatura"], tirociniocandidatura.Columns["idtirocinioproposto"]};
	cChild = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_tirociniocandidatura_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirocinioappr.Columns["idreg_referente"], tirocinioappr.Columns["idreg_studenti"], tirocinioappr.Columns["idtirociniocandidatura"], tirocinioappr.Columns["idtirocinioprogetto"], tirocinioappr.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioappr_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirocinioinvioazienda.Columns["idreg_referente"], tirocinioinvioazienda.Columns["idreg_studenti"], tirocinioinvioazienda.Columns["idtirociniocandidatura"], tirocinioinvioazienda.Columns["idtirocinioprogetto"], tirocinioinvioazienda.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioinvioazienda_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirociniorelazione.Columns["idreg_referente"], tirociniorelazione.Columns["idreg_studenti"], tirociniorelazione.Columns["idtirociniocandidatura"], tirociniorelazione.Columns["idtirocinioprogetto"], tirociniorelazione.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirociniorelazione_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirociniodiario.Columns["idreg_referente"], tirociniodiario.Columns["idreg_studenti"], tirociniodiario.Columns["idtirociniocandidatura"], tirociniodiario.Columns["idtirocinioprogetto"], tirociniodiario.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirociniodiario_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirociniocandidaturakind.Columns["idtirociniocandidaturakind"]};
	cChild = new []{tirociniocandidatura.Columns["idtirociniocandidaturakind"]};
	Relations.Add(new DataRelation("FK_tirociniocandidatura_tirociniocandidaturakind_idtirociniocandidaturakind",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{tirociniocandidatura.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_tirociniocandidatura_registry_alias1_idreg_studenti",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_studenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_studenti_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{tirociniocandidatura.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_tirociniocandidatura_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_docenti_registry_idreg",cPar,cChild,false));

	cPar = new []{aoodefaultview.Columns["idaoo"]};
	cChild = new []{tirocinioproposto.Columns["idaoo"]};
	Relations.Add(new DataRelation("FK_tirocinioproposto_aoodefaultview_idaoo",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{tirocinioproposto.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_tirocinioproposto_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{tirocinioproposto.Columns["idreg_referente"]};
	Relations.Add(new DataRelation("FK_tirocinioproposto_registrydefaultview_idreg_referente",cPar,cChild,false));

	#endregion

}
}
}
