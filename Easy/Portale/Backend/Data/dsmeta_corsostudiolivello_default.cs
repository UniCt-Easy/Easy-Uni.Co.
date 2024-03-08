
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
[System.Xml.Serialization.XmlRoot("dsmeta_corsostudiolivello_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_corsostudiolivello_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiokinddefaultview 		=> (MetaTable)Tables["corsostudiokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiolivello 		=> (MetaTable)Tables["corsostudiolivello"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_corsostudiolivello_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_corsostudiolivello_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_corsostudiolivello_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_corsostudiolivello_default.xsd";

	#region create DataTables
	//////////////////// CORSOSTUDIOKINDDEFAULTVIEW /////////////////////////////////
	var tcorsostudiokinddefaultview= new MetaTable("corsostudiokinddefaultview");
	tcorsostudiokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("idcorsostudiokind", typeof(int),false);
	Tables.Add(tcorsostudiokinddefaultview);
	tcorsostudiokinddefaultview.defineKey("idcorsostudiokind");

	//////////////////// CORSOSTUDIOLIVELLO /////////////////////////////////
	var tcorsostudiolivello= new MetaTable("corsostudiolivello");
	tcorsostudiolivello.defineColumn("idcorsostudiokind", typeof(int));
	tcorsostudiolivello.defineColumn("idcorsostudiolivello", typeof(int),false);
	tcorsostudiolivello.defineColumn("lt", typeof(DateTime),false);
	tcorsostudiolivello.defineColumn("lu", typeof(string),false);
	tcorsostudiolivello.defineColumn("title", typeof(string));
	Tables.Add(tcorsostudiolivello);
	tcorsostudiolivello.defineKey("idcorsostudiolivello");

	#endregion


	#region DataRelation creation
	var cPar = new []{corsostudiokinddefaultview.Columns["idcorsostudiokind"]};
	var cChild = new []{corsostudiolivello.Columns["idcorsostudiokind"]};
	Relations.Add(new DataRelation("FK_corsostudiolivello_corsostudiokinddefaultview_idcorsostudiokind",cPar,cChild,false));

	#endregion

}
}
}
