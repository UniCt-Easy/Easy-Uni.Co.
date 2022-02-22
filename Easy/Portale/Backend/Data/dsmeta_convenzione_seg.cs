
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
[System.Xml.Serialization.XmlRoot("dsmeta_convenzione_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_convenzione_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convenzioneattach 		=> (MetaTable)Tables["convenzioneattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convenzione 		=> (MetaTable)Tables["convenzione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convenzione_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convenzione_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convenzione_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convenzione_seg.xsd";

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

	//////////////////// CONVENZIONEATTACH /////////////////////////////////
	var tconvenzioneattach= new MetaTable("convenzioneattach");
	tconvenzioneattach.defineColumn("ct", typeof(DateTime),false);
	tconvenzioneattach.defineColumn("cu", typeof(string),false);
	tconvenzioneattach.defineColumn("idattach", typeof(int),false);
	tconvenzioneattach.defineColumn("idconvenzione", typeof(int),false);
	tconvenzioneattach.defineColumn("idreg", typeof(int),false);
	tconvenzioneattach.defineColumn("lt", typeof(DateTime),false);
	tconvenzioneattach.defineColumn("lu", typeof(string),false);
	tconvenzioneattach.defineColumn("!idattach_attach_filename", typeof(string));
	tconvenzioneattach.defineColumn("!idattach_attach_size", typeof(int));
	Tables.Add(tconvenzioneattach);
	tconvenzioneattach.defineKey("idattach", "idconvenzione", "idreg");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcity", typeof(int));
	tregistrydefaultview.defineColumn("idnation", typeof(int));
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
	tregistrydefaultview.defineColumn("idtitle", typeof(string));
	tregistrydefaultview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// CONVENZIONE /////////////////////////////////
	var tconvenzione= new MetaTable("convenzione");
	tconvenzione.defineColumn("ct", typeof(DateTime),false);
	tconvenzione.defineColumn("cu", typeof(string),false);
	tconvenzione.defineColumn("idconvenzione", typeof(int),false);
	tconvenzione.defineColumn("idreg", typeof(int),false);
	tconvenzione.defineColumn("lt", typeof(DateTime),false);
	tconvenzione.defineColumn("lu", typeof(string),false);
	tconvenzione.defineColumn("start", typeof(DateTime));
	tconvenzione.defineColumn("stop", typeof(DateTime));
	tconvenzione.defineColumn("title", typeof(string));
	tconvenzione.defineColumn("url", typeof(string));
	Tables.Add(tconvenzione);
	tconvenzione.defineKey("idconvenzione", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{convenzione.Columns["idconvenzione"], convenzione.Columns["idreg"]};
	var cChild = new []{convenzioneattach.Columns["idconvenzione"], convenzioneattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convenzioneattach_convenzione_idconvenzione-idreg",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{convenzioneattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_convenzioneattach_attach_idattach",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{convenzione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convenzione_registrydefaultview_idreg",cPar,cChild,false));

	#endregion

}
}
}
