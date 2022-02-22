
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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_sisest_corsolaurea;
using metadatalibrary;
namespace sisest_corsolaurea_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public sisest_corsolaureaTable sisest_corsolaurea 		{get { return (sisest_corsolaureaTable )Tables["sisest_corsolaurea"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable sorting3 		{get { return (MetaTable)Tables["sorting3"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable sorting1 		{get { return (MetaTable)Tables["sorting1"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable sorting2 		{get { return (MetaTable)Tables["sorting2"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public dsmeta(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";
	EnforceConstraints = false;

	#region create DataTables
	MetaTable T;
	//////////////////// SISEST_CORSOLAUREA /////////////////////////////////
	var tsisest_corsolaurea= new sisest_corsolaureaTable();
	tsisest_corsolaurea.addBaseColumns("idcorsolaurea","descrizione","codicecorso","idsor1","idsor2","idsor3","lt","lu");
	Tables.Add(tsisest_corsolaurea);
	tsisest_corsolaurea.defineKey("idcorsolaurea");

	//////////////////// SORTING3 /////////////////////////////////
	T= new MetaTable("sorting3");
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("defaultN1", typeof(Decimal));
	T.defineColumn("defaultN2", typeof(Decimal));
	T.defineColumn("defaultN3", typeof(Decimal));
	T.defineColumn("defaultN4", typeof(Decimal));
	T.defineColumn("defaultN5", typeof(Decimal));
	T.defineColumn("defaultS1", typeof(String));
	T.defineColumn("defaultS2", typeof(String));
	T.defineColumn("defaultS3", typeof(String));
	T.defineColumn("defaultS4", typeof(String));
	T.defineColumn("defaultS5", typeof(String));
	T.defineColumn("defaultv1", typeof(Decimal));
	T.defineColumn("defaultv2", typeof(Decimal));
	T.defineColumn("defaultv3", typeof(Decimal));
	T.defineColumn("defaultv4", typeof(Decimal));
	T.defineColumn("defaultv5", typeof(Decimal));
	T.defineColumn("description", typeof(String),false);
	T.defineColumn("flagnodate", typeof(String));
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("movkind", typeof(String));
	T.defineColumn("printingorder", typeof(String));
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("sortcode", typeof(String),false);
	T.defineColumn("txt", typeof(String));
	T.defineColumn("idsorkind", typeof(Int32),false);
	T.defineColumn("idsor", typeof(Int32),false);
	T.defineColumn("paridsor", typeof(Int32));
	T.defineColumn("nlevel", typeof(Byte),false);
	T.defineColumn("start", typeof(Int16));
	T.defineColumn("stop", typeof(Int16));
	T.defineColumn("email", typeof(String));
	Tables.Add(T);
	T.defineKey("idsor");

	//////////////////// SORTING1 /////////////////////////////////
	T= new MetaTable("sorting1");
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("defaultN1", typeof(Decimal));
	T.defineColumn("defaultN2", typeof(Decimal));
	T.defineColumn("defaultN3", typeof(Decimal));
	T.defineColumn("defaultN4", typeof(Decimal));
	T.defineColumn("defaultN5", typeof(Decimal));
	T.defineColumn("defaultS1", typeof(String));
	T.defineColumn("defaultS2", typeof(String));
	T.defineColumn("defaultS3", typeof(String));
	T.defineColumn("defaultS4", typeof(String));
	T.defineColumn("defaultS5", typeof(String));
	T.defineColumn("defaultv1", typeof(Decimal));
	T.defineColumn("defaultv2", typeof(Decimal));
	T.defineColumn("defaultv3", typeof(Decimal));
	T.defineColumn("defaultv4", typeof(Decimal));
	T.defineColumn("defaultv5", typeof(Decimal));
	T.defineColumn("description", typeof(String),false);
	T.defineColumn("flagnodate", typeof(String));
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("movkind", typeof(String));
	T.defineColumn("printingorder", typeof(String));
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("sortcode", typeof(String),false);
	T.defineColumn("txt", typeof(String));
	T.defineColumn("idsorkind", typeof(Int32),false);
	T.defineColumn("idsor", typeof(Int32),false);
	T.defineColumn("paridsor", typeof(Int32));
	T.defineColumn("nlevel", typeof(Byte),false);
	T.defineColumn("start", typeof(Int16));
	T.defineColumn("stop", typeof(Int16));
	T.defineColumn("email", typeof(String));
	Tables.Add(T);
	T.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	T= new MetaTable("sorting2");
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("defaultN1", typeof(Decimal));
	T.defineColumn("defaultN2", typeof(Decimal));
	T.defineColumn("defaultN3", typeof(Decimal));
	T.defineColumn("defaultN4", typeof(Decimal));
	T.defineColumn("defaultN5", typeof(Decimal));
	T.defineColumn("defaultS1", typeof(String));
	T.defineColumn("defaultS2", typeof(String));
	T.defineColumn("defaultS3", typeof(String));
	T.defineColumn("defaultS4", typeof(String));
	T.defineColumn("defaultS5", typeof(String));
	T.defineColumn("defaultv1", typeof(Decimal));
	T.defineColumn("defaultv2", typeof(Decimal));
	T.defineColumn("defaultv3", typeof(Decimal));
	T.defineColumn("defaultv4", typeof(Decimal));
	T.defineColumn("defaultv5", typeof(Decimal));
	T.defineColumn("description", typeof(String),false);
	T.defineColumn("flagnodate", typeof(String));
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("movkind", typeof(String));
	T.defineColumn("printingorder", typeof(String));
	T.defineColumn("rtf", typeof(Byte[]));
	T.defineColumn("sortcode", typeof(String),false);
	T.defineColumn("txt", typeof(String));
	T.defineColumn("idsorkind", typeof(Int32),false);
	T.defineColumn("idsor", typeof(Int32),false);
	T.defineColumn("paridsor", typeof(Int32));
	T.defineColumn("nlevel", typeof(Byte),false);
	T.defineColumn("start", typeof(Int16));
	T.defineColumn("stop", typeof(Int16));
	T.defineColumn("email", typeof(String));
	Tables.Add(T);
	T.defineKey("idsor");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{sorting3.Columns["idsor"]};
	CChild = new DataColumn[1]{sisest_corsolaurea.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_sisest_corsolaurea",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting1.Columns["idsor"]};
	CChild = new DataColumn[1]{sisest_corsolaurea.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_sisest_corsolaurea",CPar,CChild,false));

	CPar = new DataColumn[1]{sorting2.Columns["idsor"]};
	CChild = new DataColumn[1]{sisest_corsolaurea.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_sisest_corsolaurea",CPar,CChild,false));

	#endregion

}
}
}
