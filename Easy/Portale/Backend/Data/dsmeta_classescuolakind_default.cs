
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
[System.Xml.Serialization.XmlRoot("dsmeta_classescuolakind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_classescuolakind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiolivellodefaultview 		=> (MetaTable)Tables["corsostudiolivellodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiokinddefaultview 		=> (MetaTable)Tables["corsostudiokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuolakind 		=> (MetaTable)Tables["classescuolakind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_classescuolakind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_classescuolakind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_classescuolakind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_classescuolakind_default.xsd";

	#region create DataTables
	//////////////////// CORSOSTUDIOLIVELLODEFAULTVIEW /////////////////////////////////
	var tcorsostudiolivellodefaultview= new MetaTable("corsostudiolivellodefaultview");
	tcorsostudiolivellodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiolivellodefaultview.defineColumn("idcorsostudiolivello", typeof(int),false);
	Tables.Add(tcorsostudiolivellodefaultview);
	tcorsostudiolivellodefaultview.defineKey("idcorsostudiolivello");

	//////////////////// CORSOSTUDIOKINDDEFAULTVIEW /////////////////////////////////
	var tcorsostudiokinddefaultview= new MetaTable("corsostudiokinddefaultview");
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_active", typeof(string));
	tcorsostudiokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("idcorsostudiokind", typeof(int),false);
	Tables.Add(tcorsostudiokinddefaultview);
	tcorsostudiokinddefaultview.defineKey("idcorsostudiokind");

	//////////////////// CLASSESCUOLAKIND /////////////////////////////////
	var tclassescuolakind= new MetaTable("classescuolakind");
	tclassescuolakind.defineColumn("idclassescuolakind", typeof(string),false);
	tclassescuolakind.defineColumn("idcorsostudiokind", typeof(int),false);
	tclassescuolakind.defineColumn("idcorsostudiolivello", typeof(int));
	tclassescuolakind.defineColumn("title", typeof(string),false);
	Tables.Add(tclassescuolakind);
	tclassescuolakind.defineKey("idclassescuolakind");

	#endregion


	#region DataRelation creation
	var cPar = new []{corsostudiolivellodefaultview.Columns["idcorsostudiolivello"]};
	var cChild = new []{classescuolakind.Columns["idcorsostudiolivello"]};
	Relations.Add(new DataRelation("FK_classescuolakind_corsostudiolivellodefaultview_idcorsostudiolivello",cPar,cChild,false));

	cPar = new []{corsostudiokinddefaultview.Columns["idcorsostudiokind"]};
	cChild = new []{classescuolakind.Columns["idcorsostudiokind"]};
	Relations.Add(new DataRelation("FK_classescuolakind_corsostudiokinddefaultview_idcorsostudiokind",cPar,cChild,false));

	#endregion

}
}
}
