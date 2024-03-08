
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfschedacambiostatoperfruolo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfschedacambiostatoperfruolo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolodefaultview 		=> (MetaTable)Tables["perfruolodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedacambiostatoperfruolo 		=> (MetaTable)Tables["perfschedacambiostatoperfruolo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfschedacambiostatoperfruolo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfschedacambiostatoperfruolo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfschedacambiostatoperfruolo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfschedacambiostatoperfruolo_default.xsd";

	#region create DataTables
	//////////////////// PERFRUOLODEFAULTVIEW /////////////////////////////////
	var tperfruolodefaultview= new MetaTable("perfruolodefaultview");
	tperfruolodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfruolodefaultview.defineColumn("idperfruolo", typeof(string),false);
	tperfruolodefaultview.defineColumn("perfruolo_aggiorna", typeof(string));
	tperfruolodefaultview.defineColumn("perfruolo_crea", typeof(string));
	tperfruolodefaultview.defineColumn("perfruolo_ct", typeof(DateTime),false);
	tperfruolodefaultview.defineColumn("perfruolo_cu", typeof(string),false);
	tperfruolodefaultview.defineColumn("perfruolo_leggi", typeof(string));
	tperfruolodefaultview.defineColumn("perfruolo_lt", typeof(DateTime),false);
	tperfruolodefaultview.defineColumn("perfruolo_lu", typeof(string),false);
	tperfruolodefaultview.defineColumn("perfruolo_oper", typeof(string));
	tperfruolodefaultview.defineColumn("perfruolo_valuta", typeof(string));
	Tables.Add(tperfruolodefaultview);
	tperfruolodefaultview.defineKey("idperfruolo");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{perfruolodefaultview.Columns["idperfruolo"]};
	var cChild = new []{perfschedacambiostatoperfruolo.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfschedacambiostatoperfruolo_perfruolodefaultview_idperfruolo",cPar,cChild,false));

	#endregion

}
}
}
