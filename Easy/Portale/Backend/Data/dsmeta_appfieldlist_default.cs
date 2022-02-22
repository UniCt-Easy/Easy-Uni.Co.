
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
[System.Xml.Serialization.XmlRoot("dsmeta_appfieldlist_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_appfieldlist_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getsorting 		=> (MetaTable)Tables["getsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appfieldlist 		=> (MetaTable)Tables["appfieldlist"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_appfieldlist_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_appfieldlist_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_appfieldlist_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_appfieldlist_default.xsd";

	#region create DataTables
	//////////////////// GETSORTING /////////////////////////////////
	var tgetsorting= new MetaTable("getsorting");
	tgetsorting.defineColumn("getsorting", typeof(string),false);
	Tables.Add(tgetsorting);
	tgetsorting.defineKey("getsorting");

	//////////////////// APPFIELDLIST /////////////////////////////////
	var tappfieldlist= new MetaTable("appfieldlist");
	tappfieldlist.defineColumn("columnname", typeof(string));
	tappfieldlist.defineColumn("editable", typeof(string),false);
	tappfieldlist.defineColumn("filter", typeof(string));
	tappfieldlist.defineColumn("filterjs", typeof(string));
	tappfieldlist.defineColumn("getsorting", typeof(string));
	tappfieldlist.defineColumn("idappfieldlist", typeof(int),false);
	tappfieldlist.defineColumn("idapppages", typeof(int),false);
	tappfieldlist.defineColumn("position", typeof(int));
	tappfieldlist.defineColumn("summary", typeof(string));
	tappfieldlist.defineColumn("textfield", typeof(int));
	tappfieldlist.defineColumn("textfieldprefix", typeof(string));
	tappfieldlist.defineColumn("visible", typeof(string));
	Tables.Add(tappfieldlist);
	tappfieldlist.defineKey("idappfieldlist", "idapppages");

	#endregion


	#region DataRelation creation
	var cPar = new []{getsorting.Columns["getsorting"]};
	var cChild = new []{appfieldlist.Columns["getsorting"]};
	Relations.Add(new DataRelation("FK_appfieldlist_getsorting_getsorting",cPar,cChild,false));

	#endregion

}
}
}
