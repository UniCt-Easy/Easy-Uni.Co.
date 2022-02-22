
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
[System.Xml.Serialization.XmlRoot("dsmeta_tirocinioappr_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tirocinioappr_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioapprkind 		=> (MetaTable)Tables["tirocinioapprkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioappr 		=> (MetaTable)Tables["tirocinioappr"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tirocinioappr_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tirocinioappr_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tirocinioappr_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tirocinioappr_seg.xsd";

	#region create DataTables
	//////////////////// TIROCINIOAPPRKIND /////////////////////////////////
	var ttirocinioapprkind= new MetaTable("tirocinioapprkind");
	ttirocinioapprkind.defineColumn("idtirocinioapprkind", typeof(int),false);
	ttirocinioapprkind.defineColumn("title", typeof(string));
	Tables.Add(ttirocinioapprkind);
	ttirocinioapprkind.defineKey("idtirocinioapprkind");

	//////////////////// TIROCINIOAPPR /////////////////////////////////
	var ttirocinioappr= new MetaTable("tirocinioappr");
	ttirocinioappr.defineColumn("approvazione", typeof(string));
	ttirocinioappr.defineColumn("ct", typeof(DateTime),false);
	ttirocinioappr.defineColumn("cu", typeof(string),false);
	ttirocinioappr.defineColumn("dataora", typeof(DateTime));
	ttirocinioappr.defineColumn("idreg_docenti", typeof(int));
	ttirocinioappr.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioappr.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioappr", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioapprkind", typeof(int));
	ttirocinioappr.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioappr.defineColumn("lt", typeof(DateTime),false);
	ttirocinioappr.defineColumn("lu", typeof(string),false);
	Tables.Add(ttirocinioappr);
	ttirocinioappr.defineKey("idreg_referente", "idreg_studenti", "idtirocinioappr", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	#endregion


	#region DataRelation creation
	var cPar = new []{tirocinioapprkind.Columns["idtirocinioapprkind"]};
	var cChild = new []{tirocinioappr.Columns["idtirocinioapprkind"]};
	Relations.Add(new DataRelation("FK_tirocinioappr_tirocinioapprkind_idtirocinioapprkind",cPar,cChild,false));

	#endregion

}
}
}
