
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfcomportamentosoglia_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfcomportamentosoglia_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfcomportamentosoglia 		=> (MetaTable)Tables["perfcomportamentosoglia"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfcomportamentosoglia_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfcomportamentosoglia_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfcomportamentosoglia_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfcomportamentosoglia_default.xsd";

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

	//////////////////// PERFCOMPORTAMENTOSOGLIA /////////////////////////////////
	var tperfcomportamentosoglia= new MetaTable("perfcomportamentosoglia");
	tperfcomportamentosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfcomportamentosoglia.defineColumn("cu", typeof(string),false);
	tperfcomportamentosoglia.defineColumn("description", typeof(string));
	tperfcomportamentosoglia.defineColumn("idperfcomportamento", typeof(int),false);
	tperfcomportamentosoglia.defineColumn("idperfcomportamentosoglia", typeof(int),false);
	tperfcomportamentosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfcomportamentosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfcomportamentosoglia.defineColumn("lu", typeof(string),false);
	tperfcomportamentosoglia.defineColumn("valore", typeof(decimal));
	tperfcomportamentosoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfcomportamentosoglia.defineColumn("year", typeof(int));
	Tables.Add(tperfcomportamentosoglia);
	tperfcomportamentosoglia.defineKey("idperfcomportamento", "idperfcomportamentosoglia");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	var cChild = new []{perfcomportamentosoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfcomportamentosoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfcomportamentosoglia.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfcomportamentosoglia_year_year",cPar,cChild,false));

	#endregion

}
}
}
