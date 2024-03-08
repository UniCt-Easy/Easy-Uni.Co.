
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfcomportamentisoglia_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfcomportamentisoglia_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfcomportamentisoglia 		=> (MetaTable)Tables["perfcomportamentisoglia"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfcomportamentisoglia_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfcomportamentisoglia_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfcomportamentisoglia_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfcomportamentisoglia_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("description", typeof(string),false);
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFCOMPORTAMENTISOGLIA /////////////////////////////////
	var tperfcomportamentisoglia= new MetaTable("perfcomportamentisoglia");
	tperfcomportamentisoglia.defineColumn("ct", typeof(DateTime),false);
	tperfcomportamentisoglia.defineColumn("cu", typeof(string),false);
	tperfcomportamentisoglia.defineColumn("description", typeof(string));
	tperfcomportamentisoglia.defineColumn("idperfcomportamento", typeof(int),false);
	tperfcomportamentisoglia.defineColumn("idperfcomportamentosoglia", typeof(int),false);
	tperfcomportamentisoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfcomportamentisoglia.defineColumn("lt", typeof(DateTime),false);
	tperfcomportamentisoglia.defineColumn("lu", typeof(string),false);
	tperfcomportamentisoglia.defineColumn("valore", typeof(decimal));
	tperfcomportamentisoglia.defineColumn("year", typeof(string));
	Tables.Add(tperfcomportamentisoglia);
	tperfcomportamentisoglia.defineKey("idperfcomportamento", "idperfcomportamentosoglia");

	#endregion

}
}
}
