
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfindicatore_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfindicatore_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatoresoglia 		=> (MetaTable)Tables["perfindicatoresoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatorekind 		=> (MetaTable)Tables["perfindicatorekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatore 		=> (MetaTable)Tables["perfindicatore"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfindicatore_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfindicatore_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfindicatore_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfindicatore_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFINDICATORESOGLIA /////////////////////////////////
	var tperfindicatoresoglia= new MetaTable("perfindicatoresoglia");
	tperfindicatoresoglia.defineColumn("ct", typeof(DateTime),false);
	tperfindicatoresoglia.defineColumn("cu", typeof(string),false);
	tperfindicatoresoglia.defineColumn("description", typeof(string));
	tperfindicatoresoglia.defineColumn("idperfindicatore", typeof(int),false);
	tperfindicatoresoglia.defineColumn("idperfindicatoresoglia", typeof(int),false);
	tperfindicatoresoglia.defineColumn("idperfsogliakind", typeof(string),false);
	tperfindicatoresoglia.defineColumn("lt", typeof(DateTime),false);
	tperfindicatoresoglia.defineColumn("lu", typeof(string),false);
	tperfindicatoresoglia.defineColumn("valore", typeof(decimal),false);
	tperfindicatoresoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfindicatoresoglia.defineColumn("year", typeof(int),false);
	Tables.Add(tperfindicatoresoglia);
	tperfindicatoresoglia.defineKey("idperfindicatore", "idperfindicatoresoglia");

	//////////////////// PERFINDICATOREKIND /////////////////////////////////
	var tperfindicatorekind= new MetaTable("perfindicatorekind");
	tperfindicatorekind.defineColumn("idperfindicatorekind", typeof(int),false);
	tperfindicatorekind.defineColumn("title", typeof(string));
	Tables.Add(tperfindicatorekind);
	tperfindicatorekind.defineKey("idperfindicatorekind");

	//////////////////// PERFINDICATORE /////////////////////////////////
	var tperfindicatore= new MetaTable("perfindicatore");
	tperfindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfindicatore.defineColumn("cu", typeof(string),false);
	tperfindicatore.defineColumn("description", typeof(string),false);
	tperfindicatore.defineColumn("idperfindicatore", typeof(int),false);
	tperfindicatore.defineColumn("idperfindicatorekind", typeof(int));
	tperfindicatore.defineColumn("inverso", typeof(string));
	tperfindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfindicatore.defineColumn("lu", typeof(string),false);
	tperfindicatore.defineColumn("title", typeof(string));
	Tables.Add(tperfindicatore);
	tperfindicatore.defineKey("idperfindicatore");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfindicatore.Columns["idperfindicatore"]};
	var cChild = new []{perfindicatoresoglia.Columns["idperfindicatore"]};
	Relations.Add(new DataRelation("FK_perfindicatoresoglia_perfindicatore_idperfindicatore",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfindicatoresoglia.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfindicatoresoglia_year_year",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfindicatoresoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfindicatoresoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{perfindicatorekind.Columns["idperfindicatorekind"]};
	cChild = new []{perfindicatore.Columns["idperfindicatorekind"]};
	Relations.Add(new DataRelation("FK_perfindicatore_perfindicatorekind_idperfindicatorekind",cPar,cChild,false));

	#endregion

}
}
}
