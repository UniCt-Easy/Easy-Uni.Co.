
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfruolomansionekind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfruolomansionekind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolomansionekind 		=> (MetaTable)Tables["perfruolomansionekind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfruolomansionekind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfruolomansionekind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfruolomansionekind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfruolomansionekind_default.xsd";

	#region create DataTables
	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("ct", typeof(DateTime),false);
	tmansionekind.defineColumn("cu", typeof(string),false);
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("lt", typeof(DateTime),false);
	tmansionekind.defineColumn("lu", typeof(string),false);
	tmansionekind.defineColumn("pesoateneo", typeof(decimal));
	tmansionekind.defineColumn("pesocomp", typeof(decimal));
	tmansionekind.defineColumn("pesoindividuale", typeof(decimal));
	tmansionekind.defineColumn("pesouo", typeof(decimal));
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	//////////////////// PERFRUOLOMANSIONEKIND /////////////////////////////////
	var tperfruolomansionekind= new MetaTable("perfruolomansionekind");
	tperfruolomansionekind.defineColumn("ct", typeof(DateTime),false);
	tperfruolomansionekind.defineColumn("cu", typeof(string),false);
	tperfruolomansionekind.defineColumn("idmansionekind", typeof(int),false);
	tperfruolomansionekind.defineColumn("idperfruolo", typeof(string),false);
	tperfruolomansionekind.defineColumn("lt", typeof(DateTime),false);
	tperfruolomansionekind.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfruolomansionekind);
	tperfruolomansionekind.defineKey("idmansionekind", "idperfruolo");

	#endregion


	#region DataRelation creation
	var cPar = new []{mansionekind.Columns["idmansionekind"]};
	var cChild = new []{perfruolomansionekind.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_perfruolomansionekind_mansionekind_idmansionekind",cPar,cChild,false));

	#endregion

}
}
}
