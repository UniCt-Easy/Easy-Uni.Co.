
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
[System.Xml.Serialization.XmlRoot("dsmeta_cbflussiview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_cbflussiview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokind 		=> (MetaTable)Tables["pagamentokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbflussiviewdettaglio 		=> (MetaTable)Tables["cbflussiviewdettaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbflussiview 		=> (MetaTable)Tables["cbflussiview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cbflussiview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cbflussiview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cbflussiview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cbflussiview_default.xsd";

	#region create DataTables
	//////////////////// PAGAMENTOKIND /////////////////////////////////
	var tpagamentokind= new MetaTable("pagamentokind");
	tpagamentokind.defineColumn("active", typeof(string),false);
	tpagamentokind.defineColumn("idpagamentokind", typeof(int),false);
	tpagamentokind.defineColumn("title", typeof(string),false);
	Tables.Add(tpagamentokind);
	tpagamentokind.defineKey("idpagamentokind");

	//////////////////// CBFLUSSIVIEWDETTAGLIO /////////////////////////////////
	var tcbflussiviewdettaglio= new MetaTable("cbflussiviewdettaglio");
	tcbflussiviewdettaglio.defineColumn("!credkind", typeof(string));
	tcbflussiviewdettaglio.defineColumn("!monthscadenza", typeof(int));
	tcbflussiviewdettaglio.defineColumn("!yearscadenza", typeof(int));
	tcbflussiviewdettaglio.defineColumn("cbflussiviewbasekind", typeof(string),false);
	tcbflussiviewdettaglio.defineColumn("cliente", typeof(string));
	tcbflussiviewdettaglio.defineColumn("dareavere", typeof(string));
	tcbflussiviewdettaglio.defineColumn("idcbflussiview", typeof(int),false);
	tcbflussiviewdettaglio.defineColumn("idcbflussiviewdettaglio", typeof(int),false);
	tcbflussiviewdettaglio.defineColumn("idcbmese", typeof(int),false);
	tcbflussiviewdettaglio.defineColumn("idpagamentokind", typeof(int));
	tcbflussiviewdettaglio.defineColumn("importo", typeof(decimal));
	tcbflussiviewdettaglio.defineColumn("inizio", typeof(string));
	tcbflussiviewdettaglio.defineColumn("note", typeof(string));
	tcbflussiviewdettaglio.defineColumn("scadenza", typeof(DateTime));
	tcbflussiviewdettaglio.defineColumn("!idpagamentokind_pagamentokind_title", typeof(string));
	Tables.Add(tcbflussiviewdettaglio);
	tcbflussiviewdettaglio.defineKey("idcbflussiview", "idcbflussiviewdettaglio", "idcbmese");

	//////////////////// CBFLUSSIVIEW /////////////////////////////////
	var tcbflussiview= new MetaTable("cbflussiview");
	tcbflussiview.defineColumn("disponibilita", typeof(decimal));
	tcbflussiview.defineColumn("disponibilitainiziale", typeof(decimal));
	tcbflussiview.defineColumn("entrate", typeof(decimal));
	tcbflussiview.defineColumn("flusso", typeof(decimal));
	tcbflussiview.defineColumn("idcbflussiview", typeof(int),false);
	tcbflussiview.defineColumn("idcbmese", typeof(int),false);
	tcbflussiview.defineColumn("scadenza", typeof(DateTime));
	tcbflussiview.defineColumn("uscite", typeof(decimal));
	Tables.Add(tcbflussiview);
	tcbflussiview.defineKey("idcbflussiview", "idcbmese");

	#endregion


	#region DataRelation creation
	var cPar = new []{cbflussiview.Columns["idcbflussiview"], cbflussiview.Columns["idcbmese"]};
	var cChild = new []{cbflussiviewdettaglio.Columns["idcbflussiview"], cbflussiviewdettaglio.Columns["idcbmese"]};
	Relations.Add(new DataRelation("FK_cbflussiviewdettaglio_cbflussiview_idcbflussiview-idcbmese",cPar,cChild,false));

	cPar = new []{pagamentokind.Columns["idpagamentokind"]};
	cChild = new []{cbflussiviewdettaglio.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_cbflussiviewdettaglio_pagamentokind_idpagamentokind",cPar,cChild,false));

	#endregion

}
}
}
