
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using meta_fin;
using meta_accmotiveapplied;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace clawbacksetup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Automatismi dei recuperi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable clawbacksetup 		=> (MetaTable)Tables["clawbacksetup"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin_e 		=> (finTable)Tables["fin_e"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable clawbacksetupview 		=> (MetaTable)Tables["clawbacksetupview"];

	///<summary>
	///Tipi di recupero
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable clawback 		=> (MetaTable)Tables["clawback"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied 		=> (accmotiveappliedTable)Tables["accmotiveapplied"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public finTable fin_s 		=> (finTable)Tables["fin_s"];

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
	//////////////////// CLAWBACKSETUP /////////////////////////////////
	var tclawbacksetup= new MetaTable("clawbacksetup");
	tclawbacksetup.defineColumn("idclawback", typeof(int),false);
	tclawbacksetup.defineColumn("ayear", typeof(short),false);
	tclawbacksetup.defineColumn("clawbackfinance", typeof(int));
	tclawbacksetup.defineColumn("txt", typeof(string));
	tclawbacksetup.defineColumn("rtf", typeof(Byte[]));
	tclawbacksetup.defineColumn("cu", typeof(string),false);
	tclawbacksetup.defineColumn("ct", typeof(DateTime),false);
	tclawbacksetup.defineColumn("lu", typeof(string),false);
	tclawbacksetup.defineColumn("lt", typeof(DateTime),false);
	tclawbacksetup.defineColumn("idaccmotive", typeof(string));
	tclawbacksetup.defineColumn("idfin_s", typeof(int));
	Tables.Add(tclawbacksetup);
	tclawbacksetup.defineKey("idclawback", "ayear");

	//////////////////// FIN_E /////////////////////////////////
	var tfin_e= new finTable();
	tfin_e.TableName = "fin_e";
	tfin_e.addBaseColumns("idfin","ayear","codefin","paridfin","nlevel","printingorder","title","txt","rtf","cu","ct","lu","lt");
	tfin_e.ExtendedProperties["TableForReading"]="fin";
	Tables.Add(tfin_e);
	tfin_e.defineKey("idfin");

	//////////////////// CLAWBACKSETUPVIEW /////////////////////////////////
	var tclawbacksetupview= new MetaTable("clawbacksetupview");
	tclawbacksetupview.defineColumn("idclawback", typeof(int),false);
	tclawbacksetupview.defineColumn("clawback", typeof(string),false);
	tclawbacksetupview.defineColumn("ayear", typeof(short),false);
	tclawbacksetupview.defineColumn("clawbackfinance", typeof(int));
	tclawbacksetupview.defineColumn("codefin", typeof(string));
	tclawbacksetupview.defineColumn("finance", typeof(string));
	tclawbacksetupview.defineColumn("cu", typeof(string),false);
	tclawbacksetupview.defineColumn("ct", typeof(DateTime),false);
	tclawbacksetupview.defineColumn("lu", typeof(string),false);
	tclawbacksetupview.defineColumn("lt", typeof(DateTime),false);
	tclawbacksetupview.defineColumn("idaccmotive", typeof(string));
	tclawbacksetupview.defineColumn("codemotive", typeof(string));
	tclawbacksetupview.defineColumn("accmotive", typeof(string));
	tclawbacksetupview.defineColumn("idfin_s", typeof(int));
	tclawbacksetupview.defineColumn("codefin_s", typeof(string));
	tclawbacksetupview.defineColumn("finance_s", typeof(string));
	Tables.Add(tclawbacksetupview);
	tclawbacksetupview.defineKey("idclawback", "ayear");

	//////////////////// CLAWBACK /////////////////////////////////
	var tclawback= new MetaTable("clawback");
	tclawback.defineColumn("idclawback", typeof(int),false);
	tclawback.defineColumn("description", typeof(string),false);
	tclawback.defineColumn("cu", typeof(string),false);
	tclawback.defineColumn("ct", typeof(DateTime),false);
	tclawback.defineColumn("lu", typeof(string),false);
	tclawback.defineColumn("lt", typeof(DateTime),false);
	tclawback.defineColumn("active", typeof(string));
	tclawback.defineColumn("flagf24ep", typeof(string));
	Tables.Add(tclawback);
	tclawback.defineKey("idclawback");

	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new accmotiveappliedTable();
	taccmotiveapplied.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation");
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.defineKey("idaccmotive");

	//////////////////// FIN_S /////////////////////////////////
	var tfin_s= new finTable();
	tfin_s.TableName = "fin_s";
	tfin_s.addBaseColumns("idfin","ayear","codefin","paridfin","nlevel","printingorder","title","txt","rtf","cu","ct","lu","lt");
	tfin_s.ExtendedProperties["TableForReading"]="fin";
	Tables.Add(tfin_s);
	tfin_s.defineKey("idfin");

	#endregion


	#region DataRelation creation
	this.defineRelation("accmotiveappliedclawbacksetup","accmotiveapplied","clawbacksetup","idaccmotive");
	var cPar = new []{fin_e.Columns["idfin"]};
	var cChild = new []{clawbacksetup.Columns["clawbackfinance"]};
	Relations.Add(new DataRelation("finclawbacksetup",cPar,cChild,false));

	this.defineRelation("clawbackclawbacksetup","clawback","clawbacksetup","idclawback");
	cPar = new []{fin_s.Columns["idfin"]};
	cChild = new []{clawbacksetup.Columns["idfin_s"]};
	Relations.Add(new DataRelation("fin_S_clawbacksetup",cPar,cChild,false));

	#endregion

}
}
}
