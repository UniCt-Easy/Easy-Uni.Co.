
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_apptab_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_apptab_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptabcolsnumber 		=> (MetaTable)Tables["apptabcolsnumber"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptab 		=> (MetaTable)Tables["apptab"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apptab_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apptab_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apptab_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apptab_default.xsd";

	#region create DataTables
	//////////////////// APPTABCOLSNUMBER /////////////////////////////////
	var tapptabcolsnumber= new MetaTable("apptabcolsnumber");
	tapptabcolsnumber.defineColumn("idapptabcolsnumber", typeof(int),false);
	Tables.Add(tapptabcolsnumber);
	tapptabcolsnumber.defineKey("idapptabcolsnumber");

	//////////////////// APPTAB /////////////////////////////////
	var tapptab= new MetaTable("apptab");
	tapptab.defineColumn("header", typeof(string));
	tapptab.defineColumn("icon", typeof(string));
	tapptab.defineColumn("idapppages", typeof(int),false);
	tapptab.defineColumn("idapptab", typeof(int),false);
	tapptab.defineColumn("idapptabcolsnumber", typeof(int));
	tapptab.defineColumn("position", typeof(int));
	tapptab.defineColumn("title", typeof(string));
	Tables.Add(tapptab);
	tapptab.defineKey("idapppages", "idapptab");

	#endregion


	#region DataRelation creation
	var cPar = new []{apptabcolsnumber.Columns["idapptabcolsnumber"]};
	var cChild = new []{apptab.Columns["idapptabcolsnumber"]};
	Relations.Add(new DataRelation("FK_apptab_apptabcolsnumber_idapptabcolsnumber",cPar,cChild,false));

	#endregion

}
}
}
