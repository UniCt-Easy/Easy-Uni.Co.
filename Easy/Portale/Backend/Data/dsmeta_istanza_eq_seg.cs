
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_eq_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_istanza_eq_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias2 		=> (MetaTable)Tables["diniego_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarsegview 		=> (MetaTable)Tables["dichiarsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_eq 		=> (MetaTable)Tables["istanza_eq"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_eq_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_eq_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_eq_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_eq_seg.xsd";

	#region create DataTables
	//////////////////// DINIEGO_ALIAS2 /////////////////////////////////
	var tdiniego_alias2= new MetaTable("diniego_alias2");
	tdiniego_alias2.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("cu", typeof(string),false);
	tdiniego_alias2.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("idcorsostudio", typeof(int));
	tdiniego_alias2.defineColumn("iddidprog", typeof(int));
	tdiniego_alias2.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias2.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias2.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias2.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias2.defineColumn("idreg", typeof(int),false);
	tdiniego_alias2.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("lu", typeof(string),false);
	tdiniego_alias2.defineColumn("protanno", typeof(int));
	tdiniego_alias2.defineColumn("protnumero", typeof(int));
	tdiniego_alias2.ExtendedProperties["TableForReading"]="diniego";
	Tables.Add(tdiniego_alias2);
	tdiniego_alias2.defineKey("iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("ct", typeof(DateTime),false);
	tnullaosta.defineColumn("cu", typeof(string),false);
	tnullaosta.defineColumn("data", typeof(DateTime),false);
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idcorsostudio", typeof(int));
	tnullaosta.defineColumn("iddidprog", typeof(int));
	tnullaosta.defineColumn("idiscrizione", typeof(int));
	tnullaosta.defineColumn("idistanza", typeof(int),false);
	tnullaosta.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta.defineColumn("idreg", typeof(int),false);
	tnullaosta.defineColumn("lt", typeof(DateTime),false);
	tnullaosta.defineColumn("lu", typeof(string),false);
	tnullaosta.defineColumn("protanno", typeof(int));
	tnullaosta.defineColumn("protnumero", typeof(int));
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// DICHIARSEGVIEW /////////////////////////////////
	var tdichiarsegview= new MetaTable("dichiarsegview");
	tdichiarsegview.defineColumn("aa", typeof(string));
	tdichiarsegview.defineColumn("dichiar_ct", typeof(DateTime),false);
	tdichiarsegview.defineColumn("dichiar_cu", typeof(string),false);
	tdichiarsegview.defineColumn("dichiar_date", typeof(DateTime),false);
	tdichiarsegview.defineColumn("dichiar_extension", typeof(string));
	tdichiarsegview.defineColumn("dichiar_lt", typeof(DateTime),false);
	tdichiarsegview.defineColumn("dichiar_lu", typeof(string),false);
	tdichiarsegview.defineColumn("dichiar_protanno", typeof(int));
	tdichiarsegview.defineColumn("dichiar_protnumero", typeof(int));
	tdichiarsegview.defineColumn("dichiarkind_title", typeof(string));
	tdichiarsegview.defineColumn("dropdown_title", typeof(string),false);
	tdichiarsegview.defineColumn("iddichiar", typeof(int),false);
	tdichiarsegview.defineColumn("iddichiarkind", typeof(int),false);
	tdichiarsegview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiarsegview);
	tdichiarsegview.defineKey("iddichiar");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("ct", typeof(DateTime),false);
	tstatuskind.defineColumn("cu", typeof(string),false);
	tstatuskind.defineColumn("delibera", typeof(string),false);
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("istanze", typeof(string),false);
	tstatuskind.defineColumn("istanzedelibera", typeof(string),false);
	tstatuskind.defineColumn("lt", typeof(DateTime),false);
	tstatuskind.defineColumn("lu", typeof(string),false);
	tstatuskind.defineColumn("pratica", typeof(string),false);
	tstatuskind.defineColumn("sortcode", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("aa", typeof(string));
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("idareadidattica", typeof(int));
	tdidprogdefaultview.defineColumn("idconvenzione", typeof(int));
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogdefaultview.defineColumn("idgraduatoria", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_lang2", typeof(int));
	tdidprogdefaultview.defineColumn("idnation_langvis", typeof(int));
	tdidprogdefaultview.defineColumn("idreg_docenti", typeof(int));
	tdidprogdefaultview.defineColumn("idsessione", typeof(int));
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("iddidprog");

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
	tistanza.defineColumn("idcorsostudio", typeof(int));
	tistanza.defineColumn("iddidprog", typeof(int));
	tistanza.defineColumn("idiscrizione", typeof(int));
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int),false);
	tistanza.defineColumn("lt", typeof(DateTime),false);
	tistanza.defineColumn("lu", typeof(string),false);
	tistanza.defineColumn("paridistanza", typeof(int));
	tistanza.defineColumn("protanno", typeof(int),false);
	tistanza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tistanza);
	tistanza.defineKey("idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_EQ /////////////////////////////////
	var tistanza_eq= new MetaTable("istanza_eq");
	tistanza_eq.defineColumn("ct", typeof(DateTime),false);
	tistanza_eq.defineColumn("cu", typeof(string),false);
	tistanza_eq.defineColumn("iddichiar_titolo_seg", typeof(int));
	tistanza_eq.defineColumn("idistanza", typeof(int),false);
	tistanza_eq.defineColumn("idistanzakind", typeof(int),false);
	tistanza_eq.defineColumn("idreg", typeof(int),false);
	tistanza_eq.defineColumn("lt", typeof(DateTime),false);
	tistanza_eq.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanza_eq);
	tistanza_eq.defineKey("idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{diniego_alias2.Columns["idistanza"], diniego_alias2.Columns["idistanzakind"], diniego_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias2_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{dichiarsegview.Columns["iddichiar"]};
	cChild = new []{istanza_eq.Columns["iddichiar_titolo_seg"]};
	Relations.Add(new DataRelation("FK_istanza_eq_dichiarsegview_iddichiar_titolo_seg",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_eq.Columns["idistanza"], istanza_eq.Columns["idistanzakind"], istanza_eq.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_eq_istanza_idistanza-idistanzakind-idreg-",cPar,cChild,false));

	#endregion

}
}
}
