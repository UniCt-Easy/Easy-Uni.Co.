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
[System.Xml.Serialization.XmlRoot("dsmeta_costoscontodefkind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_costoscontodefkind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable estimatekind 		=> (MetaTable)Tables["estimatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefkind 		=> (MetaTable)Tables["costoscontodefkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_costoscontodefkind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_costoscontodefkind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_costoscontodefkind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_costoscontodefkind_default.xsd";

	#region create DataTables
	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new MetaTable("estimatekind");
	testimatekind.defineColumn("active", typeof(string));
	testimatekind.defineColumn("address", typeof(string));
	testimatekind.defineColumn("ct", typeof(DateTime),false);
	testimatekind.defineColumn("cu", typeof(string),false);
	testimatekind.defineColumn("deltaamount", typeof(decimal));
	testimatekind.defineColumn("deltapercentage", typeof(decimal));
	testimatekind.defineColumn("description", typeof(string),false);
	testimatekind.defineColumn("email", typeof(string));
	testimatekind.defineColumn("faxnumber", typeof(string));
	testimatekind.defineColumn("flag", typeof(int));
	testimatekind.defineColumn("flag_autodocnumbering", typeof(string));
	testimatekind.defineColumn("header", typeof(string));
	testimatekind.defineColumn("idestimkind", typeof(string),false);
	testimatekind.defineColumn("idivakind_forced", typeof(int));
	testimatekind.defineColumn("idupb", typeof(string));
	testimatekind.defineColumn("linktoinvoice", typeof(string));
	testimatekind.defineColumn("lt", typeof(DateTime),false);
	testimatekind.defineColumn("lu", typeof(string),false);
	testimatekind.defineColumn("multireg", typeof(string));
	testimatekind.defineColumn("office", typeof(string));
	testimatekind.defineColumn("phonenumber", typeof(string));
	testimatekind.defineColumn("riferimento_amministrazione", typeof(string));
	testimatekind.defineColumn("rtf", typeof(Byte[]));
	testimatekind.defineColumn("txt", typeof(string));
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	//////////////////// COSTOSCONTODEFKIND /////////////////////////////////
	var tcostoscontodefkind= new MetaTable("costoscontodefkind");
	tcostoscontodefkind.defineColumn("active", typeof(string),false);
	tcostoscontodefkind.defineColumn("ct", typeof(DateTime),false);
	tcostoscontodefkind.defineColumn("cu", typeof(string),false);
	tcostoscontodefkind.defineColumn("description", typeof(string));
	tcostoscontodefkind.defineColumn("idcostoscontodefkind", typeof(int),false);
	tcostoscontodefkind.defineColumn("idestimkind", typeof(string));
	tcostoscontodefkind.defineColumn("lt", typeof(DateTime),false);
	tcostoscontodefkind.defineColumn("lu", typeof(string),false);
	tcostoscontodefkind.defineColumn("sortcode", typeof(int),false);
	tcostoscontodefkind.defineColumn("title", typeof(string),false);
	Tables.Add(tcostoscontodefkind);
	tcostoscontodefkind.defineKey("idcostoscontodefkind");

	#endregion


	#region DataRelation creation
	var cPar = new []{estimatekind.Columns["idestimkind"]};
	var cChild = new []{costoscontodefkind.Columns["idestimkind"]};
	Relations.Add(new DataRelation("FK_costoscontodefkind_estimatekind_idestimkind",cPar,cChild,false));

	#endregion

}
}
}
