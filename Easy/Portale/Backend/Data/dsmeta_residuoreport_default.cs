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
[System.Xml.Serialization.XmlRoot("dsmeta_residuoreport_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_residuoreport_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativiprjnomcognmatview 		=> (MetaTable)Tables["getregistrydocentiamministrativiprjnomcognmatview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residuoreport 		=> (MetaTable)Tables["residuoreport"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_residuoreport_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_residuoreport_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_residuoreport_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_residuoreport_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIPRJNOMCOGNMATVIEW /////////////////////////////////
	var tgetregistrydocentiamministrativiprjnomcognmatview= new MetaTable("getregistrydocentiamministrativiprjnomcognmatview");
	tgetregistrydocentiamministrativiprjnomcognmatview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministrativiprjnomcognmatview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministrativiprjnomcognmatview);
	tgetregistrydocentiamministrativiprjnomcognmatview.defineKey("idreg");

	//////////////////// RESIDUOREPORT /////////////////////////////////
	var tresiduoreport= new MetaTable("residuoreport");
	tresiduoreport.defineColumn("ct", typeof(DateTime));
	tresiduoreport.defineColumn("cu", typeof(string));
	tresiduoreport.defineColumn("idreg", typeof(int));
	tresiduoreport.defineColumn("idresiduoreport", typeof(int),false);
	tresiduoreport.defineColumn("lt", typeof(DateTime));
	tresiduoreport.defineColumn("lu", typeof(string));
	tresiduoreport.defineColumn("year", typeof(int),false);
	Tables.Add(tresiduoreport);
	tresiduoreport.defineKey("idresiduoreport");

	#endregion


	#region DataRelation creation
	var cPar = new []{year.Columns["year"]};
	var cChild = new []{residuoreport.Columns["year"]};
	Relations.Add(new DataRelation("FK_residuoreport_year_year",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativiprjnomcognmatview.Columns["idreg"]};
	cChild = new []{residuoreport.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_residuoreport_getregistrydocentiamministrativiprjnomcognmatview_idreg",cPar,cChild,false));

	#endregion

}
}
}
