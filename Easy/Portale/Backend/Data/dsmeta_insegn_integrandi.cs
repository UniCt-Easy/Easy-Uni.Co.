
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
[System.Xml.Serialization.XmlRoot("dsmeta_insegn_integrandi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_insegn_integrandi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegncaratteristica 		=> (MetaTable)Tables["insegncaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_insegn_integrandi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_insegn_integrandi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_insegn_integrandi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_insegn_integrandi.xsd";

	#region create DataTables
	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// INSEGNCARATTERISTICA /////////////////////////////////
	var tinsegncaratteristica= new MetaTable("insegncaratteristica");
	tinsegncaratteristica.defineColumn("cf", typeof(decimal));
	tinsegncaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("cu", typeof(string),false);
	tinsegncaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegncaratteristica.defineColumn("idinsegncaratteristica", typeof(int),false);
	tinsegncaratteristica.defineColumn("idsasd", typeof(int));
	tinsegncaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("lu", typeof(string),false);
	tinsegncaratteristica.defineColumn("profess", typeof(string),false);
	tinsegncaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	Tables.Add(tinsegncaratteristica);
	tinsegncaratteristica.defineKey("idinsegn", "idinsegncaratteristica");

	//////////////////// INSEGN /////////////////////////////////
	var tinsegn= new MetaTable("insegn");
	tinsegn.defineColumn("codice", typeof(string));
	tinsegn.defineColumn("ct", typeof(DateTime),false);
	tinsegn.defineColumn("cu", typeof(string),false);
	tinsegn.defineColumn("denominazione", typeof(string));
	tinsegn.defineColumn("idcorsostudio", typeof(int));
	tinsegn.defineColumn("idcorsostudiokind", typeof(int));
	tinsegn.defineColumn("idinsegn", typeof(int),false);
	tinsegn.defineColumn("idlocation_struttura", typeof(int));
	tinsegn.defineColumn("lt", typeof(DateTime),false);
	tinsegn.defineColumn("lu", typeof(string),false);
	tinsegn.defineColumn("paridinsegn", typeof(int));
	Tables.Add(tinsegn);
	tinsegn.defineKey("idinsegn");

	#endregion


	#region DataRelation creation
	var cPar = new []{insegn.Columns["idinsegn"]};
	var cChild = new []{insegncaratteristica.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_insegncaratteristica_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{insegncaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_insegncaratteristica_sasd_idsasd",cPar,cChild,false));

	#endregion

}
}
}
