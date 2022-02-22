
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
	[Serializable, DesignerCategory("code"), System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
	[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonale_insertvalutazione"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
	public class dsmeta_perfvalutazionepersonale_insertvalutazione : DataSet {

		#region Table members declaration

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfvalutazionepersonale => (MetaTable)Tables["perfvalutazionepersonale"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfvalutazionepersonaleobiettivo => (MetaTable)Tables["perfvalutazionepersonaleobiettivo"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfvalutazionepersonalesoglia => (MetaTable)Tables["perfvalutazionepersonalesoglia"];

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable perfrequestobbindividuale => (MetaTable)Tables["perfrequestobbindividuale"];
		#endregion


		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataTableCollection Tables => base.Tables;

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once MemberCanBePrivate.Global
		public new DataRelationCollection Relations => base.Relations;


		[DebuggerNonUserCode]
		public dsmeta_perfvalutazionepersonale_insertvalutazione() {
			BeginInit();
			initClass();
			EndInit();
		}
		[DebuggerNonUserCode]
		protected dsmeta_perfvalutazionepersonale_insertvalutazione(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
		[DebuggerNonUserCode]
		private void initClass() {
			DataSetName = "dsmeta_perfrequestobbindividuale_insertvalutazione";
			Prefix = "";
			Namespace = "http://tempuri.org/dsmeta_perfrequestobbindividuale_default.xsd";

			#region create DataTables


			//////////////////// PERFVALUTAZIONEPERSONALE /////////////////////////////////
			var tperfvalutazionepersonale = new MetaTable("perfvalutazionepersonale");
			tperfvalutazionepersonale.defineColumn("ct", typeof(DateTime), false);
			tperfvalutazionepersonale.defineColumn("cu", typeof(string), false);
			tperfvalutazionepersonale.defineColumn("idperfschedastatus", typeof(int));
			tperfvalutazionepersonale.defineColumn("idperfvalutazionepersonale", typeof(int), false);
			tperfvalutazionepersonale.defineColumn("idreg", typeof(int), false);
			tperfvalutazionepersonale.defineColumn("idreg_appr", typeof(int));
			tperfvalutazionepersonale.defineColumn("idreg_val", typeof(int));
			tperfvalutazionepersonale.defineColumn("lt", typeof(DateTime), false);
			tperfvalutazionepersonale.defineColumn("lu", typeof(string), false);
			tperfvalutazionepersonale.defineColumn("perccomportamenti", typeof(decimal));
			tperfvalutazionepersonale.defineColumn("percobiettivi", typeof(decimal));
			tperfvalutazionepersonale.defineColumn("percperfuo", typeof(decimal));
			tperfvalutazionepersonale.defineColumn("pesocomportamenti", typeof(decimal));
			tperfvalutazionepersonale.defineColumn("pesoobiettivi", typeof(decimal));
			tperfvalutazionepersonale.defineColumn("pesoperfuo", typeof(decimal));
			tperfvalutazionepersonale.defineColumn("risultato", typeof(decimal));
			tperfvalutazionepersonale.defineColumn("year", typeof(int));
			Tables.Add(tperfvalutazionepersonale);
			tperfvalutazionepersonale.defineKey("idperfvalutazionepersonale", "idreg");

			//////////////////// PERFVALUTAZIONEPERSONALEOBIETTIVO /////////////////////////////////
			var tperfvalutazionepersonaleobiettivo = new MetaTable("perfvalutazionepersonaleobiettivo");
			tperfvalutazionepersonaleobiettivo.defineColumn("completamento", typeof(decimal));
			tperfvalutazionepersonaleobiettivo.defineColumn("ct", typeof(DateTime), false);
			tperfvalutazionepersonaleobiettivo.defineColumn("cu", typeof(string), false);
			tperfvalutazionepersonaleobiettivo.defineColumn("description", typeof(string));
			tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonale", typeof(int), false);
			tperfvalutazionepersonaleobiettivo.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int), false);
			tperfvalutazionepersonaleobiettivo.defineColumn("inverso", typeof(string));
			tperfvalutazionepersonaleobiettivo.defineColumn("lt", typeof(DateTime), false);
			tperfvalutazionepersonaleobiettivo.defineColumn("lu", typeof(string), false);
			tperfvalutazionepersonaleobiettivo.defineColumn("peso", typeof(decimal));
			tperfvalutazionepersonaleobiettivo.defineColumn("title", typeof(string));
			tperfvalutazionepersonaleobiettivo.defineColumn("valorenumerico", typeof(decimal));
			tperfvalutazionepersonaleobiettivo.defineColumn("!perfvalutazionepersonalesoglia", typeof(string));
			Tables.Add(tperfvalutazionepersonaleobiettivo);
			tperfvalutazionepersonaleobiettivo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo");

			//////////////////// PERFVALUTAZIONEPERSONALESOGLIA /////////////////////////////////
			var tperfvalutazionepersonalesoglia = new MetaTable("perfvalutazionepersonalesoglia");
			tperfvalutazionepersonalesoglia.defineColumn("ct", typeof(DateTime), false);
			tperfvalutazionepersonalesoglia.defineColumn("cu", typeof(string), false);
			tperfvalutazionepersonalesoglia.defineColumn("description", typeof(string));
			tperfvalutazionepersonalesoglia.defineColumn("idperfsogliakind", typeof(string));
			tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonale", typeof(int), false);
			tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonaleobiettivo", typeof(int), false);
			tperfvalutazionepersonalesoglia.defineColumn("idperfvalutazionepersonalesoglia", typeof(int), false);
			tperfvalutazionepersonalesoglia.defineColumn("lt", typeof(DateTime), false);
			tperfvalutazionepersonalesoglia.defineColumn("lu", typeof(string), false);
			tperfvalutazionepersonalesoglia.defineColumn("percentuale", typeof(decimal));
			tperfvalutazionepersonalesoglia.defineColumn("valorenumerico", typeof(decimal));
			Tables.Add(tperfvalutazionepersonalesoglia);
			tperfvalutazionepersonalesoglia.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleobiettivo", "idperfvalutazionepersonalesoglia");

			//////////////////// PERFREQUESTOBBINDIVIDUALE /////////////////////////////////
			var tperfrequestobbindividuale = new MetaTable("perfrequestobbindividuale");
			tperfrequestobbindividuale.defineColumn("ct", typeof(DateTime), false);
			tperfrequestobbindividuale.defineColumn("cu", typeof(string), false);
			tperfrequestobbindividuale.defineColumn("description", typeof(string));
			tperfrequestobbindividuale.defineColumn("idperfrequestobbindividuale", typeof(int), false);
			tperfrequestobbindividuale.defineColumn("idreg", typeof(int), false);
			tperfrequestobbindividuale.defineColumn("inserito", typeof(string));
			tperfrequestobbindividuale.defineColumn("lt", typeof(DateTime), false);
			tperfrequestobbindividuale.defineColumn("lu", typeof(string), false);
			tperfrequestobbindividuale.defineColumn("peso", typeof(decimal));
			tperfrequestobbindividuale.defineColumn("title", typeof(string));
			tperfrequestobbindividuale.defineColumn("year", typeof(int));
			Tables.Add(tperfrequestobbindividuale);
			tperfrequestobbindividuale.defineKey("idperfrequestobbindividuale", "idreg");

			#endregion


			#region DataRelation creation

			var cPar = new[] { perfvalutazionepersonale.Columns["idperfvalutazionepersonale"] };
			var cChild = new[] { perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"] };
			Relations.Add(new DataRelation("FK_perfvalutazionepersonaleobiettivo_perfvalutazionepersonale_idperfvalutazionepersonale", cPar, cChild, false));

			cPar = new[] { perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonale"], perfvalutazionepersonaleobiettivo.Columns["idperfvalutazionepersonaleobiettivo"] };
			cChild = new[] { perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonale"], perfvalutazionepersonalesoglia.Columns["idperfvalutazionepersonaleobiettivo"] };
			Relations.Add(new DataRelation("FK_perfvalutazionepersonalesoglia_perfvalutazionepersonaleobiettivo_idperfvalutazionepersonale-idperfvalutazionepersonaleobiettivo", cPar, cChild, false));


			#endregion

		}
	}
}
