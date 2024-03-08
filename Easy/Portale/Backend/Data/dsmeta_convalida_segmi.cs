
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
[System.Xml.Serialization.XmlRoot("dsmeta_convalida_segmi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_convalida_segmi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica_alias1 		=> (MetaTable)Tables["pratica_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer_alias1 		=> (MetaTable)Tables["learningagrtrainer_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud_alias1 		=> (MetaTable)Tables["learningagrstud_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias1 		=> (MetaTable)Tables["istanza_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmi 		=> (MetaTable)Tables["iscrizionebmi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias3 		=> (MetaTable)Tables["iscrizionedefaultview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias2 		=> (MetaTable)Tables["iscrizionedefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview_alias1 		=> (MetaTable)Tables["didprogdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar_alias1 		=> (MetaTable)Tables["dichiar_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskinddefaultview 		=> (MetaTable)Tables["changeskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changes 		=> (MetaTable)Tables["changes"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformdefaultview 		=> (MetaTable)Tables["attivformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrtrainer 		=> (MetaTable)Tables["learningagrtrainer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable learningagrstud 		=> (MetaTable)Tables["learningagrstud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionebmisegview 		=> (MetaTable)Tables["iscrizionebmisegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias1 		=> (MetaTable)Tables["iscrizionedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidakind 		=> (MetaTable)Tables["convalidakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convalida_segmi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convalida_segmi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convalida_segmi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convalida_segmi.xsd";

	#region create DataTables
	//////////////////// PRATICA_ALIAS1 /////////////////////////////////
	var tpratica_alias1= new MetaTable("pratica_alias1");
	tpratica_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tpratica_alias1.defineColumn("iddidprog", typeof(int),false);
	tpratica_alias1.defineColumn("idiscrizione", typeof(int),false);
	tpratica_alias1.defineColumn("idistanza", typeof(int),false);
	tpratica_alias1.defineColumn("idistanzakind", typeof(int),false);
	tpratica_alias1.defineColumn("idpratica", typeof(int),false);
	tpratica_alias1.defineColumn("idreg", typeof(int),false);
	tpratica_alias1.ExtendedProperties["TableForReading"]="pratica";
	Tables.Add(tpratica_alias1);
	tpratica_alias1.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// LEARNINGAGRTRAINER_ALIAS1 /////////////////////////////////
	var tlearningagrtrainer_alias1= new MetaTable("learningagrtrainer_alias1");
	tlearningagrtrainer_alias1.defineColumn("idbandomi", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("idlearningagrtrainer", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("idreg", typeof(int),false);
	tlearningagrtrainer_alias1.defineColumn("title", typeof(string),false);
	tlearningagrtrainer_alias1.ExtendedProperties["TableForReading"]="learningagrtrainer";
	Tables.Add(tlearningagrtrainer_alias1);
	tlearningagrtrainer_alias1.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// LEARNINGAGRSTUD_ALIAS1 /////////////////////////////////
	var tlearningagrstud_alias1= new MetaTable("learningagrstud_alias1");
	tlearningagrstud_alias1.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud_alias1.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud_alias1.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud_alias1.defineColumn("idreg", typeof(int),false);
	tlearningagrstud_alias1.ExtendedProperties["TableForReading"]="learningagrstud";
	Tables.Add(tlearningagrstud_alias1);
	tlearningagrstud_alias1.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// ISTANZA_ALIAS1 /////////////////////////////////
	var tistanza_alias1= new MetaTable("istanza_alias1");
	tistanza_alias1.defineColumn("aa", typeof(string),false);
	tistanza_alias1.defineColumn("data", typeof(DateTime),false);
	tistanza_alias1.defineColumn("iddidprog", typeof(int));
	tistanza_alias1.defineColumn("idiscrizione", typeof(int));
	tistanza_alias1.defineColumn("idistanza", typeof(int),false);
	tistanza_alias1.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias1.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias1.defineColumn("idstatuskind", typeof(int));
	tistanza_alias1.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias1);
	tistanza_alias1.defineKey("idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISCRIZIONEBMI /////////////////////////////////
	var tiscrizionebmi= new MetaTable("iscrizionebmi");
	tiscrizionebmi.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionebmi.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmi.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionebmi);
	tiscrizionebmi.defineKey("idbandomi", "idiscrizionebmi", "idreg");

	//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS3 /////////////////////////////////
	var tiscrizionedefaultview_alias3= new MetaTable("iscrizionedefaultview_alias3");
	tiscrizionedefaultview_alias3.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview_alias3.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview_alias3.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview_alias3.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview_alias3.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview_alias3.ExtendedProperties["TableForReading"]="iscrizionedefaultview";
	Tables.Add(tiscrizionedefaultview_alias3);
	tiscrizionedefaultview_alias3.defineKey("idiscrizione");

	//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tiscrizionedefaultview_alias2= new MetaTable("iscrizionedefaultview_alias2");
	tiscrizionedefaultview_alias2.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview_alias2.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview_alias2.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview_alias2.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview_alias2.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview_alias2.ExtendedProperties["TableForReading"]="iscrizionedefaultview";
	Tables.Add(tiscrizionedefaultview_alias2);
	tiscrizionedefaultview_alias2.defineKey("idiscrizione");

	//////////////////// DIDPROGDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tdidprogdefaultview_alias1= new MetaTable("didprogdefaultview_alias1");
	tdidprogdefaultview_alias1.defineColumn("aa", typeof(string));
	tdidprogdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview_alias1.defineColumn("idareadidattica", typeof(int));
	tdidprogdefaultview_alias1.defineColumn("idconvenzione", typeof(int));
	tdidprogdefaultview_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogdefaultview_alias1.defineColumn("idgraduatoria", typeof(int));
	tdidprogdefaultview_alias1.defineColumn("idnation_lang", typeof(int));
	tdidprogdefaultview_alias1.defineColumn("idnation_lang2", typeof(int));
	tdidprogdefaultview_alias1.defineColumn("idnation_langvis", typeof(int));
	tdidprogdefaultview_alias1.defineColumn("idreg_docenti", typeof(int));
	tdidprogdefaultview_alias1.defineColumn("idsessione", typeof(int));
	tdidprogdefaultview_alias1.ExtendedProperties["TableForReading"]="didprogdefaultview";
	Tables.Add(tdidprogdefaultview_alias1);
	tdidprogdefaultview_alias1.defineKey("iddidprog");

	//////////////////// DICHIAR_ALIAS1 /////////////////////////////////
	var tdichiar_alias1= new MetaTable("dichiar_alias1");
	tdichiar_alias1.defineColumn("aa", typeof(string));
	tdichiar_alias1.defineColumn("date", typeof(DateTime),false);
	tdichiar_alias1.defineColumn("iddichiar", typeof(int),false);
	tdichiar_alias1.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar_alias1.defineColumn("idreg", typeof(int),false);
	tdichiar_alias1.ExtendedProperties["TableForReading"]="dichiar";
	Tables.Add(tdichiar_alias1);
	tdichiar_alias1.defineKey("iddichiar", "idreg");

	//////////////////// CHANGESKINDDEFAULTVIEW /////////////////////////////////
	var tchangeskinddefaultview= new MetaTable("changeskinddefaultview");
	tchangeskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tchangeskinddefaultview.defineColumn("idchangeskind", typeof(int),false);
	Tables.Add(tchangeskinddefaultview);
	tchangeskinddefaultview.defineKey("idchangeskind");

	//////////////////// CHANGES /////////////////////////////////
	var tchanges= new MetaTable("changes");
	tchanges.defineColumn("idchanges", typeof(int),false);
	tchanges.defineColumn("title", typeof(string),false);
	Tables.Add(tchanges);
	tchanges.defineKey("idchanges");

	//////////////////// ATTIVFORMDEFAULTVIEW /////////////////////////////////
	var tattivformdefaultview= new MetaTable("attivformdefaultview");
	tattivformdefaultview.defineColumn("aa", typeof(string),false);
	tattivformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegn", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegninteg", typeof(int));
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("idattivform");

	//////////////////// CONVALIDATO /////////////////////////////////
	var tconvalidato= new MetaTable("convalidato");
	tconvalidato.defineColumn("changesother", typeof(string));
	tconvalidato.defineColumn("ct", typeof(DateTime),false);
	tconvalidato.defineColumn("cu", typeof(string),false);
	tconvalidato.defineColumn("idattivform", typeof(int),false);
	tconvalidato.defineColumn("idchanges", typeof(int));
	tconvalidato.defineColumn("idchangeskind", typeof(int));
	tconvalidato.defineColumn("idconvalida", typeof(int),false);
	tconvalidato.defineColumn("idconvalidato", typeof(int),false);
	tconvalidato.defineColumn("iddichiar", typeof(int));
	tconvalidato.defineColumn("iddidprog", typeof(int));
	tconvalidato.defineColumn("idiscrizione", typeof(int));
	tconvalidato.defineColumn("idiscrizione_from", typeof(int));
	tconvalidato.defineColumn("idiscrizionebmi", typeof(int));
	tconvalidato.defineColumn("idistanza", typeof(int));
	tconvalidato.defineColumn("idlearningagrstud", typeof(int));
	tconvalidato.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidato.defineColumn("idpratica", typeof(int));
	tconvalidato.defineColumn("idreg", typeof(int),false);
	tconvalidato.defineColumn("lt", typeof(DateTime),false);
	tconvalidato.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

	//////////////////// PRATICA /////////////////////////////////
	var tpratica= new MetaTable("pratica");
	tpratica.defineColumn("idcorsostudio", typeof(int),false);
	tpratica.defineColumn("iddidprog", typeof(int),false);
	tpratica.defineColumn("idiscrizione", typeof(int),false);
	tpratica.defineColumn("idistanza", typeof(int),false);
	tpratica.defineColumn("idistanzakind", typeof(int),false);
	tpratica.defineColumn("idpratica", typeof(int),false);
	tpratica.defineColumn("idreg", typeof(int),false);
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// LEARNINGAGRTRAINER /////////////////////////////////
	var tlearningagrtrainer= new MetaTable("learningagrtrainer");
	tlearningagrtrainer.defineColumn("idbandomi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrtrainer.defineColumn("idlearningagrtrainer", typeof(int),false);
	tlearningagrtrainer.defineColumn("idreg", typeof(int),false);
	tlearningagrtrainer.defineColumn("title", typeof(string),false);
	Tables.Add(tlearningagrtrainer);
	tlearningagrtrainer.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrtrainer", "idreg");

	//////////////////// LEARNINGAGRSTUD /////////////////////////////////
	var tlearningagrstud= new MetaTable("learningagrstud");
	tlearningagrstud.defineColumn("idbandomi", typeof(int),false);
	tlearningagrstud.defineColumn("idiscrizionebmi", typeof(int),false);
	tlearningagrstud.defineColumn("idlearningagrstud", typeof(int),false);
	tlearningagrstud.defineColumn("idreg", typeof(int),false);
	Tables.Add(tlearningagrstud);
	tlearningagrstud.defineKey("idbandomi", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// ISTANZA /////////////////////////////////
	var tistanza= new MetaTable("istanza");
	tistanza.defineColumn("aa", typeof(string),false);
	tistanza.defineColumn("data", typeof(DateTime),false);
	tistanza.defineColumn("iddidprog", typeof(int));
	tistanza.defineColumn("idiscrizione", typeof(int));
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int));
	Tables.Add(tistanza);
	tistanza.defineKey("idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISCRIZIONEBMISEGVIEW /////////////////////////////////
	var tiscrizionebmisegview= new MetaTable("iscrizionebmisegview");
	tiscrizionebmisegview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionebmisegview.defineColumn("idbandomi", typeof(int),false);
	tiscrizionebmisegview.defineColumn("idiscrizione", typeof(int));
	tiscrizionebmisegview.defineColumn("idiscrizionebmi", typeof(int),false);
	tiscrizionebmisegview.defineColumn("idnation", typeof(int));
	tiscrizionebmisegview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionebmisegview);
	tiscrizionebmisegview.defineKey("idiscrizionebmi");

	//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tiscrizionedefaultview_alias1= new MetaTable("iscrizionedefaultview_alias1");
	tiscrizionedefaultview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview_alias1.ExtendedProperties["TableForReading"]="iscrizionedefaultview";
	Tables.Add(tiscrizionedefaultview_alias1);
	tiscrizionedefaultview_alias1.defineKey("idiscrizione");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idiscrizione");

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

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// CONVALIDAKIND /////////////////////////////////
	var tconvalidakind= new MetaTable("convalidakind");
	tconvalidakind.defineColumn("idconvalidakind", typeof(int),false);
	tconvalidakind.defineColumn("title", typeof(string),false);
	Tables.Add(tconvalidakind);
	tconvalidakind.defineKey("idconvalidakind");

	//////////////////// CONVALIDA /////////////////////////////////
	var tconvalida= new MetaTable("convalida");
	tconvalida.defineColumn("cf", typeof(decimal));
	tconvalida.defineColumn("cfintegrazione", typeof(decimal));
	tconvalida.defineColumn("ct", typeof(DateTime),false);
	tconvalida.defineColumn("cu", typeof(string),false);
	tconvalida.defineColumn("data", typeof(DateTime));
	tconvalida.defineColumn("idconvalida", typeof(int),false);
	tconvalida.defineColumn("idconvalidakind", typeof(int));
	tconvalida.defineColumn("iddichiar", typeof(int));
	tconvalida.defineColumn("iddidprog", typeof(int));
	tconvalida.defineColumn("idiscrizione", typeof(int));
	tconvalida.defineColumn("idiscrizione_from", typeof(int));
	tconvalida.defineColumn("idiscrizionebmi", typeof(int));
	tconvalida.defineColumn("idistanza", typeof(int));
	tconvalida.defineColumn("idlearningagrstud", typeof(int));
	tconvalida.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalida.defineColumn("idpratica", typeof(int));
	tconvalida.defineColumn("idreg", typeof(int),false);
	tconvalida.defineColumn("lt", typeof(DateTime),false);
	tconvalida.defineColumn("lu", typeof(string),false);
	tconvalida.defineColumn("voto", typeof(decimal));
	tconvalida.defineColumn("votolode", typeof(string));
	tconvalida.defineColumn("votosu", typeof(int));
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idreg"]};
	var cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idreg",cPar,cChild,false));

	cPar = new []{pratica_alias1.Columns["idpratica"]};
	cChild = new []{convalidato.Columns["idpratica"]};
	Relations.Add(new DataRelation("FK_convalidato_pratica_alias1_idpratica",cPar,cChild,false));

	cPar = new []{learningagrtrainer_alias1.Columns["idlearningagrtrainer"]};
	cChild = new []{convalidato.Columns["idlearningagrtrainer"]};
	Relations.Add(new DataRelation("FK_convalidato_learningagrtrainer_alias1_idlearningagrtrainer",cPar,cChild,false));

	cPar = new []{learningagrstud_alias1.Columns["idlearningagrstud"]};
	cChild = new []{convalidato.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_convalidato_learningagrstud_alias1_idlearningagrstud",cPar,cChild,false));

	cPar = new []{istanza_alias1.Columns["idistanza"]};
	cChild = new []{convalidato.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_convalidato_istanza_alias1_idistanza",cPar,cChild,false));

	cPar = new []{iscrizionebmi.Columns["idiscrizionebmi"]};
	cChild = new []{convalidato.Columns["idiscrizionebmi"]};
	Relations.Add(new DataRelation("FK_convalidato_iscrizionebmi_idiscrizionebmi",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview_alias3.Columns["idiscrizione"]};
	cChild = new []{convalidato.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_convalidato_iscrizionedefaultview_alias3_idiscrizione_from",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview_alias2.Columns["idiscrizione"]};
	cChild = new []{convalidato.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_convalidato_iscrizionedefaultview_alias2_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview_alias1.Columns["iddidprog"]};
	cChild = new []{convalidato.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_convalidato_didprogdefaultview_alias1_iddidprog",cPar,cChild,false));

	cPar = new []{dichiar_alias1.Columns["iddichiar"]};
	cChild = new []{convalidato.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_convalidato_dichiar_alias1_iddichiar",cPar,cChild,false));

	cPar = new []{changeskinddefaultview.Columns["idchangeskind"]};
	cChild = new []{convalidato.Columns["idchangeskind"]};
	Relations.Add(new DataRelation("FK_convalidato_changeskinddefaultview_idchangeskind",cPar,cChild,false));

	cPar = new []{changes.Columns["idchanges"]};
	cChild = new []{convalidato.Columns["idchanges"]};
	Relations.Add(new DataRelation("FK_convalidato_changes_idchanges",cPar,cChild,false));

	cPar = new []{attivformdefaultview.Columns["idattivform"]};
	cChild = new []{convalidato.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_convalidato_attivformdefaultview_idattivform",cPar,cChild,false));

	cPar = new []{pratica.Columns["idpratica"]};
	cChild = new []{convalida.Columns["idpratica"]};
	Relations.Add(new DataRelation("FK_convalida_pratica_idpratica",cPar,cChild,false));

	cPar = new []{learningagrtrainer.Columns["idlearningagrtrainer"]};
	cChild = new []{convalida.Columns["idlearningagrtrainer"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrtrainer_idlearningagrtrainer",cPar,cChild,false));

	cPar = new []{learningagrstud.Columns["idlearningagrstud"]};
	cChild = new []{convalida.Columns["idlearningagrstud"]};
	Relations.Add(new DataRelation("FK_convalida_learningagrstud_idlearningagrstud",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"]};
	cChild = new []{convalida.Columns["idistanza"]};
	Relations.Add(new DataRelation("FK_convalida_istanza_idistanza",cPar,cChild,false));

	cPar = new []{iscrizionebmisegview.Columns["idiscrizionebmi"]};
	cChild = new []{convalida.Columns["idiscrizionebmi"]};
	Relations.Add(new DataRelation("FK_convalida_iscrizionebmisegview_idiscrizionebmi",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview_alias1.Columns["idiscrizione"]};
	cChild = new []{convalida.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_convalida_iscrizionedefaultview_alias1_idiscrizione_from",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{convalida.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_convalida_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{convalida.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_convalida_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{convalida.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_convalida_dichiar_iddichiar",cPar,cChild,false));

	cPar = new []{convalidakind.Columns["idconvalidakind"]};
	cChild = new []{convalida.Columns["idconvalidakind"]};
	Relations.Add(new DataRelation("FK_convalida_convalidakind_idconvalidakind",cPar,cChild,false));

	#endregion

}
}
}
