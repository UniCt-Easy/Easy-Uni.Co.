
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettouoview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettouoview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettosoglia 		=> (MetaTable)Tables["perfprogettosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouoview 		=> (MetaTable)Tables["perfprogettouoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettouoview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettouoview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettouoview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettouoview_default.xsd";

	#region create DataTables
	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

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

	//////////////////// PERFPROGETTOUOVIEW /////////////////////////////////
	var tperfprogettouoview= new MetaTable("perfprogettouoview");
	tperfprogettouoview.defineColumn("description", typeof(string));
	tperfprogettouoview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouoview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfprogettouoview.defineColumn("idstruttura", typeof(int));
	tperfprogettouoview.defineColumn("progetto_title", typeof(string));
	tperfprogettouoview.defineColumn("risultato", typeof(decimal));
	tperfprogettouoview.defineColumn("year", typeof(int),false);
	Tables.Add(tperfprogettouoview);
	tperfprogettouoview.defineKey("idperfprogetto", "idperfvalutazioneuo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettouoview.Columns["idperfprogetto"]};
	var cChild = new []{perfprogettosoglia.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettosoglia_perfprogettouoview_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfprogettosoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfprogettosoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	#endregion

}
}
}
