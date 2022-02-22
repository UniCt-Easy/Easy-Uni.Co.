
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfrequestobbunatantum_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfrequestobbunatantum_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfrequestobbunatantumsoglia 		=> (MetaTable)Tables["perfrequestobbunatantumsoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfrequestobbunatantum 		=> (MetaTable)Tables["perfrequestobbunatantum"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfrequestobbunatantum_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfrequestobbunatantum_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfrequestobbunatantum_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfrequestobbunatantum_default.xsd";

	#region create DataTables
	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFREQUESTOBBUNATANTUMSOGLIA /////////////////////////////////
	var tperfrequestobbunatantumsoglia= new MetaTable("perfrequestobbunatantumsoglia");
	tperfrequestobbunatantumsoglia.defineColumn("ct", typeof(DateTime),false);
	tperfrequestobbunatantumsoglia.defineColumn("cu", typeof(string),false);
	tperfrequestobbunatantumsoglia.defineColumn("idperfrequestobbunatantum", typeof(int),false);
	tperfrequestobbunatantumsoglia.defineColumn("idperfrequestobbunatantumsoglia", typeof(int),false);
	tperfrequestobbunatantumsoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfrequestobbunatantumsoglia.defineColumn("lt", typeof(DateTime),false);
	tperfrequestobbunatantumsoglia.defineColumn("lu", typeof(string),false);
	tperfrequestobbunatantumsoglia.defineColumn("percentuale", typeof(decimal));
	tperfrequestobbunatantumsoglia.defineColumn("valorenumerico", typeof(decimal));
	tperfrequestobbunatantumsoglia.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfrequestobbunatantumsoglia);
	tperfrequestobbunatantumsoglia.defineKey("idperfrequestobbunatantum", "idperfrequestobbunatantumsoglia");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFREQUESTOBBUNATANTUM /////////////////////////////////
	var tperfrequestobbunatantum= new MetaTable("perfrequestobbunatantum");
	tperfrequestobbunatantum.defineColumn("ct", typeof(DateTime),false);
	tperfrequestobbunatantum.defineColumn("cu", typeof(string),false);
	tperfrequestobbunatantum.defineColumn("description", typeof(string));
	tperfrequestobbunatantum.defineColumn("idperfrequestobbunatantum", typeof(int),false);
	tperfrequestobbunatantum.defineColumn("idstruttura", typeof(int),false);
	tperfrequestobbunatantum.defineColumn("inserito", typeof(string));
	tperfrequestobbunatantum.defineColumn("lt", typeof(DateTime),false);
	tperfrequestobbunatantum.defineColumn("lu", typeof(string),false);
	tperfrequestobbunatantum.defineColumn("peso", typeof(decimal));
	tperfrequestobbunatantum.defineColumn("title", typeof(string));
	tperfrequestobbunatantum.defineColumn("year", typeof(int));
	Tables.Add(tperfrequestobbunatantum);
	tperfrequestobbunatantum.defineKey("idperfrequestobbunatantum", "idstruttura");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfrequestobbunatantum.Columns["idperfrequestobbunatantum"]};
	var cChild = new []{perfrequestobbunatantumsoglia.Columns["idperfrequestobbunatantum"]};
	Relations.Add(new DataRelation("FK_perfrequestobbunatantumsoglia_perfrequestobbunatantum_idperfrequestobbunatantum",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfrequestobbunatantumsoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfrequestobbunatantumsoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{perfrequestobbunatantum.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfrequestobbunatantum_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfrequestobbunatantum.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfrequestobbunatantum_year_year",cPar,cChild,false));

	#endregion

}
}
}
