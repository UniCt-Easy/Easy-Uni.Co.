
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
[System.Xml.Serialization.XmlRoot("dsmeta_mutuazionecaratteristicaora_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_mutuazionecaratteristicaora_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable orakind 		=> (MetaTable)Tables["orakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mutuazionecaratteristicaora 		=> (MetaTable)Tables["mutuazionecaratteristicaora"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_mutuazionecaratteristicaora_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_mutuazionecaratteristicaora_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_mutuazionecaratteristicaora_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_mutuazionecaratteristicaora_default.xsd";

	#region create DataTables
	//////////////////// ORAKIND /////////////////////////////////
	var torakind= new MetaTable("orakind");
	torakind.defineColumn("idorakind", typeof(int),false);
	torakind.defineColumn("title", typeof(string));
	Tables.Add(torakind);
	torakind.defineKey("idorakind");

	//////////////////// MUTUAZIONECARATTERISTICAORA /////////////////////////////////
	var tmutuazionecaratteristicaora= new MetaTable("mutuazionecaratteristicaora");
	tmutuazionecaratteristicaora.defineColumn("aa", typeof(string),false);
	tmutuazionecaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	tmutuazionecaratteristicaora.defineColumn("cu", typeof(string),false);
	tmutuazionecaratteristicaora.defineColumn("idattivform", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idcanale", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idmutuazione", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idmutuazionecaratteristica", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idmutuazionecaratteristicaora", typeof(int),false);
	tmutuazionecaratteristicaora.defineColumn("idorakind", typeof(int));
	tmutuazionecaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	tmutuazionecaratteristicaora.defineColumn("lu", typeof(string),false);
	tmutuazionecaratteristicaora.defineColumn("ora", typeof(int));
	Tables.Add(tmutuazionecaratteristicaora);
	tmutuazionecaratteristicaora.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idmutuazione", "idmutuazionecaratteristica", "idmutuazionecaratteristicaora");

	#endregion


	#region DataRelation creation
	var cPar = new []{orakind.Columns["idorakind"]};
	var cChild = new []{mutuazionecaratteristicaora.Columns["idorakind"]};
	Relations.Add(new DataRelation("FK_mutuazionecaratteristicaora_orakind_idorakind",cPar,cChild,false));

	#endregion

}
}
}
