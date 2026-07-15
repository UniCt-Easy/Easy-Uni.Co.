/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_pas_stu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_istanza_pas_stu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias1 		=> (MetaTable)Tables["diniego_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskinddefaultview 		=> (MetaTable)Tables["statuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview_alias1 		=> (MetaTable)Tables["iscrizioneseganagstuview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneseganagstuview 		=> (MetaTable)Tables["iscrizioneseganagstuview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_pas 		=> (MetaTable)Tables["istanza_pas"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_pas_stu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_pas_stu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_pas_stu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_pas_stu.xsd";

	#region create DataTables
	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("ct", typeof(DateTime),false);
	tnullaosta.defineColumn("cu", typeof(string),false);
	tnullaosta.defineColumn("data", typeof(DateTime),false);
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta.defineColumn("iddidprog", typeof(int),false);
	tnullaosta.defineColumn("idiscrizione", typeof(int));
	tnullaosta.defineColumn("idistanza", typeof(int),false);
	tnullaosta.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta.defineColumn("idreg", typeof(int),false);
	tnullaosta.defineColumn("lt", typeof(DateTime),false);
	tnullaosta.defineColumn("lu", typeof(string),false);
	tnullaosta.defineColumn("protanno", typeof(int));
	tnullaosta.defineColumn("protnumero", typeof(int));
	tnullaosta.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// DINIEGO_ALIAS1 /////////////////////////////////
	var tdiniego_alias1= new MetaTable("diniego_alias1");
	tdiniego_alias1.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("cu", typeof(string),false);
	tdiniego_alias1.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias1.defineColumn("iddidprog", typeof(int),false);
	tdiniego_alias1.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias1.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias1.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias1.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias1.defineColumn("idreg", typeof(int),false);
	tdiniego_alias1.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("lu", typeof(string),false);
	tdiniego_alias1.defineColumn("protanno", typeof(int));
	tdiniego_alias1.defineColumn("protnumero", typeof(int));
	tdiniego_alias1.ExtendedProperties["TableForReading"]="diniego";
	Tables.Add(tdiniego_alias1);
	tdiniego_alias1.defineKey("idcorsostudio", "iddidprog", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// STATUSKINDDEFAULTVIEW /////////////////////////////////
	var tstatuskinddefaultview= new MetaTable("statuskinddefaultview");
	tstatuskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstatuskinddefaultview.defineColumn("idstatuskind", typeof(int),false);
	tstatuskinddefaultview.defineColumn("statuskind_ct", typeof(DateTime),false);
	tstatuskinddefaultview.defineColumn("statuskind_cu", typeof(string),false);
	tstatuskinddefaultview.defineColumn("statuskind_delibera", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_istanze", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_istanzedelibera", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_lt", typeof(DateTime),false);
	tstatuskinddefaultview.defineColumn("statuskind_lu", typeof(string),false);
	tstatuskinddefaultview.defineColumn("statuskind_pratica", typeof(string));
	tstatuskinddefaultview.defineColumn("statuskind_sortcode", typeof(int),false);
	tstatuskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskinddefaultview);
	tstatuskinddefaultview.defineKey("idstatuskind");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int),false);
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ISCRIZIONESEGANAGSTUVIEW_ALIAS1 /////////////////////////////////
	var tiscrizioneseganagstuview_alias1= new MetaTable("iscrizioneseganagstuview_alias1");
	tiscrizioneseganagstuview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("didprog_aa", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("didprog_idsede", typeof(int));
	tiscrizioneseganagstuview_alias1.defineColumn("didprog_title", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_anno", typeof(int));
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizioneseganagstuview_alias1.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizioneseganagstuview_alias1.defineColumn("sede_title", typeof(string));
	tiscrizioneseganagstuview_alias1.ExtendedProperties["TableForReading"]="iscrizioneseganagstuview";
	Tables.Add(tiscrizioneseganagstuview_alias1);
	tiscrizioneseganagstuview_alias1.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// ISCRIZIONESEGANAGSTUVIEW /////////////////////////////////
	var tiscrizioneseganagstuview= new MetaTable("iscrizioneseganagstuview");
	tiscrizioneseganagstuview.defineColumn("aa", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("didprog_aa", typeof(string));
	tiscrizioneseganagstuview.defineColumn("didprog_idsede", typeof(int));
	tiscrizioneseganagstuview.defineColumn("didprog_title", typeof(string));
	tiscrizioneseganagstuview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("idreg", typeof(int),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_anno", typeof(int));
	tiscrizioneseganagstuview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizioneseganagstuview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizioneseganagstuview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizioneseganagstuview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizioneseganagstuview);
	tiscrizioneseganagstuview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISTANZA /////////////////////////////////
	var tistanza= new MetaTable("istanza");
	tistanza.defineColumn("aa", typeof(string),false);
	tistanza.defineColumn("ct", typeof(DateTime),false);
	tistanza.defineColumn("cu", typeof(string),false);
	tistanza.defineColumn("data", typeof(DateTime),false);
	tistanza.defineColumn("extension", typeof(string));
	tistanza.defineColumn("idcorsostudio", typeof(int),false);
	tistanza.defineColumn("iddidprog", typeof(int),false);
	tistanza.defineColumn("idiscrizione", typeof(int),false);
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int));
	tistanza.defineColumn("lt", typeof(DateTime),false);
	tistanza.defineColumn("lu", typeof(string),false);
	tistanza.defineColumn("paridistanza", typeof(int));
	tistanza.defineColumn("protanno", typeof(int));
	tistanza.defineColumn("protnumero", typeof(int));
	Tables.Add(tistanza);
	tistanza.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_PAS /////////////////////////////////
	var tistanza_pas= new MetaTable("istanza_pas");
	tistanza_pas.defineColumn("ct", typeof(DateTime),false);
	tistanza_pas.defineColumn("cu", typeof(string),false);
	tistanza_pas.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_pas.defineColumn("iddidprog", typeof(int),false);
	tistanza_pas.defineColumn("idiscrizione", typeof(int),false);
	tistanza_pas.defineColumn("idiscrizione_from", typeof(int));
	tistanza_pas.defineColumn("idistanza", typeof(int),false);
	tistanza_pas.defineColumn("idistanzakind", typeof(int),false);
	tistanza_pas.defineColumn("idreg", typeof(int),false);
	tistanza_pas.defineColumn("lt", typeof(DateTime),false);
	tistanza_pas.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanza_pas);
	tistanza_pas.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{nullaosta.Columns["idcorsostudio"], nullaosta.Columns["iddidprog"], nullaosta.Columns["idiscrizione"], nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	cChild = new []{diniego_alias1.Columns["idcorsostudio"], diniego_alias1.Columns["iddidprog"], diniego_alias1.Columns["idistanza"], diniego_alias1.Columns["idistanzakind"], diniego_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias1_istanza_pas_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{statuskinddefaultview.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskinddefaultview_idstatuskind",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview_alias1.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizioneseganagstuview_alias1_idiscrizione",cPar,cChild,false));

	cPar = new []{iscrizioneseganagstuview.Columns["idiscrizione"]};
	cChild = new []{istanza_pas.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_istanza_pas_iscrizioneseganagstuview_idiscrizione_from",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idiscrizione"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_pas_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	#endregion

}
}
}
