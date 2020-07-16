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
using meta_treasurer;
using meta_accmotive;
using meta_sorting;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace treasurer_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public treasurerTable treasurer 		=> (treasurerTable)Tables["treasurer"];

	///<summary>
	///Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bank 		=> (MetaTable)Tables["bank"];

	///<summary>
	///Sportello Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cab 		=> (MetaTable)Tables["cab"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive 		=> (accmotiveTable)Tables["accmotive"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveTable accmotive1 		=> (accmotiveTable)Tables["accmotive1"];

	///<summary>
	///Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bankcbi 		=> (MetaTable)Tables["bankcbi"];

	///<summary>
	///Sportello Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cabcbi 		=> (MetaTable)Tables["cabcbi"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting01 		=> (sortingTable)Tables["sorting01"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting02 		=> (sortingTable)Tables["sorting02"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting03 		=> (sortingTable)Tables["sorting03"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting04 		=> (sortingTable)Tables["sorting04"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public sortingTable sorting05 		=> (sortingTable)Tables["sorting05"];

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
	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new treasurerTable();
	ttreasurer.addBaseColumns("idtreasurer","codetreasurer","description","flagdefault","cin","idbank","idcab","cc","address","cap","city","country","ftpuser","ftppassword","ftpaddress","pasvmode","ftpport","phoneprefix","phonenumber","faxprefix","faxnumber","cu","ct","lu","lt","idsor01","idsor02","idsor03","idsor04","idsor05","agencycodefortransmission","depcodefortransmission","cabcodefortransmission","idaccmotive_proceeds","idaccmotive_payment","spexportexp","flagmultiexp","fileextension","spexportinc","iban","bic","flagfruitful","idbankcbi","idcabcbi","cccbi","cincbi","ibancbi","siacodecbi","reccbikind","trasmcode","flagbank_grouping","motivelen","motiveprefix","motiveseparator","annotations","flagedisp","billcode","active","flag","header","savepath","departmentname_fe","enable_ndoc_treasurer","flussocrediticode","ftpdir","tramite_bt_code","tramite_agency_code","agency_istat_code");
	Tables.Add(ttreasurer);
	ttreasurer.defineKey("idtreasurer");

	//////////////////// BANK /////////////////////////////////
	var tbank= new MetaTable("bank");
	tbank.defineColumn("idbank", typeof(string),false);
	tbank.defineColumn("description", typeof(string),false);
	tbank.defineColumn("cu", typeof(string),false);
	tbank.defineColumn("ct", typeof(DateTime),false);
	tbank.defineColumn("lu", typeof(string),false);
	tbank.defineColumn("lt", typeof(DateTime),false);
	tbank.defineColumn("flagusable", typeof(string));
	Tables.Add(tbank);
	tbank.defineKey("idbank");

	//////////////////// CAB /////////////////////////////////
	var tcab= new MetaTable("cab");
	tcab.defineColumn("idbank", typeof(string),false);
	tcab.defineColumn("idcab", typeof(string),false);
	tcab.defineColumn("description", typeof(string),false);
	tcab.defineColumn("address", typeof(string));
	tcab.defineColumn("cap", typeof(string));
	tcab.defineColumn("cu", typeof(string),false);
	tcab.defineColumn("ct", typeof(DateTime),false);
	tcab.defineColumn("lu", typeof(string),false);
	tcab.defineColumn("lt", typeof(DateTime),false);
	tcab.defineColumn("flagusable", typeof(string));
	Tables.Add(tcab);
	tcab.defineKey("idbank", "idcab");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new accmotiveTable();
	taccmotive.addBaseColumns("idaccmotive","active","codemotive","ct","cu","lt","lu","paridaccmotive","title");
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// ACCMOTIVE1 /////////////////////////////////
	var taccmotive1= new accmotiveTable();
	taccmotive1.TableName = "accmotive1";
	taccmotive1.addBaseColumns("idaccmotive","active","codemotive","ct","cu","lt","lu","paridaccmotive","title");
	taccmotive1.ExtendedProperties["TableForReading"]="accmotive";
	Tables.Add(taccmotive1);
	taccmotive1.defineKey("idaccmotive");

	//////////////////// BANKCBI /////////////////////////////////
	var tbankcbi= new MetaTable("bankcbi");
	tbankcbi.defineColumn("idbank", typeof(string),false);
	tbankcbi.defineColumn("ct", typeof(DateTime),false);
	tbankcbi.defineColumn("cu", typeof(string),false);
	tbankcbi.defineColumn("description", typeof(string),false);
	tbankcbi.defineColumn("flagusable", typeof(string));
	tbankcbi.defineColumn("lt", typeof(DateTime),false);
	tbankcbi.defineColumn("lu", typeof(string),false);
	tbankcbi.ExtendedProperties["TableForReading"]="bank";
	Tables.Add(tbankcbi);
	tbankcbi.defineKey("idbank");

	//////////////////// CABCBI /////////////////////////////////
	var tcabcbi= new MetaTable("cabcbi");
	tcabcbi.defineColumn("idbank", typeof(string),false);
	tcabcbi.defineColumn("idcab", typeof(string),false);
	tcabcbi.defineColumn("address", typeof(string));
	tcabcbi.defineColumn("cap", typeof(string));
	tcabcbi.defineColumn("ct", typeof(DateTime),false);
	tcabcbi.defineColumn("cu", typeof(string),false);
	tcabcbi.defineColumn("description", typeof(string),false);
	tcabcbi.defineColumn("flagusable", typeof(string));
	tcabcbi.defineColumn("lt", typeof(DateTime),false);
	tcabcbi.defineColumn("lu", typeof(string),false);
	tcabcbi.ExtendedProperties["TableForReading"]="cab";
	Tables.Add(tcabcbi);
	tcabcbi.defineKey("idbank", "idcab");

	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new sortingTable();
	tsorting01.TableName = "sorting01";
	tsorting01.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting01.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting01);
	tsorting01.defineKey("idsor");

	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new sortingTable();
	tsorting02.TableName = "sorting02";
	tsorting02.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting02.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting02);
	tsorting02.defineKey("idsor");

	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new sortingTable();
	tsorting03.TableName = "sorting03";
	tsorting03.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting03.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting03);
	tsorting03.defineKey("idsor");

	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new sortingTable();
	tsorting04.TableName = "sorting04";
	tsorting04.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting04.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting04);
	tsorting04.defineKey("idsor");

	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new sortingTable();
	tsorting05.TableName = "sorting05";
	tsorting05.addBaseColumns("ct","cu","defaultN1","defaultN2","defaultN3","defaultN4","defaultN5","defaultS1","defaultS2","defaultS3","defaultS4","defaultS5","defaultv1","defaultv2","defaultv3","defaultv4","defaultv5","description","flagnodate","lt","lu","movkind","printingorder","rtf","sortcode","txt","idsorkind","idsor","paridsor","nlevel","start","stop");
	tsorting05.ExtendedProperties["TableForReading"]="sorting";
	Tables.Add(tsorting05);
	tsorting05.defineKey("idsor");

	#endregion


	#region DataRelation creation
	var cPar = new []{cabcbi.Columns["idbank"], cabcbi.Columns["idcab"]};
	var cChild = new []{treasurer.Columns["idbankcbi"], treasurer.Columns["idcabcbi"]};
	Relations.Add(new DataRelation("FK_cabcbi_treasurer",cPar,cChild,false));

	cPar = new []{bankcbi.Columns["idbank"]};
	cChild = new []{treasurer.Columns["idbankcbi"]};
	Relations.Add(new DataRelation("FK_bankcbi_treasurer",cPar,cChild,false));

	this.defineRelation("banktreasurer","bank","treasurer","idbank");
	cPar = new []{accmotive1.Columns["idaccmotive"]};
	cChild = new []{treasurer.Columns["idaccmotive_payment"]};
	Relations.Add(new DataRelation("accmotive18treasurer",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{treasurer.Columns["idaccmotive_proceeds"]};
	Relations.Add(new DataRelation("accmotive16treasurer",cPar,cChild,false));

	this.defineRelation("cabtreasurer","cab","treasurer","idbank","idcab");
	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_treasurer",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_treasurer",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_treasurer",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_treasurer",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_treasurer",cPar,cChild,false));

	#endregion

}
}
}
