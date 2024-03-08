
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
[System.Xml.Serialization.XmlRoot("dsmeta_registrydurc_anagraficadetail"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registrydurc_anagraficadetail : DataSet {

	#region Table members declaration
	///<summary>
	///DURC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydurc 		=> (MetaTable)Tables["registrydurc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach_self 		=> (MetaTable)Tables["attach_self"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach_durc 		=> (MetaTable)Tables["attach_durc"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registrydurc_anagraficadetail(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registrydurc_anagraficadetail(SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registrydurc_anagraficadetail";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registrydurc_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYDURC /////////////////////////////////
	var tregistrydurc= new MetaTable("registrydurc");
	tregistrydurc.defineColumn("idregistrydurc", typeof(int),false);
	tregistrydurc.defineColumn("idreg", typeof(int),false);
	tregistrydurc.defineColumn("iddurckind", typeof(short));
	tregistrydurc.defineColumn("start", typeof(DateTime));
	tregistrydurc.defineColumn("stop", typeof(DateTime));
	tregistrydurc.defineColumn("adate", typeof(DateTime));
	tregistrydurc.defineColumn("selfcertification", typeof(Byte[]));
	tregistrydurc.defineColumn("durccertification", typeof(Byte[]));
	tregistrydurc.defineColumn("doc", typeof(string));
	tregistrydurc.defineColumn("docdate", typeof(DateTime));
	tregistrydurc.defineColumn("inpscode", typeof(string));
	tregistrydurc.defineColumn("inailcode", typeof(string));
	tregistrydurc.defineColumn("buildingcode", typeof(string));
	tregistrydurc.defineColumn("otherinsurancecode", typeof(string));
	tregistrydurc.defineColumn("ct", typeof(DateTime),false);
	tregistrydurc.defineColumn("cu", typeof(string),false);
	tregistrydurc.defineColumn("lt", typeof(DateTime),false);
	tregistrydurc.defineColumn("lu", typeof(string),false);
	tregistrydurc.defineColumn("txt", typeof(string));
	tregistrydurc.defineColumn("rtf", typeof(Byte[]));
	tregistrydurc.defineColumn("flagirregular", typeof(string));
	tregistrydurc.defineColumn("!durccertification", typeof(int));
	tregistrydurc.defineColumn("!selfcertification", typeof(int));
	Tables.Add(tregistrydurc);
	tregistrydurc.defineKey("idregistrydurc", "idreg");

	//////////////////// ATTACH_SELF /////////////////////////////////
	var tattach_self= new MetaTable("attach_self");
	tattach_self.defineColumn("attachment", typeof(string),false);
	tattach_self.defineColumn("ct", typeof(DateTime),false);
	tattach_self.defineColumn("cu", typeof(string),false);
	tattach_self.defineColumn("filename", typeof(string),false);
	tattach_self.defineColumn("hash", typeof(string),false);
	tattach_self.defineColumn("idattach", typeof(int),false);
	tattach_self.defineColumn("lt", typeof(DateTime),false);
	tattach_self.defineColumn("lu", typeof(string),false);
	tattach_self.defineColumn("size", typeof(int),false);
	Tables.Add(tattach_self);
	tattach_self.defineKey("idattach");

	//////////////////// ATTACH_DURC /////////////////////////////////
	var tattach_durc= new MetaTable("attach_durc");
	tattach_durc.defineColumn("attachment", typeof(string),false);
	tattach_durc.defineColumn("ct", typeof(DateTime),false);
	tattach_durc.defineColumn("cu", typeof(string),false);
	tattach_durc.defineColumn("filename", typeof(string),false);
	tattach_durc.defineColumn("hash", typeof(string),false);
	tattach_durc.defineColumn("idattach", typeof(int),false);
	tattach_durc.defineColumn("lt", typeof(DateTime),false);
	tattach_durc.defineColumn("lu", typeof(string),false);
	tattach_durc.defineColumn("size", typeof(int),false);
	Tables.Add(tattach_durc);
	tattach_durc.defineKey("idattach");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach_durc.Columns["idattach"]};
	var cChild = new []{registrydurc.Columns["!durccertification"]};
	Relations.Add(new DataRelation("attach_durc_registrydurc",cPar,cChild,false));

	cPar = new []{attach_self.Columns["idattach"]};
	cChild = new []{registrydurc.Columns["!selfcertification"]};
	Relations.Add(new DataRelation("attach_self_registrydurc",cPar,cChild,false));

	#endregion

}
}
}
