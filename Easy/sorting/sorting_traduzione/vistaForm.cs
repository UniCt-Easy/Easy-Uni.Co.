
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using meta_sorting;
using meta_sortingkind;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace sorting_traduzione {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting 		=> (sortingTable)Tables["sorting"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable tipoclassmovimenti_dest 		=> (sortingkindTable)Tables["tipoclassmovimenti_dest"];

	///<summary>
	///Traduzione classificazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingtranslation 		=> (MetaTable)Tables["sortingtranslation"];

	///<summary>
	///Livello Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortinglevel 		=> (MetaTable)Tables["sortinglevel"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable classmovimenti_dest 		=> (sortingTable)Tables["classmovimenti_dest"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingkindTable sortingkind 		=> (sortingkindTable)Tables["sortingkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// SORTING /////////////////////////////////
	var tsorting= new sortingTable();
	tsorting.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","flagnodate","movkind","start","idsor01","idsor02","idsor03","idsor04","idsor05","stop");
	Tables.Add(tsorting);
	tsorting.defineKey("idsor");

	//////////////////// TIPOCLASSMOVIMENTI_DEST /////////////////////////////////
	var ttipoclassmovimenti_dest= new sortingkindTable();
	ttipoclassmovimenti_dest.TableName = "tipoclassmovimenti_dest";
	ttipoclassmovimenti_dest.addBaseColumns("idsorkind","codesorkind","description","nphaseincome","nphaseexpense","flag","cu","ct","lu","lt","forcedN1","forcedN2","forcedN3","forcedN4","forcedN5","forcedS1","forcedS2","forcedS3","forcedS4","forcedS5","lockedN1","lockedN2","lockedN3","lockedN4","lockedN5","lockedS1","lockedS2","lockedS3","lockedS4","lockedS5","labeln1","labeln2","labeln3","labeln4","labeln5","labels1","labels2","labels3","labels4","labels5","flagdate","labelfordate","nodatelabel","totalexpression","labelv1","lockedv1","forcedv1","labelv2","lockedv2","forcedv2","labelv3","lockedv3","forcedv3","labelv4","lockedv4","forcedv4","labelv5","allowedS1","allowedS2","allowedS3","allowedS4","allowedS5","lockedv5","forcedv5");
	ttipoclassmovimenti_dest.ExtendedProperties["TableForReading"]="sortingkind";
	Tables.Add(ttipoclassmovimenti_dest);
	ttipoclassmovimenti_dest.defineKey("idsorkind");

	//////////////////// SORTINGTRANSLATION /////////////////////////////////
	var tsortingtranslation= new MetaTable("sortingtranslation");
	tsortingtranslation.defineColumn("idsortingmaster", typeof(int),false);
	tsortingtranslation.defineColumn("idsortingchild", typeof(int),false);
	tsortingtranslation.defineColumn("numerator", typeof(int));
	tsortingtranslation.defineColumn("denominator", typeof(int));
	tsortingtranslation.defineColumn("defaultn1", typeof(string));
	tsortingtranslation.defineColumn("defaultn2", typeof(string));
	tsortingtranslation.defineColumn("defaultn3", typeof(string));
	tsortingtranslation.defineColumn("defaultn4", typeof(string));
	tsortingtranslation.defineColumn("defaultn5", typeof(string));
	tsortingtranslation.defineColumn("defaults1", typeof(string));
	tsortingtranslation.defineColumn("defaults2", typeof(string));
	tsortingtranslation.defineColumn("defaults3", typeof(string));
	tsortingtranslation.defineColumn("defaults4", typeof(string));
	tsortingtranslation.defineColumn("defaults5", typeof(string));
	tsortingtranslation.defineColumn("defaultv1", typeof(string));
	tsortingtranslation.defineColumn("defaultv2", typeof(string));
	tsortingtranslation.defineColumn("defaultv3", typeof(string));
	tsortingtranslation.defineColumn("defaultv4", typeof(string));
	tsortingtranslation.defineColumn("defaultv5", typeof(string));
	tsortingtranslation.defineColumn("flagnodate", typeof(string));
	tsortingtranslation.defineColumn("cu", typeof(string),false);
	tsortingtranslation.defineColumn("ct", typeof(DateTime),false);
	tsortingtranslation.defineColumn("lu", typeof(string),false);
	tsortingtranslation.defineColumn("lt", typeof(DateTime),false);
	tsortingtranslation.defineColumn("percentage", typeof(decimal));
	tsortingtranslation.defineColumn("!frazione", typeof(string));
	tsortingtranslation.defineColumn("!tipo1", typeof(string));
	tsortingtranslation.defineColumn("!codice1", typeof(string));
	tsortingtranslation.defineColumn("!classificazione1", typeof(string));
	tsortingtranslation.defineColumn("!tipo2", typeof(string));
	tsortingtranslation.defineColumn("!codice2", typeof(string));
	tsortingtranslation.defineColumn("!classificazione2", typeof(string));
	tsortingtranslation.defineColumn("!sortingkindmaster", typeof(int));
	tsortingtranslation.defineColumn("!sortingkindchild", typeof(int));
	Tables.Add(tsortingtranslation);
	tsortingtranslation.defineKey("idsortingmaster", "idsortingchild");

	//////////////////// SORTINGLEVEL /////////////////////////////////
	var tsortinglevel= new MetaTable("sortinglevel");
	tsortinglevel.defineColumn("nlevel", typeof(byte),false);
	tsortinglevel.defineColumn("idsorkind", typeof(int),false);
	tsortinglevel.defineColumn("description", typeof(string),false);
	tsortinglevel.defineColumn("cu", typeof(string),false);
	tsortinglevel.defineColumn("ct", typeof(DateTime),false);
	tsortinglevel.defineColumn("lu", typeof(string),false);
	tsortinglevel.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tsortinglevel);
	tsortinglevel.defineKey("nlevel", "idsorkind");

	//////////////////// CLASSMOVIMENTI_DEST /////////////////////////////////
	var tclassmovimenti_dest= new sortingTable();
	tclassmovimenti_dest.TableName = "classmovimenti_dest";
	tclassmovimenti_dest.addBaseColumns("idsorkind","idsor","sortcode","paridsor","nlevel","description","txt","rtf","cu","ct","lu","lt","defaultn1","defaultn2","defaultn3","defaultn4","defaultn5","defaults1","defaults2","defaults3","defaults4","defaults5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","flagnodate","movkind");
	tclassmovimenti_dest.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tclassmovimenti_dest);
	tclassmovimenti_dest.defineKey("idsor");

	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new sortingkindTable();
	tsortingkind.addBaseColumns("active","ct","cu","description","flagdate","forcedN1","forcedN2","forcedN3","forcedN4","forcedN5","forcedS1","forcedS2","forcedS3","forcedS4","forcedS5","forcedv1","forcedv2","forcedv3","forcedv4","forcedv5","labelfordate","labeln1","labeln2","labeln3","labeln4","labeln5","labels1","labels2","labels3","labels4","labels5","labelv1","labelv2","labelv3","labelv4","labelv5","lockedN1","lockedN2","lockedN3","lockedN4","lockedN5","lockedS1","lockedS2","lockedS3","lockedS4","lockedS5","lockedv1","lockedv2","lockedv3","lockedv4","lockedv5","lt","lu","nodatelabel","totalexpression","nphaseexpense","nphaseincome","codesorkind","idsorkind","flag","start","stop","idparentkind","allowedS1","allowedS2","allowedS3","allowedS4","allowedS5");
	Tables.Add(tsortingkind);
	tsortingkind.defineKey("idsorkind");

	#endregion


	#region DataRelation creation
	this.defineRelation("tipoclassmovimenti_dest_classmovimenti_dest","tipoclassmovimenti_dest","classmovimenti_dest","idsorkind");
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{sortingtranslation.Columns["idsortingmaster"]};
	Relations.Add(new DataRelation("sortingsortingtranslation",cPar,cChild,false));

	cPar = new []{classmovimenti_dest.Columns["idsor"]};
	cChild = new []{sortingtranslation.Columns["idsortingchild"]};
	Relations.Add(new DataRelation("classmovimenti_destsortingtranslation",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sorting.Columns["paridsor"]};
	Relations.Add(new DataRelation("sortingsorting",cPar,cChild,false));

	this.defineRelation("sortinglevelsorting","sortinglevel","sorting","nlevel","idsorkind");
	this.defineRelation("tipoclassmovimenti_dest_sorting","tipoclassmovimenti_dest","sorting","idsorkind");
	this.defineRelation("sortingkind_sorting","sortingkind","sorting","idsorkind");
	#endregion

}
}
}
