
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
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_diniego_segpratica"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_diniego_segpratica: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego 		=> (MetaTable)Tables["diniego"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_diniego_segpratica(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_diniego_segpratica (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_diniego_segpratica";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_diniego_segpratica.xsd";

	#region create DataTables
	//////////////////// DINIEGO /////////////////////////////////
	var tdiniego= new MetaTable("diniego");
	tdiniego.defineColumn("ct", typeof(DateTime),false);
	tdiniego.defineColumn("cu", typeof(string),false);
	tdiniego.defineColumn("data", typeof(DateTime),false);
	tdiniego.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego.defineColumn("iddidprog", typeof(int));
	tdiniego.defineColumn("iddiniego", typeof(int),false);
	tdiniego.defineColumn("idiscrizione", typeof(int));
	tdiniego.defineColumn("idistanza", typeof(int),false);
	tdiniego.defineColumn("idistanzakind", typeof(int),false);
	tdiniego.defineColumn("idreg", typeof(int),false);
	tdiniego.defineColumn("lt", typeof(DateTime),false);
	tdiniego.defineColumn("lu", typeof(string),false);
	tdiniego.defineColumn("protanno", typeof(int));
	tdiniego.defineColumn("protnumero", typeof(int));
	Tables.Add(tdiniego);
	tdiniego.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	#endregion

}
}
}
