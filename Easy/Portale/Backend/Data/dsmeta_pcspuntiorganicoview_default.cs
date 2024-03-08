
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
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_pcspuntiorganicoview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pcspuntiorganicoview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcspuntiorganicoview 		=> (MetaTable)Tables["pcspuntiorganicoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pcspuntiorganicoview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pcspuntiorganicoview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pcspuntiorganicoview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pcspuntiorganicoview_default.xsd";

	#region create DataTables
	//////////////////// PCSPUNTIORGANICOVIEW /////////////////////////////////
	var tpcspuntiorganicoview= new MetaTable("pcspuntiorganicoview");
	tpcspuntiorganicoview.defineColumn("idanalisiannuale", typeof(int),false);
	tpcspuntiorganicoview.defineColumn("importo0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importo1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importo2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importo3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoateneo3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("importoesterno3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("isdoc", typeof(string),false);
	tpcspuntiorganicoview.defineColumn("position_title", typeof(string),false);
	tpcspuntiorganicoview.defineColumn("puntimeno0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntimeno1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntimeno2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntimeno3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu0", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu1", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu2", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("puntipiu3", typeof(decimal));
	tpcspuntiorganicoview.defineColumn("year", typeof(int),false);
	Tables.Add(tpcspuntiorganicoview);
	tpcspuntiorganicoview.defineKey("idanalisiannuale", "position_title", "year");

	#endregion

}
}
}
