
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_assicurazione_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_assicurazione_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable assicurazione 		=> (MetaTable)Tables["assicurazione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_assicurazione_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_assicurazione_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_assicurazione_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_assicurazione_default.xsd";

	#region create DataTables
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

	//////////////////// ASSICURAZIONE /////////////////////////////////
	var tassicurazione= new MetaTable("assicurazione");
	tassicurazione.defineColumn("ct", typeof(DateTime),false);
	tassicurazione.defineColumn("cu", typeof(string),false);
	tassicurazione.defineColumn("datarilascio", typeof(DateTime));
	tassicurazione.defineColumn("datascadenza", typeof(DateTime));
	tassicurazione.defineColumn("idassicurazione", typeof(int),false);
	tassicurazione.defineColumn("idattach", typeof(int));
	tassicurazione.defineColumn("infortunisullavoro", typeof(string));
	tassicurazione.defineColumn("lt", typeof(DateTime),false);
	tassicurazione.defineColumn("lu", typeof(string),false);
	tassicurazione.defineColumn("numeropolizza", typeof(string));
	tassicurazione.defineColumn("rca", typeof(string));
	tassicurazione.defineColumn("societaassicura", typeof(string));
	tassicurazione.defineColumn("spostamenti", typeof(string));
	tassicurazione.defineColumn("viaggi", typeof(string));
	Tables.Add(tassicurazione);
	tassicurazione.defineKey("idassicurazione");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach.Columns["idattach"]};
	var cChild = new []{assicurazione.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_assicurazione_attach_idattach",cPar,cChild,false));

	#endregion

}
}
}