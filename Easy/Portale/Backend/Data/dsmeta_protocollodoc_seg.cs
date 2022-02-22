
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
[System.Xml.Serialization.XmlRoot("dsmeta_protocollodoc_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_protocollodoc_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodockind 		=> (MetaTable)Tables["protocollodockind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodocelement_alias1 		=> (MetaTable)Tables["protocollodocelement_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodocelement 		=> (MetaTable)Tables["protocollodocelement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollorifkind 		=> (MetaTable)Tables["protocollorifkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable protocollodoc 		=> (MetaTable)Tables["protocollodoc"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_protocollodoc_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_protocollodoc_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_protocollodoc_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_protocollodoc_seg.xsd";

	#region create DataTables
	//////////////////// PROTOCOLLODOCKIND /////////////////////////////////
	var tprotocollodockind= new MetaTable("protocollodockind");
	tprotocollodockind.defineColumn("idprotocollodockind", typeof(int),false);
	tprotocollodockind.defineColumn("title", typeof(string),false);
	Tables.Add(tprotocollodockind);
	tprotocollodockind.defineKey("idprotocollodockind");

	//////////////////// PROTOCOLLODOCELEMENT_ALIAS1 /////////////////////////////////
	var tprotocollodocelement_alias1= new MetaTable("protocollodocelement_alias1");
	tprotocollodocelement_alias1.defineColumn("idprotocollodoc", typeof(int),false);
	tprotocollodocelement_alias1.defineColumn("idprotocollodocelement", typeof(int),false);
	tprotocollodocelement_alias1.defineColumn("protanno", typeof(int),false);
	tprotocollodocelement_alias1.defineColumn("protnumero", typeof(int),false);
	tprotocollodocelement_alias1.ExtendedProperties["TableForReading"]="protocollodocelement";
	Tables.Add(tprotocollodocelement_alias1);
	tprotocollodocelement_alias1.defineKey("idprotocollodoc", "idprotocollodocelement", "protanno", "protnumero");

	//////////////////// PROTOCOLLODOCELEMENT /////////////////////////////////
	var tprotocollodocelement= new MetaTable("protocollodocelement");
	tprotocollodocelement.defineColumn("ct", typeof(DateTime));
	tprotocollodocelement.defineColumn("cu", typeof(string));
	tprotocollodocelement.defineColumn("idprotocollodoc", typeof(int),false);
	tprotocollodocelement.defineColumn("idprotocollodocelement", typeof(int),false);
	tprotocollodocelement.defineColumn("idprotocollodocelement_primo", typeof(int),false);
	tprotocollodocelement.defineColumn("idprotocollodockind", typeof(int),false);
	tprotocollodocelement.defineColumn("lt", typeof(DateTime));
	tprotocollodocelement.defineColumn("lu", typeof(string));
	tprotocollodocelement.defineColumn("oggetto", typeof(string),false);
	tprotocollodocelement.defineColumn("protanno", typeof(int),false);
	tprotocollodocelement.defineColumn("protnumero", typeof(int),false);
	tprotocollodocelement.defineColumn("telematicocolloc", typeof(string));
	tprotocollodocelement.defineColumn("telematicohash", typeof(Byte[]));
	tprotocollodocelement.defineColumn("!idprotocollodocelement_primo_protocollodocelement_protnumero", typeof(int));
	tprotocollodocelement.defineColumn("!idprotocollodocelement_primo_protocollodocelement_protanno", typeof(int));
	tprotocollodocelement.defineColumn("!idprotocollodockind_protocollodockind_title", typeof(string));
	Tables.Add(tprotocollodocelement);
	tprotocollodocelement.defineKey("idprotocollodoc", "idprotocollodocelement", "protanno", "protnumero");

	//////////////////// PROTOCOLLORIFKIND /////////////////////////////////
	var tprotocollorifkind= new MetaTable("protocollorifkind");
	tprotocollorifkind.defineColumn("idprotocollorifkind", typeof(int),false);
	tprotocollorifkind.defineColumn("title", typeof(string),false);
	Tables.Add(tprotocollorifkind);
	tprotocollorifkind.defineKey("idprotocollorifkind");

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

	//////////////////// PROTOCOLLODOC /////////////////////////////////
	var tprotocollodoc= new MetaTable("protocollodoc");
	tprotocollodoc.defineColumn("ct", typeof(DateTime));
	tprotocollodoc.defineColumn("cu", typeof(string));
	tprotocollodoc.defineColumn("filename", typeof(string));
	tprotocollodoc.defineColumn("idattach", typeof(int));
	tprotocollodoc.defineColumn("idmimetype", typeof(int));
	tprotocollodoc.defineColumn("idprotocollodoc", typeof(int),false);
	tprotocollodoc.defineColumn("idprotocollorifkind", typeof(int),false);
	tprotocollodoc.defineColumn("lt", typeof(DateTime));
	tprotocollodoc.defineColumn("lu", typeof(string));
	tprotocollodoc.defineColumn("protanno", typeof(int),false);
	tprotocollodoc.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tprotocollodoc);
	tprotocollodoc.defineKey("idprotocollodoc", "protanno", "protnumero");

	#endregion


	#region DataRelation creation
	var cPar = new []{protocollodoc.Columns["idprotocollodoc"], protocollodoc.Columns["protanno"], protocollodoc.Columns["protnumero"]};
	var cChild = new []{protocollodocelement.Columns["idprotocollodoc"], protocollodocelement.Columns["protanno"], protocollodocelement.Columns["protnumero"]};
	Relations.Add(new DataRelation("FK_protocollodocelement_protocollodoc_idprotocollodoc-protanno-protnumero",cPar,cChild,false));

	cPar = new []{protocollodockind.Columns["idprotocollodockind"]};
	cChild = new []{protocollodocelement.Columns["idprotocollodockind"]};
	Relations.Add(new DataRelation("FK_protocollodocelement_protocollodockind_idprotocollodockind",cPar,cChild,false));

	cPar = new []{protocollodocelement_alias1.Columns["idprotocollodocelement"]};
	cChild = new []{protocollodocelement.Columns["idprotocollodocelement_primo"]};
	Relations.Add(new DataRelation("FK_protocollodocelement_protocollodocelement_alias1_idprotocollodocelement_primo",cPar,cChild,false));

	cPar = new []{protocollorifkind.Columns["idprotocollorifkind"]};
	cChild = new []{protocollodoc.Columns["idprotocollorifkind"]};
	Relations.Add(new DataRelation("FK_protocollodoc_protocollorifkind_idprotocollorifkind",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{protocollodoc.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_protocollodoc_attach_idattach",cPar,cChild,false));

	#endregion

}
}
}
