
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_didproggrupp_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_didproggrupp_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproggruppcaratteristica 		=> (MetaTable)Tables["didproggruppcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno 		=> (MetaTable)Tables["didproganno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproggrupp 		=> (MetaTable)Tables["didproggrupp"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_didproggrupp_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_didproggrupp_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_didproggrupp_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_didproggrupp_default.xsd";

	#region create DataTables
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

	//////////////////// DIDPROGGRUPPCARATTERISTICA /////////////////////////////////
	var tdidproggruppcaratteristica= new MetaTable("didproggruppcaratteristica");
	tdidproggruppcaratteristica.defineColumn("cf", typeof(decimal));
	tdidproggruppcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tdidproggruppcaratteristica.defineColumn("cu", typeof(string),false);
	tdidproggruppcaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tdidproggruppcaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tdidproggruppcaratteristica.defineColumn("iddidprog", typeof(int),false);
	tdidproggruppcaratteristica.defineColumn("iddidproggrupp", typeof(int),false);
	tdidproggruppcaratteristica.defineColumn("iddidproggruppcaratteristica", typeof(int),false);
	tdidproggruppcaratteristica.defineColumn("idsasd", typeof(int));
	tdidproggruppcaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tdidproggruppcaratteristica.defineColumn("idtipoattform", typeof(int));
	tdidproggruppcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tdidproggruppcaratteristica.defineColumn("lu", typeof(string),false);
	tdidproggruppcaratteristica.defineColumn("profess", typeof(string),false);
	tdidproggruppcaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	tdidproggruppcaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tdidproggruppcaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	tdidproggruppcaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	tdidproggruppcaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	tdidproggruppcaratteristica.defineColumn("!idtipoattform_tipoattform_description", typeof(string));
	Tables.Add(tdidproggruppcaratteristica);
	tdidproggruppcaratteristica.defineKey("idcorsostudio", "iddidprog", "iddidproggrupp", "iddidproggruppcaratteristica");

	//////////////////// INSEGNINTEG /////////////////////////////////
	var tinsegninteg= new MetaTable("insegninteg");
	tinsegninteg.defineColumn("codice", typeof(string));
	tinsegninteg.defineColumn("denominazione", typeof(string));
	tinsegninteg.defineColumn("idinsegn", typeof(int),false);
	tinsegninteg.defineColumn("idinsegninteg", typeof(int),false);
	Tables.Add(tinsegninteg);
	tinsegninteg.defineKey("idinsegn", "idinsegninteg");

	//////////////////// INSEGN /////////////////////////////////
	var tinsegn= new MetaTable("insegn");
	tinsegn.defineColumn("codice", typeof(string));
	tinsegn.defineColumn("denominazione", typeof(string));
	tinsegn.defineColumn("idinsegn", typeof(int),false);
	Tables.Add(tinsegn);
	tinsegn.defineKey("idinsegn");

	//////////////////// DIDPROGPORZANNO /////////////////////////////////
	var tdidprogporzanno= new MetaTable("didprogporzanno");
	tdidprogporzanno.defineColumn("aa", typeof(string),false);
	tdidprogporzanno.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzanno.defineColumn("title", typeof(string));
	Tables.Add(tdidprogporzanno);
	tdidprogporzanno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// DIDPROGANNO /////////////////////////////////
	var tdidproganno= new MetaTable("didproganno");
	tdidproganno.defineColumn("aa", typeof(string),false);
	tdidproganno.defineColumn("idcorsostudio", typeof(int),false);
	tdidproganno.defineColumn("iddidprog", typeof(int),false);
	tdidproganno.defineColumn("iddidproganno", typeof(int),false);
	tdidproganno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidproganno.defineColumn("iddidprogori", typeof(int),false);
	tdidproganno.defineColumn("title", typeof(string));
	Tables.Add(tdidproganno);
	tdidproganno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori");

	//////////////////// ATTIVFORM /////////////////////////////////
	var tattivform= new MetaTable("attivform");
	tattivform.defineColumn("aa", typeof(string),false);
	tattivform.defineColumn("ct", typeof(DateTime),false);
	tattivform.defineColumn("cu", typeof(string),false);
	tattivform.defineColumn("idattivform", typeof(int),false);
	tattivform.defineColumn("idcorsostudio", typeof(int),false);
	tattivform.defineColumn("iddidprog", typeof(int),false);
	tattivform.defineColumn("iddidproganno", typeof(int),false);
	tattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform.defineColumn("iddidproggrupp", typeof(int));
	tattivform.defineColumn("iddidprogori", typeof(int),false);
	tattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform.defineColumn("idinsegn", typeof(int),false);
	tattivform.defineColumn("idinsegninteg", typeof(int));
	tattivform.defineColumn("idsede", typeof(int),false);
	tattivform.defineColumn("lt", typeof(DateTime),false);
	tattivform.defineColumn("lu", typeof(string),false);
	tattivform.defineColumn("obbform", typeof(string));
	tattivform.defineColumn("obbform_en", typeof(string));
	tattivform.defineColumn("sortcode", typeof(int));
	tattivform.defineColumn("start", typeof(DateTime));
	tattivform.defineColumn("stop", typeof(DateTime));
	tattivform.defineColumn("tipovalutaz", typeof(string));
	tattivform.defineColumn("title", typeof(string));
	tattivform.defineColumn("!iddidproganno_didproganno_title", typeof(string));
	tattivform.defineColumn("!iddidprogcurr_didprogcurr_title", typeof(string));
	tattivform.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tattivform.defineColumn("!iddidprogporzanno_didprogporzanno_title", typeof(string));
	tattivform.defineColumn("!idinsegn_insegn_denominazione", typeof(string));
	tattivform.defineColumn("!idinsegn_insegn_codice", typeof(string));
	tattivform.defineColumn("!idinsegninteg_insegninteg_denominazione", typeof(string));
	tattivform.defineColumn("!idinsegninteg_insegninteg_codice", typeof(string));
	tattivform.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// DIDPROGGRUPP /////////////////////////////////
	var tdidproggrupp= new MetaTable("didproggrupp");
	tdidproggrupp.defineColumn("codice", typeof(string));
	tdidproggrupp.defineColumn("ct", typeof(DateTime),false);
	tdidproggrupp.defineColumn("cu", typeof(string),false);
	tdidproggrupp.defineColumn("idcorsostudio", typeof(int),false);
	tdidproggrupp.defineColumn("iddidprog", typeof(int),false);
	tdidproggrupp.defineColumn("iddidproggrupp", typeof(int),false);
	tdidproggrupp.defineColumn("lt", typeof(DateTime),false);
	tdidproggrupp.defineColumn("lu", typeof(string),false);
	tdidproggrupp.defineColumn("title", typeof(string));
	Tables.Add(tdidproggrupp);
	tdidproggrupp.defineKey("idcorsostudio", "iddidprog", "iddidproggrupp");

	#endregion


	#region DataRelation creation
	var cPar = new []{didproggrupp.Columns["idcorsostudio"], didproggrupp.Columns["iddidprog"], didproggrupp.Columns["iddidproggrupp"]};
	var cChild = new []{didproggruppcaratteristica.Columns["idcorsostudio"], didproggruppcaratteristica.Columns["iddidprog"], didproggruppcaratteristica.Columns["iddidproggrupp"]};
	Relations.Add(new DataRelation("FK_didproggruppcaratteristica_didproggrupp_idcorsostudio-iddidprog-iddidproggrupp",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{didproggruppcaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_didproggruppcaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{didproggruppcaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_didproggruppcaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{didproggruppcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_didproggruppcaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{didproggruppcaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_didproggruppcaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{didproggrupp.Columns["idcorsostudio"], didproggrupp.Columns["iddidprog"], didproggrupp.Columns["iddidproggrupp"]};
	cChild = new []{attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproggrupp"]};
	Relations.Add(new DataRelation("FK_attivform_didproggrupp_idcorsostudio-iddidprog-iddidproggrupp",cPar,cChild,false));

	cPar = new []{insegninteg.Columns["idinsegninteg"]};
	cChild = new []{attivform.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_attivform_insegninteg_idinsegninteg",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{attivform.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_attivform_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{didprogporzanno.Columns["iddidprogporzanno"]};
	cChild = new []{attivform.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivform_didprogporzanno_iddidprogporzanno",cPar,cChild,false));

	cPar = new []{didprogori.Columns["iddidprogori"]};
	cChild = new []{attivform.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_attivform_didprogori_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{attivform.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_attivform_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didproganno.Columns["iddidproganno"]};
	cChild = new []{attivform.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_attivform_didproganno_iddidproganno",cPar,cChild,false));

	#endregion

}
}
}
