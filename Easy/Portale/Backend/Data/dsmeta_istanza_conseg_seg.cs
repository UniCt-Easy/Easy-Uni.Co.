
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
	[Serializable, DesignerCategory("code"), System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
	[System.Xml.Serialization.XmlRoot("dsmeta_istanza_conseg_seg"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
	public class dsmeta_istanza_conseg_seg :DataSet {

		#region Table members declaration
		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable tesikeyword => (MetaTable)Tables["tesikeyword"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable tesi => (MetaTable)Tables["tesi"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registry_alias1 => (MetaTable)Tables["registry_alias1"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registry_docenti_alias1 => (MetaTable)Tables["registry_docenti_alias1"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable richitesi => (MetaTable)Tables["richitesi"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable relatorekind => (MetaTable)Tables["relatorekind"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registry => (MetaTable)Tables["registry"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registry_docenti => (MetaTable)Tables["registry_docenti"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable relatore => (MetaTable)Tables["relatore"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable appellosegview => (MetaTable)Tables["appellosegview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable statuskind => (MetaTable)Tables["statuskind"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registrystudentiview => (MetaTable)Tables["registrystudentiview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable didprogdefaultview => (MetaTable)Tables["didprogdefaultview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable annoaccademico => (MetaTable)Tables["annoaccademico"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable istanza => (MetaTable)Tables["istanza"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable istanza_conseg => (MetaTable)Tables["istanza_conseg"];

		#endregion


		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataTableCollection Tables => base.Tables;

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once MemberCanBePrivate.Global
		public new DataRelationCollection Relations => base.Relations;

		[DebuggerNonUserCode]
		public dsmeta_istanza_conseg_seg() {
			BeginInit();
			initClass();
			EndInit();
		}
		[DebuggerNonUserCode]
		protected dsmeta_istanza_conseg_seg(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
		[DebuggerNonUserCode]
		private void initClass() {
			DataSetName = "dsmeta_istanza_conseg_seg";
			Prefix = "";
			Namespace = "http://tempuri.org/dsmeta_istanza_conseg_seg.xsd";

			#region create DataTables
			//////////////////// TESIKEYWORD /////////////////////////////////
			var ttesikeyword = new MetaTable("tesikeyword");
			ttesikeyword.defineColumn("ct", typeof(DateTime), false);
			ttesikeyword.defineColumn("cu", typeof(string), false);
			ttesikeyword.defineColumn("idistanza", typeof(int), false);
			ttesikeyword.defineColumn("idreg", typeof(int), false);
			ttesikeyword.defineColumn("idrichitesi", typeof(int), false);
			ttesikeyword.defineColumn("idtesi", typeof(int), false);
			ttesikeyword.defineColumn("idtesikeyword", typeof(int), false);
			ttesikeyword.defineColumn("keyword", typeof(int), false);
			ttesikeyword.defineColumn("lang", typeof(string), false);
			ttesikeyword.defineColumn("lt", typeof(DateTime), false);
			ttesikeyword.defineColumn("lu", typeof(string), false);
			Tables.Add(ttesikeyword);
			ttesikeyword.defineKey("idistanza", "idreg", "idrichitesi", "idtesi", "idtesikeyword");

			//////////////////// TESI /////////////////////////////////
			var ttesi = new MetaTable("tesi");
			ttesi.defineColumn("aa", typeof(string));
			ttesi.defineColumn("abstract", typeof(string));
			ttesi.defineColumn("abstract_en", typeof(string));
			ttesi.defineColumn("ct", typeof(DateTime), false);
			ttesi.defineColumn("cu", typeof(string), false);
			ttesi.defineColumn("filestatus", typeof(string));
			ttesi.defineColumn("idattach", typeof(int));
			ttesi.defineColumn("idinsegn", typeof(int));
			ttesi.defineColumn("idistanza", typeof(int), false);
			ttesi.defineColumn("idreg", typeof(int), false);
			ttesi.defineColumn("idrichitesi", typeof(int), false);
			ttesi.defineColumn("idtesi", typeof(int), false);
			ttesi.defineColumn("idtesikind", typeof(int));
			ttesi.defineColumn("lt", typeof(DateTime), false);
			ttesi.defineColumn("lu", typeof(string), false);
			ttesi.defineColumn("title", typeof(string));
			ttesi.defineColumn("title_en", typeof(string));
			Tables.Add(ttesi);
			ttesi.defineKey("idistanza", "idreg", "idrichitesi", "idtesi");

			//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
			var tregistry_alias1 = new MetaTable("registry_alias1");
			tregistry_alias1.defineColumn("active", typeof(string), false);
			tregistry_alias1.defineColumn("annotation", typeof(string));
			tregistry_alias1.defineColumn("authorization_free", typeof(string));
			tregistry_alias1.defineColumn("badgecode", typeof(string));
			tregistry_alias1.defineColumn("birthdate", typeof(DateTime), false);
			tregistry_alias1.defineColumn("ccp", typeof(string));
			tregistry_alias1.defineColumn("cf", typeof(string));
			tregistry_alias1.defineColumn("ct", typeof(DateTime), false);
			tregistry_alias1.defineColumn("cu", typeof(string), false);
			tregistry_alias1.defineColumn("email_fe", typeof(string));
			tregistry_alias1.defineColumn("extension", typeof(string));
			tregistry_alias1.defineColumn("extmatricula", typeof(string));
			tregistry_alias1.defineColumn("flag_pa", typeof(string));
			tregistry_alias1.defineColumn("flagbankitaliaproceeds", typeof(string));
			tregistry_alias1.defineColumn("foreigncf", typeof(string));
			tregistry_alias1.defineColumn("forename", typeof(string), false);
			tregistry_alias1.defineColumn("gender", typeof(string), false);
			tregistry_alias1.defineColumn("idaccmotivecredit", typeof(string));
			tregistry_alias1.defineColumn("idaccmotivedebit", typeof(string));
			tregistry_alias1.defineColumn("idcategory", typeof(string));
			tregistry_alias1.defineColumn("idcentralizedcategory", typeof(string));
			tregistry_alias1.defineColumn("idcity", typeof(int), false);
			tregistry_alias1.defineColumn("idexternal", typeof(int));
			tregistry_alias1.defineColumn("idmaritalstatus", typeof(string));
			tregistry_alias1.defineColumn("idnation", typeof(int));
			tregistry_alias1.defineColumn("idreg", typeof(int), false);
			tregistry_alias1.defineColumn("idregistryclass", typeof(string));
			tregistry_alias1.defineColumn("idregistrykind", typeof(int));
			tregistry_alias1.defineColumn("idtitle", typeof(string));
			tregistry_alias1.defineColumn("ipa_fe", typeof(string));
			tregistry_alias1.defineColumn("ipa_perlapa", typeof(string));
			tregistry_alias1.defineColumn("location", typeof(string));
			tregistry_alias1.defineColumn("lt", typeof(DateTime), false);
			tregistry_alias1.defineColumn("lu", typeof(string), false);
			tregistry_alias1.defineColumn("maritalsurname", typeof(string));
			tregistry_alias1.defineColumn("multi_cf", typeof(string));
			tregistry_alias1.defineColumn("p_iva", typeof(string));
			tregistry_alias1.defineColumn("pec_fe", typeof(string));
			tregistry_alias1.defineColumn("residence", typeof(int), false);
			tregistry_alias1.defineColumn("rtf", typeof(Byte[]));
			tregistry_alias1.defineColumn("sdi_defrifamm", typeof(string));
			tregistry_alias1.defineColumn("sdi_norifamm", typeof(string));
			tregistry_alias1.defineColumn("surname", typeof(string), false);
			tregistry_alias1.defineColumn("title", typeof(string), false);
			tregistry_alias1.defineColumn("toredirect", typeof(int));
			tregistry_alias1.defineColumn("txt", typeof(string));
			tregistry_alias1.ExtendedProperties["TableForReading"] = "registry";
			Tables.Add(tregistry_alias1);
			tregistry_alias1.defineKey("idreg");

			//////////////////// REGISTRY_DOCENTI_ALIAS1 /////////////////////////////////
			var tregistry_docenti_alias1 = new MetaTable("registry_docenti_alias1");
			tregistry_docenti_alias1.defineColumn("ct", typeof(DateTime), false);
			tregistry_docenti_alias1.defineColumn("cu", typeof(string), false);
			tregistry_docenti_alias1.defineColumn("cv", typeof(string));
			tregistry_docenti_alias1.defineColumn("idclassconsorsuale", typeof(int));
			tregistry_docenti_alias1.defineColumn("idcontrattokind", typeof(int));
			tregistry_docenti_alias1.defineColumn("idfonteindicebibliometrico", typeof(int));
			tregistry_docenti_alias1.defineColumn("idreg", typeof(int), false);
			tregistry_docenti_alias1.defineColumn("idreg_istituti", typeof(int));
			tregistry_docenti_alias1.defineColumn("idsasd", typeof(int));
			tregistry_docenti_alias1.defineColumn("idstruttura", typeof(int));
			tregistry_docenti_alias1.defineColumn("indicebibliometrico", typeof(int));
			tregistry_docenti_alias1.defineColumn("lt", typeof(DateTime), false);
			tregistry_docenti_alias1.defineColumn("lu", typeof(string), false);
			tregistry_docenti_alias1.defineColumn("matricola", typeof(string));
			tregistry_docenti_alias1.defineColumn("ricevimento", typeof(string));
			tregistry_docenti_alias1.defineColumn("soggiorno", typeof(string));
			tregistry_docenti_alias1.ExtendedProperties["TableForReading"] = "registry_docenti";
			Tables.Add(tregistry_docenti_alias1);
			tregistry_docenti_alias1.defineKey("idreg");

			//////////////////// RICHITESI /////////////////////////////////
			var trichitesi = new MetaTable("richitesi");
			trichitesi.defineColumn("accettata", typeof(string));
			trichitesi.defineColumn("ct", typeof(DateTime), false);
			trichitesi.defineColumn("cu", typeof(string), false);
			trichitesi.defineColumn("idistanza", typeof(int), false);
			trichitesi.defineColumn("idreg", typeof(int), false);
			trichitesi.defineColumn("idreg_docenti", typeof(int), false);
			trichitesi.defineColumn("idrichitesi", typeof(int), false);
			trichitesi.defineColumn("lt", typeof(DateTime), false);
			trichitesi.defineColumn("lu", typeof(string), false);
			trichitesi.defineColumn("!idreg_docenti_registry_docenti_title", typeof(string));
			trichitesi.ExtendedProperties["NotEntityChild"] = "true";
			Tables.Add(trichitesi);
			trichitesi.defineKey("idistanza", "idreg", "idrichitesi");

			//////////////////// RELATOREKIND /////////////////////////////////
			var trelatorekind = new MetaTable("relatorekind");
			trelatorekind.defineColumn("active", typeof(string), false);
			trelatorekind.defineColumn("idrelatorekind", typeof(int), false);
			trelatorekind.defineColumn("title", typeof(string), false);
			Tables.Add(trelatorekind);
			trelatorekind.defineKey("idrelatorekind");

			//////////////////// REGISTRY /////////////////////////////////
			var tregistry = new MetaTable("registry");
			tregistry.defineColumn("active", typeof(string), false);
			tregistry.defineColumn("annotation", typeof(string));
			tregistry.defineColumn("authorization_free", typeof(string));
			tregistry.defineColumn("badgecode", typeof(string));
			tregistry.defineColumn("birthdate", typeof(DateTime), false);
			tregistry.defineColumn("ccp", typeof(string));
			tregistry.defineColumn("cf", typeof(string));
			tregistry.defineColumn("ct", typeof(DateTime), false);
			tregistry.defineColumn("cu", typeof(string), false);
			tregistry.defineColumn("email_fe", typeof(string));
			tregistry.defineColumn("extension", typeof(string));
			tregistry.defineColumn("extmatricula", typeof(string));
			tregistry.defineColumn("flag_pa", typeof(string));
			tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
			tregistry.defineColumn("foreigncf", typeof(string));
			tregistry.defineColumn("forename", typeof(string), false);
			tregistry.defineColumn("gender", typeof(string), false);
			tregistry.defineColumn("idaccmotivecredit", typeof(string));
			tregistry.defineColumn("idaccmotivedebit", typeof(string));
			tregistry.defineColumn("idcategory", typeof(string));
			tregistry.defineColumn("idcentralizedcategory", typeof(string));
			tregistry.defineColumn("idcity", typeof(int), false);
			tregistry.defineColumn("idexternal", typeof(int));
			tregistry.defineColumn("idmaritalstatus", typeof(string));
			tregistry.defineColumn("idnation", typeof(int));
			tregistry.defineColumn("idreg", typeof(int), false);
			tregistry.defineColumn("idregistryclass", typeof(string));
			tregistry.defineColumn("idregistrykind", typeof(int));
			tregistry.defineColumn("idtitle", typeof(string));
			tregistry.defineColumn("ipa_fe", typeof(string));
			tregistry.defineColumn("ipa_perlapa", typeof(string));
			tregistry.defineColumn("location", typeof(string));
			tregistry.defineColumn("lt", typeof(DateTime), false);
			tregistry.defineColumn("lu", typeof(string), false);
			tregistry.defineColumn("maritalsurname", typeof(string));
			tregistry.defineColumn("multi_cf", typeof(string));
			tregistry.defineColumn("p_iva", typeof(string));
			tregistry.defineColumn("pec_fe", typeof(string));
			tregistry.defineColumn("residence", typeof(int), false);
			tregistry.defineColumn("rtf", typeof(Byte[]));
			tregistry.defineColumn("sdi_defrifamm", typeof(string));
			tregistry.defineColumn("sdi_norifamm", typeof(string));
			tregistry.defineColumn("surname", typeof(string), false);
			tregistry.defineColumn("title", typeof(string), false);
			tregistry.defineColumn("toredirect", typeof(int));
			tregistry.defineColumn("txt", typeof(string));
			Tables.Add(tregistry);
			tregistry.defineKey("idreg");

			//////////////////// REGISTRY_DOCENTI /////////////////////////////////
			var tregistry_docenti = new MetaTable("registry_docenti");
			tregistry_docenti.defineColumn("ct", typeof(DateTime), false);
			tregistry_docenti.defineColumn("cu", typeof(string), false);
			tregistry_docenti.defineColumn("cv", typeof(string));
			tregistry_docenti.defineColumn("idclassconsorsuale", typeof(int));
			tregistry_docenti.defineColumn("idcontrattokind", typeof(int));
			tregistry_docenti.defineColumn("idfonteindicebibliometrico", typeof(int));
			tregistry_docenti.defineColumn("idreg", typeof(int), false);
			tregistry_docenti.defineColumn("idreg_istituti", typeof(int));
			tregistry_docenti.defineColumn("idsasd", typeof(int));
			tregistry_docenti.defineColumn("idstruttura", typeof(int));
			tregistry_docenti.defineColumn("indicebibliometrico", typeof(int));
			tregistry_docenti.defineColumn("lt", typeof(DateTime), false);
			tregistry_docenti.defineColumn("lu", typeof(string), false);
			tregistry_docenti.defineColumn("matricola", typeof(string));
			tregistry_docenti.defineColumn("ricevimento", typeof(string));
			tregistry_docenti.defineColumn("soggiorno", typeof(string));
			Tables.Add(tregistry_docenti);
			tregistry_docenti.defineKey("idreg");

			//////////////////// RELATORE /////////////////////////////////
			var trelatore = new MetaTable("relatore");
			trelatore.defineColumn("ct", typeof(DateTime), false);
			trelatore.defineColumn("cu", typeof(string), false);
			trelatore.defineColumn("idistanza", typeof(int), false);
			trelatore.defineColumn("idreg", typeof(int), false);
			trelatore.defineColumn("idreg_docenti", typeof(int));
			trelatore.defineColumn("idrelatore", typeof(int), false);
			trelatore.defineColumn("idrelatorekind", typeof(int));
			trelatore.defineColumn("lt", typeof(DateTime), false);
			trelatore.defineColumn("lu", typeof(string), false);
			trelatore.defineColumn("!idreg_docenti_registry_docenti_title", typeof(string));
			trelatore.defineColumn("!idrelatorekind_relatorekind_title", typeof(string));
			trelatore.ExtendedProperties["NotEntityChild"] = "true";
			Tables.Add(trelatore);
			trelatore.defineKey("idistanza", "idreg", "idrelatore");

			//////////////////// APPELLOSEGVIEW /////////////////////////////////
			var tappellosegview = new MetaTable("appellosegview");
			tappellosegview.defineColumn("dropdown_title", typeof(string), false);
			tappellosegview.defineColumn("idappello", typeof(int), false);
			Tables.Add(tappellosegview);
			tappellosegview.defineKey("idappello");

			//////////////////// STATUSKIND /////////////////////////////////
			var tstatuskind = new MetaTable("statuskind");
			tstatuskind.defineColumn("ct", typeof(DateTime), false);
			tstatuskind.defineColumn("cu", typeof(string), false);
			tstatuskind.defineColumn("delibera", typeof(string), false);
			tstatuskind.defineColumn("idstatuskind", typeof(int), false);
			tstatuskind.defineColumn("istanze", typeof(string), false);
			tstatuskind.defineColumn("istanzedelibera", typeof(string), false);
			tstatuskind.defineColumn("lt", typeof(DateTime), false);
			tstatuskind.defineColumn("lu", typeof(string), false);
			tstatuskind.defineColumn("pratica", typeof(string), false);
			tstatuskind.defineColumn("sortcode", typeof(int), false);
			tstatuskind.defineColumn("title", typeof(string), false);
			Tables.Add(tstatuskind);
			tstatuskind.defineKey("idstatuskind");

			//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
			var tregistrystudentiview = new MetaTable("registrystudentiview");
			tregistrystudentiview.defineColumn("dropdown_title", typeof(string), false);
			tregistrystudentiview.defineColumn("idreg", typeof(int), false);
			tregistrystudentiview.defineColumn("registry_active", typeof(string));
			Tables.Add(tregistrystudentiview);
			tregistrystudentiview.defineKey("idreg");

			//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
			var tdidprogdefaultview = new MetaTable("didprogdefaultview");
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
			tdidprogdefaultview.defineColumn("dropdown_title", typeof(string), false);
			tdidprogdefaultview.defineColumn("erogazkind_title", typeof(string));
			tdidprogdefaultview.defineColumn("geo_nationlang_lang", typeof(string));
			tdidprogdefaultview.defineColumn("geo_nationlang2_lang", typeof(string));
			tdidprogdefaultview.defineColumn("geo_nationlangvis_lang", typeof(string));
			tdidprogdefaultview.defineColumn("graduatoria_title", typeof(string));
			tdidprogdefaultview.defineColumn("idareadidattica", typeof(int));
			tdidprogdefaultview.defineColumn("idconvenzione", typeof(int));
			tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int), false);
			tdidprogdefaultview.defineColumn("iddidprog", typeof(int), false);
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
			tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

			//////////////////// ANNOACCADEMICO /////////////////////////////////
			var tannoaccademico = new MetaTable("annoaccademico");
			tannoaccademico.defineColumn("aa", typeof(string), false);
			Tables.Add(tannoaccademico);
			tannoaccademico.defineKey("aa");

			//////////////////// ISTANZA /////////////////////////////////
			var tistanza = new MetaTable("istanza");
			tistanza.defineColumn("aa", typeof(string), false);
			tistanza.defineColumn("ct", typeof(DateTime), false);
			tistanza.defineColumn("cu", typeof(string), false);
			tistanza.defineColumn("data", typeof(DateTime), false);
			tistanza.defineColumn("extension", typeof(string));
			tistanza.defineColumn("idcorsostudio", typeof(int));
			tistanza.defineColumn("iddidprog", typeof(int));
			tistanza.defineColumn("idiscrizione", typeof(int));
			tistanza.defineColumn("idistanza", typeof(int), false);
			tistanza.defineColumn("idistanzakind", typeof(int), false);
			tistanza.defineColumn("idreg_studenti", typeof(int), false);
			tistanza.defineColumn("idstatuskind", typeof(int));
			tistanza.defineColumn("lt", typeof(DateTime), false);
			tistanza.defineColumn("lu", typeof(string), false);
			tistanza.defineColumn("paridistanza", typeof(int));
			tistanza.defineColumn("protanno", typeof(int), false);
			tistanza.defineColumn("protnumero", typeof(int), false);
			Tables.Add(tistanza);
			tistanza.defineKey("idistanza", "idistanzakind", "idreg_studenti");

			//////////////////// ISTANZA_CONSEG /////////////////////////////////
			var tistanza_conseg = new MetaTable("istanza_conseg");
			tistanza_conseg.defineColumn("ct", typeof(DateTime), false);
			tistanza_conseg.defineColumn("cu", typeof(string), false);
			tistanza_conseg.defineColumn("datacompalmalaur", typeof(DateTime));
			tistanza_conseg.defineColumn("fascicolo", typeof(string));
			tistanza_conseg.defineColumn("idappello", typeof(int));
			tistanza_conseg.defineColumn("idistanza", typeof(int), false);
			tistanza_conseg.defineColumn("idistanzakind", typeof(int), false);
			tistanza_conseg.defineColumn("idreg", typeof(int), false);
			tistanza_conseg.defineColumn("idrichitesi", typeof(int));
			tistanza_conseg.defineColumn("lt", typeof(DateTime), false);
			tistanza_conseg.defineColumn("lu", typeof(string), false);
			tistanza_conseg.defineColumn("posizione", typeof(string));
			Tables.Add(tistanza_conseg);
			tistanza_conseg.defineKey("idistanza", "idistanzakind", "idreg");

			#endregion


			#region DataRelation creation
			var cPar = new[] { istanza.Columns["idistanza"], istanza.Columns["idreg_studenti"] };
			var cChild = new[] { richitesi.Columns["idistanza"], richitesi.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_richitesi_istanza_idistanza-idreg", cPar, cChild, false));

			cPar = new[] { richitesi.Columns["idistanza"], richitesi.Columns["idreg"], richitesi.Columns["idrichitesi"] };
			cChild = new[] { tesi.Columns["idistanza"], tesi.Columns["idreg"], tesi.Columns["idrichitesi"] };
			Relations.Add(new DataRelation("FK_tesi_richitesi_idistanza-idreg-idrichitesi", cPar, cChild, false));

			cPar = new[] { tesi.Columns["idistanza"], tesi.Columns["idreg"], tesi.Columns["idrichitesi"], tesi.Columns["idtesi"] };
			cChild = new[] { tesikeyword.Columns["idistanza"], tesikeyword.Columns["idreg"], tesikeyword.Columns["idrichitesi"], tesikeyword.Columns["idtesi"] };
			Relations.Add(new DataRelation("FK_tesikeyword_tesi_idistanza-idreg-idrichitesi-idtesi", cPar, cChild, false));

			cPar = new[] { registry_alias1.Columns["idreg"] };
			cChild = new[] { richitesi.Columns["idreg_docenti"] };
			Relations.Add(new DataRelation("FK_richitesi_registry_alias1_idreg_docenti", cPar, cChild, false));

			cPar = new[] { registry_alias1.Columns["idreg"] };
			cChild = new[] { registry_docenti_alias1.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_registry_docenti_alias1_registry_alias1_idreg", cPar, cChild, false));

			cPar = new[] { istanza.Columns["idistanza"], istanza.Columns["idreg_studenti"] };
			cChild = new[] { relatore.Columns["idistanza"], relatore.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_relatore_istanza_idistanza-idreg", cPar, cChild, false));

			cPar = new[] { relatorekind.Columns["idrelatorekind"] };
			cChild = new[] { relatore.Columns["idrelatorekind"] };
			Relations.Add(new DataRelation("FK_relatore_relatorekind_idrelatorekind", cPar, cChild, false));

			cPar = new[] { registry.Columns["idreg"] };
			cChild = new[] { relatore.Columns["idreg_docenti"] };
			Relations.Add(new DataRelation("FK_relatore_registry_idreg_docenti", cPar, cChild, false));

			cPar = new[] { registry.Columns["idreg"] };
			cChild = new[] { registry_docenti.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_registry_docenti_registry_idreg", cPar, cChild, false));

			cPar = new[] { appellosegview.Columns["idappello"] };
			cChild = new[] { istanza_conseg.Columns["idappello"] };
			Relations.Add(new DataRelation("FK_istanza_conseg_appellosegview_idappello", cPar, cChild, false));

			cPar = new[] { statuskind.Columns["idstatuskind"] };
			cChild = new[] { istanza.Columns["idstatuskind"] };
			Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind", cPar, cChild, false));

			cPar = new[] { registrystudentiview.Columns["idreg"] };
			cChild = new[] { istanza.Columns["idreg_studenti"] };
			Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti", cPar, cChild, false));

			cPar = new[] { didprogdefaultview.Columns["iddidprog"] };
			cChild = new[] { istanza.Columns["iddidprog"] };
			Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog", cPar, cChild, false));

			cPar = new[] { annoaccademico.Columns["aa"] };
			cChild = new[] { istanza.Columns["aa"] };
			Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa", cPar, cChild, false));

			cPar = new[] { istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"] };
			cChild = new[] { istanza_conseg.Columns["idistanza"], istanza_conseg.Columns["idistanzakind"], istanza_conseg.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_istanza_conseg_istanza_idistanza-idistanzakind-idreg", cPar, cChild, false));

			#endregion

		}
	}
}
