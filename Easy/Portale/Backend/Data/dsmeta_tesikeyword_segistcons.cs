
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
	[System.Xml.Serialization.XmlRoot("dsmeta_tesikeyword_segistcons"), System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
	public class dsmeta_tesikeyword_segistcons :DataSet {

		#region Table members declaration
		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
		public MetaTable tesikeyword => (MetaTable)Tables["tesikeyword"];

		#endregion


		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new DataTableCollection Tables => base.Tables;

		[DebuggerNonUserCode, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		// ReSharper disable once MemberCanBePrivate.Global
		public new DataRelationCollection Relations => base.Relations;

		[DebuggerNonUserCode]
		public dsmeta_tesikeyword_segistcons() {
			BeginInit();
			initClass();
			EndInit();
		}
		[DebuggerNonUserCode]
		protected dsmeta_tesikeyword_segistcons(SerializationInfo info, StreamingContext ctx) : base(info, ctx) { }
		[DebuggerNonUserCode]
		private void initClass() {
			DataSetName = "dsmeta_tesikeyword_segistcons";
			Prefix = "";
			Namespace = "http://tempuri.org/dsmeta_tesikeyword_segistcons.xsd";

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

			#endregion

		}
	}
}
