
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfschedacambiostato_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfschedacambiostato_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolo 		=> (MetaTable)Tables["perfruolo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedacambiostatoperfruolo 		=> (MetaTable)Tables["perfschedacambiostatoperfruolo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolodefaultview 		=> (MetaTable)Tables["perfruolodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview_alias1 		=> (MetaTable)Tables["perfschedastatusdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedacambiostato 		=> (MetaTable)Tables["perfschedacambiostato"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfschedacambiostato_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfschedacambiostato_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfschedacambiostato_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfschedacambiostato_default.xsd";

	#region create DataTables
	//////////////////// PERFRUOLO /////////////////////////////////
	var tperfruolo= new MetaTable("perfruolo");
	tperfruolo.defineColumn("aggiorna", typeof(string));
	tperfruolo.defineColumn("crea", typeof(string));
	tperfruolo.defineColumn("ct", typeof(DateTime),false);
	tperfruolo.defineColumn("cu", typeof(string),false);
	tperfruolo.defineColumn("idperfruolo", typeof(string),false);
	tperfruolo.defineColumn("leggi", typeof(string));
	tperfruolo.defineColumn("lt", typeof(DateTime),false);
	tperfruolo.defineColumn("lu", typeof(string),false);
	tperfruolo.defineColumn("oper", typeof(string));
	tperfruolo.defineColumn("valuta", typeof(string));
	Tables.Add(tperfruolo);
	tperfruolo.defineKey("idperfruolo");

	//////////////////// PERFSCHEDACAMBIOSTATOPERFRUOLO /////////////////////////////////
	var tperfschedacambiostatoperfruolo= new MetaTable("perfschedacambiostatoperfruolo");
	tperfschedacambiostatoperfruolo.defineColumn("ct", typeof(DateTime),false);
	tperfschedacambiostatoperfruolo.defineColumn("cu", typeof(string),false);
	tperfschedacambiostatoperfruolo.defineColumn("idperfruolo", typeof(string),false);
	tperfschedacambiostatoperfruolo.defineColumn("idperfschedacambiostato", typeof(int),false);
	tperfschedacambiostatoperfruolo.defineColumn("lt", typeof(DateTime),false);
	tperfschedacambiostatoperfruolo.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfschedacambiostatoperfruolo);
	tperfschedacambiostatoperfruolo.defineKey("idperfruolo", "idperfschedacambiostato");

	//////////////////// PERFRUOLODEFAULTVIEW /////////////////////////////////
	var tperfruolodefaultview= new MetaTable("perfruolodefaultview");
	tperfruolodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfruolodefaultview.defineColumn("idperfruolo", typeof(string),false);
	Tables.Add(tperfruolodefaultview);
	tperfruolodefaultview.defineKey("idperfruolo");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tperfschedastatusdefaultview_alias1= new MetaTable("perfschedastatusdefaultview_alias1");
	tperfschedastatusdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview_alias1.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview_alias1.defineColumn("perfschedastatus_active", typeof(string));
	tperfschedastatusdefaultview_alias1.ExtendedProperties["TableForReading"]="perfschedastatusdefaultview";
	Tables.Add(tperfschedastatusdefaultview_alias1);
	tperfschedastatusdefaultview_alias1.defineKey("idperfschedastatus");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW /////////////////////////////////
	var tperfschedastatusdefaultview= new MetaTable("perfschedastatusdefaultview");
	tperfschedastatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_active", typeof(string));
	Tables.Add(tperfschedastatusdefaultview);
	tperfschedastatusdefaultview.defineKey("idperfschedastatus");

	//////////////////// PERFSCHEDACAMBIOSTATO /////////////////////////////////
	var tperfschedacambiostato= new MetaTable("perfschedacambiostato");
	tperfschedacambiostato.defineColumn("idperfruolo", typeof(string));
	tperfschedacambiostato.defineColumn("idperfruolo_mail", typeof(string));
	tperfschedacambiostato.defineColumn("idperfschedacambiostato", typeof(int),false);
	tperfschedacambiostato.defineColumn("idperfschedastatus", typeof(int));
	tperfschedacambiostato.defineColumn("idperfschedastatus_to", typeof(int));
	Tables.Add(tperfschedacambiostato);
	tperfschedacambiostato.defineKey("idperfschedacambiostato");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfschedacambiostato.Columns["idperfschedacambiostato"]};
	var cChild = new []{perfschedacambiostatoperfruolo.Columns["idperfschedacambiostato"]};
	Relations.Add(new DataRelation("FK_perfschedacambiostatoperfruolo_perfschedacambiostato_idperfschedacambiostato",cPar,cChild,false));

	cPar = new []{perfruolo.Columns["idperfruolo"]};
	cChild = new []{perfschedacambiostatoperfruolo.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfschedacambiostatoperfruolo_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{perfruolodefaultview.Columns["idperfruolo"]};
	cChild = new []{perfschedacambiostato.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfschedacambiostato_perfruolodefaultview_idperfruolo",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview_alias1.Columns["idperfschedastatus"]};
	cChild = new []{perfschedacambiostato.Columns["idperfschedastatus_to"]};
	Relations.Add(new DataRelation("FK_perfschedacambiostato_perfschedastatusdefaultview_alias1_idperfschedastatus_to",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	cChild = new []{perfschedacambiostato.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfschedacambiostato_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	#endregion

}
}
}
