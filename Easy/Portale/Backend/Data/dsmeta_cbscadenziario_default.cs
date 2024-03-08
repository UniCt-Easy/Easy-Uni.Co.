
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
[System.Xml.Serialization.XmlRoot("dsmeta_cbscadenziario_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_cbscadenziario_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbconf 		=> (MetaTable)Tables["cbconf"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokinddefaultview 		=> (MetaTable)Tables["pagamentokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbscadenziario 		=> (MetaTable)Tables["cbscadenziario"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cbscadenziario_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cbscadenziario_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cbscadenziario_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cbscadenziario_default.xsd";

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

	//////////////////// CBSCADENZIARIO /////////////////////////////////
	var tcbscadenziario= new MetaTable("cbscadenziario");
	tcbscadenziario.defineColumn("!credkind", typeof(string));
	tcbscadenziario.defineColumn("!importoflussi", typeof(decimal));
	tcbscadenziario.defineColumn("!monthscadenza", typeof(int));
	tcbscadenziario.defineColumn("!scadenzaflussi", typeof(DateTime));
	tcbscadenziario.defineColumn("!yeardoc", typeof(int));
	tcbscadenziario.defineColumn("!yearscadenza", typeof(int));
	tcbscadenziario.defineColumn("cliente", typeof(string));
	tcbscadenziario.defineColumn("codiceconto", typeof(string));
	tcbscadenziario.defineColumn("dareavere", typeof(string));
	tcbscadenziario.defineColumn("datadocumeto", typeof(DateTime));
	tcbscadenziario.defineColumn("dataparte", typeof(DateTime));
	tcbscadenziario.defineColumn("dataprevistaincasso", typeof(DateTime));
	tcbscadenziario.defineColumn("idcbmese", typeof(int),false);
	tcbscadenziario.defineColumn("idcbscadenziario", typeof(int),false);
	tcbscadenziario.defineColumn("idpagamentokind", typeof(int));
	tcbscadenziario.defineColumn("importo", typeof(decimal));
	tcbscadenziario.defineColumn("importodaincassare", typeof(decimal));
	tcbscadenziario.defineColumn("importooriginale", typeof(decimal));
	tcbscadenziario.defineColumn("note", typeof(string));
	tcbscadenziario.defineColumn("nprotocollo", typeof(string));
	tcbscadenziario.defineColumn("numerodocumento", typeof(string));
	tcbscadenziario.defineColumn("numeroparte", typeof(string));
	tcbscadenziario.defineColumn("scadenza", typeof(DateTime));
	tcbscadenziario.defineColumn("scadenzaoriginale", typeof(DateTime));
	Tables.Add(tcbscadenziario);
	tcbscadenziario.defineKey("idcbmese", "idcbscadenziario");

	#endregion


	#region DataRelation creation
	var cPar = new []{pagamentokinddefaultview.Columns["idpagamentokind"]};
	var cChild = new []{cbscadenziario.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_cbscadenziario_pagamentokinddefaultview_idpagamentokind",cPar,cChild,false));

	#endregion

}
}
}
