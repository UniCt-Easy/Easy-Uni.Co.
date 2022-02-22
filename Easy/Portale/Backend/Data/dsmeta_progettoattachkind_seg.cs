
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoattachkind_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoattachkind_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettostatuskind 		=> (MetaTable)Tables["progettostatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoattachkindprogettostatuskind 		=> (MetaTable)Tables["progettoattachkindprogettostatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoattachkind 		=> (MetaTable)Tables["progettoattachkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoattachkind_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoattachkind_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoattachkind_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoattachkind_seg.xsd";

	#region create DataTables
	//////////////////// PROGETTOSTATUSKIND /////////////////////////////////
	var tprogettostatuskind= new MetaTable("progettostatuskind");
	tprogettostatuskind.defineColumn("ct", typeof(DateTime),false);
	tprogettostatuskind.defineColumn("cu", typeof(string),false);
	tprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettostatuskind.defineColumn("lt", typeof(DateTime),false);
	tprogettostatuskind.defineColumn("lu", typeof(string),false);
	tprogettostatuskind.defineColumn("sortcode", typeof(int),false);
	tprogettostatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tprogettostatuskind);
	tprogettostatuskind.defineKey("idprogettostatuskind");

	//////////////////// PROGETTOATTACHKINDPROGETTOSTATUSKIND /////////////////////////////////
	var tprogettoattachkindprogettostatuskind= new MetaTable("progettoattachkindprogettostatuskind");
	tprogettoattachkindprogettostatuskind.defineColumn("ct", typeof(DateTime));
	tprogettoattachkindprogettostatuskind.defineColumn("cu", typeof(string));
	tprogettoattachkindprogettostatuskind.defineColumn("idprogettoattachkind", typeof(int),false);
	tprogettoattachkindprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettoattachkindprogettostatuskind.defineColumn("lt", typeof(DateTime));
	tprogettoattachkindprogettostatuskind.defineColumn("lu", typeof(string));
	Tables.Add(tprogettoattachkindprogettostatuskind);
	tprogettoattachkindprogettostatuskind.defineKey("idprogettoattachkind", "idprogettostatuskind");

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

	//////////////////// PROGETTOATTACHKIND /////////////////////////////////
	var tprogettoattachkind= new MetaTable("progettoattachkind");
	tprogettoattachkind.defineColumn("ct", typeof(DateTime),false);
	tprogettoattachkind.defineColumn("cu", typeof(string),false);
	tprogettoattachkind.defineColumn("idattach_template", typeof(int));
	tprogettoattachkind.defineColumn("idprogettoattachkind", typeof(int),false);
	tprogettoattachkind.defineColumn("idprogettokind", typeof(int),false);
	tprogettoattachkind.defineColumn("linktemplate", typeof(string));
	tprogettoattachkind.defineColumn("lt", typeof(DateTime),false);
	tprogettoattachkind.defineColumn("lu", typeof(string),false);
	tprogettoattachkind.defineColumn("title", typeof(string));
	Tables.Add(tprogettoattachkind);
	tprogettoattachkind.defineKey("idprogettoattachkind", "idprogettokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettoattachkind.Columns["idprogettoattachkind"]};
	var cChild = new []{progettoattachkindprogettostatuskind.Columns["idprogettoattachkind"]};
	Relations.Add(new DataRelation("FK_progettoattachkindprogettostatuskind_progettoattachkind_idprogettoattachkind-",cPar,cChild,false));

	cPar = new []{progettostatuskind.Columns["idprogettostatuskind"]};
	cChild = new []{progettoattachkindprogettostatuskind.Columns["idprogettostatuskind"]};
	Relations.Add(new DataRelation("FK_progettoattachkindprogettostatuskind_progettostatuskind_idprogettostatuskind",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{progettoattachkind.Columns["idattach_template"]};
	Relations.Add(new DataRelation("FK_progettoattachkind_attach_idattach_template",cPar,cChild,false));

	#endregion

}
}
}
