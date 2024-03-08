
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
[System.Xml.Serialization.XmlRoot("dsmeta_finmotive_tree"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_finmotive_tree: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotive 		=> (MetaTable)Tables["finmotive"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_finmotive_tree(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_finmotive_tree (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_finmotive_tree";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_finmotive_tree.xsd";

	#region create DataTables
	//////////////////// FINMOTIVE /////////////////////////////////
	var tfinmotive= new MetaTable("finmotive");
	tfinmotive.defineColumn("idfinmotive", typeof(string),false);
	tfinmotive.defineColumn("paridfinmotive", typeof(string));
	tfinmotive.defineColumn("codemotive", typeof(string),false);
	tfinmotive.defineColumn("title", typeof(string),false);
	tfinmotive.defineColumn("cu", typeof(string),false);
	tfinmotive.defineColumn("ct", typeof(DateTime),false);
	tfinmotive.defineColumn("lu", typeof(string),false);
	tfinmotive.defineColumn("lt", typeof(DateTime),false);
	tfinmotive.defineColumn("active", typeof(string));
	Tables.Add(tfinmotive);
	tfinmotive.defineKey("idfinmotive");

	#endregion


	#region DataRelation creation
	var cPar = new []{finmotive.Columns["idfinmotive"]};
	var cChild = new []{finmotive.Columns["paridfinmotive"]};
	Relations.Add(new DataRelation("finmotivefinmotive",cPar,cChild,false));

	#endregion

}
}
}
