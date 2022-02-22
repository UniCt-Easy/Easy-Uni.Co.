
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
[System.Xml.Serialization.XmlRoot("dsmeta_menuweb_tree"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_menuweb_tree: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable menuweb_alias1 		=> (MetaTable)Tables["menuweb_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable menuweb 		=> (MetaTable)Tables["menuweb"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_menuweb_tree(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_menuweb_tree (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_menuweb_tree";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_menuweb_tree.xsd";

	#region create DataTables
	//////////////////// MENUWEB_ALIAS1 /////////////////////////////////
	var tmenuweb_alias1= new MetaTable("menuweb_alias1");
	tmenuweb_alias1.defineColumn("idmenuweb", typeof(int),false);
	tmenuweb_alias1.defineColumn("label", typeof(string),false);
	tmenuweb_alias1.ExtendedProperties["TableForReading"]="menuweb";
	Tables.Add(tmenuweb_alias1);
	tmenuweb_alias1.defineKey("idmenuweb");

	//////////////////// MENUWEB /////////////////////////////////
	var tmenuweb= new MetaTable("menuweb");
	tmenuweb.defineColumn("editType", typeof(string));
	tmenuweb.defineColumn("idmenuweb", typeof(int),false);
	tmenuweb.defineColumn("idmenuwebparent", typeof(int));
	tmenuweb.defineColumn("label", typeof(string),false);
	tmenuweb.defineColumn("link", typeof(string));
	tmenuweb.defineColumn("sort", typeof(int));
	tmenuweb.defineColumn("tableName", typeof(string));
	Tables.Add(tmenuweb);
	tmenuweb.defineKey("idmenuweb");

	#endregion


	#region DataRelation creation
	var cPar = new []{menuweb_alias1.Columns["idmenuweb"]};
	var cChild = new []{menuweb.Columns["idmenuwebparent"]};
	Relations.Add(new DataRelation("FK_menuweb_menuweb_alias1_idmenuwebparent",cPar,cChild,false));

	cPar = new []{menuweb.Columns["idmenuweb"]};
	cChild = new []{menuweb.Columns["idmenuwebparent"]};
	Relations.Add(new DataRelation("FK_menuweb_menuweb_idmenuweb",cPar,cChild,false));

	#endregion

}
}
}
