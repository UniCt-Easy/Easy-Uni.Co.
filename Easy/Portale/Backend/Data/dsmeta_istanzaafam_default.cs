
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanzaafam_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_istanzaafam_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzaafamattach 		=> (MetaTable)Tables["istanzaafamattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziriepilogoview 		=> (MetaTable)Tables["serviziriepilogoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatus 		=> (MetaTable)Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzaafamkind 		=> (MetaTable)Tables["istanzaafamkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzaafam 		=> (MetaTable)Tables["istanzaafam"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanzaafam_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanzaafam_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanzaafam_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanzaafam_default.xsd";

	#region create DataTables
	//////////////////// ISTANZAAFAMATTACH /////////////////////////////////
	var tistanzaafamattach= new MetaTable("istanzaafamattach");
	tistanzaafamattach.defineColumn("ct", typeof(DateTime),false);
	tistanzaafamattach.defineColumn("cu", typeof(string),false);
	tistanzaafamattach.defineColumn("idattach", typeof(int),false);
	tistanzaafamattach.defineColumn("idistanzaafam", typeof(int),false);
	tistanzaafamattach.defineColumn("idreg", typeof(int),false);
	tistanzaafamattach.defineColumn("lt", typeof(DateTime),false);
	tistanzaafamattach.defineColumn("lu", typeof(string),false);
	tistanzaafamattach.defineColumn("title", typeof(string));
	tistanzaafamattach.defineColumn("!idattach_attach_filename", typeof(string));
	tistanzaafamattach.defineColumn("!idattach_attach_size", typeof(int));
	Tables.Add(tistanzaafamattach);
	tistanzaafamattach.defineKey("idattach", "idistanzaafam", "idreg");

	//////////////////// SERVIZIRIEPILOGOVIEW /////////////////////////////////
	var tserviziriepilogoview= new MetaTable("serviziriepilogoview");
	tserviziriepilogoview.defineColumn("anni", typeof(int));
	tserviziriepilogoview.defineColumn("cedolini", typeof(string));
	tserviziriepilogoview.defineColumn("ct", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("cu", typeof(string),false);
	tserviziriepilogoview.defineColumn("giorni", typeof(int));
	tserviziriepilogoview.defineColumn("idreg", typeof(int),false);
	tserviziriepilogoview.defineColumn("idserviziriepilogoview", typeof(string),false);
	tserviziriepilogoview.defineColumn("istituzione", typeof(string));
	tserviziriepilogoview.defineColumn("lt", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("lu", typeof(string),false);
	tserviziriepilogoview.defineColumn("mesi", typeof(int));
	tserviziriepilogoview.defineColumn("start", typeof(DateTime));
	tserviziriepilogoview.defineColumn("stop", typeof(DateTime));
	tserviziriepilogoview.defineColumn("tipologia", typeof(string),false);
	tserviziriepilogoview.defineColumn("totaldays", typeof(int));
	Tables.Add(tserviziriepilogoview);
	tserviziriepilogoview.defineKey("idreg", "idserviziriepilogoview");

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

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new MetaTable("registrylegalstatus");
	tregistrylegalstatus.defineColumn("active", typeof(string));
	tregistrylegalstatus.defineColumn("anni", typeof(int));
	tregistrylegalstatus.defineColumn("annokind", typeof(string));
	tregistrylegalstatus.defineColumn("cedolini", typeof(string));
	tregistrylegalstatus.defineColumn("csa_class", typeof(string));
	tregistrylegalstatus.defineColumn("csa_compartment", typeof(string));
	tregistrylegalstatus.defineColumn("csa_role", typeof(string));
	tregistrylegalstatus.defineColumn("ct", typeof(DateTime));
	tregistrylegalstatus.defineColumn("cu", typeof(string));
	tregistrylegalstatus.defineColumn("datarivalutazione", typeof(DateTime));
	tregistrylegalstatus.defineColumn("flagdefault", typeof(string));
	tregistrylegalstatus.defineColumn("giorni", typeof(int));
	tregistrylegalstatus.defineColumn("idclassconsorsuale", typeof(int));
	tregistrylegalstatus.defineColumn("iddaliaposition", typeof(int));
	tregistrylegalstatus.defineColumn("idinquadramento", typeof(int));
	tregistrylegalstatus.defineColumn("idposition", typeof(int));
	tregistrylegalstatus.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatus.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatus.defineColumn("idtipologiaruolo", typeof(int));
	tregistrylegalstatus.defineColumn("idtiponomina", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclass", typeof(int));
	tregistrylegalstatus.defineColumn("incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatus.defineColumn("istituzione", typeof(string));
	tregistrylegalstatus.defineColumn("livello", typeof(int));
	tregistrylegalstatus.defineColumn("lt", typeof(DateTime));
	tregistrylegalstatus.defineColumn("lu", typeof(string));
	tregistrylegalstatus.defineColumn("mesi", typeof(int));
	tregistrylegalstatus.defineColumn("parttime", typeof(decimal));
	tregistrylegalstatus.defineColumn("percentualesufondiateneo", typeof(decimal));
	tregistrylegalstatus.defineColumn("rtf", typeof(Byte[]));
	tregistrylegalstatus.defineColumn("start", typeof(DateTime));
	tregistrylegalstatus.defineColumn("stop", typeof(DateTime));
	tregistrylegalstatus.defineColumn("tempdef", typeof(string));
	tregistrylegalstatus.defineColumn("tempindet", typeof(string));
	tregistrylegalstatus.defineColumn("txt", typeof(string));
	tregistrylegalstatus.defineColumn("!idposition_position_title", typeof(string));
	tregistrylegalstatus.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// ISTANZAAFAMKIND /////////////////////////////////
	var tistanzaafamkind= new MetaTable("istanzaafamkind");
	tistanzaafamkind.defineColumn("idistanzaafamkind", typeof(int),false);
	tistanzaafamkind.defineColumn("title", typeof(string));
	Tables.Add(tistanzaafamkind);
	tistanzaafamkind.defineKey("idistanzaafamkind");

	//////////////////// ISTANZAAFAM /////////////////////////////////
	var tistanzaafam= new MetaTable("istanzaafam");
	tistanzaafam.defineColumn("ct", typeof(DateTime),false);
	tistanzaafam.defineColumn("cu", typeof(string),false);
	tistanzaafam.defineColumn("data", typeof(DateTime));
	tistanzaafam.defineColumn("idattach", typeof(int));
	tistanzaafam.defineColumn("idistanzaafam", typeof(int),false);
	tistanzaafam.defineColumn("idistanzaafamkind", typeof(int));
	tistanzaafam.defineColumn("idreg", typeof(int),false);
	tistanzaafam.defineColumn("lt", typeof(DateTime),false);
	tistanzaafam.defineColumn("lu", typeof(string),false);
	tistanzaafam.defineColumn("note", typeof(string));
	tistanzaafam.defineColumn("noteistituto", typeof(string));
	tistanzaafam.defineColumn("protanno", typeof(int));
	tistanzaafam.defineColumn("protnumero", typeof(int));
	Tables.Add(tistanzaafam);
	tistanzaafam.defineKey("idistanzaafam", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanzaafam.Columns["idistanzaafam"], istanzaafam.Columns["idreg"]};
	var cChild = new []{istanzaafamattach.Columns["idistanzaafam"], istanzaafamattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanzaafamattach_istanzaafam_idistanzaafam-idreg",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{istanzaafamattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_istanzaafamattach_attach_idattach",cPar,cChild,false));

	cPar = new []{serviziriepilogoview.Columns["idreg"]};
	cChild = new []{istanzaafam.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanzaafam_serviziriepilogoview_idreg",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{istanzaafam.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_istanzaafam_attach_idattach",cPar,cChild,false));

	cPar = new []{istanzaafam.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_istanzaafam_idreg",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_registrylegalstatus_position_idposition",cPar,cChild,false));

	cPar = new []{istanzaafamkind.Columns["idistanzaafamkind"]};
	cChild = new []{istanzaafam.Columns["idistanzaafamkind"]};
	Relations.Add(new DataRelation("FK_istanzaafam_istanzaafamkind_idistanzaafamkind",cPar,cChild,false));

	#endregion

}
}
}
