
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonalereport_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazionepersonalereport_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativinomcognview 		=> (MetaTable)Tables["getregistrydocentiamministrativinomcognview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalereport 		=> (MetaTable)Tables["perfvalutazionepersonalereport"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazionepersonalereport_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonalereport_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonalereport_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonalereport_default.xsd";

	#region create DataTables
	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVINOMCOGNVIEW /////////////////////////////////
	var tgetregistrydocentiamministrativinomcognview= new MetaTable("getregistrydocentiamministrativinomcognview");
	tgetregistrydocentiamministrativinomcognview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministrativinomcognview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministrativinomcognview);
	tgetregistrydocentiamministrativinomcognview.defineKey("idreg");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFVALUTAZIONEPERSONALEREPORT /////////////////////////////////
	var tperfvalutazionepersonalereport= new MetaTable("perfvalutazionepersonalereport");
	tperfvalutazionepersonalereport.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonalereport.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonalereport.defineColumn("idperfvalutazionepersonalereport", typeof(int),false);
	tperfvalutazionepersonalereport.defineColumn("idreg", typeof(int));
	tperfvalutazionepersonalereport.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonalereport.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonalereport.defineColumn("tipo", typeof(string));
	tperfvalutazionepersonalereport.defineColumn("year", typeof(int));
	Tables.Add(tperfvalutazionepersonalereport);
	tperfvalutazionepersonalereport.defineKey("idperfvalutazionepersonalereport");

	#endregion


	#region DataRelation creation
	var cPar = new []{getregistrydocentiamministrativinomcognview.Columns["idreg"]};
	var cChild = new []{perfvalutazionepersonalereport.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalereport_getregistrydocentiamministrativinomcognview_idreg",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazionepersonalereport.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalereport_year_year",cPar,cChild,false));

	#endregion

}
}
}
