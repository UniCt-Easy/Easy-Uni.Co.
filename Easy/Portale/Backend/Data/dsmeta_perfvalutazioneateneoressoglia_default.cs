
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneateneoressoglia_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneateneoressoglia_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneoressoglia 		=> (MetaTable)Tables["perfvalutazioneateneoressoglia"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneateneoressoglia_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneateneoressoglia_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneateneoressoglia_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneateneoressoglia_default.xsd";

	#region create DataTables
	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFVALUTAZIONEATENEORESSOGLIA /////////////////////////////////
	var tperfvalutazioneateneoressoglia= new MetaTable("perfvalutazioneateneoressoglia");
	tperfvalutazioneateneoressoglia.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneateneoressoglia.defineColumn("cu", typeof(string),false);
	tperfvalutazioneateneoressoglia.defineColumn("description", typeof(string));
	tperfvalutazioneateneoressoglia.defineColumn("idperfmission", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfvalutazioneateneoressoglia.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("idperfvalutazioneateneores", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("idperfvalutazioneateneoressoglia", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneateneoressoglia.defineColumn("lu", typeof(string),false);
	tperfvalutazioneateneoressoglia.defineColumn("percentuale", typeof(decimal));
	tperfvalutazioneateneoressoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfvalutazioneateneoressoglia);
	tperfvalutazioneateneoressoglia.defineKey("idperfmission", "idperfvalutazioneateneo", "idperfvalutazioneateneores", "idperfvalutazioneateneoressoglia");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	var cChild = new []{perfvalutazioneateneoressoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoressoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	#endregion

}
}
}
