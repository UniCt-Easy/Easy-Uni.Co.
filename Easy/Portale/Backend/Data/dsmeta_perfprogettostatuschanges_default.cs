
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettostatuschanges_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettostatuschanges_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatusdefaultview 		=> (MetaTable)Tables["perfprogettostatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatuschanges 		=> (MetaTable)Tables["perfprogettostatuschanges"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettostatuschanges_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettostatuschanges_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettostatuschanges_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettostatuschanges_default.xsd";

	#region create DataTables
	//////////////////// PERFPROGETTOSTATUSDEFAULTVIEW /////////////////////////////////
	var tperfprogettostatusdefaultview= new MetaTable("perfprogettostatusdefaultview");
	tperfprogettostatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettostatusdefaultview.defineColumn("idperfprogettostatus", typeof(int),false);
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_active", typeof(string));
	Tables.Add(tperfprogettostatusdefaultview);
	tperfprogettostatusdefaultview.defineKey("idperfprogettostatus");

	//////////////////// PERFPROGETTOSTATUSCHANGES /////////////////////////////////
	var tperfprogettostatuschanges= new MetaTable("perfprogettostatuschanges");
	tperfprogettostatuschanges.defineColumn("changedate", typeof(DateTime));
	tperfprogettostatuschanges.defineColumn("changeuser", typeof(string));
	tperfprogettostatuschanges.defineColumn("ct", typeof(DateTime));
	tperfprogettostatuschanges.defineColumn("cu", typeof(string));
	tperfprogettostatuschanges.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettostatuschanges.defineColumn("idperfprogettostatus", typeof(int));
	tperfprogettostatuschanges.defineColumn("idperfprogettostatuschanges", typeof(int),false);
	tperfprogettostatuschanges.defineColumn("lt", typeof(DateTime));
	tperfprogettostatuschanges.defineColumn("lu", typeof(string));
	Tables.Add(tperfprogettostatuschanges);
	tperfprogettostatuschanges.defineKey("idperfprogetto", "idperfprogettostatuschanges");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettostatusdefaultview.Columns["idperfprogettostatus"]};
	var cChild = new []{perfprogettostatuschanges.Columns["idperfprogettostatus"]};
	Relations.Add(new DataRelation("FK_perfprogettostatuschanges_perfprogettostatusdefaultview_idperfprogettostatus",cPar,cChild,false));

	#endregion

}
}
}
