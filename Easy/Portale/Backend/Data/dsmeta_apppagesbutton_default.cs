
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
[System.Xml.Serialization.XmlRoot("dsmeta_apppagesbutton_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_apppagesbutton_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apptabdefaultview 		=> (MetaTable)Tables["apptabdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable apppagesbutton 		=> (MetaTable)Tables["apppagesbutton"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_apppagesbutton_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_apppagesbutton_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_apppagesbutton_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_apppagesbutton_default.xsd";

	#region create DataTables
	//////////////////// APPTABDEFAULTVIEW /////////////////////////////////
	var tapptabdefaultview= new MetaTable("apptabdefaultview");
	tapptabdefaultview.defineColumn("apptab_header", typeof(string));
	tapptabdefaultview.defineColumn("apptab_icon", typeof(string));
	tapptabdefaultview.defineColumn("apptab_position", typeof(int));
	tapptabdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tapptabdefaultview.defineColumn("idapppages", typeof(int),false);
	tapptabdefaultview.defineColumn("idapptab", typeof(int),false);
	tapptabdefaultview.defineColumn("idapptabcolsnumber", typeof(int));
	tapptabdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tapptabdefaultview);
	tapptabdefaultview.defineKey("idapppages", "idapptab");

	//////////////////// APPPAGESBUTTON /////////////////////////////////
	var tapppagesbutton= new MetaTable("apppagesbutton");
	tapppagesbutton.defineColumn("code", typeof(string));
	tapppagesbutton.defineColumn("icon", typeof(string));
	tapppagesbutton.defineColumn("idapppages", typeof(int),false);
	tapppagesbutton.defineColumn("idapppagesbutton", typeof(int),false);
	tapppagesbutton.defineColumn("idapptab", typeof(int));
	tapppagesbutton.defineColumn("javascript", typeof(string));
	tapppagesbutton.defineColumn("name", typeof(string));
	tapppagesbutton.defineColumn("parameter", typeof(string));
	tapppagesbutton.defineColumn("position", typeof(string),false);
	tapppagesbutton.defineColumn("refresh", typeof(string));
	tapppagesbutton.defineColumn("storeprocedure", typeof(string));
	tapppagesbutton.defineColumn("title", typeof(string));
	Tables.Add(tapppagesbutton);
	tapppagesbutton.defineKey("idapppages", "idapppagesbutton");

	#endregion


	#region DataRelation creation
	var cPar = new []{apptabdefaultview.Columns["idapptab"]};
	var cChild = new []{apppagesbutton.Columns["idapptab"]};
	Relations.Add(new DataRelation("FK_apppagesbutton_apptabdefaultview_idapptab",cPar,cChild,false));

	#endregion

}
}
}
