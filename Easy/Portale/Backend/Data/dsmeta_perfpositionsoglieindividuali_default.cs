
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfpositionsoglieindividuali_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfpositionsoglieindividuali_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfpositionsoglieindividuali 		=> (MetaTable)Tables["perfpositionsoglieindividuali"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfpositionsoglieindividuali_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfpositionsoglieindividuali_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfpositionsoglieindividuali_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfpositionsoglieindividuali_default.xsd";

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

	//////////////////// PERFPOSITIONSOGLIEINDIVIDUALI /////////////////////////////////
	var tperfpositionsoglieindividuali= new MetaTable("perfpositionsoglieindividuali");
	tperfpositionsoglieindividuali.defineColumn("ct", typeof(DateTime),false);
	tperfpositionsoglieindividuali.defineColumn("cu", typeof(string),false);
	tperfpositionsoglieindividuali.defineColumn("idmansionekind", typeof(int),false);
	tperfpositionsoglieindividuali.defineColumn("idperfpositionsoglieindividuali", typeof(int),false);
	tperfpositionsoglieindividuali.defineColumn("idperfsogliakind", typeof(string));
	tperfpositionsoglieindividuali.defineColumn("lt", typeof(DateTime),false);
	tperfpositionsoglieindividuali.defineColumn("lu", typeof(string),false);
	tperfpositionsoglieindividuali.defineColumn("valore", typeof(decimal));
	tperfpositionsoglieindividuali.defineColumn("year", typeof(int));
	Tables.Add(tperfpositionsoglieindividuali);
	tperfpositionsoglieindividuali.defineKey("idmansionekind", "idperfpositionsoglieindividuali");

	#endregion


	#region DataRelation creation
	var cPar = new []{year.Columns["year"]};
	var cChild = new []{perfpositionsoglieindividuali.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfpositionsoglieindividuali_year_year",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfpositionsoglieindividuali.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfpositionsoglieindividuali_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	#endregion

}
}
}
