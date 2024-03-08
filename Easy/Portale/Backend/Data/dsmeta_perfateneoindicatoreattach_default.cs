
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfateneoindicatoreattach_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfateneoindicatoreattach_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoindicatoreattach 		=> (MetaTable)Tables["perfateneoindicatoreattach"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfateneoindicatoreattach_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfateneoindicatoreattach_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfateneoindicatoreattach_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfateneoindicatoreattach_default.xsd";

	#region create DataTables
	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// PERFATENEOINDICATOREATTACH /////////////////////////////////
	var tperfateneoindicatoreattach= new MetaTable("perfateneoindicatoreattach");
	tperfateneoindicatoreattach.defineColumn("ct", typeof(DateTime),false);
	tperfateneoindicatoreattach.defineColumn("cu", typeof(string),false);
	tperfateneoindicatoreattach.defineColumn("idattach", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfateneoindicatore", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfateneoindicatoreattach", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("lt", typeof(DateTime),false);
	tperfateneoindicatoreattach.defineColumn("lu", typeof(string),false);
	tperfateneoindicatoreattach.defineColumn("title", typeof(string));
	Tables.Add(tperfateneoindicatoreattach);
	tperfateneoindicatoreattach.defineKey("idattach", "idperfateneoindicatore", "idperfateneoindicatoreattach", "idperfateneoobiettivo", "idperfvalutazioneateneo");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach.Columns["idattach"]};
	var cChild = new []{perfateneoindicatoreattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfateneoindicatoreattach_attach_idattach",cPar,cChild,false));

	#endregion

}
}
}
