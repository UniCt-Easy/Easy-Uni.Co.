
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoobiettivouoview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoobiettivouoview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind_alias1 		=> (MetaTable)Tables["perfsogliakind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettosoglia 		=> (MetaTable)Tables["perfprogettosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia 		=> (MetaTable)Tables["perfprogettoobiettivosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivouoview 		=> (MetaTable)Tables["perfprogettoobiettivouoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoobiettivouoview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoobiettivouoview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoobiettivouoview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoobiettivouoview_default.xsd";

	#region create DataTables
	//////////////////// PERFSOGLIAKIND_ALIAS1 /////////////////////////////////
	var tperfsogliakind_alias1= new MetaTable("perfsogliakind_alias1");
	tperfsogliakind_alias1.defineColumn("idperfsogliakind", typeof(string),false);
	tperfsogliakind_alias1.ExtendedProperties["TableForReading"]="perfsogliakind";
	Tables.Add(tperfsogliakind_alias1);
	tperfsogliakind_alias1.defineKey("idperfsogliakind");

	//////////////////// PERFPROGETTOSOGLIA /////////////////////////////////
	var tperfprogettosoglia= new MetaTable("perfprogettosoglia");
	tperfprogettosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfprogettosoglia.defineColumn("cu", typeof(string),false);
	tperfprogettosoglia.defineColumn("description", typeof(string));
	tperfprogettosoglia.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettosoglia.defineColumn("idperfprogettosoglia", typeof(int),false);
	tperfprogettosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfprogettosoglia.defineColumn("lu", typeof(string),false);
	tperfprogettosoglia.defineColumn("percentuale", typeof(decimal));
	tperfprogettosoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfprogettosoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettosoglia);
	tperfprogettosoglia.defineKey("idperfprogetto", "idperfprogettosoglia");

	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFPROGETTOOBIETTIVOSOGLIA /////////////////////////////////
	var tperfprogettoobiettivosoglia= new MetaTable("perfprogettoobiettivosoglia");
	tperfprogettoobiettivosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("description", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivosoglia", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("percentuale", typeof(decimal));
	tperfprogettoobiettivosoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfprogettoobiettivosoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettoobiettivosoglia);
	tperfprogettoobiettivosoglia.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivosoglia");

	//////////////////// PERFPROGETTOOBIETTIVOUOVIEW /////////////////////////////////
	var tperfprogettoobiettivouoview= new MetaTable("perfprogettoobiettivouoview");
	tperfprogettoobiettivouoview.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivouoview.defineColumn("description", typeof(string));
	tperfprogettoobiettivouoview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("idstruttura", typeof(int),false);
	tperfprogettoobiettivouoview.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivouoview.defineColumn("progetto_title", typeof(string));
	tperfprogettoobiettivouoview.defineColumn("title", typeof(string));
	tperfprogettoobiettivouoview.defineColumn("year", typeof(int),false);
	Tables.Add(tperfprogettoobiettivouoview);
	tperfprogettoobiettivouoview.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfvalutazioneuo", "idstruttura");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettoobiettivouoview.Columns["idperfprogetto"]};
	var cChild = new []{perfprogettosoglia.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettosoglia_perfprogettoobiettivouoview_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfsogliakind_alias1.Columns["idperfsogliakind"]};
	cChild = new []{perfprogettosoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfprogettosoglia_perfsogliakind_alias1_idperfsogliakind",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivouoview.Columns["idperfprogetto"], perfprogettoobiettivouoview.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfprogetto"], perfprogettoobiettivosoglia.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfprogettoobiettivouoview_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	#endregion

}
}
}
