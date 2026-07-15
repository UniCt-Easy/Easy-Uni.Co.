/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_registrymultikindregistry_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registrymultikindregistry_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymultikind 		=> (MetaTable)Tables["registrymultikind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrymultikindregistry 		=> (MetaTable)Tables["registrymultikindregistry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registrymultikindregistry_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registrymultikindregistry_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registrymultikindregistry_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registrymultikindregistry_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYMULTIKIND /////////////////////////////////
	var tregistrymultikind= new MetaTable("registrymultikind");
	tregistrymultikind.defineColumn("active", typeof(string));
	tregistrymultikind.defineColumn("ct", typeof(DateTime));
	tregistrymultikind.defineColumn("cu", typeof(string));
	tregistrymultikind.defineColumn("description", typeof(string));
	tregistrymultikind.defineColumn("idregistrymultikind", typeof(int),false);
	tregistrymultikind.defineColumn("lt", typeof(DateTime));
	tregistrymultikind.defineColumn("lu", typeof(string));
	tregistrymultikind.defineColumn("title", typeof(string));
	Tables.Add(tregistrymultikind);
	tregistrymultikind.defineKey("idregistrymultikind");

	//////////////////// REGISTRYMULTIKINDREGISTRY /////////////////////////////////
	var tregistrymultikindregistry= new MetaTable("registrymultikindregistry");
	tregistrymultikindregistry.defineColumn("ct", typeof(DateTime));
	tregistrymultikindregistry.defineColumn("cu", typeof(string));
	tregistrymultikindregistry.defineColumn("idreg", typeof(int),false);
	tregistrymultikindregistry.defineColumn("idregistrymultikind", typeof(int),false);
	tregistrymultikindregistry.defineColumn("lt", typeof(DateTime));
	tregistrymultikindregistry.defineColumn("lu", typeof(string));
	Tables.Add(tregistrymultikindregistry);
	tregistrymultikindregistry.defineKey("idreg", "idregistrymultikind");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrymultikind.Columns["idregistrymultikind"]};
	var cChild = new []{registrymultikindregistry.Columns["idregistrymultikind"]};
	Relations.Add(new DataRelation("FK_registrymultikindregistry_registrymultikind_idregistrymultikind",cPar,cChild,false));

	#endregion

}
}
}
