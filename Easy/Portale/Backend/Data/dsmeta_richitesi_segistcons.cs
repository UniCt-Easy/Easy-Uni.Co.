
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
	[System.Xml.Serialization.XmlRoot("dsmeta_richitesi_segistcons"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
	public class dsmeta_richitesi_segistcons :DataSet {

		#region Table members declaration
		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable tesikeyword => (MetaTable)Tables["tesikeyword"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable tesikinddefaultview => (MetaTable)Tables["tesikinddefaultview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable insegndefaultview => (MetaTable)Tables["insegndefaultview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable attach => (MetaTable)Tables["attach"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable annoaccademico => (MetaTable)Tables["annoaccademico"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable tesi => (MetaTable)Tables["tesi"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registrydocentiview => (MetaTable)Tables["registrydocentiview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable registrydefaultview => (MetaTable)Tables["registrydefaultview"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable richitesi => (MetaTable)Tables["richitesi"];

		#endregion


		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataTableCollection Tables => base.Tables;

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once MemberCanBePrivate.Global
		public new DataRelationCollection Relations => base.Relations;

		[DebuggerNonUserCode]
		public dsmeta_richitesi_segistcons() {
			BeginInit();
			initClass();
			EndInit();
		}
		[DebuggerNonUserCode]
		protected dsmeta_richitesi_segistcons(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
		[DebuggerNonUserCode]
		private void initClass() {
			DataSetName = "dsmeta_richitesi_segistcons";
			Prefix = "";
			Namespace = "http://tempuri.org/dsmeta_richitesi_segistcons.xsd";

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

			//////////////////// TESIKINDDEFAULTVIEW /////////////////////////////////
			var ttesikinddefaultview = new MetaTable("tesikinddefaultview");
			ttesikinddefaultview.defineColumn("dropdown_title", typeof(string), false);
			ttesikinddefaultview.defineColumn("idtesikind", typeof(int), false);
			ttesikinddefaultview.defineColumn("tesikind_active", typeof(string));
			Tables.Add(ttesikinddefaultview);
			ttesikinddefaultview.defineKey("idtesikind");

			//////////////////// INSEGNDEFAULTVIEW /////////////////////////////////
			var tinsegndefaultview = new MetaTable("insegndefaultview");
			tinsegndefaultview.defineColumn("dropdown_title", typeof(string), false);
			tinsegndefaultview.defineColumn("idinsegn", typeof(int), false);
			Tables.Add(tinsegndefaultview);
			tinsegndefaultview.defineKey("idinsegn");

			//////////////////// ATTACH /////////////////////////////////
			var tattach = new MetaTable("attach");
			tattach.defineColumn("attachment", typeof(Byte[]));
			tattach.defineColumn("ct", typeof(DateTime), false);
			tattach.defineColumn("cu", typeof(string), false);
			tattach.defineColumn("filename", typeof(string), false);
			tattach.defineColumn("hash", typeof(string), false);
			tattach.defineColumn("idattach", typeof(int), false);
			tattach.defineColumn("lt", typeof(DateTime), false);
			tattach.defineColumn("lu", typeof(string), false);
			tattach.defineColumn("size", typeof(int), false);
			Tables.Add(tattach);
			tattach.defineKey("idattach");

			//////////////////// ANNOACCADEMICO /////////////////////////////////
			var tannoaccademico = new MetaTable("annoaccademico");
			tannoaccademico.defineColumn("aa", typeof(string), false);
			Tables.Add(tannoaccademico);
			tannoaccademico.defineKey("aa");

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

			//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
			var tregistrydocentiview = new MetaTable("registrydocentiview");
			tregistrydocentiview.defineColumn("dropdown_title", typeof(string), false);
			tregistrydocentiview.defineColumn("idreg", typeof(int), false);
			tregistrydocentiview.defineColumn("registry_active", typeof(string));
			Tables.Add(tregistrydocentiview);
			tregistrydocentiview.defineKey("idreg");

			//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
			var tregistrydefaultview = new MetaTable("registrydefaultview");
			tregistrydefaultview.defineColumn("accmotive_codemotive", typeof(string));
			tregistrydefaultview.defineColumn("accmotive_registry_codemotive", typeof(string));
			tregistrydefaultview.defineColumn("accmotive_registry_title", typeof(string));
			tregistrydefaultview.defineColumn("accmotive_title", typeof(string));
			tregistrydefaultview.defineColumn("category_description", typeof(string));
			tregistrydefaultview.defineColumn("centralizedcategory_description", typeof(string));
			tregistrydefaultview.defineColumn("dropdown_title", typeof(string), false);
			tregistrydefaultview.defineColumn("geo_city_title", typeof(string));
			tregistrydefaultview.defineColumn("geo_nation_title", typeof(string));
			tregistrydefaultview.defineColumn("idaccmotivecredit", typeof(string));
			tregistrydefaultview.defineColumn("idaccmotivedebit", typeof(string));
			tregistrydefaultview.defineColumn("idcategory", typeof(string));
			tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
			tregistrydefaultview.defineColumn("idcity", typeof(int));
			tregistrydefaultview.defineColumn("idnation", typeof(int));
			tregistrydefaultview.defineColumn("idreg", typeof(int), false);
			tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
			tregistrydefaultview.defineColumn("idtitle", typeof(string));
			tregistrydefaultview.defineColumn("maritalstatus_description", typeof(string));
			tregistrydefaultview.defineColumn("registry_active", typeof(string));
			tregistrydefaultview.defineColumn("registry_annotation", typeof(string));
			tregistrydefaultview.defineColumn("registry_authorization_free", typeof(string));
			tregistrydefaultview.defineColumn("registry_badgecode", typeof(string));
			tregistrydefaultview.defineColumn("registry_birthdate", typeof(DateTime));
			tregistrydefaultview.defineColumn("registry_ccp", typeof(string));
			tregistrydefaultview.defineColumn("registry_cf", typeof(string));
			tregistrydefaultview.defineColumn("registry_ct", typeof(DateTime), false);
			tregistrydefaultview.defineColumn("registry_cu", typeof(string), false);
			tregistrydefaultview.defineColumn("registry_email_fe", typeof(string));
			tregistrydefaultview.defineColumn("registry_extension", typeof(string));
			tregistrydefaultview.defineColumn("registry_extmatricula", typeof(string));
			tregistrydefaultview.defineColumn("registry_flag_pa", typeof(string));
			tregistrydefaultview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
			tregistrydefaultview.defineColumn("registry_foreigncf", typeof(string));
			tregistrydefaultview.defineColumn("registry_forename", typeof(string));
			tregistrydefaultview.defineColumn("registry_gender", typeof(string));
			tregistrydefaultview.defineColumn("registry_idexternal", typeof(int));
			tregistrydefaultview.defineColumn("registry_idmaritalstatus", typeof(string));
			tregistrydefaultview.defineColumn("registry_idregistrykind", typeof(int));
			tregistrydefaultview.defineColumn("registry_ipa_fe", typeof(string));
			tregistrydefaultview.defineColumn("registry_ipa_perlapa", typeof(string));
			tregistrydefaultview.defineColumn("registry_location", typeof(string));
			tregistrydefaultview.defineColumn("registry_lt", typeof(DateTime), false);
			tregistrydefaultview.defineColumn("registry_lu", typeof(string), false);
			tregistrydefaultview.defineColumn("registry_maritalsurname", typeof(string));
			tregistrydefaultview.defineColumn("registry_multi_cf", typeof(string));
			tregistrydefaultview.defineColumn("registry_p_iva", typeof(string));
			tregistrydefaultview.defineColumn("registry_pec_fe", typeof(string));
			tregistrydefaultview.defineColumn("registry_rtf", typeof(Byte[]));
			tregistrydefaultview.defineColumn("registry_sdi_defrifamm", typeof(string));
			tregistrydefaultview.defineColumn("registry_sdi_norifamm", typeof(string));
			tregistrydefaultview.defineColumn("registry_surname", typeof(string));
			tregistrydefaultview.defineColumn("registry_toredirect", typeof(int));
			tregistrydefaultview.defineColumn("registry_txt", typeof(string));
			tregistrydefaultview.defineColumn("registryclass_description", typeof(string));
			tregistrydefaultview.defineColumn("registrykind_description", typeof(string));
			tregistrydefaultview.defineColumn("residence", typeof(int), false);
			tregistrydefaultview.defineColumn("residence_description", typeof(string));
			tregistrydefaultview.defineColumn("title", typeof(string), false);
			tregistrydefaultview.defineColumn("title_description", typeof(string));
			Tables.Add(tregistrydefaultview);
			tregistrydefaultview.defineKey("idreg");

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
			Tables.Add(trichitesi);
			trichitesi.defineKey("idistanza", "idreg", "idrichitesi");

			#endregion


			#region DataRelation creation
			var cPar = new[] { richitesi.Columns["idistanza"], richitesi.Columns["idreg"], richitesi.Columns["idrichitesi"] };
			var cChild = new[] { tesi.Columns["idistanza"], tesi.Columns["idreg"], tesi.Columns["idrichitesi"] };
			Relations.Add(new DataRelation("FK_tesi_richitesi_idistanza-idreg-idrichitesi", cPar, cChild, false));

			cPar = new[] { tesi.Columns["idistanza"], tesi.Columns["idreg"], tesi.Columns["idrichitesi"], tesi.Columns["idtesi"] };
			cChild = new[] { tesikeyword.Columns["idistanza"], tesikeyword.Columns["idreg"], tesikeyword.Columns["idrichitesi"], tesikeyword.Columns["idtesi"] };
			Relations.Add(new DataRelation("FK_tesikeyword_tesi_idistanza-idreg-idrichitesi-idtesi", cPar, cChild, false));

			cPar = new[] { tesikinddefaultview.Columns["idtesikind"] };
			cChild = new[] { tesi.Columns["idtesikind"] };
			Relations.Add(new DataRelation("FK_tesi_tesikinddefaultview_idtesikind", cPar, cChild, false));

			cPar = new[] { insegndefaultview.Columns["idinsegn"] };
			cChild = new[] { tesi.Columns["idinsegn"] };
			Relations.Add(new DataRelation("FK_tesi_insegndefaultview_idinsegn", cPar, cChild, false));

			cPar = new[] { attach.Columns["idattach"] };
			cChild = new[] { tesi.Columns["idattach"] };
			Relations.Add(new DataRelation("FK_tesi_attach_idattach", cPar, cChild, false));

			cPar = new[] { annoaccademico.Columns["aa"] };
			cChild = new[] { tesi.Columns["aa"] };
			Relations.Add(new DataRelation("FK_tesi_annoaccademico_aa", cPar, cChild, false));

			cPar = new[] { registrydocentiview.Columns["idreg"] };
			cChild = new[] { richitesi.Columns["idreg_docenti"] };
			Relations.Add(new DataRelation("FK_richitesi_registrydocentiview_idreg_docenti", cPar, cChild, false));

			cPar = new[] { registrydefaultview.Columns["idreg"] };
			cChild = new[] { richitesi.Columns["idreg"] };
			Relations.Add(new DataRelation("FK_richitesi_registrydefaultview_idreg", cPar, cChild, false));

			#endregion

		}
	}
}
