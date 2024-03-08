
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
[System.Xml.Serialization.XmlRoot("dsmeta_cbflussiviewdettaglio_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_cbflussiviewdettaglio_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbconf 		=> (MetaTable)Tables["cbconf"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokinddefaultview 		=> (MetaTable)Tables["pagamentokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbflussiviewdettaglio 		=> (MetaTable)Tables["cbflussiviewdettaglio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cbflussiviewdettaglio_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cbflussiviewdettaglio_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cbflussiviewdettaglio_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cbflussiviewdettaglio_default.xsd";

	#region create DataTables
	//////////////////// CBCONF /////////////////////////////////
	var tcbconf= new MetaTable("cbconf");
	tcbconf.defineColumn("giorno", typeof(int));
	tcbconf.defineColumn("idcbconf", typeof(int),false);
	Tables.Add(tcbconf);
	tcbconf.defineKey("idcbconf");

	//////////////////// PAGAMENTOKINDDEFAULTVIEW /////////////////////////////////
	var tpagamentokinddefaultview= new MetaTable("pagamentokinddefaultview");
	tpagamentokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpagamentokinddefaultview.defineColumn("idpagamentokind", typeof(int),false);
	Tables.Add(tpagamentokinddefaultview);
	tpagamentokinddefaultview.defineKey("idpagamentokind");

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
	Tables.Add(tcbflussiviewdettaglio);
	tcbflussiviewdettaglio.defineKey("idcbflussiview", "idcbflussiviewdettaglio", "idcbmese");

	#endregion


	#region DataRelation creation
	var cPar = new []{pagamentokinddefaultview.Columns["idpagamentokind"]};
	var cChild = new []{cbflussiviewdettaglio.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_cbflussiviewdettaglio_pagamentokinddefaultview_idpagamentokind",cPar,cChild,false));

	#endregion

}
}
}
