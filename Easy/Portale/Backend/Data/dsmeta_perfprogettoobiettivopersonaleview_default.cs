
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoobiettivopersonaleview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoobiettivopersonaleview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia 		=> (MetaTable)Tables["perfprogettoobiettivosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivopersonaleview 		=> (MetaTable)Tables["perfprogettoobiettivopersonaleview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoobiettivopersonaleview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoobiettivopersonaleview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoobiettivopersonaleview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoobiettivopersonaleview_default.xsd";

	#region create DataTables
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

	//////////////////// PERFPROGETTOOBIETTIVOPERSONALEVIEW /////////////////////////////////
	var tperfprogettoobiettivopersonaleview= new MetaTable("perfprogettoobiettivopersonaleview");
	tperfprogettoobiettivopersonaleview.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivopersonaleview.defineColumn("description", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idstruttura", typeof(int),false);
	tperfprogettoobiettivopersonaleview.defineColumn("idstruttura_perfprogetto", typeof(int));
	tperfprogettoobiettivopersonaleview.defineColumn("perfprogetto_struttura_title", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("perfprogetto_strutturakind_title", typeof(string),false);
	tperfprogettoobiettivopersonaleview.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivopersonaleview.defineColumn("progetto_title", typeof(string));
	tperfprogettoobiettivopersonaleview.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivopersonaleview);
	tperfprogettoobiettivopersonaleview.defineKey("idperfprogettoobiettivo", "idperfvalutazioneuo", "idstruttura");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettoobiettivopersonaleview.Columns["idperfprogetto"], perfprogettoobiettivopersonaleview.Columns["idperfprogettoobiettivo"]};
	var cChild = new []{perfprogettoobiettivosoglia.Columns["idperfprogetto"], perfprogettoobiettivosoglia.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfprogettoobiettivopersonaleview_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	#endregion

}
}
}
