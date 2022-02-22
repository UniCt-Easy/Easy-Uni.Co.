
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
[System.Xml.Serialization.XmlRoot("dsmeta_affidamentokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_affidamentokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentokindcostoora 		=> (MetaTable)Tables["affidamentokindcostoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentokind 		=> (MetaTable)Tables["affidamentokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_affidamentokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_affidamentokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_affidamentokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_affidamentokind_default.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// AFFIDAMENTOKINDCOSTOORA /////////////////////////////////
	var taffidamentokindcostoora= new MetaTable("affidamentokindcostoora");
	taffidamentokindcostoora.defineColumn("aa", typeof(string));
	taffidamentokindcostoora.defineColumn("costoora", typeof(decimal));
	taffidamentokindcostoora.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamentokindcostoora.defineColumn("idaffidamentokindcostoora", typeof(int),false);
	taffidamentokindcostoora.defineColumn("title", typeof(string));
	Tables.Add(taffidamentokindcostoora);
	taffidamentokindcostoora.defineKey("idaffidamentokind", "idaffidamentokindcostoora");

	//////////////////// AFFIDAMENTOKIND /////////////////////////////////
	var taffidamentokind= new MetaTable("affidamentokind");
	taffidamentokind.defineColumn("active", typeof(string),false);
	taffidamentokind.defineColumn("costoora", typeof(decimal));
	taffidamentokind.defineColumn("costoorariodacontratto", typeof(string));
	taffidamentokind.defineColumn("ct", typeof(DateTime),false);
	taffidamentokind.defineColumn("cu", typeof(string),false);
	taffidamentokind.defineColumn("description", typeof(string),false);
	taffidamentokind.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamentokind.defineColumn("lt", typeof(DateTime),false);
	taffidamentokind.defineColumn("lu", typeof(string),false);
	taffidamentokind.defineColumn("sortcode", typeof(int),false);
	taffidamentokind.defineColumn("title", typeof(string),false);
	Tables.Add(taffidamentokind);
	taffidamentokind.defineKey("idaffidamentokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{affidamentokind.Columns["idaffidamentokind"]};
	var cChild = new []{affidamentokindcostoora.Columns["idaffidamentokind"]};
	Relations.Add(new DataRelation("FK_affidamentokindcostoora_affidamentokind_idaffidamentokind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{affidamentokindcostoora.Columns["aa"]};
	Relations.Add(new DataRelation("FK_affidamentokindcostoora_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
