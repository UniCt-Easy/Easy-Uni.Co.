
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuoindicatorisoglia_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneuoindicatorisoglia_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoindicatorisoglia 		=> (MetaTable)Tables["perfvalutazioneuoindicatorisoglia"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneuoindicatorisoglia_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneuoindicatorisoglia_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneuoindicatorisoglia_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneuoindicatorisoglia_default.xsd";

	#region create DataTables
	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFVALUTAZIONEUOINDICATORISOGLIA /////////////////////////////////
	var tperfvalutazioneuoindicatorisoglia= new MetaTable("perfvalutazioneuoindicatorisoglia");
	tperfvalutazioneuoindicatorisoglia.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("description", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("idperfsogliakind", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("idperfvalutazioneuoindicatori", typeof(int),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("idperfvalutazioneuoindicatorisoglia", typeof(int),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("valore", typeof(decimal),false);
	tperfvalutazioneuoindicatorisoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfvalutazioneuoindicatorisoglia.defineColumn("year", typeof(int),false);
	Tables.Add(tperfvalutazioneuoindicatorisoglia);
	tperfvalutazioneuoindicatorisoglia.defineKey("idperfvalutazioneuoindicatori", "idperfvalutazioneuoindicatorisoglia");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	var cChild = new []{perfvalutazioneuoindicatorisoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatorisoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazioneuoindicatorisoglia.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoindicatorisoglia_year_year",cPar,cChild,false));

	#endregion

}
}
}
