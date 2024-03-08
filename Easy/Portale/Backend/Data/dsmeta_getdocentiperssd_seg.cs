
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
[System.Xml.Serialization.XmlRoot("dsmeta_getdocentiperssd_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_getdocentiperssd_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiperssd 		=> (MetaTable)Tables["getdocentiperssd"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_getdocentiperssd_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_getdocentiperssd_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_getdocentiperssd_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_getdocentiperssd_seg.xsd";

	#region create DataTables
	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idareadidattica", typeof(int));
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// GETDOCENTIPERSSD /////////////////////////////////
	var tgetdocentiperssd= new MetaTable("getdocentiperssd");
	tgetdocentiperssd.defineColumn("aa", typeof(string),false);
	tgetdocentiperssd.defineColumn("cognome", typeof(string));
	tgetdocentiperssd.defineColumn("contratto", typeof(string),false);
	tgetdocentiperssd.defineColumn("costoorario", typeof(decimal));
	tgetdocentiperssd.defineColumn("idreg", typeof(int),false);
	tgetdocentiperssd.defineColumn("idsasd", typeof(int),false);
	tgetdocentiperssd.defineColumn("iniziocontratto", typeof(DateTime),false);
	tgetdocentiperssd.defineColumn("matricola", typeof(string));
	tgetdocentiperssd.defineColumn("nome", typeof(string));
	tgetdocentiperssd.defineColumn("oremaxdida", typeof(int));
	tgetdocentiperssd.defineColumn("oremindida", typeof(int));
	tgetdocentiperssd.defineColumn("oreperaaaffidamento", typeof(int));
	tgetdocentiperssd.defineColumn("oreperaacontratto", typeof(int));
	tgetdocentiperssd.defineColumn("parttime", typeof(decimal));
	tgetdocentiperssd.defineColumn("ssd", typeof(string),false);
	tgetdocentiperssd.defineColumn("struttura", typeof(string));
	tgetdocentiperssd.defineColumn("tempodefinito", typeof(string),false);
	tgetdocentiperssd.defineColumn("terminecontratto", typeof(DateTime),false);
	Tables.Add(tgetdocentiperssd);
	tgetdocentiperssd.defineKey("aa", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{sasddefaultview.Columns["idsasd"]};
	var cChild = new []{getdocentiperssd.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_getdocentiperssd_sasddefaultview_idsasd",cPar,cChild,false));

	#endregion

}
}
}
