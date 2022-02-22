
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettocambiostato_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettocambiostato_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolo 		=> (MetaTable)Tables["perfruolo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettocambiostatoperfruolo 		=> (MetaTable)Tables["perfprogettocambiostatoperfruolo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolodefaultview 		=> (MetaTable)Tables["perfruolodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatusdefaultview_alias1 		=> (MetaTable)Tables["perfprogettostatusdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatusdefaultview 		=> (MetaTable)Tables["perfprogettostatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettocambiostato 		=> (MetaTable)Tables["perfprogettocambiostato"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettocambiostato_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettocambiostato_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettocambiostato_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettocambiostato_default.xsd";

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

	//////////////////// PERFPROGETTOCAMBIOSTATOPERFRUOLO /////////////////////////////////
	var tperfprogettocambiostatoperfruolo= new MetaTable("perfprogettocambiostatoperfruolo");
	tperfprogettocambiostatoperfruolo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettocambiostatoperfruolo.defineColumn("cu", typeof(string),false);
	tperfprogettocambiostatoperfruolo.defineColumn("idperfprogettocambiostato", typeof(int),false);
	tperfprogettocambiostatoperfruolo.defineColumn("idperfruolo", typeof(string),false);
	tperfprogettocambiostatoperfruolo.defineColumn("lt", typeof(DateTime),false);
	tperfprogettocambiostatoperfruolo.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettocambiostatoperfruolo);
	tperfprogettocambiostatoperfruolo.defineKey("idperfprogettocambiostato", "idperfruolo");

	//////////////////// PERFRUOLODEFAULTVIEW /////////////////////////////////
	var tperfruolodefaultview= new MetaTable("perfruolodefaultview");
	tperfruolodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfruolodefaultview.defineColumn("idperfruolo", typeof(string),false);
	Tables.Add(tperfruolodefaultview);
	tperfruolodefaultview.defineKey("idperfruolo");

	//////////////////// PERFPROGETTOSTATUSDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tperfprogettostatusdefaultview_alias1= new MetaTable("perfprogettostatusdefaultview_alias1");
	tperfprogettostatusdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettostatusdefaultview_alias1.defineColumn("idperfprogettostatus", typeof(int),false);
	tperfprogettostatusdefaultview_alias1.defineColumn("perfprogettostatus_active", typeof(string));
	tperfprogettostatusdefaultview_alias1.ExtendedProperties["TableForReading"]="perfprogettostatusdefaultview";
	Tables.Add(tperfprogettostatusdefaultview_alias1);
	tperfprogettostatusdefaultview_alias1.defineKey("idperfprogettostatus");

	//////////////////// PERFPROGETTOSTATUSDEFAULTVIEW /////////////////////////////////
	var tperfprogettostatusdefaultview= new MetaTable("perfprogettostatusdefaultview");
	tperfprogettostatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettostatusdefaultview.defineColumn("idperfprogettostatus", typeof(int),false);
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_active", typeof(string));
	Tables.Add(tperfprogettostatusdefaultview);
	tperfprogettostatusdefaultview.defineKey("idperfprogettostatus");

	//////////////////// PERFPROGETTOCAMBIOSTATO /////////////////////////////////
	var tperfprogettocambiostato= new MetaTable("perfprogettocambiostato");
	tperfprogettocambiostato.defineColumn("ct", typeof(DateTime),false);
	tperfprogettocambiostato.defineColumn("cu", typeof(string),false);
	tperfprogettocambiostato.defineColumn("idperfprogettocambiostato", typeof(int),false);
	tperfprogettocambiostato.defineColumn("idperfprogettostatus", typeof(int));
	tperfprogettocambiostato.defineColumn("idperfprogettostatus_to", typeof(int));
	tperfprogettocambiostato.defineColumn("idperfruolo", typeof(string));
	tperfprogettocambiostato.defineColumn("idperfruolo_mail", typeof(string));
	tperfprogettocambiostato.defineColumn("lt", typeof(DateTime),false);
	tperfprogettocambiostato.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettocambiostato);
	tperfprogettocambiostato.defineKey("idperfprogettocambiostato");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettocambiostato.Columns["idperfprogettocambiostato"]};
	var cChild = new []{perfprogettocambiostatoperfruolo.Columns["idperfprogettocambiostato"]};
	Relations.Add(new DataRelation("FK_perfprogettocambiostatoperfruolo_perfprogettocambiostato_idperfprogettocambiostato",cPar,cChild,false));

	cPar = new []{perfruolo.Columns["idperfruolo"]};
	cChild = new []{perfprogettocambiostatoperfruolo.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfprogettocambiostatoperfruolo_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{perfruolodefaultview.Columns["idperfruolo"]};
	cChild = new []{perfprogettocambiostato.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_perfprogettocambiostato_perfruolodefaultview_idperfruolo",cPar,cChild,false));

	cPar = new []{perfprogettostatusdefaultview_alias1.Columns["idperfprogettostatus"]};
	cChild = new []{perfprogettocambiostato.Columns["idperfprogettostatus_to"]};
	Relations.Add(new DataRelation("FK_perfprogettocambiostato_perfprogettostatusdefaultview_alias1_idperfprogettostatus_to",cPar,cChild,false));

	cPar = new []{perfprogettostatusdefaultview.Columns["idperfprogettostatus"]};
	cChild = new []{perfprogettocambiostato.Columns["idperfprogettostatus"]};
	Relations.Add(new DataRelation("FK_perfprogettocambiostato_perfprogettostatusdefaultview_idperfprogettostatus",cPar,cChild,false));

	#endregion

}
}
}
