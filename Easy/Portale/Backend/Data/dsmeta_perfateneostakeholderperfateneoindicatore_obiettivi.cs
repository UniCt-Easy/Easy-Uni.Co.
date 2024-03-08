
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfateneostakeholderperfateneoindicatore_obiettivi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfateneostakeholderperfateneoindicatore_obiettivi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneostakeholder 		=> (MetaTable)Tables["perfateneostakeholder"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneostakeholderperfateneoindicatore 		=> (MetaTable)Tables["perfateneostakeholderperfateneoindicatore"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfateneostakeholderperfateneoindicatore_obiettivi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfateneostakeholderperfateneoindicatore_obiettivi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfateneostakeholderperfateneoindicatore_obiettivi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfateneostakeholderperfateneoindicatore_obiettivi.xsd";

	#region create DataTables
	//////////////////// PERFATENEOSTAKEHOLDER /////////////////////////////////
	var tperfateneostakeholder= new MetaTable("perfateneostakeholder");
	tperfateneostakeholder.defineColumn("ct", typeof(DateTime),false);
	tperfateneostakeholder.defineColumn("cu", typeof(string),false);
	tperfateneostakeholder.defineColumn("idperfateneostakeholder", typeof(int),false);
	tperfateneostakeholder.defineColumn("lt", typeof(DateTime),false);
	tperfateneostakeholder.defineColumn("lu", typeof(string),false);
	tperfateneostakeholder.defineColumn("title", typeof(string));
	Tables.Add(tperfateneostakeholder);
	tperfateneostakeholder.defineKey("idperfateneostakeholder");

	//////////////////// PERFATENEOSTAKEHOLDERPERFATENEOINDICATORE /////////////////////////////////
	var tperfateneostakeholderperfateneoindicatore= new MetaTable("perfateneostakeholderperfateneoindicatore");
	tperfateneostakeholderperfateneoindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("cu", typeof(string),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfateneoindicatore", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfateneostakeholder", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfateneostakeholderperfateneoindicatore);
	tperfateneostakeholderperfateneoindicatore.defineKey("idperfateneoindicatore", "idperfateneoobiettivo", "idperfateneostakeholder", "idperfvalutazioneateneo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfateneostakeholder.Columns["idperfateneostakeholder"]};
	var cChild = new []{perfateneostakeholderperfateneoindicatore.Columns["idperfateneostakeholder"]};
	Relations.Add(new DataRelation("FK_perfateneostakeholderperfateneoindicatore_perfateneostakeholder_idperfateneostakeholder",cPar,cChild,false));

	#endregion

}
}
}
