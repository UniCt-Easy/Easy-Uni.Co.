/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_lezione_docenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_lezione_docenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontlezionestud 		=> (MetaTable)Tables["rendicontlezionestud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentosegview 		=> (MetaTable)Tables["affidamentosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canaledefaultview 		=> (MetaTable)Tables["canaledefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformdefaultview 		=> (MetaTable)Tables["attivformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzannodefaultview 		=> (MetaTable)Tables["didprogporzannodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogannodefaultview 		=> (MetaTable)Tables["didprogannodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogoridefaultview 		=> (MetaTable)Tables["didprogoridefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione 		=> (MetaTable)Tables["lezione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_lezione_docenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_lezione_docenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_lezione_docenti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_lezione_docenti.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("acronim", typeof(string));
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("code", typeof(string));
	tregistry.defineColumn("codicemiur", typeof(string));
	tregistry.defineColumn("codiceustat", typeof(string));
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
	tregistry.defineColumn("idanpr", typeof(string));
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry.defineColumn("idistitutokind", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnace", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idnaturagiur", typeof(int));
	tregistry.defineColumn("idnumerodip", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idreg_istituti", typeof(int));
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idsasd", typeof(int));
	tregistry.defineColumn("idstruttura", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("indicebibliometrico", typeof(int));
	tregistry.defineColumn("institutionalcode", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("pic", typeof(string));
	tregistry.defineColumn("referencenumber", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("ricevimento", typeof(string));
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("soggiorno", typeof(string));
	tregistry.defineColumn("surname", typeof(string),false);
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("title_en", typeof(string));
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// RENDICONTLEZIONESTUD /////////////////////////////////
	var trendicontlezionestud= new MetaTable("rendicontlezionestud");
	trendicontlezionestud.defineColumn("aa", typeof(string),false);
	trendicontlezionestud.defineColumn("assente", typeof(string),false);
	trendicontlezionestud.defineColumn("ct", typeof(DateTime),false);
	trendicontlezionestud.defineColumn("cu", typeof(string),false);
	trendicontlezionestud.defineColumn("idaffidamento", typeof(int),false);
	trendicontlezionestud.defineColumn("idattivform", typeof(int),false);
	trendicontlezionestud.defineColumn("idaula", typeof(int),false);
	trendicontlezionestud.defineColumn("idcanale", typeof(int),false);
	trendicontlezionestud.defineColumn("idcorsostudio", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprog", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidproganno", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogcurr", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogori", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogporzanno", typeof(int),false);
	trendicontlezionestud.defineColumn("idedificio", typeof(int),false);
	trendicontlezionestud.defineColumn("idlezione", typeof(int),false);
	trendicontlezionestud.defineColumn("idreg_docenti", typeof(int),false);
	trendicontlezionestud.defineColumn("idreg_studenti", typeof(int),false);
	trendicontlezionestud.defineColumn("idsede", typeof(int),false);
	trendicontlezionestud.defineColumn("lt", typeof(DateTime),false);
	trendicontlezionestud.defineColumn("lu", typeof(string),false);
	trendicontlezionestud.defineColumn("notadisciplinare", typeof(string));
	trendicontlezionestud.defineColumn("ritardo", typeof(DateTime));
	trendicontlezionestud.defineColumn("ritardogiustifica", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_surname", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_forename", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_cf", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_extmatricula", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_active", typeof(string));
	Tables.Add(trendicontlezionestud);
	trendicontlezionestud.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idreg_studenti", "idsede");

	//////////////////// AFFIDAMENTOSEGVIEW /////////////////////////////////
	var taffidamentosegview= new MetaTable("affidamentosegview");
	taffidamentosegview.defineColumn("aa", typeof(string),false);
	taffidamentosegview.defineColumn("affidamento_ct", typeof(DateTime),false);
	taffidamentosegview.defineColumn("affidamento_cu", typeof(string),false);
	taffidamentosegview.defineColumn("affidamento_freqobbl", typeof(string));
	taffidamentosegview.defineColumn("affidamento_frequenzaminima", typeof(int));
	taffidamentosegview.defineColumn("affidamento_frequenzaminimadebito", typeof(int));
	taffidamentosegview.defineColumn("affidamento_gratuito", typeof(string));
	taffidamentosegview.defineColumn("affidamento_idaffidamentokind", typeof(int),false);
	taffidamentosegview.defineColumn("affidamento_iderogazkind", typeof(int));
	taffidamentosegview.defineColumn("affidamento_idsede", typeof(int),false);
	taffidamentosegview.defineColumn("affidamento_json", typeof(string));
	taffidamentosegview.defineColumn("affidamento_jsonancestor", typeof(string));
	taffidamentosegview.defineColumn("affidamento_lt", typeof(DateTime),false);
	taffidamentosegview.defineColumn("affidamento_lu", typeof(string),false);
	taffidamentosegview.defineColumn("affidamento_orariric", typeof(string));
	taffidamentosegview.defineColumn("affidamento_orariric_en", typeof(string));
	taffidamentosegview.defineColumn("affidamento_paridaffidamento", typeof(int));
	taffidamentosegview.defineColumn("affidamento_prog", typeof(string));
	taffidamentosegview.defineColumn("affidamento_prog_en", typeof(string));
	taffidamentosegview.defineColumn("affidamento_riferimento", typeof(string));
	taffidamentosegview.defineColumn("affidamento_start", typeof(DateTime));
	taffidamentosegview.defineColumn("affidamento_stop", typeof(DateTime));
	taffidamentosegview.defineColumn("affidamento_testi", typeof(string));
	taffidamentosegview.defineColumn("affidamento_testi_en", typeof(string));
	taffidamentosegview.defineColumn("affidamento_urlcorso", typeof(string));
	taffidamentosegview.defineColumn("affidamentokind_title", typeof(string));
	taffidamentosegview.defineColumn("dropdown_title", typeof(string),false);
	taffidamentosegview.defineColumn("erogazkind_title", typeof(string));
	taffidamentosegview.defineColumn("idaffidamento", typeof(int),false);
	taffidamentosegview.defineColumn("idattivform", typeof(int),false);
	taffidamentosegview.defineColumn("idcanale", typeof(int),false);
	taffidamentosegview.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentosegview.defineColumn("iddidprog", typeof(int),false);
	taffidamentosegview.defineColumn("iddidproganno", typeof(int),false);
	taffidamentosegview.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentosegview.defineColumn("iddidprogori", typeof(int),false);
	taffidamentosegview.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentosegview.defineColumn("idreg_docenti", typeof(int),false);
	taffidamentosegview.defineColumn("title", typeof(string));
	Tables.Add(taffidamentosegview);
	taffidamentosegview.defineKey("aa", "idaffidamento", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idreg_docenti");

	//////////////////// CANALEDEFAULTVIEW /////////////////////////////////
	var tcanaledefaultview= new MetaTable("canaledefaultview");
	tcanaledefaultview.defineColumn("aa", typeof(string),false);
	tcanaledefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcanaledefaultview.defineColumn("idattivform", typeof(int),false);
	tcanaledefaultview.defineColumn("idcanale", typeof(int),false);
	tcanaledefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcanaledefaultview.defineColumn("iddidprog", typeof(int),false);
	tcanaledefaultview.defineColumn("iddidproganno", typeof(int),false);
	tcanaledefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tcanaledefaultview.defineColumn("iddidprogori", typeof(int),false);
	tcanaledefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	Tables.Add(tcanaledefaultview);
	tcanaledefaultview.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// ATTIVFORMDEFAULTVIEW /////////////////////////////////
	var tattivformdefaultview= new MetaTable("attivformdefaultview");
	tattivformdefaultview.defineColumn("aa", typeof(string),false);
	tattivformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// DIDPROGPORZANNODEFAULTVIEW /////////////////////////////////
	var tdidprogporzannodefaultview= new MetaTable("didprogporzannodefaultview");
	tdidprogporzannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	Tables.Add(tdidprogporzannodefaultview);
	tdidprogporzannodefaultview.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// DIDPROGANNODEFAULTVIEW /////////////////////////////////
	var tdidprogannodefaultview= new MetaTable("didprogannodefaultview");
	tdidprogannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	Tables.Add(tdidprogannodefaultview);
	tdidprogannodefaultview.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGORIDEFAULTVIEW /////////////////////////////////
	var tdidprogoridefaultview= new MetaTable("didprogoridefaultview");
	tdidprogoridefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogoridefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogori", typeof(int),false);
	Tables.Add(tdidprogoridefaultview);
	tdidprogoridefaultview.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// LEZIONE /////////////////////////////////
	var tlezione= new MetaTable("lezione");
	tlezione.defineColumn("!title", typeof(string));
	tlezione.defineColumn("aa", typeof(string),false);
	tlezione.defineColumn("ct", typeof(DateTime),false);
	tlezione.defineColumn("cu", typeof(string),false);
	tlezione.defineColumn("idaffidamento", typeof(int),false);
	tlezione.defineColumn("idattivform", typeof(int),false);
	tlezione.defineColumn("idaula", typeof(int),false);
	tlezione.defineColumn("idcanale", typeof(int),false);
	tlezione.defineColumn("idcorsostudio", typeof(int),false);
	tlezione.defineColumn("iddidprog", typeof(int),false);
	tlezione.defineColumn("iddidproganno", typeof(int),false);
	tlezione.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione.defineColumn("iddidprogori", typeof(int),false);
	tlezione.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione.defineColumn("idedificio", typeof(int),false);
	tlezione.defineColumn("idlezione", typeof(int),false);
	tlezione.defineColumn("idreg_docenti", typeof(int),false);
	tlezione.defineColumn("idsede", typeof(int),false);
	tlezione.defineColumn("lt", typeof(DateTime),false);
	tlezione.defineColumn("lu", typeof(string),false);
	tlezione.defineColumn("nonsvolta", typeof(string));
	tlezione.defineColumn("stage", typeof(string));
	tlezione.defineColumn("start", typeof(DateTime),false);
	tlezione.defineColumn("stop", typeof(DateTime),false);
	tlezione.defineColumn("titolo", typeof(string));
	tlezione.defineColumn("visita", typeof(string));
	Tables.Add(tlezione);
	tlezione.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{lezione.Columns["aa"], lezione.Columns["idaffidamento"], lezione.Columns["idattivform"], lezione.Columns["idaula"], lezione.Columns["idcanale"], lezione.Columns["idcorsostudio"], lezione.Columns["iddidprog"], lezione.Columns["iddidproganno"], lezione.Columns["iddidprogcurr"], lezione.Columns["iddidprogori"], lezione.Columns["iddidprogporzanno"], lezione.Columns["idedificio"], lezione.Columns["idlezione"], lezione.Columns["idreg_docenti"], lezione.Columns["idsede"]};
	var cChild = new []{rendicontlezionestud.Columns["aa"], rendicontlezionestud.Columns["idaffidamento"], rendicontlezionestud.Columns["idattivform"], rendicontlezionestud.Columns["idaula"], rendicontlezionestud.Columns["idcanale"], rendicontlezionestud.Columns["idcorsostudio"], rendicontlezionestud.Columns["iddidprog"], rendicontlezionestud.Columns["iddidproganno"], rendicontlezionestud.Columns["iddidprogcurr"], rendicontlezionestud.Columns["iddidprogori"], rendicontlezionestud.Columns["iddidprogporzanno"], rendicontlezionestud.Columns["idedificio"], rendicontlezionestud.Columns["idlezione"], rendicontlezionestud.Columns["idreg_docenti"], rendicontlezionestud.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_rendicontlezionestud_lezione_aa-idaffidamento-idattivform-idaula-idcanale-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idedificio-idlezione-idreg_docenti-idsede",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{rendicontlezionestud.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_rendicontlezionestud_registry_idreg_studenti",cPar,cChild,false));

	cPar = new []{affidamentosegview.Columns["idaffidamento"]};
	cChild = new []{lezione.Columns["idaffidamento"]};
	Relations.Add(new DataRelation("FK_lezione_affidamentosegview_idaffidamento",cPar,cChild,false));

	#endregion

}
}
}
