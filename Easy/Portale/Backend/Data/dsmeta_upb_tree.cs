
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
[System.Xml.Serialization.XmlRoot("dsmeta_sorting_treeall"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_sorting_treeall: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sorting_treeall(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sorting_treeall (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sorting_treeall";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sorting_treeall.xsd";

	#region create DataTables
	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("codeupb", typeof(string),false);
	tupb.defineColumn("title", typeof(string),false);
	tupb.defineColumn("paridupb", typeof(string));
	tupb.defineColumn("idunderwriter", typeof(int));
	tupb.defineColumn("idman", typeof(int));
	tupb.defineColumn("requested", typeof(decimal));
	tupb.defineColumn("granted", typeof(decimal));
	tupb.defineColumn("previousappropriation", typeof(decimal));
	tupb.defineColumn("expiration", typeof(DateTime));
	tupb.defineColumn("txt", typeof(string));
	tupb.defineColumn("rtf", typeof(Byte[]));
	tupb.defineColumn("cu", typeof(string),false);
	tupb.defineColumn("ct", typeof(DateTime),false);
	tupb.defineColumn("lu", typeof(string),false);
	tupb.defineColumn("lt", typeof(DateTime),false);
	tupb.defineColumn("assured", typeof(string));
	tupb.defineColumn("printingorder", typeof(string),false);
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("previousassessment", typeof(decimal));
	tupb.defineColumn("cupcode", typeof(string));
	tupb.defineColumn("flagactivity", typeof(int));
	tupb.defineColumn("flagkind", typeof(byte));
	tupb.defineColumn("newcodeupb", typeof(string));
	tupb.defineColumn("idsor01", typeof(int));
	tupb.defineColumn("idsor02", typeof(int));
	tupb.defineColumn("idsor03", typeof(int));
	tupb.defineColumn("idsor04", typeof(int));
	tupb.defineColumn("idsor05", typeof(int));
	tupb.defineColumn("idtreasurer", typeof(int));
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	#endregion


	#region DataRelation creation
	var cPar = new []{upb.Columns["idupb"]};
	var cChild = new []{upb.Columns["paridupb"]};
	Relations.Add(new DataRelation("upbupb",cPar,cChild,false));

	#endregion

}
}
}
