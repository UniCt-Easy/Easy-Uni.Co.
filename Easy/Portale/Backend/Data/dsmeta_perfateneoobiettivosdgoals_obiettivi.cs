
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfateneoobiettivosdgoals_obiettivi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfateneoobiettivosdgoals_obiettivi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sdgoals 		=> (MetaTable)Tables["sdgoals"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoobiettivosdgoals 		=> (MetaTable)Tables["perfateneoobiettivosdgoals"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfateneoobiettivosdgoals_obiettivi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfateneoobiettivosdgoals_obiettivi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfateneoobiettivosdgoals_obiettivi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfateneoobiettivosdgoals_obiettivi.xsd";

	#region create DataTables
	//////////////////// SDGOALS /////////////////////////////////
	var tsdgoals= new MetaTable("sdgoals");
	tsdgoals.defineColumn("active", typeof(string));
	tsdgoals.defineColumn("ct", typeof(DateTime),false);
	tsdgoals.defineColumn("cu", typeof(string),false);
	tsdgoals.defineColumn("idattach", typeof(int));
	tsdgoals.defineColumn("idsdgoals", typeof(int),false);
	tsdgoals.defineColumn("lt", typeof(DateTime),false);
	tsdgoals.defineColumn("lu", typeof(string),false);
	tsdgoals.defineColumn("sortcode", typeof(int));
	tsdgoals.defineColumn("title", typeof(string));
	Tables.Add(tsdgoals);
	tsdgoals.defineKey("idsdgoals");

	//////////////////// PERFATENEOOBIETTIVOSDGOALS /////////////////////////////////
	var tperfateneoobiettivosdgoals= new MetaTable("perfateneoobiettivosdgoals");
	tperfateneoobiettivosdgoals.defineColumn("ct", typeof(DateTime),false);
	tperfateneoobiettivosdgoals.defineColumn("cu", typeof(string),false);
	tperfateneoobiettivosdgoals.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneoobiettivosdgoals.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneoobiettivosdgoals.defineColumn("idsdgoals", typeof(int),false);
	tperfateneoobiettivosdgoals.defineColumn("lt", typeof(DateTime),false);
	tperfateneoobiettivosdgoals.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfateneoobiettivosdgoals);
	tperfateneoobiettivosdgoals.defineKey("idperfateneoobiettivo", "idperfvalutazioneateneo", "idsdgoals");

	#endregion


	#region DataRelation creation
	var cPar = new []{sdgoals.Columns["idsdgoals"]};
	var cChild = new []{perfateneoobiettivosdgoals.Columns["idsdgoals"]};
	Relations.Add(new DataRelation("FK_perfateneoobiettivosdgoals_sdgoals_idsdgoals",cPar,cChild,false));

	#endregion

}
}
}
