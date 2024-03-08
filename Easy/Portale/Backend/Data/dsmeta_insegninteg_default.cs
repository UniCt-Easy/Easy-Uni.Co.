
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
[System.Xml.Serialization.XmlRoot("dsmeta_insegninteg_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_insegninteg_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd_alias1 		=> (MetaTable)Tables["sasd_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegnintegcaratteristica 		=> (MetaTable)Tables["insegnintegcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_insegninteg_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_insegninteg_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_insegninteg_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_insegninteg_default.xsd";

	#region create DataTables
	//////////////////// SASD_ALIAS1 /////////////////////////////////
	var tsasd_alias1= new MetaTable("sasd_alias1");
	tsasd_alias1.defineColumn("codice", typeof(string),false);
	tsasd_alias1.defineColumn("idsasd", typeof(int),false);
	tsasd_alias1.defineColumn("title", typeof(string),false);
	tsasd_alias1.ExtendedProperties["TableForReading"]="sasd";
	Tables.Add(tsasd_alias1);
	tsasd_alias1.defineKey("idsasd");

	//////////////////// INSEGNINTEGCARATTERISTICA /////////////////////////////////
	var tinsegnintegcaratteristica= new MetaTable("insegnintegcaratteristica");
	tinsegnintegcaratteristica.defineColumn("cf", typeof(decimal));
	tinsegnintegcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("cu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegninteg", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegnintegcaratteristica", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idsasd", typeof(int));
	tinsegnintegcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("lu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("profess", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tinsegnintegcaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	Tables.Add(tinsegnintegcaratteristica);
	tinsegnintegcaratteristica.defineKey("idinsegn", "idinsegninteg", "idinsegnintegcaratteristica");

	//////////////////// INSEGNINTEG /////////////////////////////////
	var tinsegninteg= new MetaTable("insegninteg");
	tinsegninteg.defineColumn("codice", typeof(string));
	tinsegninteg.defineColumn("ct", typeof(DateTime),false);
	tinsegninteg.defineColumn("cu", typeof(string),false);
	tinsegninteg.defineColumn("denominazione", typeof(string));
	tinsegninteg.defineColumn("denominazione_en", typeof(string));
	tinsegninteg.defineColumn("idinsegn", typeof(int),false);
	tinsegninteg.defineColumn("idinsegninteg", typeof(int),false);
	tinsegninteg.defineColumn("lt", typeof(DateTime),false);
	tinsegninteg.defineColumn("lu", typeof(string),false);
	Tables.Add(tinsegninteg);
	tinsegninteg.defineKey("idinsegn", "idinsegninteg");

	#endregion


	#region DataRelation creation
	var cPar = new []{insegninteg.Columns["idinsegn"], insegninteg.Columns["idinsegninteg"]};
	var cChild = new []{insegnintegcaratteristica.Columns["idinsegn"], insegnintegcaratteristica.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_insegnintegcaratteristica_insegninteg_idinsegn-idinsegninteg",cPar,cChild,false));

	cPar = new []{sasd_alias1.Columns["idsasd"]};
	cChild = new []{insegnintegcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_insegnintegcaratteristica_sasd_alias1_idsasd",cPar,cChild,false));

	#endregion

}
}
}
