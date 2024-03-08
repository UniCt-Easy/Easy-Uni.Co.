
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
[System.Xml.Serialization.XmlRoot("dsmeta_cbscadenziariofornitori_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_cbscadenziariofornitori_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbconf 		=> (MetaTable)Tables["cbconf"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokinddefaultview 		=> (MetaTable)Tables["pagamentokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbscadenziariofornitori 		=> (MetaTable)Tables["cbscadenziariofornitori"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cbscadenziariofornitori_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cbscadenziariofornitori_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cbscadenziariofornitori_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cbscadenziariofornitori_default.xsd";

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
	tpagamentokinddefaultview.defineColumn("pagamentokind_active", typeof(string));
	Tables.Add(tpagamentokinddefaultview);
	tpagamentokinddefaultview.defineKey("idpagamentokind");

	//////////////////// CBSCADENZIARIOFORNITORI /////////////////////////////////
	var tcbscadenziariofornitori= new MetaTable("cbscadenziariofornitori");
	tcbscadenziariofornitori.defineColumn("!credkind", typeof(string));
	tcbscadenziariofornitori.defineColumn("!importoflussi", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("!monthscadenza", typeof(int));
	tcbscadenziariofornitori.defineColumn("!scadenzaflussi", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("!yeardoc", typeof(int));
	tcbscadenziariofornitori.defineColumn("!yearscadenza", typeof(int));
	tcbscadenziariofornitori.defineColumn("anomaliaimport", typeof(string));
	tcbscadenziariofornitori.defineColumn("cliente", typeof(string));
	tcbscadenziariofornitori.defineColumn("codiceconto", typeof(string));
	tcbscadenziariofornitori.defineColumn("dareavere", typeof(string));
	tcbscadenziariofornitori.defineColumn("datadocumeto", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("dataparte", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("dataprevistaincasso", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("idcbmese", typeof(int),false);
	tcbscadenziariofornitori.defineColumn("idcbscadenziariofornitori", typeof(int),false);
	tcbscadenziariofornitori.defineColumn("idpagamentokind", typeof(int));
	tcbscadenziariofornitori.defineColumn("importo", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("importodaincassare", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("importooriginale", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("note", typeof(string));
	tcbscadenziariofornitori.defineColumn("nprotocollo", typeof(string));
	tcbscadenziariofornitori.defineColumn("numerodocumento", typeof(string));
	tcbscadenziariofornitori.defineColumn("numeroparte", typeof(string));
	tcbscadenziariofornitori.defineColumn("numeroregistrazione", typeof(decimal));
	tcbscadenziariofornitori.defineColumn("scadenza", typeof(DateTime));
	tcbscadenziariofornitori.defineColumn("scadenzaoriginale", typeof(DateTime));
	Tables.Add(tcbscadenziariofornitori);
	tcbscadenziariofornitori.defineKey("idcbmese", "idcbscadenziariofornitori");

	#endregion


	#region DataRelation creation
	var cPar = new []{pagamentokinddefaultview.Columns["idpagamentokind"]};
	var cChild = new []{cbscadenziariofornitori.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_cbscadenziariofornitori_pagamentokinddefaultview_idpagamentokind",cPar,cChild,false));

	#endregion

}
}
}
