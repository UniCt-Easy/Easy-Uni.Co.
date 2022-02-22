
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
[System.Xml.Serialization.XmlRoot("dsmeta_scadenziarioclienti_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_scadenziarioclienti_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cbconf 		=> (MetaTable)Tables["cbconf"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokinddefaultview 		=> (MetaTable)Tables["pagamentokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable scadenziarioclienti 		=> (MetaTable)Tables["scadenziarioclienti"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_scadenziarioclienti_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_scadenziarioclienti_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_scadenziarioclienti_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_scadenziarioclienti_default.xsd";

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

	//////////////////// SCADENZIARIOCLIENTI /////////////////////////////////
	var tscadenziarioclienti= new MetaTable("scadenziarioclienti");
	tscadenziarioclienti.defineColumn("!credkind", typeof(string));
	tscadenziarioclienti.defineColumn("!importoflussi", typeof(decimal));
	tscadenziarioclienti.defineColumn("!monthscadenza", typeof(int));
	tscadenziarioclienti.defineColumn("!scadenzaflussi", typeof(DateTime));
	tscadenziarioclienti.defineColumn("!yeardoc", typeof(int));
	tscadenziarioclienti.defineColumn("!yearscadenza", typeof(int));
	tscadenziarioclienti.defineColumn("anomaliaimport", typeof(string));
	tscadenziarioclienti.defineColumn("cliente", typeof(string));
	tscadenziarioclienti.defineColumn("codiceconto", typeof(string));
	tscadenziarioclienti.defineColumn("dareavere", typeof(string));
	tscadenziarioclienti.defineColumn("datadocumeto", typeof(DateTime));
	tscadenziarioclienti.defineColumn("dataparte", typeof(DateTime));
	tscadenziarioclienti.defineColumn("dataprevistaincasso", typeof(DateTime));
	tscadenziarioclienti.defineColumn("idcbmese", typeof(int),false);
	tscadenziarioclienti.defineColumn("idpagamentokind", typeof(int));
	tscadenziarioclienti.defineColumn("idscadenziarioclienti", typeof(int),false);
	tscadenziarioclienti.defineColumn("importo", typeof(decimal));
	tscadenziarioclienti.defineColumn("importodaincassare", typeof(decimal));
	tscadenziarioclienti.defineColumn("importooriginale", typeof(decimal));
	tscadenziarioclienti.defineColumn("note", typeof(string));
	tscadenziarioclienti.defineColumn("nprotocollo", typeof(string));
	tscadenziarioclienti.defineColumn("numerodocumento", typeof(string));
	tscadenziarioclienti.defineColumn("numeroparte", typeof(string));
	tscadenziarioclienti.defineColumn("scadenza", typeof(DateTime));
	tscadenziarioclienti.defineColumn("scadenzaoriginale", typeof(DateTime));
	Tables.Add(tscadenziarioclienti);
	tscadenziarioclienti.defineKey("idcbmese", "idscadenziarioclienti");

	#endregion


	#region DataRelation creation
	var cPar = new []{pagamentokinddefaultview.Columns["idpagamentokind"]};
	var cChild = new []{scadenziarioclienti.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_scadenziarioclienti_pagamentokinddefaultview_idpagamentokind",cPar,cChild,false));

	#endregion

}
}
}
