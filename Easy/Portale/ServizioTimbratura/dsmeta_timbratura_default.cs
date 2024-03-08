
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
namespace ServizioTimbratura
{
	[Serializable, DesignerCategory("code"), System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
	[System.Xml.Serialization.XmlRoot("dsmeta_timbratura_default"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
	public class dsmeta_timbratura_default : DataSet
	{

		#region Table members declaration
		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable timbratura => (MetaTable)Tables["timbratura"];

		#endregion


		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataTableCollection Tables => base.Tables;

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once MemberCanBePrivate.Global
		public new DataRelationCollection Relations => base.Relations;

		[DebuggerNonUserCode]
		public dsmeta_timbratura_default()
		{
			BeginInit();
			initClass();
			EndInit();
		}
		[DebuggerNonUserCode]
		protected dsmeta_timbratura_default(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
		[DebuggerNonUserCode]
		private void initClass()
		{
			DataSetName = "dsmeta_timbratura_default";
			Prefix = "";
			Namespace = "http://tempuri.org/dsmeta_timbratura_default.xsd";

			#region create DataTables
			//////////////////// TIMBRATURA /////////////////////////////////
			var ttimbratura = new MetaTable("timbratura");
			ttimbratura.defineColumn("convalida", typeof(string));
			ttimbratura.defineColumn("ct", typeof(DateTime), false);
			ttimbratura.defineColumn("cu", typeof(string), false);
			ttimbratura.defineColumn("data", typeof(DateTime));
			ttimbratura.defineColumn("idreg", typeof(int), false);
			ttimbratura.defineColumn("idtimbratura", typeof(int), false);
			ttimbratura.defineColumn("lt", typeof(DateTime), false);
			ttimbratura.defineColumn("lu", typeof(string), false);
			ttimbratura.defineColumn("minuti", typeof(int));
			Tables.Add(ttimbratura);
			ttimbratura.defineKey("idreg", "idtimbratura");

			#endregion

		}
	}
}
