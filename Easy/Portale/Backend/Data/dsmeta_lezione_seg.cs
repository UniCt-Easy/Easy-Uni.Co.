
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
[System.Xml.Serialization.XmlRoot("dsmeta_lezione_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_lezione_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable auladefaultview 		=> (MetaTable)Tables["auladefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable edificiodefaultview 		=> (MetaTable)Tables["edificiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_docenti 		=> (MetaTable)Tables["registry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamento 		=> (MetaTable)Tables["affidamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione 		=> (MetaTable)Tables["lezione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_lezione_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_lezione_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_lezione_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_lezione_seg.xsd";

	#region create DataTables
	//////////////////// AULADEFAULTVIEW /////////////////////////////////
	var tauladefaultview= new MetaTable("auladefaultview");
	tauladefaultview.defineColumn("dropdown_title", typeof(string),false);
	tauladefaultview.defineColumn("idaula", typeof(int),false);
	tauladefaultview.defineColumn("idcity", typeof(int));
	tauladefaultview.defineColumn("idedificio", typeof(int),false);
	tauladefaultview.defineColumn("idnation", typeof(int));
	tauladefaultview.defineColumn("idsede", typeof(int),false);
	tauladefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tauladefaultview);
	tauladefaultview.defineKey("idaula");

	//////////////////// EDIFICIODEFAULTVIEW /////////////////////////////////
	var tedificiodefaultview= new MetaTable("edificiodefaultview");
	tedificiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tedificiodefaultview.defineColumn("idcity", typeof(int));
	tedificiodefaultview.defineColumn("idedificio", typeof(int),false);
	tedificiodefaultview.defineColumn("idnation", typeof(int));
	tedificiodefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tedificiodefaultview);
	tedificiodefaultview.defineKey("idedificio");

	//////////////////// REGISTRY_DOCENTI /////////////////////////////////
	var tregistry_docenti= new MetaTable("registry_docenti");
	tregistry_docenti.defineColumn("ct", typeof(DateTime),false);
	tregistry_docenti.defineColumn("cu", typeof(string),false);
	tregistry_docenti.defineColumn("cv", typeof(string));
	tregistry_docenti.defineColumn("idclassconsorsuale", typeof(int));
	tregistry_docenti.defineColumn("idcontrattokind", typeof(int));
	tregistry_docenti.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("idreg", typeof(int),false);
	tregistry_docenti.defineColumn("idreg_istituti", typeof(int));
	tregistry_docenti.defineColumn("idsasd", typeof(int));
	tregistry_docenti.defineColumn("idstruttura", typeof(int));
	tregistry_docenti.defineColumn("indicebibliometrico", typeof(int));
	tregistry_docenti.defineColumn("lt", typeof(DateTime),false);
	tregistry_docenti.defineColumn("lu", typeof(string),false);
	tregistry_docenti.defineColumn("matricola", typeof(string));
	tregistry_docenti.defineColumn("ricevimento", typeof(string));
	tregistry_docenti.defineColumn("soggiorno", typeof(string));
	Tables.Add(tregistry_docenti);
	tregistry_docenti.defineKey("idreg");

	//////////////////// AFFIDAMENTO /////////////////////////////////
	var taffidamento= new MetaTable("affidamento");
	taffidamento.defineColumn("aa", typeof(string),false);
	taffidamento.defineColumn("ct", typeof(DateTime),false);
	taffidamento.defineColumn("cu", typeof(string),false);
	taffidamento.defineColumn("freqobbl", typeof(string));
	taffidamento.defineColumn("frequenzaminima", typeof(int));
	taffidamento.defineColumn("frequenzaminimadebito", typeof(int));
	taffidamento.defineColumn("gratuito", typeof(string),false);
	taffidamento.defineColumn("idaffidamento", typeof(int),false);
	taffidamento.defineColumn("idaffidamentokind", typeof(int),false);
	taffidamento.defineColumn("idattivform", typeof(int),false);
	taffidamento.defineColumn("idcanale", typeof(int),false);
	taffidamento.defineColumn("idcorsostudio", typeof(int),false);
	taffidamento.defineColumn("iddidprog", typeof(int),false);
	taffidamento.defineColumn("iddidproganno", typeof(int),false);
	taffidamento.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamento.defineColumn("iddidprogori", typeof(int),false);
	taffidamento.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamento.defineColumn("iderogazkind", typeof(int));
	taffidamento.defineColumn("idreg_docenti", typeof(int));
	taffidamento.defineColumn("idsede", typeof(int),false);
	taffidamento.defineColumn("json", typeof(string));
	taffidamento.defineColumn("jsonancestor", typeof(string));
	taffidamento.defineColumn("lt", typeof(DateTime),false);
	taffidamento.defineColumn("lu", typeof(string),false);
	taffidamento.defineColumn("orariric", typeof(string));
	taffidamento.defineColumn("orariric_en", typeof(string));
	taffidamento.defineColumn("paridaffidamento", typeof(int));
	taffidamento.defineColumn("prog", typeof(string));
	taffidamento.defineColumn("prog_en", typeof(string));
	taffidamento.defineColumn("riferimento", typeof(string),false);
	taffidamento.defineColumn("start", typeof(DateTime));
	taffidamento.defineColumn("stop", typeof(DateTime));
	taffidamento.defineColumn("testi", typeof(string));
	taffidamento.defineColumn("testi_en", typeof(string));
	taffidamento.defineColumn("title", typeof(string));
	taffidamento.defineColumn("urlcorso", typeof(string));
	Tables.Add(taffidamento);
	taffidamento.defineKey("aa", "idaffidamento", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// LEZIONE /////////////////////////////////
	var tlezione= new MetaTable("lezione");
	tlezione.defineColumn("!title", typeof(string));
	tlezione.defineColumn("aa", typeof(string),false);
	tlezione.defineColumn("ct", typeof(DateTime),false);
	tlezione.defineColumn("cu", typeof(string),false);
	tlezione.defineColumn("idaffidamento", typeof(int),false);
	tlezione.defineColumn("idattivform", typeof(int),false);
	tlezione.defineColumn("idaula", typeof(int),false);
	tlezione.defineColumn("idcanale", typeof(int),false);
	tlezione.defineColumn("idcorsostudio", typeof(int),false);
	tlezione.defineColumn("iddidprog", typeof(int),false);
	tlezione.defineColumn("iddidproganno", typeof(int),false);
	tlezione.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione.defineColumn("iddidprogori", typeof(int),false);
	tlezione.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione.defineColumn("idedificio", typeof(int),false);
	tlezione.defineColumn("idlezione", typeof(int),false);
	tlezione.defineColumn("idreg_docenti", typeof(int),false);
	tlezione.defineColumn("idsede", typeof(int),false);
	tlezione.defineColumn("lt", typeof(DateTime),false);
	tlezione.defineColumn("lu", typeof(string),false);
	tlezione.defineColumn("nonsvolta", typeof(string));
	tlezione.defineColumn("stage", typeof(string));
	tlezione.defineColumn("start", typeof(DateTime),false);
	tlezione.defineColumn("stop", typeof(DateTime),false);
	tlezione.defineColumn("visita", typeof(string));
	Tables.Add(tlezione);
	tlezione.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{auladefaultview.Columns["idaula"]};
	var cChild = new []{lezione.Columns["idaula"]};
	Relations.Add(new DataRelation("FK_lezione_auladefaultview_idaula",cPar,cChild,false));

	cPar = new []{edificiodefaultview.Columns["idedificio"]};
	cChild = new []{auladefaultview.Columns["idedificio"]};
	Relations.Add(new DataRelation("FK_auladefaultview_edificiodefaultview_idedificio",cPar,cChild,false));

	cPar = new []{edificiodefaultview.Columns["idedificio"]};
	cChild = new []{lezione.Columns["idedificio"]};
	Relations.Add(new DataRelation("FK_lezione_edificiodefaultview_idedificio",cPar,cChild,false));

	cPar = new []{registry_docenti.Columns["idreg"]};
	cChild = new []{lezione.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_lezione_registry_docenti_idreg_docenti",cPar,cChild,false));

	cPar = new []{affidamento.Columns["idaffidamento"]};
	cChild = new []{lezione.Columns["idaffidamento"]};
	Relations.Add(new DataRelation("FK_lezione_affidamento_idaffidamento",cPar,cChild,false));

	#endregion

}
}
}
