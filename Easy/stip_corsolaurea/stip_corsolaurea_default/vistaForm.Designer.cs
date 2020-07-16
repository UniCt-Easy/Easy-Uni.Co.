/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using meta_stip_corsolaurea;
using meta_upb;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace stip_corsolaurea_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///elenco voci prog. esterno segr. studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stip_voce 		=> (MetaTable)Tables["stip_voce"];

	///<summary>
	///elenco tasse  prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stip_tassa 		=> (MetaTable)Tables["stip_tassa"];

	///<summary>
	///elenco corsi laurea prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public stip_corsolaureaTable stip_corsolaurea 		=> (stip_corsolaureaTable)Tables["stip_corsolaurea"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public upbTable upb 		=> (upbTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting1 		=> (MetaTable)Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting3 		=> (MetaTable)Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sorting2 		=> (MetaTable)Tables["sorting2"];

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
	//////////////////// STIP_VOCE /////////////////////////////////
	var tstip_voce= new MetaTable("stip_voce");
	tstip_voce.defineColumn("idstipvoce", typeof(int),false);
	tstip_voce.defineColumn("codicevoce", typeof(string));
	tstip_voce.defineColumn("descrizione", typeof(string));
	tstip_voce.defineColumn("cu", typeof(string));
	tstip_voce.defineColumn("ct", typeof(DateTime),false);
	tstip_voce.defineColumn("lu", typeof(string));
	tstip_voce.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tstip_voce);
	tstip_voce.defineKey("idstipvoce");

	//////////////////// STIP_TASSA /////////////////////////////////
	var tstip_tassa= new MetaTable("stip_tassa");
	tstip_tassa.defineColumn("idstiptassa", typeof(int),false);
	tstip_tassa.defineColumn("codicetassa", typeof(string));
	tstip_tassa.defineColumn("descrizione", typeof(string));
	tstip_tassa.defineColumn("cu", typeof(string));
	tstip_tassa.defineColumn("ct", typeof(DateTime),false);
	tstip_tassa.defineColumn("lu", typeof(string));
	tstip_tassa.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tstip_tassa);
	tstip_tassa.defineKey("idstiptassa");

	//////////////////// STIP_CORSOLAUREA /////////////////////////////////
	var tstip_corsolaurea= new stip_corsolaureaTable();
	tstip_corsolaurea.addBaseColumns("idstipcorsolaurea","codicecorsolaurea","descrizione","idupb","cu","ct","lu","lt","anno","dipartimento","percorso","sede","codicedipartimento","codicepercorso","codicesede","descrizionecorsolaurea","codicecausale","causale","idstiptassa","idstipvoce","idsor1","idsor2","idsor3");
	Tables.Add(tstip_corsolaurea);
	tstip_corsolaurea.defineKey("idstipcorsolaurea");

	//////////////////// UPB /////////////////////////////////
	var tupb= new upbTable();
	tupb.addBaseColumns("idupb","active","assured","codeupb","ct","cu","expiration","granted","lt","lu","paridupb","previousappropriation","previousassessment","printingorder","requested","rtf","title","txt","idman","idunderwriter","cupcode","idsor01","idsor02","idsor03","idsor04","idsor05","flagactivity","flagkind","newcodeupb","idtreasurer","start","stop","cigcode","idepupbkind");
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new MetaTable("sorting1");
	tsorting1.defineColumn("idsorkind", typeof(int),false);
	tsorting1.defineColumn("idsor", typeof(int),false);
	tsorting1.defineColumn("sortcode", typeof(string),false);
	tsorting1.defineColumn("paridsor", typeof(int));
	tsorting1.defineColumn("nlevel", typeof(byte),false);
	tsorting1.defineColumn("description", typeof(string),false);
	tsorting1.defineColumn("txt", typeof(string));
	tsorting1.defineColumn("rtf", typeof(Byte[]));
	tsorting1.defineColumn("cu", typeof(string),false);
	tsorting1.defineColumn("ct", typeof(DateTime),false);
	tsorting1.defineColumn("lu", typeof(string),false);
	tsorting1.defineColumn("lt", typeof(DateTime),false);
	tsorting1.defineColumn("defaultN1", typeof(decimal));
	tsorting1.defineColumn("defaultN2", typeof(decimal));
	tsorting1.defineColumn("defaultN3", typeof(decimal));
	tsorting1.defineColumn("defaultN4", typeof(decimal));
	tsorting1.defineColumn("defaultN5", typeof(decimal));
	tsorting1.defineColumn("defaultS1", typeof(string));
	tsorting1.defineColumn("defaultS2", typeof(string));
	tsorting1.defineColumn("defaultS3", typeof(string));
	tsorting1.defineColumn("defaultS4", typeof(string));
	tsorting1.defineColumn("defaultS5", typeof(string));
	tsorting1.defineColumn("flagnodate", typeof(string));
	tsorting1.defineColumn("movkind", typeof(string));
	tsorting1.defineColumn("printingorder", typeof(string));
	tsorting1.defineColumn("defaultv1", typeof(decimal));
	tsorting1.defineColumn("defaultv2", typeof(decimal));
	tsorting1.defineColumn("defaultv3", typeof(decimal));
	tsorting1.defineColumn("defaultv4", typeof(decimal));
	tsorting1.defineColumn("defaultv5", typeof(decimal));
	Tables.Add(tsorting1);
	tsorting1.defineKey("idsor");

	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new MetaTable("sorting3");
	tsorting3.defineColumn("idsorkind", typeof(int),false);
	tsorting3.defineColumn("idsor", typeof(int),false);
	tsorting3.defineColumn("sortcode", typeof(string),false);
	tsorting3.defineColumn("paridsor", typeof(int));
	tsorting3.defineColumn("nlevel", typeof(byte),false);
	tsorting3.defineColumn("description", typeof(string),false);
	tsorting3.defineColumn("txt", typeof(string));
	tsorting3.defineColumn("rtf", typeof(Byte[]));
	tsorting3.defineColumn("cu", typeof(string),false);
	tsorting3.defineColumn("ct", typeof(DateTime),false);
	tsorting3.defineColumn("lu", typeof(string),false);
	tsorting3.defineColumn("lt", typeof(DateTime),false);
	tsorting3.defineColumn("defaultN1", typeof(decimal));
	tsorting3.defineColumn("defaultN2", typeof(decimal));
	tsorting3.defineColumn("defaultN3", typeof(decimal));
	tsorting3.defineColumn("defaultN4", typeof(decimal));
	tsorting3.defineColumn("defaultN5", typeof(decimal));
	tsorting3.defineColumn("defaultS1", typeof(string));
	tsorting3.defineColumn("defaultS2", typeof(string));
	tsorting3.defineColumn("defaultS3", typeof(string));
	tsorting3.defineColumn("defaultS4", typeof(string));
	tsorting3.defineColumn("defaultS5", typeof(string));
	tsorting3.defineColumn("flagnodate", typeof(string));
	tsorting3.defineColumn("movkind", typeof(string));
	tsorting3.defineColumn("printingorder", typeof(string));
	tsorting3.defineColumn("defaultv1", typeof(decimal));
	tsorting3.defineColumn("defaultv2", typeof(decimal));
	tsorting3.defineColumn("defaultv3", typeof(decimal));
	tsorting3.defineColumn("defaultv4", typeof(decimal));
	tsorting3.defineColumn("defaultv5", typeof(decimal));
	Tables.Add(tsorting3);
	tsorting3.defineKey("idsor");

	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new MetaTable("sorting2");
	tsorting2.defineColumn("idsorkind", typeof(int),false);
	tsorting2.defineColumn("idsor", typeof(int),false);
	tsorting2.defineColumn("sortcode", typeof(string),false);
	tsorting2.defineColumn("paridsor", typeof(int));
	tsorting2.defineColumn("nlevel", typeof(byte),false);
	tsorting2.defineColumn("description", typeof(string),false);
	tsorting2.defineColumn("txt", typeof(string));
	tsorting2.defineColumn("rtf", typeof(Byte[]));
	tsorting2.defineColumn("cu", typeof(string),false);
	tsorting2.defineColumn("ct", typeof(DateTime),false);
	tsorting2.defineColumn("lu", typeof(string),false);
	tsorting2.defineColumn("lt", typeof(DateTime),false);
	tsorting2.defineColumn("defaultN1", typeof(decimal));
	tsorting2.defineColumn("defaultN2", typeof(decimal));
	tsorting2.defineColumn("defaultN3", typeof(decimal));
	tsorting2.defineColumn("defaultN4", typeof(decimal));
	tsorting2.defineColumn("defaultN5", typeof(decimal));
	tsorting2.defineColumn("defaultS1", typeof(string));
	tsorting2.defineColumn("defaultS2", typeof(string));
	tsorting2.defineColumn("defaultS3", typeof(string));
	tsorting2.defineColumn("defaultS4", typeof(string));
	tsorting2.defineColumn("defaultS5", typeof(string));
	tsorting2.defineColumn("flagnodate", typeof(string));
	tsorting2.defineColumn("movkind", typeof(string));
	tsorting2.defineColumn("printingorder", typeof(string));
	tsorting2.defineColumn("defaultv1", typeof(decimal));
	tsorting2.defineColumn("defaultv2", typeof(decimal));
	tsorting2.defineColumn("defaultv3", typeof(decimal));
	tsorting2.defineColumn("defaultv4", typeof(decimal));
	tsorting2.defineColumn("defaultv5", typeof(decimal));
	Tables.Add(tsorting2);
	tsorting2.defineKey("idsor");

	#endregion


	#region DataRelation creation
	this.defineRelation("upb_stip_corsolaurea","upb","stip_corsolaurea","idupb");
	var cPar = new []{sorting1.Columns["idsor"]};
	var cChild = new []{stip_corsolaurea.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_stip_corsolaurea",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{stip_corsolaurea.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_stip_corsolaurea",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{stip_corsolaurea.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_stip_corsolaurea",cPar,cChild,false));

	this.defineRelation("stip_tassa_stip_corsolaurea","stip_tassa","stip_corsolaurea","idstiptassa");
	this.defineRelation("stip_voce_stip_corsolaurea","stip_voce","stip_corsolaurea","idstipvoce");
	#endregion

}
}
}
