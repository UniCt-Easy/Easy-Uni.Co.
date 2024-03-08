
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanzadichiar_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_istanzadichiar_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzadichiar 		=> (MetaTable)Tables["istanzadichiar"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanzadichiar_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanzadichiar_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanzadichiar_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanzadichiar_seg.xsd";

	#region create DataTables
	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("ct", typeof(DateTime),false);
	tdichiar.defineColumn("cu", typeof(string),false);
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("extension", typeof(string));
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	tdichiar.defineColumn("lt", typeof(DateTime),false);
	tdichiar.defineColumn("lu", typeof(string),false);
	tdichiar.defineColumn("protanno", typeof(int));
	tdichiar.defineColumn("protnumero", typeof(int));
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// ISTANZADICHIAR /////////////////////////////////
	var tistanzadichiar= new MetaTable("istanzadichiar");
	tistanzadichiar.defineColumn("ct", typeof(DateTime),false);
	tistanzadichiar.defineColumn("cu", typeof(string),false);
	tistanzadichiar.defineColumn("iddichiar", typeof(int),false);
	tistanzadichiar.defineColumn("idistanza", typeof(int),false);
	tistanzadichiar.defineColumn("idreg", typeof(int),false);
	tistanzadichiar.defineColumn("lt", typeof(DateTime),false);
	tistanzadichiar.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanzadichiar);
	tistanzadichiar.defineKey("iddichiar", "idistanza", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{dichiar.Columns["iddichiar"]};
	var cChild = new []{istanzadichiar.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_istanzadichiar_dichiar_iddichiar",cPar,cChild,false));

	#endregion

}
}
}
