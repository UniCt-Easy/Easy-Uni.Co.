
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfrequestobbindividuale_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfrequestobbindividuale_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfrequestobbindividualesoglia 		=> (MetaTable)Tables["perfrequestobbindividualesoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfrequestobbindividuale 		=> (MetaTable)Tables["perfrequestobbindividuale"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfrequestobbindividuale_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfrequestobbindividuale_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfrequestobbindividuale_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfrequestobbindividuale_default.xsd";

	#region create DataTables
	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFREQUESTOBBINDIVIDUALESOGLIA /////////////////////////////////
	var tperfrequestobbindividualesoglia= new MetaTable("perfrequestobbindividualesoglia");
	tperfrequestobbindividualesoglia.defineColumn("ct", typeof(DateTime),false);
	tperfrequestobbindividualesoglia.defineColumn("cu", typeof(string),false);
	tperfrequestobbindividualesoglia.defineColumn("idperfrequestobbindividuale", typeof(int),false);
	tperfrequestobbindividualesoglia.defineColumn("idperfrequestobbindividualesoglia", typeof(int),false);
	tperfrequestobbindividualesoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfrequestobbindividualesoglia.defineColumn("lt", typeof(DateTime),false);
	tperfrequestobbindividualesoglia.defineColumn("lu", typeof(string),false);
	tperfrequestobbindividualesoglia.defineColumn("percentuale", typeof(decimal));
	tperfrequestobbindividualesoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfrequestobbindividualesoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfrequestobbindividualesoglia);
	tperfrequestobbindividualesoglia.defineKey("idperfrequestobbindividuale", "idperfrequestobbindividualesoglia");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFREQUESTOBBINDIVIDUALE /////////////////////////////////
	var tperfrequestobbindividuale= new MetaTable("perfrequestobbindividuale");
	tperfrequestobbindividuale.defineColumn("ct", typeof(DateTime),false);
	tperfrequestobbindividuale.defineColumn("cu", typeof(string),false);
	tperfrequestobbindividuale.defineColumn("description", typeof(string));
	tperfrequestobbindividuale.defineColumn("idperfrequestobbindividuale", typeof(int),false);
	tperfrequestobbindividuale.defineColumn("idreg", typeof(int),false);
	tperfrequestobbindividuale.defineColumn("inserito", typeof(string));
	tperfrequestobbindividuale.defineColumn("lt", typeof(DateTime),false);
	tperfrequestobbindividuale.defineColumn("lu", typeof(string),false);
	tperfrequestobbindividuale.defineColumn("peso", typeof(decimal));
	tperfrequestobbindividuale.defineColumn("title", typeof(string));
	tperfrequestobbindividuale.defineColumn("year", typeof(int));
	Tables.Add(tperfrequestobbindividuale);
	tperfrequestobbindividuale.defineKey("idperfrequestobbindividuale", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfrequestobbindividuale.Columns["idperfrequestobbindividuale"]};
	var cChild = new []{perfrequestobbindividualesoglia.Columns["idperfrequestobbindividuale"]};
	Relations.Add(new DataRelation("FK_perfrequestobbindividualesoglia_perfrequestobbindividuale_idperfrequestobbindividuale",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfrequestobbindividualesoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfrequestobbindividualesoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{perfrequestobbindividuale.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfrequestobbindividuale_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfrequestobbindividuale.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfrequestobbindividuale_year_year",cPar,cChild,false));

	#endregion

}
}
}
