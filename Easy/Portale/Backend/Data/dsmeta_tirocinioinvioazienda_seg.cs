
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
[System.Xml.Serialization.XmlRoot("dsmeta_tirocinioinvioazienda_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tirocinioinvioazienda_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioinvioazienda 		=> (MetaTable)Tables["tirocinioinvioazienda"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tirocinioinvioazienda_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tirocinioinvioazienda_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tirocinioinvioazienda_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tirocinioinvioazienda_seg.xsd";

	#region create DataTables
	//////////////////// TIROCINIOINVIOAZIENDA /////////////////////////////////
	var ttirocinioinvioazienda= new MetaTable("tirocinioinvioazienda");
	ttirocinioinvioazienda.defineColumn("ct", typeof(DateTime),false);
	ttirocinioinvioazienda.defineColumn("cu", typeof(string),false);
	ttirocinioinvioazienda.defineColumn("dataora", typeof(DateTime));
	ttirocinioinvioazienda.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioinvioazienda", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("lt", typeof(DateTime),false);
	ttirocinioinvioazienda.defineColumn("lu", typeof(string),false);
	Tables.Add(ttirocinioinvioazienda);
	ttirocinioinvioazienda.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioinvioazienda", "idtirocinioprogetto", "idtirocinioproposto");

	#endregion

}
}
}
