
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
[System.Xml.Serialization.XmlRoot("dsmeta_didprog_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_didprog_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentoattach 		=> (MetaTable)Tables["affidamentoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristicaora 		=> (MetaTable)Tables["affidamentocaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamentocaratteristica 		=> (MetaTable)Tables["affidamentocaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable affidamento 		=> (MetaTable)Tables["affidamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurrcaratteristica 		=> (MetaTable)Tables["didprogcurrcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneanno 		=> (MetaTable)Tables["iscrizioneanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform 		=> (MetaTable)Tables["pianostudioattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudio 		=> (MetaTable)Tables["pianostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias2 		=> (MetaTable)Tables["annoaccademico_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studprenotkind 		=> (MetaTable)Tables["studprenotkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studdirittokind 		=> (MetaTable)Tables["studdirittokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_studenti 		=> (MetaTable)Tables["registry_studenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprograppstud 		=> (MetaTable)Tables["didprograppstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdatepiano 		=> (MetaTable)Tables["didprogdatepiano"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale 		=> (MetaTable)Tables["classconsorsuale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogclassconsorsuale 		=> (MetaTable)Tables["didprogclassconsorsuale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformproped 		=> (MetaTable)Tables["attivformproped"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristicaora 		=> (MetaTable)Tables["attivformcaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristica 		=> (MetaTable)Tables["attivformcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproggrupp 		=> (MetaTable)Tables["didproggrupp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno 		=> (MetaTable)Tables["didproganno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolokind 		=> (MetaTable)Tables["titolokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessionedefaultview 		=> (MetaTable)Tables["sessionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias2 		=> (MetaTable)Tables["geo_nation_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias1 		=> (MetaTable)Tables["geo_nation_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoria 		=> (MetaTable)Tables["graduatoria"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable erogazkinddefaultview 		=> (MetaTable)Tables["erogazkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogsuddannokind 		=> (MetaTable)Tables["didprogsuddannokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprognumchiusokind 		=> (MetaTable)Tables["didprognumchiusokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convenzionesegview 		=> (MetaTable)Tables["convenzionesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable areadidatticadefaultview 		=> (MetaTable)Tables["areadidatticadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_didprog_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_didprog_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_didprog_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_didprog_default.xsd";

	#region create DataTables
	//////////////////// AFFIDAMENTOATTACH /////////////////////////////////
	var taffidamentoattach= new MetaTable("affidamentoattach");
	taffidamentoattach.defineColumn("aa", typeof(string),false);
	taffidamentoattach.defineColumn("ct", typeof(DateTime),false);
	taffidamentoattach.defineColumn("cu", typeof(string),false);
	taffidamentoattach.defineColumn("idaffidamento", typeof(int),false);
	taffidamentoattach.defineColumn("idattach", typeof(int),false);
	taffidamentoattach.defineColumn("idattivform", typeof(int),false);
	taffidamentoattach.defineColumn("idcanale", typeof(int),false);
	taffidamentoattach.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprog", typeof(int),false);
	taffidamentoattach.defineColumn("iddidproganno", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogori", typeof(int),false);
	taffidamentoattach.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentoattach.defineColumn("idreg_docenti", typeof(int));
	taffidamentoattach.defineColumn("lt", typeof(DateTime),false);
	taffidamentoattach.defineColumn("lu", typeof(string),false);
	Tables.Add(taffidamentoattach);
	taffidamentoattach.defineKey("aa", "idaffidamento", "idattach", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// AFFIDAMENTOCARATTERISTICAORA /////////////////////////////////
	var taffidamentocaratteristicaora= new MetaTable("affidamentocaratteristicaora");
	taffidamentocaratteristicaora.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idaffidamentocaratteristicaora", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristicaora.defineColumn("idorakind", typeof(int));
	taffidamentocaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristicaora.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristicaora.defineColumn("ora", typeof(int));
	taffidamentocaratteristicaora.defineColumn("ripetizioni", typeof(int));
	Tables.Add(taffidamentocaratteristicaora);
	taffidamentocaratteristicaora.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idaffidamentocaratteristicaora", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// AFFIDAMENTOCARATTERISTICA /////////////////////////////////
	var taffidamentocaratteristica= new MetaTable("affidamentocaratteristica");
	taffidamentocaratteristica.defineColumn("aa", typeof(string),false);
	taffidamentocaratteristica.defineColumn("cf", typeof(decimal));
	taffidamentocaratteristica.defineColumn("ct", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("cu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("idaffidamento", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idaffidamentocaratteristica", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idambitoareadisc", typeof(int));
	taffidamentocaratteristica.defineColumn("idattivform", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idcanale", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprog", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidproganno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogori", typeof(int),false);
	taffidamentocaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	taffidamentocaratteristica.defineColumn("idsasd", typeof(int));
	taffidamentocaratteristica.defineColumn("idsasdgruppo", typeof(int));
	taffidamentocaratteristica.defineColumn("idtipoattform", typeof(int));
	taffidamentocaratteristica.defineColumn("json", typeof(string));
	taffidamentocaratteristica.defineColumn("lt", typeof(DateTime),false);
	taffidamentocaratteristica.defineColumn("lu", typeof(string),false);
	taffidamentocaratteristica.defineColumn("profess", typeof(string),false);
	taffidamentocaratteristica.defineColumn("title", typeof(string));
	Tables.Add(taffidamentocaratteristica);
	taffidamentocaratteristica.defineKey("aa", "idaffidamento", "idaffidamentocaratteristica", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

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
	Tables.Add(tdidprogcurrcaratteristica);
	tdidprogcurrcaratteristica.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogcurrcaratteristica");

	//////////////////// ISCRIZIONEANNO /////////////////////////////////
	var tiscrizioneanno= new MetaTable("iscrizioneanno");
	tiscrizioneanno.defineColumn("aa", typeof(string),false);
	tiscrizioneanno.defineColumn("anno", typeof(int),false);
	tiscrizioneanno.defineColumn("annofc", typeof(int));
	tiscrizioneanno.defineColumn("ct", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("cu", typeof(string),false);
	tiscrizioneanno.defineColumn("data", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprogori", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizioneanno", typeof(int),false);
	tiscrizioneanno.defineColumn("idreg", typeof(int),false);
	tiscrizioneanno.defineColumn("lt", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("lu", typeof(string),false);
	tiscrizioneanno.defineColumn("protanno", typeof(int));
	tiscrizioneanno.defineColumn("protnumero", typeof(int));
	Tables.Add(tiscrizioneanno);
	tiscrizioneanno.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idiscrizioneanno", "idreg");

	//////////////////// PIANOSTUDIOATTIVFORM /////////////////////////////////
	var tpianostudioattivform= new MetaTable("pianostudioattivform");
	tpianostudioattivform.defineColumn("anno", typeof(int),false);
	tpianostudioattivform.defineColumn("ct", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("cu", typeof(string),false);
	tpianostudioattivform.defineColumn("idattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idattivform_scelta", typeof(int),false);
	tpianostudioattivform.defineColumn("idcorsostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("iddidprog", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizione", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudioattivform.defineColumn("idpianostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("idpianostudioattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idreg", typeof(int),false);
	tpianostudioattivform.defineColumn("idsostenimento", typeof(int));
	tpianostudioattivform.defineColumn("lt", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("lu", typeof(string),false);
	Tables.Add(tpianostudioattivform);
	tpianostudioattivform.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PIANOSTUDIO /////////////////////////////////
	var tpianostudio= new MetaTable("pianostudio");
	tpianostudio.defineColumn("aa", typeof(string));
	tpianostudio.defineColumn("ct", typeof(DateTime),false);
	tpianostudio.defineColumn("cu", typeof(string),false);
	tpianostudio.defineColumn("idcorsostudio", typeof(int),false);
	tpianostudio.defineColumn("iddidprog", typeof(int),false);
	tpianostudio.defineColumn("idiscrizione", typeof(int),false);
	tpianostudio.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudio.defineColumn("idpianostudio", typeof(int),false);
	tpianostudio.defineColumn("idpianostudiostatus", typeof(int));
	tpianostudio.defineColumn("idreg", typeof(int),false);
	tpianostudio.defineColumn("lt", typeof(DateTime),false);
	tpianostudio.defineColumn("lu", typeof(string),false);
	Tables.Add(tpianostudio);
	tpianostudio.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idreg");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int));
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento.defineColumn("iddidprog", typeof(int),false);
	tsostenimento.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento.defineColumn("idprova", typeof(int));
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento.defineColumn("idtitolostudio", typeof(int));
	tsostenimento.defineColumn("insecod", typeof(string));
	tsostenimento.defineColumn("insedesc", typeof(string));
	tsostenimento.defineColumn("livello", typeof(string));
	tsostenimento.defineColumn("lt", typeof(DateTime),false);
	tsostenimento.defineColumn("lu", typeof(string),false);
	tsostenimento.defineColumn("paridsostenimento", typeof(int));
	tsostenimento.defineColumn("protanno", typeof(int));
	tsostenimento.defineColumn("protnumero", typeof(int));
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg", "idsostenimento");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// ANNOACCADEMICO_ALIAS2 /////////////////////////////////
	var tannoaccademico_alias2= new MetaTable("annoaccademico_alias2");
	tannoaccademico_alias2.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias2.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias2);
	tannoaccademico_alias2.defineKey("aa");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("ct", typeof(DateTime),false);
	tiscrizione.defineColumn("cu", typeof(string),false);
	tiscrizione.defineColumn("data", typeof(DateTime));
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	tiscrizione.defineColumn("lt", typeof(DateTime),false);
	tiscrizione.defineColumn("lu", typeof(string),false);
	tiscrizione.defineColumn("matricola", typeof(string));
	tiscrizione.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int),false);
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("surname", typeof(string),false);
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// STUDPRENOTKIND /////////////////////////////////
	var tstudprenotkind= new MetaTable("studprenotkind");
	tstudprenotkind.defineColumn("active", typeof(string),false);
	tstudprenotkind.defineColumn("idstudprenotkind", typeof(int),false);
	tstudprenotkind.defineColumn("title", typeof(string),false);
	Tables.Add(tstudprenotkind);
	tstudprenotkind.defineKey("idstudprenotkind");

	//////////////////// STUDDIRITTOKIND /////////////////////////////////
	var tstuddirittokind= new MetaTable("studdirittokind");
	tstuddirittokind.defineColumn("active", typeof(string),false);
	tstuddirittokind.defineColumn("idstuddirittokind", typeof(int),false);
	tstuddirittokind.defineColumn("title", typeof(string),false);
	Tables.Add(tstuddirittokind);
	tstuddirittokind.defineKey("idstuddirittokind");

	//////////////////// REGISTRY_STUDENTI /////////////////////////////////
	var tregistry_studenti= new MetaTable("registry_studenti");
	tregistry_studenti.defineColumn("authinps", typeof(string),false);
	tregistry_studenti.defineColumn("ct", typeof(DateTime),false);
	tregistry_studenti.defineColumn("cu", typeof(string),false);
	tregistry_studenti.defineColumn("idreg", typeof(int),false);
	tregistry_studenti.defineColumn("idstuddirittokind", typeof(int));
	tregistry_studenti.defineColumn("idstudprenotkind", typeof(int),false);
	tregistry_studenti.defineColumn("lt", typeof(DateTime),false);
	tregistry_studenti.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistry_studenti);
	tregistry_studenti.defineKey("idreg");

	//////////////////// DIDPROGRAPPSTUD /////////////////////////////////
	var tdidprograppstud= new MetaTable("didprograppstud");
	tdidprograppstud.defineColumn("ct", typeof(DateTime),false);
	tdidprograppstud.defineColumn("cu", typeof(string),false);
	tdidprograppstud.defineColumn("idcorsostudio", typeof(int),false);
	tdidprograppstud.defineColumn("iddidprog", typeof(int),false);
	tdidprograppstud.defineColumn("idreg_studenti", typeof(int),false);
	tdidprograppstud.defineColumn("lt", typeof(DateTime),false);
	tdidprograppstud.defineColumn("lu", typeof(string),false);
	tdidprograppstud.defineColumn("!idreg_studenti_registry_title", typeof(string));
	tdidprograppstud.defineColumn("!idreg_studenti_registry_cf", typeof(string));
	tdidprograppstud.defineColumn("!idreg_studenti_registry_p_iva", typeof(string));
	tdidprograppstud.defineColumn("!idreg_studenti_registry_active", typeof(string));
	tdidprograppstud.defineColumn("!idreg_studenti_registry_studenti_authinps", typeof(string));
	tdidprograppstud.defineColumn("!idreg_studenti_studdirittokind_title", typeof(string));
	tdidprograppstud.defineColumn("!idreg_studenti_studprenotkind_title", typeof(string));
	Tables.Add(tdidprograppstud);
	tdidprograppstud.defineKey("idcorsostudio", "iddidprog", "idreg_studenti");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// DIDPROGDATEPIANO /////////////////////////////////
	var tdidprogdatepiano= new MetaTable("didprogdatepiano");
	tdidprogdatepiano.defineColumn("aa", typeof(string));
	tdidprogdatepiano.defineColumn("ct", typeof(DateTime),false);
	tdidprogdatepiano.defineColumn("cu", typeof(string),false);
	tdidprogdatepiano.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdatepiano.defineColumn("iddidprog", typeof(int),false);
	tdidprogdatepiano.defineColumn("iddidprogdatepiano", typeof(int),false);
	tdidprogdatepiano.defineColumn("lt", typeof(DateTime),false);
	tdidprogdatepiano.defineColumn("lu", typeof(string),false);
	tdidprogdatepiano.defineColumn("start", typeof(DateTime));
	tdidprogdatepiano.defineColumn("stop", typeof(DateTime));
	Tables.Add(tdidprogdatepiano);
	tdidprogdatepiano.defineKey("idcorsostudio", "iddidprog", "iddidprogdatepiano");

	//////////////////// CLASSCONSORSUALE /////////////////////////////////
	var tclassconsorsuale= new MetaTable("classconsorsuale");
	tclassconsorsuale.defineColumn("active", typeof(string),false);
	tclassconsorsuale.defineColumn("ambitodisci", typeof(string));
	tclassconsorsuale.defineColumn("corr2592017", typeof(string));
	tclassconsorsuale.defineColumn("description", typeof(string),false);
	tclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale.defineColumn("lt", typeof(DateTime));
	tclassconsorsuale.defineColumn("lu", typeof(string));
	tclassconsorsuale.defineColumn("normativa", typeof(string),false);
	tclassconsorsuale.defineColumn("title", typeof(string),false);
	Tables.Add(tclassconsorsuale);
	tclassconsorsuale.defineKey("idclassconsorsuale");

	//////////////////// DIDPROGCLASSCONSORSUALE /////////////////////////////////
	var tdidprogclassconsorsuale= new MetaTable("didprogclassconsorsuale");
	tdidprogclassconsorsuale.defineColumn("ct", typeof(DateTime),false);
	tdidprogclassconsorsuale.defineColumn("cu", typeof(string),false);
	tdidprogclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tdidprogclassconsorsuale.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogclassconsorsuale.defineColumn("iddidprog", typeof(int),false);
	tdidprogclassconsorsuale.defineColumn("lt", typeof(DateTime),false);
	tdidprogclassconsorsuale.defineColumn("lu", typeof(string),false);
	tdidprogclassconsorsuale.defineColumn("!idclassconsorsuale_classconsorsuale_title", typeof(string));
	tdidprogclassconsorsuale.defineColumn("!idclassconsorsuale_classconsorsuale_description", typeof(string));
	tdidprogclassconsorsuale.defineColumn("!idclassconsorsuale_classconsorsuale_active", typeof(string));
	tdidprogclassconsorsuale.defineColumn("!idclassconsorsuale_classconsorsuale_ambitodisci", typeof(string));
	tdidprogclassconsorsuale.defineColumn("!idclassconsorsuale_classconsorsuale_corr2592017", typeof(string));
	tdidprogclassconsorsuale.defineColumn("!idclassconsorsuale_classconsorsuale_normativa", typeof(string));
	Tables.Add(tdidprogclassconsorsuale);
	tdidprogclassconsorsuale.defineKey("idclassconsorsuale", "idcorsostudio", "iddidprog");

	//////////////////// ATTIVFORMPROPED /////////////////////////////////
	var tattivformproped= new MetaTable("attivformproped");
	tattivformproped.defineColumn("aa", typeof(string),false);
	tattivformproped.defineColumn("alternativa", typeof(int),false);
	tattivformproped.defineColumn("ct", typeof(DateTime),false);
	tattivformproped.defineColumn("cu", typeof(string),false);
	tattivformproped.defineColumn("idattivform", typeof(int),false);
	tattivformproped.defineColumn("idattivform_proped", typeof(int),false);
	tattivformproped.defineColumn("idcorsostudio", typeof(int),false);
	tattivformproped.defineColumn("iddidprog", typeof(int),false);
	tattivformproped.defineColumn("iddidproganno", typeof(int),false);
	tattivformproped.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformproped.defineColumn("iddidprogori", typeof(int),false);
	tattivformproped.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformproped.defineColumn("lt", typeof(DateTime),false);
	tattivformproped.defineColumn("lu", typeof(string),false);
	tattivformproped.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tattivformproped);
	tattivformproped.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// ATTIVFORMCARATTERISTICAORA /////////////////////////////////
	var tattivformcaratteristicaora= new MetaTable("attivformcaratteristicaora");
	tattivformcaratteristicaora.defineColumn("aa", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("cu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristicaora", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idorakind", typeof(int));
	tattivformcaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("lu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("ora", typeof(int));
	Tables.Add(tattivformcaratteristicaora);
	tattivformcaratteristicaora.defineKey("aa", "idattivform", "idattivformcaratteristica", "idattivformcaratteristicaora", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// TIPOATTFORM /////////////////////////////////
	var ttipoattform= new MetaTable("tipoattform");
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

	//////////////////// ATTIVFORMCARATTERISTICA /////////////////////////////////
	var tattivformcaratteristica= new MetaTable("attivformcaratteristica");
	tattivformcaratteristica.defineColumn("aa", typeof(string),false);
	tattivformcaratteristica.defineColumn("cf", typeof(decimal));
	tattivformcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("cu", typeof(string),false);
	tattivformcaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tattivformcaratteristica.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristica.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristica.defineColumn("idsasd", typeof(int));
	tattivformcaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tattivformcaratteristica.defineColumn("idtipoattform", typeof(int));
	tattivformcaratteristica.defineColumn("json", typeof(string));
	tattivformcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("lu", typeof(string),false);
	tattivformcaratteristica.defineColumn("profess", typeof(string),false);
	tattivformcaratteristica.defineColumn("title", typeof(string));
	tattivformcaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	tattivformcaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tattivformcaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	tattivformcaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	tattivformcaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	tattivformcaratteristica.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tattivformcaratteristica);
	tattivformcaratteristica.defineKey("aa", "idattivform", "idattivformcaratteristica", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// CANALE /////////////////////////////////
	var tcanale= new MetaTable("canale");
	tcanale.defineColumn("aa", typeof(string),false);
	tcanale.defineColumn("ct", typeof(DateTime),false);
	tcanale.defineColumn("cu", typeof(string),false);
	tcanale.defineColumn("CUIN", typeof(string));
	tcanale.defineColumn("idattivform", typeof(int),false);
	tcanale.defineColumn("idcanale", typeof(int),false);
	tcanale.defineColumn("idcorsostudio", typeof(int),false);
	tcanale.defineColumn("iddidprog", typeof(int),false);
	tcanale.defineColumn("iddidproganno", typeof(int),false);
	tcanale.defineColumn("iddidprogcurr", typeof(int),false);
	tcanale.defineColumn("iddidprogori", typeof(int),false);
	tcanale.defineColumn("iddidprogporzanno", typeof(int),false);
	tcanale.defineColumn("idsede", typeof(int),false);
	tcanale.defineColumn("lt", typeof(DateTime),false);
	tcanale.defineColumn("lu", typeof(string),false);
	tcanale.defineColumn("numerostud", typeof(int));
	tcanale.defineColumn("sortcode", typeof(int));
	tcanale.defineColumn("title", typeof(string));
	tcanale.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcanale);
	tcanale.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

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

	//////////////////// DIDPROGGRUPP /////////////////////////////////
	var tdidproggrupp= new MetaTable("didproggrupp");
	tdidproggrupp.defineColumn("idcorsostudio", typeof(int),false);
	tdidproggrupp.defineColumn("iddidprog", typeof(int),false);
	tdidproggrupp.defineColumn("iddidproggrupp", typeof(int),false);
	tdidproggrupp.defineColumn("title", typeof(string));
	Tables.Add(tdidproggrupp);
	tdidproggrupp.defineKey("idcorsostudio", "iddidprog", "iddidproggrupp");

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
	tattivform.defineColumn("!iddidproggrupp_didproggrupp_title", typeof(string));
	tattivform.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tattivform.defineColumn("!iddidprogporzanno_didprogporzanno_title", typeof(string));
	tattivform.defineColumn("!idinsegn_insegn_denominazione", typeof(string));
	tattivform.defineColumn("!idinsegn_insegn_codice", typeof(string));
	tattivform.defineColumn("!idinsegninteg_insegninteg_denominazione", typeof(string));
	tattivform.defineColumn("!idinsegninteg_insegninteg_codice", typeof(string));
	tattivform.defineColumn("!canale", typeof(string));
	tattivform.defineColumn("!attivformcaratteristica", typeof(string));
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// TITOLOKIND /////////////////////////////////
	var ttitolokind= new MetaTable("titolokind");
	ttitolokind.defineColumn("active", typeof(string),false);
	ttitolokind.defineColumn("idtitolokind", typeof(int),false);
	ttitolokind.defineColumn("title", typeof(string),false);
	Tables.Add(ttitolokind);
	ttitolokind.defineKey("idtitolokind");

	//////////////////// SESSIONEDEFAULTVIEW /////////////////////////////////
	var tsessionedefaultview= new MetaTable("sessionedefaultview");
	tsessionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsessionedefaultview.defineColumn("idsessione", typeof(int),false);
	tsessionedefaultview.defineColumn("idsessionekind", typeof(int));
	Tables.Add(tsessionedefaultview);
	tsessionedefaultview.defineKey("idsessione");

	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("idcity", typeof(int));
	tregistrydocentiview.defineColumn("idclassconsorsuale", typeof(int));
	tregistrydocentiview.defineColumn("idnation", typeof(int));
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("idreg_istituti", typeof(int));
	tregistrydocentiview.defineColumn("idregistryclass", typeof(string));
	tregistrydocentiview.defineColumn("idsasd", typeof(int));
	tregistrydocentiview.defineColumn("idstruttura", typeof(int));
	tregistrydocentiview.defineColumn("idtitle", typeof(string));
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// GEO_NATION_ALIAS2 /////////////////////////////////
	var tgeo_nation_alias2= new MetaTable("geo_nation_alias2");
	tgeo_nation_alias2.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias2.defineColumn("lang", typeof(string));
	tgeo_nation_alias2.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias2);
	tgeo_nation_alias2.defineKey("idnation");

	//////////////////// GEO_NATION_ALIAS1 /////////////////////////////////
	var tgeo_nation_alias1= new MetaTable("geo_nation_alias1");
	tgeo_nation_alias1.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias1.defineColumn("lang", typeof(string));
	tgeo_nation_alias1.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias1);
	tgeo_nation_alias1.defineKey("idnation");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("lang", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("idcity", typeof(int));
	tsededefaultview.defineColumn("idnation", typeof(int));
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

	//////////////////// GRADUATORIA /////////////////////////////////
	var tgraduatoria= new MetaTable("graduatoria");
	tgraduatoria.defineColumn("idgraduatoria", typeof(int),false);
	tgraduatoria.defineColumn("title", typeof(string));
	Tables.Add(tgraduatoria);
	tgraduatoria.defineKey("idgraduatoria");

	//////////////////// EROGAZKINDDEFAULTVIEW /////////////////////////////////
	var terogazkinddefaultview= new MetaTable("erogazkinddefaultview");
	terogazkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	terogazkinddefaultview.defineColumn("erogazkind_active", typeof(string));
	terogazkinddefaultview.defineColumn("iderogazkind", typeof(int),false);
	Tables.Add(terogazkinddefaultview);
	terogazkinddefaultview.defineKey("iderogazkind");

	//////////////////// DIDPROGSUDDANNOKIND /////////////////////////////////
	var tdidprogsuddannokind= new MetaTable("didprogsuddannokind");
	tdidprogsuddannokind.defineColumn("active", typeof(string));
	tdidprogsuddannokind.defineColumn("iddidprogsuddannokind", typeof(int),false);
	tdidprogsuddannokind.defineColumn("title", typeof(string));
	Tables.Add(tdidprogsuddannokind);
	tdidprogsuddannokind.defineKey("iddidprogsuddannokind");

	//////////////////// DIDPROGNUMCHIUSOKIND /////////////////////////////////
	var tdidprognumchiusokind= new MetaTable("didprognumchiusokind");
	tdidprognumchiusokind.defineColumn("active", typeof(string),false);
	tdidprognumchiusokind.defineColumn("iddidprognumchiusokind", typeof(int),false);
	tdidprognumchiusokind.defineColumn("title", typeof(string),false);
	Tables.Add(tdidprognumchiusokind);
	tdidprognumchiusokind.defineKey("iddidprognumchiusokind");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudiodefaultview.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudiodefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// CONVENZIONESEGVIEW /////////////////////////////////
	var tconvenzionesegview= new MetaTable("convenzionesegview");
	tconvenzionesegview.defineColumn("dropdown_title", typeof(string),false);
	tconvenzionesegview.defineColumn("idconvenzione", typeof(int),false);
	tconvenzionesegview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tconvenzionesegview);
	tconvenzionesegview.defineKey("idconvenzione", "idreg");

	//////////////////// AREADIDATTICADEFAULTVIEW /////////////////////////////////
	var tareadidatticadefaultview= new MetaTable("areadidatticadefaultview");
	tareadidatticadefaultview.defineColumn("areadidattica_active", typeof(string));
	tareadidatticadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tareadidatticadefaultview.defineColumn("idareadidattica", typeof(int),false);
	Tables.Add(tareadidatticadefaultview);
	tareadidatticadefaultview.defineKey("idareadidattica");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("annosolare", typeof(int));
	tdidprog.defineColumn("attribdebiti", typeof(string));
	tdidprog.defineColumn("ciclo", typeof(int));
	tdidprog.defineColumn("codice", typeof(string));
	tdidprog.defineColumn("codicemiur", typeof(string));
	tdidprog.defineColumn("dataconsmaxiscr", typeof(DateTime));
	tdidprog.defineColumn("freqobbl", typeof(string));
	tdidprog.defineColumn("idareadidattica", typeof(int));
	tdidprog.defineColumn("idconvenzione", typeof(int));
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("iddidprognumchiusokind", typeof(int));
	tdidprog.defineColumn("iddidprogsuddannokind", typeof(int),false);
	tdidprog.defineColumn("iderogazkind", typeof(int));
	tdidprog.defineColumn("idgraduatoria", typeof(int));
	tdidprog.defineColumn("idnation_lang", typeof(int));
	tdidprog.defineColumn("idnation_lang2", typeof(int));
	tdidprog.defineColumn("idnation_langvis", typeof(int));
	tdidprog.defineColumn("idreg_docenti", typeof(int));
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("idsessione", typeof(int));
	tdidprog.defineColumn("idtitolokind", typeof(int));
	tdidprog.defineColumn("immatoltreauth", typeof(string));
	tdidprog.defineColumn("modaccesso", typeof(string));
	tdidprog.defineColumn("modaccesso_en", typeof(string));
	tdidprog.defineColumn("obbformativi", typeof(string));
	tdidprog.defineColumn("obbformativi_en", typeof(string));
	tdidprog.defineColumn("preimmatoltreauth", typeof(string));
	tdidprog.defineColumn("progesamamm", typeof(string));
	tdidprog.defineColumn("prospoccupaz", typeof(string));
	tdidprog.defineColumn("provafinaledesc", typeof(string));
	tdidprog.defineColumn("regolamentotax", typeof(string));
	tdidprog.defineColumn("regolamentotaxurl", typeof(string));
	tdidprog.defineColumn("startiscrizioni", typeof(DateTime));
	tdidprog.defineColumn("stopiscrizioni", typeof(DateTime));
	tdidprog.defineColumn("title", typeof(string));
	tdidprog.defineColumn("title_en", typeof(string));
	tdidprog.defineColumn("utenzasost", typeof(int));
	tdidprog.defineColumn("website", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	#endregion


	#region DataRelation creation
	var cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	var cChild = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{iscrizioneanno.Columns["idcorsostudio"], iscrizioneanno.Columns["iddidprog"], iscrizioneanno.Columns["idiscrizione"], iscrizioneanno.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizioneanno_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{pianostudio.Columns["idcorsostudio"], pianostudio.Columns["iddidprog"], pianostudio.Columns["idiscrizione"], pianostudio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudio_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{pianostudio.Columns["idcorsostudio"], pianostudio.Columns["iddidprog"], pianostudio.Columns["idiscrizione"], pianostudio.Columns["idpianostudio"], pianostudio.Columns["idreg"]};
	cChild = new []{pianostudioattivform.Columns["idcorsostudio"], pianostudioattivform.Columns["iddidprog"], pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idpianostudio"], pianostudioattivform.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_pianostudio_idcorsostudio-iddidprog-idiscrizione-idpianostudio-idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idcorsostudio"], sostenimento.Columns["iddidprog"], sostenimento.Columns["idiscrizione"], sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{iscrizione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{annoaccademico_alias2.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_alias2_aa",cPar,cChild,false));

	cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	cChild = new []{didprograppstud.Columns["idcorsostudio"], didprograppstud.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_didprograppstud_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{didprograppstud.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_didprograppstud_registry_idreg_studenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_studenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_studenti_registry_idreg",cPar,cChild,false));

	cPar = new []{studprenotkind.Columns["idstudprenotkind"]};
	cChild = new []{registry_studenti.Columns["idstudprenotkind"]};
	Relations.Add(new DataRelation("FK_registry_studenti_studprenotkind_idstudprenotkind",cPar,cChild,false));

	cPar = new []{studdirittokind.Columns["idstuddirittokind"]};
	cChild = new []{registry_studenti.Columns["idstuddirittokind"]};
	Relations.Add(new DataRelation("FK_registry_studenti_studdirittokind_idstuddirittokind",cPar,cChild,false));

	cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	cChild = new []{didprogdatepiano.Columns["idcorsostudio"], didprogdatepiano.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_didprogdatepiano_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{didprogdatepiano.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprogdatepiano_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	cChild = new []{didprogclassconsorsuale.Columns["idcorsostudio"], didprogclassconsorsuale.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_didprogclassconsorsuale_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{classconsorsuale.Columns["idclassconsorsuale"]};
	cChild = new []{didprogclassconsorsuale.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_didprogclassconsorsuale_classconsorsuale_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{didprog.Columns["idcorsostudio"], didprog.Columns["iddidprog"]};
	cChild = new []{attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_attivform_didprog_idcorsostudio-iddidprog",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	cChild = new []{attivformproped.Columns["aa"], attivformproped.Columns["idattivform"], attivformproped.Columns["idcorsostudio"], attivformproped.Columns["iddidprog"], attivformproped.Columns["iddidproganno"], attivformproped.Columns["iddidprogcurr"], attivformproped.Columns["iddidprogori"], attivformproped.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformproped_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"]};
	cChild = new []{attivformcaratteristica.Columns["aa"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{attivformcaratteristica.Columns["aa"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idattivformcaratteristica"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidprogporzanno"]};
	cChild = new []{attivformcaratteristicaora.Columns["aa"], attivformcaratteristicaora.Columns["idattivform"], attivformcaratteristicaora.Columns["idattivformcaratteristica"], attivformcaratteristicaora.Columns["idcorsostudio"], attivformcaratteristicaora.Columns["iddidprog"], attivformcaratteristicaora.Columns["iddidproganno"], attivformcaratteristicaora.Columns["iddidprogcurr"], attivformcaratteristicaora.Columns["iddidprogori"], attivformcaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristicaora_attivformcaratteristica_aa-idattivform-idattivformcaratteristica-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{attivformcaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{attivformcaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{attivformcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{attivformcaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{attivform.Columns["aa"], attivform.Columns["idattivform"], attivform.Columns["idcorsostudio"], attivform.Columns["iddidprog"], attivform.Columns["iddidproganno"], attivform.Columns["iddidprogcurr"], attivform.Columns["iddidprogori"], attivform.Columns["iddidprogporzanno"], attivform.Columns["idsede"]};
	cChild = new []{canale.Columns["aa"], canale.Columns["idattivform"], canale.Columns["idcorsostudio"], canale.Columns["iddidprog"], canale.Columns["iddidproganno"], canale.Columns["iddidprogcurr"], canale.Columns["iddidprogori"], canale.Columns["iddidprogporzanno"], canale.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_canale_attivform_aa-idattivform-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno-idsede",cPar,cChild,false));

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

	cPar = new []{didproggrupp.Columns["iddidproggrupp"]};
	cChild = new []{attivform.Columns["iddidproggrupp"]};
	Relations.Add(new DataRelation("FK_attivform_didproggrupp_iddidproggrupp",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{attivform.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_attivform_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didproganno.Columns["iddidproganno"]};
	cChild = new []{attivform.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_attivform_didproganno_iddidproganno",cPar,cChild,false));

	cPar = new []{titolokind.Columns["idtitolokind"]};
	cChild = new []{didprog.Columns["idtitolokind"]};
	Relations.Add(new DataRelation("FK_didprog_titolokind_idtitolokind",cPar,cChild,false));

	cPar = new []{sessionedefaultview.Columns["idsessione"]};
	cChild = new []{didprog.Columns["idsessione"]};
	Relations.Add(new DataRelation("FK_didprog_sessionedefaultview_idsessione",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{didprog.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_didprog_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{geo_nation_alias2.Columns["idnation"]};
	cChild = new []{didprog.Columns["idnation_langvis"]};
	Relations.Add(new DataRelation("FK_didprog_geo_nation_alias2_idnation_langvis",cPar,cChild,false));

	cPar = new []{geo_nation_alias1.Columns["idnation"]};
	cChild = new []{didprog.Columns["idnation_lang2"]};
	Relations.Add(new DataRelation("FK_didprog_geo_nation_alias1_idnation_lang2",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{didprog.Columns["idnation_lang"]};
	Relations.Add(new DataRelation("FK_didprog_geo_nation_idnation_lang",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sededefaultview_idsede",cPar,cChild,false));

	cPar = new []{graduatoria.Columns["idgraduatoria"]};
	cChild = new []{didprog.Columns["idgraduatoria"]};
	Relations.Add(new DataRelation("FK_didprog_graduatoria_idgraduatoria",cPar,cChild,false));

	cPar = new []{erogazkinddefaultview.Columns["iderogazkind"]};
	cChild = new []{didprog.Columns["iderogazkind"]};
	Relations.Add(new DataRelation("FK_didprog_erogazkinddefaultview_iderogazkind",cPar,cChild,false));

	cPar = new []{didprogsuddannokind.Columns["iddidprogsuddannokind"]};
	cChild = new []{didprog.Columns["iddidprogsuddannokind"]};
	Relations.Add(new DataRelation("FK_didprog_didprogsuddannokind_iddidprogsuddannokind",cPar,cChild,false));

	cPar = new []{didprognumchiusokind.Columns["iddidprognumchiusokind"]};
	cChild = new []{didprog.Columns["iddidprognumchiusokind"]};
	Relations.Add(new DataRelation("FK_didprog_didprognumchiusokind_iddidprognumchiusokind",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{didprog.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_didprog_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{convenzionesegview.Columns["idconvenzione"]};
	cChild = new []{didprog.Columns["idconvenzione"]};
	Relations.Add(new DataRelation("FK_didprog_convenzionesegview_idconvenzione",cPar,cChild,false));

	cPar = new []{areadidatticadefaultview.Columns["idareadidattica"]};
	cChild = new []{didprog.Columns["idareadidattica"]};
	Relations.Add(new DataRelation("FK_didprog_areadidatticadefaultview_idareadidattica",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{didprog.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprog_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
