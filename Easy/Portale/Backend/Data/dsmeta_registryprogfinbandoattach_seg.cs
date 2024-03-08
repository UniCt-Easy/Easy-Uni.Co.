
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
[System.Xml.Serialization.XmlRoot("dsmeta_registryprogfinbandoattach_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registryprogfinbandoattach_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfinbandoattach 		=> (MetaTable)Tables["registryprogfinbandoattach"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registryprogfinbandoattach_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registryprogfinbandoattach_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registryprogfinbandoattach_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registryprogfinbandoattach_seg.xsd";

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

	//////////////////// REGISTRYPROGFINBANDOATTACH /////////////////////////////////
	var tregistryprogfinbandoattach= new MetaTable("registryprogfinbandoattach");
	tregistryprogfinbandoattach.defineColumn("ct", typeof(DateTime),false);
	tregistryprogfinbandoattach.defineColumn("cu", typeof(string),false);
	tregistryprogfinbandoattach.defineColumn("idattach", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("idreg", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("idregistryprogfinbando", typeof(int),false);
	tregistryprogfinbandoattach.defineColumn("lt", typeof(DateTime),false);
	tregistryprogfinbandoattach.defineColumn("lu", typeof(string),false);
	tregistryprogfinbandoattach.defineColumn("title", typeof(string));
	Tables.Add(tregistryprogfinbandoattach);
	tregistryprogfinbandoattach.defineKey("idattach", "idreg", "idregistryprogfin", "idregistryprogfinbando");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach.Columns["idattach"]};
	var cChild = new []{registryprogfinbandoattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_registryprogfinbandoattach_attach_idattach",cPar,cChild,false));

	#endregion

}
}
}
