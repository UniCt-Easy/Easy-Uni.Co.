/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_liquidazione_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_liquidazione_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable liquidazione 		=> (MetaTable)Tables["liquidazione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_liquidazione_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_liquidazione_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_liquidazione_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_liquidazione_seg.xsd";

	#region create DataTables
	//////////////////// LIQUIDAZIONE /////////////////////////////////
	var tliquidazione= new MetaTable("liquidazione");
	tliquidazione.defineColumn("ct", typeof(DateTime));
	tliquidazione.defineColumn("cu", typeof(string));
	tliquidazione.defineColumn("data", typeof(DateTime));
	tliquidazione.defineColumn("idcredito", typeof(int),false);
	tliquidazione.defineColumn("iddebito_credito", typeof(int),false);
	tliquidazione.defineColumn("idliquidazione", typeof(int),false);
	tliquidazione.defineColumn("idpagamento", typeof(int),false);
	tliquidazione.defineColumn("idreg", typeof(int),false);
	tliquidazione.defineColumn("importo", typeof(decimal));
	tliquidazione.defineColumn("lt", typeof(DateTime));
	tliquidazione.defineColumn("lu", typeof(string));
	Tables.Add(tliquidazione);
	tliquidazione.defineKey("idcredito", "iddebito_credito", "idliquidazione", "idpagamento", "idreg");

	#endregion

}
}
}
