
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
[System.Xml.Serialization.XmlRoot("dsmeta_tirociniodiario_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tirociniodiario_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniodiario 		=> (MetaTable)Tables["tirociniodiario"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tirociniodiario_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tirociniodiario_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tirociniodiario_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tirociniodiario_seg.xsd";

	#region create DataTables
	//////////////////// TIROCINIODIARIO /////////////////////////////////
	var ttirociniodiario= new MetaTable("tirociniodiario");
	ttirociniodiario.defineColumn("ct", typeof(DateTime),false);
	ttirociniodiario.defineColumn("cu", typeof(string),false);
	ttirociniodiario.defineColumn("data", typeof(DateTime));
	ttirociniodiario.defineColumn("description", typeof(string));
	ttirociniodiario.defineColumn("idreg_referente", typeof(int),false);
	ttirociniodiario.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniodiario.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniodiario.defineColumn("idtirociniodiario", typeof(int),false);
	ttirociniodiario.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirociniodiario.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniodiario.defineColumn("lt", typeof(DateTime),false);
	ttirociniodiario.defineColumn("lu", typeof(string),false);
	ttirociniodiario.defineColumn("ore", typeof(int));
	Tables.Add(ttirociniodiario);
	ttirociniodiario.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirociniodiario", "idtirocinioprogetto", "idtirocinioproposto");

	#endregion

}
}
}
