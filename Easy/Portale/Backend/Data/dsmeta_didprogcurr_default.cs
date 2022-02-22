
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
[System.Xml.Serialization.XmlRoot("dsmeta_didprogcurr_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_didprogcurr_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno 		=> (MetaTable)Tables["didproganno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurrcaratteristica 		=> (MetaTable)Tables["didprogcurrcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_didprogcurr_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_didprogcurr_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_didprogcurr_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_didprogcurr_default.xsd";

	#region create DataTables
	//////////////////// DIDPROGPORZANNO /////////////////////////////////
	var tdidprogporzanno= new MetaTable("didprogporzanno");
	tdidprogporzanno.defineColumn("aa", typeof(string),false);
	tdidprogporzanno.defineColumn("ct", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("cu", typeof(string),false);
	tdidprogporzanno.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzannokind", typeof(int));
	tdidprogporzanno.defineColumn("indice", typeof(int));
	tdidprogporzanno.defineColumn("lt", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("lu", typeof(string),false);
	tdidprogporzanno.defineColumn("start", typeof(DateTime));
	tdidprogporzanno.defineColumn("stop", typeof(DateTime));
	tdidprogporzanno.defineColumn("title", typeof(string));
	Tables.Add(tdidprogporzanno);
	tdidprogporzanno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// DIDPROGANNO /////////////////////////////////
	var tdidproganno= new MetaTable("didproganno");
	tdidproganno.defineColumn("aa", typeof(string),false);
	tdidproganno.defineColumn("anno", typeof(int));
	tdidproganno.defineColumn("cf", typeof(decimal));
	tdidproganno.defineColumn("ct", typeof(DateTime),false);
	tdidproganno.defineColumn("cu", typeof(string),false);
	tdidproganno.defineColumn("idcorsostudio", typeof(int),false);
	tdidproganno.defineColumn("iddidprog", typeof(int),false);
	tdidproganno.defineColumn("iddidproganno", typeof(int),false);
	tdidproganno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidproganno.defineColumn("iddidprogori", typeof(int),false);
	tdidproganno.defineColumn("lt", typeof(DateTime),false);
	tdidproganno.defineColumn("lu", typeof(string),false);
	tdidproganno.defineColumn("title", typeof(string));
	Tables.Add(tdidproganno);
	tdidproganno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("codice", typeof(string));
	tdidprogori.defineColumn("ct", typeof(DateTime),false);
	tdidprogori.defineColumn("cu", typeof(string),false);
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("lt", typeof(DateTime),false);
	tdidprogori.defineColumn("lu", typeof(string),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// TIPOATTFORM /////////////////////////////////
	var ttipoattform= new MetaTable("tipoattform");
	ttipoattform.defineColumn("description", typeof(string));
	ttipoattform.defineColumn("idtipoattform", typeof(int),false);
	ttipoattform.defineColumn("title", typeof(string),false);
	Tables.Add(ttipoattform);
	ttipoattform.defineKey("idtipoattform");

	//////////////////// SASDGRUPPO /////////////////////////////////
	var tsasdgruppo= new MetaTable("sasdgruppo");
	tsasdgruppo.defineColumn("idsasdgruppo", typeof(int),false);
	tsasdgruppo.defineColumn("idtipoattform", typeof(int),false);
	tsasdgruppo.defineColumn("title", typeof(string));
	Tables.Add(tsasdgruppo);
	tsasdgruppo.defineKey("idsasdgruppo", "idtipoattform");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// AMBITOAREADISC /////////////////////////////////
	var tambitoareadisc= new MetaTable("ambitoareadisc");
	tambitoareadisc.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadisc.defineColumn("title", typeof(string),false);
	Tables.Add(tambitoareadisc);
	tambitoareadisc.defineKey("idambitoareadisc");

	//////////////////// DIDPROGCURRCARATTERISTICA /////////////////////////////////
	var tdidprogcurrcaratteristica= new MetaTable("didprogcurrcaratteristica");
	tdidprogcurrcaratteristica.defineColumn("cf", typeof(decimal));
	tdidprogcurrcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tdidprogcurrcaratteristica.defineColumn("cu", typeof(string),false);
	tdidprogcurrcaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tdidprogcurrcaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurrcaratteristica.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurrcaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurrcaratteristica.defineColumn("iddidprogcurrcaratteristica", typeof(int),false);
	tdidprogcurrcaratteristica.defineColumn("idsasd", typeof(int));
	tdidprogcurrcaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tdidprogcurrcaratteristica.defineColumn("idtipoattform", typeof(int));
	tdidprogcurrcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tdidprogcurrcaratteristica.defineColumn("lu", typeof(string),false);
	tdidprogcurrcaratteristica.defineColumn("profess", typeof(string),false);
	tdidprogcurrcaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	tdidprogcurrcaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tdidprogcurrcaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	tdidprogcurrcaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	tdidprogcurrcaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	tdidprogcurrcaratteristica.defineColumn("!idtipoattform_tipoattform_description", typeof(string));
	Tables.Add(tdidprogcurrcaratteristica);
	tdidprogcurrcaratteristica.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogcurrcaratteristica");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("codice", typeof(string));
	tdidprogcurr.defineColumn("codicemiur", typeof(string));
	tdidprogcurr.defineColumn("ct", typeof(DateTime),false);
	tdidprogcurr.defineColumn("cu", typeof(string),false);
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("lt", typeof(DateTime),false);
	tdidprogcurr.defineColumn("lu", typeof(string),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	#endregion


	#region DataRelation creation
	var cPar = new []{didprogcurr.Columns["idcorsostudio"], didprogcurr.Columns["iddidprog"], didprogcurr.Columns["iddidprogcurr"]};
	var cChild = new []{didprogori.Columns["idcorsostudio"], didprogori.Columns["iddidprog"], didprogori.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_didprogori_didprogcurr_idcorsostudio-iddidprog-iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogori.Columns["idcorsostudio"], didprogori.Columns["iddidprog"], didprogori.Columns["iddidprogcurr"], didprogori.Columns["iddidprogori"]};
	cChild = new []{didproganno.Columns["idcorsostudio"], didproganno.Columns["iddidprog"], didproganno.Columns["iddidprogcurr"], didproganno.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_didproganno_didprogori_idcorsostudio-iddidprog-iddidprogcurr-iddidprogori",cPar,cChild,false));

	cPar = new []{didproganno.Columns["aa"], didproganno.Columns["idcorsostudio"], didproganno.Columns["iddidprog"], didproganno.Columns["iddidproganno"], didproganno.Columns["iddidprogcurr"], didproganno.Columns["iddidprogori"]};
	cChild = new []{didprogporzanno.Columns["aa"], didprogporzanno.Columns["idcorsostudio"], didprogporzanno.Columns["iddidprog"], didprogporzanno.Columns["iddidproganno"], didprogporzanno.Columns["iddidprogcurr"], didprogporzanno.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_didprogporzanno_didproganno_aa-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["idcorsostudio"], didprogcurr.Columns["iddidprog"], didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{didprogcurrcaratteristica.Columns["idcorsostudio"], didprogcurrcaratteristica.Columns["iddidprog"], didprogcurrcaratteristica.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_didprogcurrcaratteristica_didprogcurr_idcorsostudio-iddidprog-iddidprogcurr",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{didprogcurrcaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_didprogcurrcaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{didprogcurrcaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_didprogcurrcaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{didprogcurrcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_didprogcurrcaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{didprogcurrcaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_didprogcurrcaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	#endregion

}
}
}
