
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
	[System.Xml.Serialization.XmlRoot("dsmeta_convalida_segistpass"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
	public class dsmeta_convalida_segistpass :DataSet {

		#region Table members declaration
		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable changes => (MetaTable)Tables["changes"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable convalidato => (MetaTable)Tables["convalidato"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable tirocinioprogetto => (MetaTable)Tables["tirocinioprogetto"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable sostenimento => (MetaTable)Tables["sostenimento"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registry => (MetaTable)Tables["registry"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable attivform => (MetaTable)Tables["attivform"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable changeskind => (MetaTable)Tables["changeskind"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable convalidante => (MetaTable)Tables["convalidante"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable praticaseganagstuview => (MetaTable)Tables["praticaseganagstuview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable learningagrtrainersegview => (MetaTable)Tables["learningagrtrainersegview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable learningagrstudsegview => (MetaTable)Tables["learningagrstudsegview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable istanzaabbr_segview => (MetaTable)Tables["istanzaabbr_segview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable iscrizionebmisegview => (MetaTable)Tables["iscrizionebmisegview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable iscrizionedefaultview_alias1 => (MetaTable)Tables["iscrizionedefaultview_alias1"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable iscrizionedefaultview => (MetaTable)Tables["iscrizionedefaultview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable didprogdefaultview => (MetaTable)Tables["didprogdefaultview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable dichiaraltre_segview => (MetaTable)Tables["dichiaraltre_segview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable convalida => (MetaTable)Tables["convalida"];

		#endregion


		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataTableCollection Tables => base.Tables;

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once MemberCanBePrivate.Global
		public new DataRelationCollection Relations => base.Relations;

		[DebuggerNonUserCode]
		public dsmeta_convalida_segistpass() {
			BeginInit();
			initClass();
			EndInit();
		}
		[DebuggerNonUserCode]
		protected dsmeta_convalida_segistpass(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
		[DebuggerNonUserCode]
		private void initClass() {
			DataSetName = "dsmeta_convalida_segistpass";
			Prefix = "";
			Namespace = "http://tempuri.org/dsmeta_convalida_segistpass.xsd";

			#region create DataTables
			//////////////////// CHANGES /////////////////////////////////
			var tchanges = new MetaTable("changes");
			tchanges.defineColumn("idchanges", typeof(int), false);
			tchanges.defineColumn("title", typeof(string), false);
			Tables.Add(tchanges);
			tchanges.defineKey("idchanges");

			//////////////////// CONVALIDATO /////////////////////////////////
			var tconvalidato = new MetaTable("convalidato");
			tconvalidato.defineColumn("changesother", typeof(string));
			tconvalidato.defineColumn("ct", typeof(DateTime), false);
			tconvalidato.defineColumn("cu", typeof(string), false);
			tconvalidato.defineColumn("idattivform", typeof(int), false);
			tconvalidato.defineColumn("idchanges", typeof(int));
			tconvalidato.defineColumn("idchangeskind", typeof(int));
			tconvalidato.defineColumn("idconvalida", typeof(int), false);
			tconvalidato.defineColumn("idconvalidato", typeof(int), false);
			tconvalidato.defineColumn("iddichiar", typeof(int));
			tconvalidato.defineColumn("iddidprog", typeof(int));
			tconvalidato.defineColumn("idiscrizione", typeof(int));
			tconvalidato.defineColumn("idiscrizione_from", typeof(int));
			tconvalidato.defineColumn("idiscrizionebmi", typeof(int));
			tconvalidato.defineColumn("idistanza", typeof(int));
			tconvalidato.defineColumn("idlearningagrstud", typeof(int));
			tconvalidato.defineColumn("idlearningagrtrainer", typeof(int));
			tconvalidato.defineColumn("idpratica", typeof(int));
			tconvalidato.defineColumn("idreg", typeof(int), false);
			tconvalidato.defineColumn("lt", typeof(DateTime), false);
			tconvalidato.defineColumn("lu", typeof(string), false);
			tconvalidato.defineColumn("!idattivform_attivform_title", typeof(string));
			tconvalidato.defineColumn("!idchanges_changes_title", typeof(string));
			tconvalidato.defineColumn("!idchangeskind_changeskind_title", typeof(string));
			Tables.Add(tconvalidato);
			tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

			//////////////////// TIROCINIOPROGETTO /////////////////////////////////
			var ttirocinioprogetto = new MetaTable("tirocinioprogetto");
			ttirocinioprogetto.defineColumn("description", typeof(string), false);
			ttirocinioprogetto.defineColumn("idreg_referente", typeof(int), false);
			ttirocinioprogetto.defineColumn("idreg_studenti", typeof(int), false);
			ttirocinioprogetto.defineColumn("idtirociniocandidatura", typeof(int), false);
			ttirocinioprogetto.defineColumn("idtirocinioprogetto", typeof(int), false);
			ttirocinioprogetto.defineColumn("idtirocinioproposto", typeof(int), false);
			ttirocinioprogetto.defineColumn("title", typeof(string), false);
			Tables.Add(ttirocinioprogetto);
			ttirocinioprogetto.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

			//////////////////// SOSTENIMENTO /////////////////////////////////
			var tsostenimento = new MetaTable("sostenimento");
			tsostenimento.defineColumn("idappello", typeof(int), false);
			tsostenimento.defineColumn("idattivform", typeof(int));
			tsostenimento.defineColumn("idprova", typeof(int), false);
			tsostenimento.defineColumn("idreg", typeof(int), false);
			tsostenimento.defineColumn("idsostenimento", typeof(int), false);
			tsostenimento.defineColumn("voto", typeof(decimal));
			tsostenimento.defineColumn("votolode", typeof(string));
			tsostenimento.defineColumn("votosu", typeof(int));
			Tables.Add(tsostenimento);
			tsostenimento.defineKey("idappello", "idprova", "idreg", "idsostenimento");

			//////////////////// REGISTRY /////////////////////////////////
			var tregistry = new MetaTable("registry");
			tregistry.defineColumn("idreg", typeof(int), false);
			tregistry.defineColumn("title", typeof(string), false);
			Tables.Add(tregistry);
			tregistry.defineKey("idreg");

			//////////////////// ATTIVFORM /////////////////////////////////
			var tattivform = new MetaTable("attivform");
			tattivform.defineColumn("aa", typeof(string), false);
			tattivform.defineColumn("idattivform", typeof(int), false);
			tattivform.defineColumn("idcorsostudio", typeof(int), false);
			tattivform.defineColumn("iddidprog", typeof(int), false);
			tattivform.defineColumn("iddidproganno", typeof(int), false);
			tattivform.defineColumn("iddidprogcurr", typeof(int), false);
			tattivform.defineColumn("iddidprogori", typeof(int), false);
			tattivform.defineColumn("iddidprogporzanno", typeof(int), false);
			tattivform.defineColumn("idsede", typeof(int), false);
			tattivform.defineColumn("title", typeof(string));
			Tables.Add(tattivform);
			tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

			//////////////////// CHANGESKIND /////////////////////////////////
			var tchangeskind = new MetaTable("changeskind");
			tchangeskind.defineColumn("idchangeskind", typeof(int), false);
			tchangeskind.defineColumn("title", typeof(string), false);
			Tables.Add(tchangeskind);
			tchangeskind.defineKey("idchangeskind");

			//////////////////// CONVALIDANTE /////////////////////////////////
			var tconvalidante = new MetaTable("convalidante");
			tconvalidante.defineColumn("changes", typeof(string));
			tconvalidante.defineColumn("changesother", typeof(string));
			tconvalidante.defineColumn("ct", typeof(DateTime), false);
			tconvalidante.defineColumn("cu", typeof(string), false);
			tconvalidante.defineColumn("idchangeskind", typeof(int));
			tconvalidante.defineColumn("idconvalida", typeof(int), false);
			tconvalidante.defineColumn("idconvalidante", typeof(int), false);
			tconvalidante.defineColumn("iddichiar", typeof(int));
			tconvalidante.defineColumn("iddidprog", typeof(int));
			tconvalidante.defineColumn("idiscrizione", typeof(int));
			tconvalidante.defineColumn("idiscrizione_from", typeof(int));
			tconvalidante.defineColumn("idiscrizionebmi", typeof(int));
			tconvalidante.defineColumn("idistanza", typeof(int));
			tconvalidante.defineColumn("idlearningagrstud", typeof(int));
			tconvalidante.defineColumn("idlearningagrtrainer", typeof(int));
			tconvalidante.defineColumn("idpratica", typeof(int));
			tconvalidante.defineColumn("idreg", typeof(int), false);
			tconvalidante.defineColumn("idsostenimento", typeof(int));
			tconvalidante.defineColumn("idtirocinioprogetto", typeof(int));
			tconvalidante.defineColumn("lt", typeof(DateTime), false);
			tconvalidante.defineColumn("lu", typeof(string), false);
			tconvalidante.defineColumn("!idchangeskind_changeskind_title", typeof(string));
			tconvalidante.defineColumn("!idsostenimento_sostenimento_voto", typeof(decimal));
			tconvalidante.defineColumn("!idsostenimento_sostenimento_votosu", typeof(int));
			tconvalidante.defineColumn("!idsostenimento_sostenimento_votolode", typeof(string));
			tconvalidante.defineColumn("!idsostenimento_sostenimento_idattivform_title", typeof(string));
			tconvalidante.defineColumn("!idsostenimento_sostenimento_idreg_title", typeof(string));
			tconvalidante.defineColumn("!idtirocinioprogetto_tirocinioprogetto_title", typeof(string));
			tconvalidante.defineColumn("!idtirocinioprogetto_tirocinioprogetto_description", typeof(string));
			Tables.Add(tconvalidante);
			tconvalidante.defineKey("idconvalida", "idconvalidante", "idreg");

			//////////////////// PRATICASEGANAGSTUVIEW /////////////////////////////////
			var tpraticaseganagstuview = new MetaTable("praticaseganagstuview");
			tpraticaseganagstuview.defineColumn("dropdown_title", typeof(string), false);
			tpraticaseganagstuview.defineColumn("idcorsostudio", typeof(int), false);
			tpraticaseganagstuview.defineColumn("iddichiar", typeof(int));
			tpraticaseganagstuview.defineColumn("iddidprog", typeof(int), false);
			tpraticaseganagstuview.defineColumn("idiscrizione", typeof(int), false);
			tpraticaseganagstuview.defineColumn("idiscrizione_from", typeof(int));
			tpraticaseganagstuview.defineColumn("idistanza", typeof(int), false);
			tpraticaseganagstuview.defineColumn("idistanzakind", typeof(int), false);
			tpraticaseganagstuview.defineColumn("idpratica", typeof(int), false);
			tpraticaseganagstuview.defineColumn("idreg", typeof(int), false);
			tpraticaseganagstuview.defineColumn("idtitolostudio", typeof(int));
			Tables.Add(tpraticaseganagstuview);
			tpraticaseganagstuview.defineKey("idpratica");

			//////////////////// LEARNINGAGRTRAINERSEGVIEW /////////////////////////////////
			var tlearningagrtrainersegview = new MetaTable("learningagrtrainersegview");
			tlearningagrtrainersegview.defineColumn("dropdown_title", typeof(string), false);
			tlearningagrtrainersegview.defineColumn("idbandomi", typeof(int), false);
			tlearningagrtrainersegview.defineColumn("idcity", typeof(int));
			tlearningagrtrainersegview.defineColumn("iddichiar", typeof(int));
			tlearningagrtrainersegview.defineColumn("iddidprog", typeof(int));
			tlearningagrtrainersegview.defineColumn("idiscrizione", typeof(int));
			tlearningagrtrainersegview.defineColumn("idiscrizionebmi", typeof(int), false);
			tlearningagrtrainersegview.defineColumn("idlearningagrtrainer", typeof(int), false);
			tlearningagrtrainersegview.defineColumn("idlearningagrtrainervalut", typeof(int));
			tlearningagrtrainersegview.defineColumn("idnation", typeof(int));
			tlearningagrtrainersegview.defineColumn("idpratica", typeof(int));
			tlearningagrtrainersegview.defineColumn("idreg", typeof(int), false);
			tlearningagrtrainersegview.defineColumn("idreg_aziende", typeof(int));
			Tables.Add(tlearningagrtrainersegview);
			tlearningagrtrainersegview.defineKey("idlearningagrtrainer");

			//////////////////// LEARNINGAGRSTUDSEGVIEW /////////////////////////////////
			var tlearningagrstudsegview = new MetaTable("learningagrstudsegview");
			tlearningagrstudsegview.defineColumn("idbandomi", typeof(int), false);
			tlearningagrstudsegview.defineColumn("idiscrizionebmi", typeof(int), false);
			tlearningagrstudsegview.defineColumn("idlearningagrstud", typeof(int), false);
			tlearningagrstudsegview.defineColumn("idnation", typeof(int));
			tlearningagrstudsegview.defineColumn("idreg", typeof(int), false);
			tlearningagrstudsegview.defineColumn("idreg_istitutiesteri", typeof(int));
			Tables.Add(tlearningagrstudsegview);
			tlearningagrstudsegview.defineKey("idlearningagrstud");

			//////////////////// ISTANZAABBR_SEGVIEW /////////////////////////////////
			var tistanzaabbr_segview = new MetaTable("istanzaabbr_segview");
			tistanzaabbr_segview.defineColumn("aa", typeof(string), false);
			tistanzaabbr_segview.defineColumn("dropdown_title", typeof(string), false);
			tistanzaabbr_segview.defineColumn("idcorsostudio", typeof(int));
			tistanzaabbr_segview.defineColumn("iddichiar", typeof(int));
			tistanzaabbr_segview.defineColumn("iddidprog", typeof(int));
			tistanzaabbr_segview.defineColumn("idiscrizione", typeof(int));
			tistanzaabbr_segview.defineColumn("idiscrizione_from", typeof(int));
			tistanzaabbr_segview.defineColumn("idistanza", typeof(int), false);
			tistanzaabbr_segview.defineColumn("idistanzakind", typeof(int), false);
			tistanzaabbr_segview.defineColumn("idreg_studenti", typeof(int), false);
			tistanzaabbr_segview.defineColumn("idtitolostudio", typeof(int));
			tistanzaabbr_segview.defineColumn("paridistanza", typeof(int));
			Tables.Add(tistanzaabbr_segview);
			tistanzaabbr_segview.defineKey("idistanza");

			//////////////////// ISCRIZIONEBMISEGVIEW /////////////////////////////////
			var tiscrizionebmisegview = new MetaTable("iscrizionebmisegview");
			tiscrizionebmisegview.defineColumn("dropdown_title", typeof(string), false);
			tiscrizionebmisegview.defineColumn("idbandomi", typeof(int), false);
			tiscrizionebmisegview.defineColumn("idiscrizione", typeof(int));
			tiscrizionebmisegview.defineColumn("idiscrizionebmi", typeof(int), false);
			tiscrizionebmisegview.defineColumn("idnation", typeof(int));
			tiscrizionebmisegview.defineColumn("idreg", typeof(int), false);
			Tables.Add(tiscrizionebmisegview);
			tiscrizionebmisegview.defineKey("idiscrizionebmi");

			//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS1 /////////////////////////////////
			var tiscrizionedefaultview_alias1 = new MetaTable("iscrizionedefaultview_alias1");
			tiscrizionedefaultview_alias1.defineColumn("aa", typeof(string), false);
			tiscrizionedefaultview_alias1.defineColumn("dropdown_title", typeof(string), false);
			tiscrizionedefaultview_alias1.defineColumn("idcorsostudio", typeof(int));
			tiscrizionedefaultview_alias1.defineColumn("iddidprog", typeof(int));
			tiscrizionedefaultview_alias1.defineColumn("idiscrizione", typeof(int), false);
			tiscrizionedefaultview_alias1.defineColumn("idreg", typeof(int), false);
			tiscrizionedefaultview_alias1.ExtendedProperties["TableForReading"] = "iscrizionedefaultview";
			Tables.Add(tiscrizionedefaultview_alias1);
			tiscrizionedefaultview_alias1.defineKey("idiscrizione");

			//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
			var tiscrizionedefaultview = new MetaTable("iscrizionedefaultview");
			tiscrizionedefaultview.defineColumn("aa", typeof(string), false);
			tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string), false);
			tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int));
			tiscrizionedefaultview.defineColumn("iddidprog", typeof(int));
			tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int), false);
			tiscrizionedefaultview.defineColumn("idreg", typeof(int), false);
			Tables.Add(tiscrizionedefaultview);
			tiscrizionedefaultview.defineKey("idiscrizione");

			//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
			var tdidprogdefaultview = new MetaTable("didprogdefaultview");
			tdidprogdefaultview.defineColumn("aa", typeof(string));
			tdidprogdefaultview.defineColumn("dropdown_title", typeof(string), false);
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
			Tables.Add(tdidprogdefaultview);
			tdidprogdefaultview.defineKey("iddidprog");

			//////////////////// DICHIARALTRE_SEGVIEW /////////////////////////////////
			var tdichiaraltre_segview = new MetaTable("dichiaraltre_segview");
			tdichiaraltre_segview.defineColumn("aa", typeof(string));
			tdichiaraltre_segview.defineColumn("iddichiar", typeof(int), false);
			tdichiaraltre_segview.defineColumn("idreg", typeof(int), false);
			Tables.Add(tdichiaraltre_segview);
			tdichiaraltre_segview.defineKey("iddichiar");

			//////////////////// CONVALIDA /////////////////////////////////
			var tconvalida = new MetaTable("convalida");
			tconvalida.defineColumn("cf", typeof(decimal));
			tconvalida.defineColumn("cfintegrazione", typeof(decimal));
			tconvalida.defineColumn("ct", typeof(DateTime), false);
			tconvalida.defineColumn("cu", typeof(string), false);
			tconvalida.defineColumn("data", typeof(DateTime));
			tconvalida.defineColumn("idconvalida", typeof(int), false);
			tconvalida.defineColumn("idconvalidakind", typeof(int));
			tconvalida.defineColumn("iddichiar", typeof(int));
			tconvalida.defineColumn("iddidprog", typeof(int));
			tconvalida.defineColumn("idiscrizione", typeof(int));
			tconvalida.defineColumn("idiscrizione_from", typeof(int));
			tconvalida.defineColumn("idiscrizionebmi", typeof(int));
			tconvalida.defineColumn("idistanza", typeof(int));
			tconvalida.defineColumn("idlearningagrstud", typeof(int));
			tconvalida.defineColumn("idlearningagrtrainer", typeof(int));
			tconvalida.defineColumn("idpratica", typeof(int));
			tconvalida.defineColumn("idreg", typeof(int), false);
			tconvalida.defineColumn("lt", typeof(DateTime), false);
			tconvalida.defineColumn("lu", typeof(string), false);
			tconvalida.defineColumn("voto", typeof(decimal));
			tconvalida.defineColumn("votolode", typeof(string));
			tconvalida.defineColumn("votosu", typeof(int));
			Tables.Add(tconvalida);
			tconvalida.defineKey("idconvalida", "idreg");

			#endregion


			#region DataRelation creation
			var cPar = new[] { convalida.Columns["idconvalida"], convalida.Columns["idreg"] };
			var cChild = new[] { convalidato.Columns["idconvalida"], convalidato.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg", cPar, cChild, false));

			cPar = new[] { changeskind.Columns["idchangeskind"] };
			cChild = new[] { convalidato.Columns["idchangeskind"] };
			Relations.Add(new DataRelation("FK_convalidato_changeskind_idchangeskind", cPar, cChild, false));

			cPar = new[] { changes.Columns["idchanges"] };
			cChild = new[] { convalidato.Columns["idchanges"] };
			Relations.Add(new DataRelation("FK_convalidato_changes_idchanges", cPar, cChild, false));

			cPar = new[] { attivform.Columns["idattivform"] };
			cChild = new[] { convalidato.Columns["idattivform"] };
			Relations.Add(new DataRelation("FK_convalidato_attivform_idattivform", cPar, cChild, false));

			cPar = new[] { convalida.Columns["idconvalida"], convalida.Columns["idreg"] };
			cChild = new[] { convalidante.Columns["idconvalida"], convalidante.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-idreg", cPar, cChild, false));

			cPar = new[] { tirocinioprogetto.Columns["idtirocinioprogetto"] };
			cChild = new[] { convalidante.Columns["idtirocinioprogetto"] };
			Relations.Add(new DataRelation("FK_convalidante_tirocinioprogetto_idtirocinioprogetto", cPar, cChild, false));

			cPar = new[] { sostenimento.Columns["idsostenimento"] };
			cChild = new[] { convalidante.Columns["idsostenimento"] };
			Relations.Add(new DataRelation("FK_convalidante_sostenimento_idsostenimento", cPar, cChild, false));

			cPar = new[] { registry.Columns["idreg"] };
			cChild = new[] { sostenimento.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_sostenimento_registry_idreg", cPar, cChild, false));

			cPar = new[] { attivform.Columns["idattivform"] };
			cChild = new[] { sostenimento.Columns["idattivform"] };
			Relations.Add(new DataRelation("FK_sostenimento_attivform_idattivform", cPar, cChild, false));

			cPar = new[] { changeskind.Columns["idchangeskind"] };
			cChild = new[] { convalidante.Columns["idchangeskind"] };
			Relations.Add(new DataRelation("FK_convalidante_changeskind_idchangeskind", cPar, cChild, false));

			cPar = new[] { praticaseganagstuview.Columns["idpratica"] };
			cChild = new[] { convalida.Columns["idpratica"] };
			Relations.Add(new DataRelation("FK_convalida_praticaseganagstuview_idpratica", cPar, cChild, false));

			cPar = new[] { learningagrtrainersegview.Columns["idlearningagrtrainer"] };
			cChild = new[] { convalida.Columns["idlearningagrtrainer"] };
			Relations.Add(new DataRelation("FK_convalida_learningagrtrainersegview_idlearningagrtrainer", cPar, cChild, false));

			cPar = new[] { learningagrstudsegview.Columns["idlearningagrstud"] };
			cChild = new[] { convalida.Columns["idlearningagrstud"] };
			Relations.Add(new DataRelation("FK_convalida_learningagrstudsegview_idlearningagrstud", cPar, cChild, false));

			cPar = new[] { istanzaabbr_segview.Columns["idistanza"] };
			cChild = new[] { convalida.Columns["idistanza"] };
			Relations.Add(new DataRelation("FK_convalida_istanzaabbr_segview_idistanza", cPar, cChild, false));

			cPar = new[] { iscrizionebmisegview.Columns["idiscrizionebmi"] };
			cChild = new[] { convalida.Columns["idiscrizionebmi"] };
			Relations.Add(new DataRelation("FK_convalida_iscrizionebmisegview_idiscrizionebmi", cPar, cChild, false));

			cPar = new[] { iscrizionedefaultview_alias1.Columns["idiscrizione"] };
			cChild = new[] { convalida.Columns["idiscrizione_from"] };
			Relations.Add(new DataRelation("FK_convalida_iscrizionedefaultview_alias1_idiscrizione_from", cPar, cChild, false));

			cPar = new[] { iscrizionedefaultview.Columns["idiscrizione"] };
			cChild = new[] { convalida.Columns["idiscrizione"] };
			Relations.Add(new DataRelation("FK_convalida_iscrizionedefaultview_idiscrizione", cPar, cChild, false));

			cPar = new[] { didprogdefaultview.Columns["iddidprog"] };
			cChild = new[] { convalida.Columns["iddidprog"] };
			Relations.Add(new DataRelation("FK_convalida_didprogdefaultview_iddidprog", cPar, cChild, false));

			cPar = new[] { dichiaraltre_segview.Columns["iddichiar"] };
			cChild = new[] { convalida.Columns["iddichiar"] };
			Relations.Add(new DataRelation("FK_convalida_dichiaraltre_segview_iddichiar", cPar, cChild, false));

			#endregion

		}
	}
}
