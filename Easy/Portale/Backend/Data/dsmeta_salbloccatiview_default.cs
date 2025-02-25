
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_salbloccatiview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_salbloccatiview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salbloccatiview 		=> (MetaTable)Tables["salbloccatiview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_salbloccatiview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_salbloccatiview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_salbloccatiview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_salbloccatiview_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// SALBLOCCATIVIEW /////////////////////////////////
	var tsalbloccatiview= new MetaTable("salbloccatiview");
	tsalbloccatiview.defineColumn("acronimo", typeof(string));
	tsalbloccatiview.defineColumn("datablocco", typeof(DateTime));
	tsalbloccatiview.defineColumn("idprogetto", typeof(int),false);
	tsalbloccatiview.defineColumn("idreg", typeof(int),false);
	tsalbloccatiview.defineColumn("idsal", typeof(int),false);
	tsalbloccatiview.defineColumn("referenti", typeof(string));
	tsalbloccatiview.defineColumn("start", typeof(DateTime));
	tsalbloccatiview.defineColumn("stop", typeof(DateTime));
	tsalbloccatiview.defineColumn("year", typeof(int),false);
	Tables.Add(tsalbloccatiview);
	tsalbloccatiview.defineKey("idprogetto", "idreg", "idsal");

	#endregion


	#region DataRelation creation
	var cPar = new []{year.Columns["year"]};
	var cChild = new []{salbloccatiview.Columns["year"]};
	Relations.Add(new DataRelation("FK_salbloccatiview_year_year",cPar,cChild,false));

	#endregion

}
}
}
