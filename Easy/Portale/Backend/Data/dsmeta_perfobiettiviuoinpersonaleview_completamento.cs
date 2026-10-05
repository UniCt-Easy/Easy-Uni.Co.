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
[System.Xml.Serialization.XmlRoot("dsmeta_perfobiettiviuoinpersonaleview_completamento"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfobiettiviuoinpersonaleview_completamento: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuoinpersonaleview 		=> (MetaTable)Tables["perfobiettiviuoinpersonaleview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfobiettiviuoinpersonaleview_completamento(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfobiettiviuoinpersonaleview_completamento (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfobiettiviuoinpersonaleview_completamento";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfobiettiviuoinpersonaleview_completamento.xsd";

	#region create DataTables
	//////////////////// PERFOBIETTIVIUOINPERSONALEVIEW /////////////////////////////////
	var tperfobiettiviuoinpersonaleview= new MetaTable("perfobiettiviuoinpersonaleview");
	tperfobiettiviuoinpersonaleview.defineColumn("completamento", typeof(decimal));
	tperfobiettiviuoinpersonaleview.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuoinpersonaleview.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfobiettiviuoinpersonaleview.defineColumn("note", typeof(string));
	tperfobiettiviuoinpersonaleview.defineColumn("peso", typeof(decimal));
	tperfobiettiviuoinpersonaleview.defineColumn("punteggio", typeof(int));
	tperfobiettiviuoinpersonaleview.defineColumn("title", typeof(string));
	Tables.Add(tperfobiettiviuoinpersonaleview);
	tperfobiettiviuoinpersonaleview.defineKey("idperfobiettiviuo", "idperfvalutazionepersonale");

	#endregion

}
}
}
