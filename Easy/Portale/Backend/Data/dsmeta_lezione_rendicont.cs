
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
[System.Xml.Serialization.XmlRoot("dsmeta_lezione_rendicont"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_lezione_rendicont: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studprenotkind 		=> (MetaTable)Tables["studprenotkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studdirittokind 		=> (MetaTable)Tables["studdirittokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_studenti 		=> (MetaTable)Tables["registry_studenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontlezionestud 		=> (MetaTable)Tables["rendicontlezionestud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentosegview 		=> (MetaTable)Tables["affidamentosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

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
public dsmeta_lezione_rendicont(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_lezione_rendicont (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_lezione_rendicont";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_lezione_rendicont.xsd";

	#region create DataTables
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
	tregistry.defineColumn("idnation", typeof(int),false);
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

	//////////////////// STUDPRENOTKIND /////////////////////////////////
	var tstudprenotkind= new MetaTable("studprenotkind");
	tstudprenotkind.defineColumn("active", typeof(string),false);
	tstudprenotkind.defineColumn("idstudprenotkind", typeof(int),false);
	tstudprenotkind.defineColumn("title", typeof(string),false);
	Tables.Add(tstudprenotkind);
	tstudprenotkind.defineKey("idstudprenotkind");

	//////////////////// STUDDIRITTOKIND /////////////////////////////////
	var tstuddirittokind= new MetaTable("studdirittokind");
	tstuddirittokind.defineColumn("active", typeof(string),false);
	tstuddirittokind.defineColumn("idstuddirittokind", typeof(int),false);
	tstuddirittokind.defineColumn("title", typeof(string),false);
	Tables.Add(tstuddirittokind);
	tstuddirittokind.defineKey("idstuddirittokind");

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
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_title", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_cf", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_p_iva", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_active", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_registry_studenti_authinps", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_studdirittokind_title", typeof(string));
	trendicontlezionestud.defineColumn("!idreg_studenti_studprenotkind_title", typeof(string));
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
	taffidamentosegview.defineColumn("idreg_docenti", typeof(int));
	taffidamentosegview.defineColumn("title", typeof(string));
	Tables.Add(taffidamentosegview);
	taffidamentosegview.defineKey("idaffidamento");

	//////////////////// CANALE /////////////////////////////////
	var tcanale= new MetaTable("canale");
	tcanale.defineColumn("aa", typeof(string),false);
	tcanale.defineColumn("ct", typeof(DateTime),false);
	tcanale.defineColumn("cu", typeof(string),false);
	tcanale.defineColumn("CUIN", typeof(string));
	tcanale.defineColumn("idattivform", typeof(int),false);
	tcanale.defineColumn("idcanale", typeof(int),false);
	tcanale.defineColumn("idcorsostudio", typeof(int),false);
	tcanale.defineColumn("iddidprog", typeof(int),false);
	tcanale.defineColumn("iddidproganno", typeof(int),false);
	tcanale.defineColumn("iddidprogcurr", typeof(int),false);
	tcanale.defineColumn("iddidprogori", typeof(int),false);
	tcanale.defineColumn("iddidprogporzanno", typeof(int),false);
	tcanale.defineColumn("idsede", typeof(int),false);
	tcanale.defineColumn("lt", typeof(DateTime),false);
	tcanale.defineColumn("lu", typeof(string),false);
	tcanale.defineColumn("numerostud", typeof(int));
	tcanale.defineColumn("sortcode", typeof(int));
	tcanale.defineColumn("title", typeof(string));
	Tables.Add(tcanale);
	tcanale.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// ATTIVFORMDEFAULTVIEW /////////////////////////////////
	var tattivformdefaultview= new MetaTable("attivformdefaultview");
	tattivformdefaultview.defineColumn("aa", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_ct", typeof(DateTime),false);
	tattivformdefaultview.defineColumn("attivform_cu", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_iddidproggrupp", typeof(int));
	tattivformdefaultview.defineColumn("attivform_lt", typeof(DateTime),false);
	tattivformdefaultview.defineColumn("attivform_lu", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_obbform", typeof(string));
	tattivformdefaultview.defineColumn("attivform_obbform_en", typeof(string));
	tattivformdefaultview.defineColumn("attivform_sortcode", typeof(int));
	tattivformdefaultview.defineColumn("attivform_start", typeof(DateTime));
	tattivformdefaultview.defineColumn("attivform_stop", typeof(DateTime));
	tattivformdefaultview.defineColumn("attivform_tipovalutaz", typeof(string));
	tattivformdefaultview.defineColumn("didproganno_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogcurr_title", typeof(string));
	tattivformdefaultview.defineColumn("didproggrupp_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogori_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogporzanno_title", typeof(string));
	tattivformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegn", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegninteg", typeof(int));
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	tattivformdefaultview.defineColumn("insegn_codice", typeof(string));
	tattivformdefaultview.defineColumn("insegn_denominazione", typeof(string));
	tattivformdefaultview.defineColumn("insegninteg_codice", typeof(string));
	tattivformdefaultview.defineColumn("insegninteg_denominazione", typeof(string));
	tattivformdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("idattivform");

	//////////////////// DIDPROGPORZANNODEFAULTVIEW /////////////////////////////////
	var tdidprogporzannodefaultview= new MetaTable("didprogporzannodefaultview");
	tdidprogporzannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_ct", typeof(DateTime),false);
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_cu", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_iddidprogporzannokind", typeof(int));
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_indice", typeof(int));
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_lt", typeof(DateTime),false);
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_lu", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_start", typeof(DateTime));
	tdidprogporzannodefaultview.defineColumn("didprogporzanno_stop", typeof(DateTime));
	tdidprogporzannodefaultview.defineColumn("didprogporzannokind_title", typeof(string));
	tdidprogporzannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("title", typeof(string));
	Tables.Add(tdidprogporzannodefaultview);
	tdidprogporzannodefaultview.defineKey("iddidprogporzanno");

	//////////////////// DIDPROGANNODEFAULTVIEW /////////////////////////////////
	var tdidprogannodefaultview= new MetaTable("didprogannodefaultview");
	tdidprogannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogannodefaultview.defineColumn("didproganno_anno", typeof(int));
	tdidprogannodefaultview.defineColumn("didproganno_cf", typeof(decimal));
	tdidprogannodefaultview.defineColumn("didproganno_ct", typeof(DateTime),false);
	tdidprogannodefaultview.defineColumn("didproganno_cu", typeof(string),false);
	tdidprogannodefaultview.defineColumn("didproganno_lt", typeof(DateTime),false);
	tdidprogannodefaultview.defineColumn("didproganno_lu", typeof(string),false);
	tdidprogannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	tdidprogannodefaultview.defineColumn("title", typeof(string));
	Tables.Add(tdidprogannodefaultview);
	tdidprogannodefaultview.defineKey("iddidproganno");

	//////////////////// DIDPROGORIDEFAULTVIEW /////////////////////////////////
	var tdidprogoridefaultview= new MetaTable("didprogoridefaultview");
	tdidprogoridefaultview.defineColumn("corsostudio_annoistituz", typeof(int));
	tdidprogoridefaultview.defineColumn("corsostudio_title", typeof(string));
	tdidprogoridefaultview.defineColumn("didprogori_codice", typeof(string));
	tdidprogoridefaultview.defineColumn("didprogori_ct", typeof(DateTime),false);
	tdidprogoridefaultview.defineColumn("didprogori_cu", typeof(string),false);
	tdidprogoridefaultview.defineColumn("didprogori_lt", typeof(DateTime),false);
	tdidprogoridefaultview.defineColumn("didprogori_lu", typeof(string),false);
	tdidprogoridefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogoridefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogori", typeof(int),false);
	tdidprogoridefaultview.defineColumn("title", typeof(string));
	Tables.Add(tdidprogoridefaultview);
	tdidprogoridefaultview.defineKey("iddidprogori");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("codice", typeof(string));
	tdidprogcurr.defineColumn("codicemiur", typeof(string));
	tdidprogcurr.defineColumn("ct", typeof(DateTime),false);
	tdidprogcurr.defineColumn("cu", typeof(string),false);
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("lt", typeof(DateTime),false);
	tdidprogcurr.defineColumn("lu", typeof(string),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

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

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudiodefaultview.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudiodefaultview.defineColumn("idstruttura", typeof(int));
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

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_studenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_studenti_registry_idreg",cPar,cChild,false));

	cPar = new []{studprenotkind.Columns["idstudprenotkind"]};
	cChild = new []{registry_studenti.Columns["idstudprenotkind"]};
	Relations.Add(new DataRelation("FK_registry_studenti_studprenotkind_idstudprenotkind",cPar,cChild,false));

	cPar = new []{studdirittokind.Columns["idstuddirittokind"]};
	cChild = new []{registry_studenti.Columns["idstuddirittokind"]};
	Relations.Add(new DataRelation("FK_registry_studenti_studdirittokind_idstuddirittokind",cPar,cChild,false));

	cPar = new []{affidamentosegview.Columns["idaffidamento"]};
	cChild = new []{lezione.Columns["idaffidamento"]};
	Relations.Add(new DataRelation("FK_lezione_affidamentosegview_idaffidamento",cPar,cChild,false));

	cPar = new []{canale.Columns["idcanale"]};
	cChild = new []{lezione.Columns["idcanale"]};
	Relations.Add(new DataRelation("FK_lezione_canale_idcanale",cPar,cChild,false));

	cPar = new []{attivformdefaultview.Columns["idattivform"]};
	cChild = new []{lezione.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_lezione_attivformdefaultview_idattivform",cPar,cChild,false));

	cPar = new []{didprogporzannodefaultview.Columns["iddidprogporzanno"]};
	cChild = new []{lezione.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_lezione_didprogporzannodefaultview_iddidprogporzanno",cPar,cChild,false));

	cPar = new []{didprogannodefaultview.Columns["iddidproganno"]};
	cChild = new []{lezione.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_lezione_didprogannodefaultview_iddidproganno",cPar,cChild,false));

	cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	cChild = new []{lezione.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_lezione_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{lezione.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_lezione_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{lezione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_lezione_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{lezione.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_lezione_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	#endregion

}
}
}
