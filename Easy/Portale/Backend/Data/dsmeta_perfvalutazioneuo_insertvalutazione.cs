
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
	[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuo_insertvalutazione"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
	public class dsmeta_perfvalutazioneuo_insertvalutazione :DataSet {

		#region Table members declaration

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfobiettiviuosoglia => (MetaTable)Tables["perfobiettiviuosoglia"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfobiettiviuo => (MetaTable)Tables["perfobiettiviuo"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfrequestobbindividuale => (MetaTable)Tables["perfrequestobbindividuale"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfvalutazioneuo => (MetaTable)Tables["perfvalutazioneuo"];
		#endregion


		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataTableCollection Tables => base.Tables;

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once MemberCanBePrivate.Global
		public new DataRelationCollection Relations => base.Relations;


		[DebuggerNonUserCode]
		public dsmeta_perfvalutazioneuo_insertvalutazione() {
			BeginInit();
			initClass();
			EndInit();
		}
		[DebuggerNonUserCode]
		protected dsmeta_perfvalutazioneuo_insertvalutazione(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
		[DebuggerNonUserCode]
		private void initClass() {
			DataSetName = "dsmeta_perfvalutazioneuo_insertvalutazione";
			Prefix = "";
			Namespace = "http://tempuri.org/dsmeta_perfrequestobbindividuale_default.xsd";

			#region create DataTables


			//////////////////// PERFVALUTAZIONEUO /////////////////////////////////
			var tperfvalutazioneuo = new MetaTable("perfvalutazioneuo");
			tperfvalutazioneuo.defineColumn("completamentopsauo", typeof(decimal));
			tperfvalutazioneuo.defineColumn("completamentopsuo", typeof(decimal));
			tperfvalutazioneuo.defineColumn("ct", typeof(DateTime), false);
			tperfvalutazioneuo.defineColumn("cu", typeof(string), false);
			tperfvalutazioneuo.defineColumn("idperfschedastatus", typeof(int));
			tperfvalutazioneuo.defineColumn("idperfvalutazioneuo", typeof(int), false);
			tperfvalutazioneuo.defineColumn("idreg_appr", typeof(int));
			tperfvalutazioneuo.defineColumn("idreg_val", typeof(int));
			tperfvalutazioneuo.defineColumn("idstruttura", typeof(int), false);
			tperfvalutazioneuo.defineColumn("indicatori", typeof(decimal));
			tperfvalutazioneuo.defineColumn("lt", typeof(DateTime), false);
			tperfvalutazioneuo.defineColumn("lu", typeof(string), false);
			tperfvalutazioneuo.defineColumn("obiettiviindividuali", typeof(decimal));
			tperfvalutazioneuo.defineColumn("pesoindicatori", typeof(decimal));
			tperfvalutazioneuo.defineColumn("pesoobiettivi", typeof(decimal));
			tperfvalutazioneuo.defineColumn("pesoprogaltreuo", typeof(decimal));
			tperfvalutazioneuo.defineColumn("pesoproguo", typeof(decimal));
			tperfvalutazioneuo.defineColumn("risultato", typeof(decimal));
			tperfvalutazioneuo.defineColumn("year", typeof(int));
			Tables.Add(tperfvalutazioneuo);
			tperfvalutazioneuo.defineKey("idperfvalutazioneuo", "idstruttura");

			//////////////////// PERFOBIETTIVIUOSOGLIA /////////////////////////////////
			var tperfobiettiviuosoglia = new MetaTable("perfobiettiviuosoglia");
			tperfobiettiviuosoglia.defineColumn("ct", typeof(DateTime), false);
			tperfobiettiviuosoglia.defineColumn("cu", typeof(string), false);
			tperfobiettiviuosoglia.defineColumn("description", typeof(string));
			tperfobiettiviuosoglia.defineColumn("idperfobiettiviuo", typeof(int), false);
			tperfobiettiviuosoglia.defineColumn("idperfobiettiviuosoglia", typeof(int), false);
			tperfobiettiviuosoglia.defineColumn("idperfsogliakind", typeof(string));
			tperfobiettiviuosoglia.defineColumn("idperfvalutazioneuo", typeof(int), false);
			tperfobiettiviuosoglia.defineColumn("lt", typeof(DateTime), false);
			tperfobiettiviuosoglia.defineColumn("lu", typeof(string), false);
			tperfobiettiviuosoglia.defineColumn("percentuale", typeof(decimal));
			tperfobiettiviuosoglia.defineColumn("valorenumerico", typeof(decimal));
			Tables.Add(tperfobiettiviuosoglia);
			tperfobiettiviuosoglia.defineKey("idperfobiettiviuo", "idperfobiettiviuosoglia", "idperfvalutazioneuo");

			//////////////////// PERFOBIETTIVIUO /////////////////////////////////
			var tperfobiettiviuo = new MetaTable("perfobiettiviuo");
			tperfobiettiviuo.defineColumn("completamento", typeof(decimal));
			tperfobiettiviuo.defineColumn("description", typeof(string));
			tperfobiettiviuo.defineColumn("idperfobiettiviuo", typeof(int), false);
			tperfobiettiviuo.defineColumn("idperfvalutazioneuo", typeof(int), false);
			tperfobiettiviuo.defineColumn("peso", typeof(decimal));
			tperfobiettiviuo.defineColumn("title", typeof(string));
			tperfobiettiviuo.defineColumn("valorenumerico", typeof(decimal));
			tperfobiettiviuo.defineColumn("!perfobiettiviuosoglia", typeof(string));
			Tables.Add(tperfobiettiviuo);
			tperfobiettiviuo.defineKey("idperfobiettiviuo", "idperfvalutazioneuo");


			//////////////////// PERFREQUESTOBBUNATANTUM /////////////////////////////////
			var tperfrequestobbunatantum = new MetaTable("perfrequestobbunatantum");
			tperfrequestobbunatantum.defineColumn("ct", typeof(DateTime), false);
			tperfrequestobbunatantum.defineColumn("cu", typeof(string), false);
			tperfrequestobbunatantum.defineColumn("description", typeof(string));
			tperfrequestobbunatantum.defineColumn("idperfrequestobbunatantum", typeof(int), false);
			tperfrequestobbunatantum.defineColumn("idstruttura", typeof(int), false);
			tperfrequestobbunatantum.defineColumn("inserito", typeof(string));
			tperfrequestobbunatantum.defineColumn("lt", typeof(DateTime), false);
			tperfrequestobbunatantum.defineColumn("lu", typeof(string), false);
			tperfrequestobbunatantum.defineColumn("peso", typeof(decimal));
			tperfrequestobbunatantum.defineColumn("title", typeof(string));
			tperfrequestobbunatantum.defineColumn("year", typeof(int));
			Tables.Add(tperfrequestobbunatantum);
			tperfrequestobbunatantum.defineKey("idperfrequestobbunatantum", "idstruttura");
			#endregion


			#region DataRelation creation

			var cPar = new[] { perfvalutazioneuo.Columns["idperfvalutazioneuo"] };
			var cChild = new[] { perfobiettiviuo.Columns["idperfvalutazioneuo"] };
			Relations.Add(new DataRelation("FK_perfobiettiviuo_perfvalutazioneuo_idperfvalutazioneuo", cPar, cChild, false));

			cPar = new[] { perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"] };
			cChild = new[] { perfobiettiviuosoglia.Columns["idperfobiettiviuo"], perfobiettiviuosoglia.Columns["idperfvalutazioneuo"] };
			Relations.Add(new DataRelation("FK_perfobiettiviuosoglia_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo", cPar, cChild, false));


			#endregion

		}
	}
}
