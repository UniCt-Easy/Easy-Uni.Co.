
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_pas_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_istanza_pas_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_alias4 		=> (MetaTable)Tables["nullaosta_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias3 		=> (MetaTable)Tables["diniego_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istattitolistudio 		=> (MetaTable)Tables["istattitolistudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias1 		=> (MetaTable)Tables["statuskind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarkind 		=> (MetaTable)Tables["dichiarkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

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
public dsmeta_istanza_pas_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_pas_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_pas_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_pas_seganagstu.xsd";

	#region create DataTables
	//////////////////// NULLAOSTA_ALIAS4 /////////////////////////////////
	var tnullaosta_alias4= new MetaTable("nullaosta_alias4");
	tnullaosta_alias4.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_alias4.defineColumn("cu", typeof(string),false);
	tnullaosta_alias4.defineColumn("data", typeof(DateTime),false);
	tnullaosta_alias4.defineColumn("extension", typeof(string));
	tnullaosta_alias4.defineColumn("idcorsostudio", typeof(int));
	tnullaosta_alias4.defineColumn("iddidprog", typeof(int));
	tnullaosta_alias4.defineColumn("idiscrizione", typeof(int));
	tnullaosta_alias4.defineColumn("idistanza", typeof(int),false);
	tnullaosta_alias4.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_alias4.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_alias4.defineColumn("idreg", typeof(int),false);
	tnullaosta_alias4.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_alias4.defineColumn("lu", typeof(string),false);
	tnullaosta_alias4.defineColumn("protanno", typeof(int));
	tnullaosta_alias4.defineColumn("protnumero", typeof(int));
	tnullaosta_alias4.ExtendedProperties["TableForReading"]="nullaosta";
	Tables.Add(tnullaosta_alias4);
	tnullaosta_alias4.defineKey("idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// DINIEGO_ALIAS3 /////////////////////////////////
	var tdiniego_alias3= new MetaTable("diniego_alias3");
	tdiniego_alias3.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("cu", typeof(string),false);
	tdiniego_alias3.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias3.defineColumn("iddidprog", typeof(int));
	tdiniego_alias3.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias3.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias3.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias3.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias3.defineColumn("idreg", typeof(int),false);
	tdiniego_alias3.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("lu", typeof(string),false);
	tdiniego_alias3.defineColumn("protanno", typeof(int));
	tdiniego_alias3.defineColumn("protnumero", typeof(int));
	tdiniego_alias3.ExtendedProperties["TableForReading"]="diniego";
	Tables.Add(tdiniego_alias3);
	tdiniego_alias3.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// TITOLOSTUDIO /////////////////////////////////
	var ttitolostudio= new MetaTable("titolostudio");
	ttitolostudio.defineColumn("aa", typeof(string),false);
	ttitolostudio.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudio.defineColumn("idreg", typeof(int),false);
	ttitolostudio.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudio.defineColumn("voto", typeof(int));
	ttitolostudio.defineColumn("votolode", typeof(string));
	ttitolostudio.defineColumn("votosu", typeof(int));
	Tables.Add(ttitolostudio);
	ttitolostudio.defineKey("idreg", "idtitolostudio");

	//////////////////// ISTATTITOLISTUDIO /////////////////////////////////
	var tistattitolistudio= new MetaTable("istattitolistudio");
	tistattitolistudio.defineColumn("idistattitolistudio", typeof(int),false);
	tistattitolistudio.defineColumn("titolo", typeof(string),false);
	Tables.Add(tistattitolistudio);
	tistattitolistudio.defineKey("idistattitolistudio");

	//////////////////// STATUSKIND_ALIAS1 /////////////////////////////////
	var tstatuskind_alias1= new MetaTable("statuskind_alias1");
	tstatuskind_alias1.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias1.defineColumn("title", typeof(string),false);
	tstatuskind_alias1.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias1);
	tstatuskind_alias1.defineKey("idstatuskind");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// DICHIARKIND /////////////////////////////////
	var tdichiarkind= new MetaTable("dichiarkind");
	tdichiarkind.defineColumn("iddichiarkind", typeof(int),false);
	tdichiarkind.defineColumn("title", typeof(string),false);
	Tables.Add(tdichiarkind);
	tdichiarkind.defineKey("iddichiarkind");

	//////////////////// PRATICA /////////////////////////////////
	var tpratica= new MetaTable("pratica");
	tpratica.defineColumn("ct", typeof(DateTime),false);
	tpratica.defineColumn("cu", typeof(string),false);
	tpratica.defineColumn("idcorsostudio", typeof(int),false);
	tpratica.defineColumn("iddichiar", typeof(int));
	tpratica.defineColumn("iddidprog", typeof(int),false);
	tpratica.defineColumn("idiscrizione", typeof(int),false);
	tpratica.defineColumn("idiscrizione_from", typeof(int));
	tpratica.defineColumn("idistanza", typeof(int),false);
	tpratica.defineColumn("idistanzakind", typeof(int),false);
	tpratica.defineColumn("idpratica", typeof(int),false);
	tpratica.defineColumn("idreg", typeof(int),false);
	tpratica.defineColumn("idstatuskind", typeof(int),false);
	tpratica.defineColumn("idtitolostudio", typeof(int));
	tpratica.defineColumn("lt", typeof(DateTime),false);
	tpratica.defineColumn("lu", typeof(string),false);
	tpratica.defineColumn("protanno", typeof(int));
	tpratica.defineColumn("protnumero", typeof(int));
	tpratica.defineColumn("!iddichiar_dichiar_aa", typeof(string));
	tpratica.defineColumn("!iddichiar_dichiar_date", typeof(DateTime));
	tpratica.defineColumn("!iddichiar_dichiar_iddichiarkind_title", typeof(string));
	tpratica.defineColumn("!iddichiar_dichiar_idreg_title", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_anno", typeof(int));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_aa", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_title", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_aa", typeof(string));
	tpratica.defineColumn("!idiscrizione_from_iscrizione_iddidprog_idsede", typeof(int));
	tpratica.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	tpratica.defineColumn("!idtitolostudio_titolostudio_voto", typeof(int));
	tpratica.defineColumn("!idtitolostudio_titolostudio_votosu", typeof(int));
	tpratica.defineColumn("!idtitolostudio_titolostudio_votolode", typeof(string));
	tpratica.defineColumn("!idtitolostudio_titolostudio_aa", typeof(string));
	tpratica.defineColumn("!idtitolostudio_titolostudio_idistattitolistudio_titolo", typeof(string));
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("annoaccademico_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int));
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int));
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idiscrizione");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

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
	tistanza.defineColumn("protanno", typeof(int),false);
	tistanza.defineColumn("protnumero", typeof(int),false);
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
	var cChild = new []{nullaosta_alias4.Columns["idcorsostudio"], nullaosta_alias4.Columns["iddidprog"], nullaosta_alias4.Columns["idiscrizione"], nullaosta_alias4.Columns["idistanza"], nullaosta_alias4.Columns["idistanzakind"], nullaosta_alias4.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_alias4_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{diniego_alias3.Columns["idcorsostudio"], diniego_alias3.Columns["iddidprog"], diniego_alias3.Columns["idiscrizione"], diniego_alias3.Columns["idistanza"], diniego_alias3.Columns["idistanzakind"], diniego_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias3_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{pratica.Columns["idcorsostudio"], pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idistanza"], pratica.Columns["idistanzakind"], pratica.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{titolostudio.Columns["idtitolostudio"]};
	cChild = new []{pratica.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_pratica_titolostudio_idtitolostudio",cPar,cChild,false));

	cPar = new []{istattitolistudio.Columns["idistattitolistudio"]};
	cChild = new []{titolostudio.Columns["idistattitolistudio"]};
	Relations.Add(new DataRelation("FK_titolostudio_istattitolistudio_idistattitolistudio",cPar,cChild,false));

	cPar = new []{statuskind_alias1.Columns["idstatuskind"]};
	cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskind_alias1_idstatuskind",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizione_idiscrizione_from",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{pratica.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_pratica_dichiar_iddichiar",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{dichiar.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_dichiar_registry_idreg",cPar,cChild,false));

	cPar = new []{dichiarkind.Columns["iddichiarkind"]};
	cChild = new []{dichiar.Columns["iddichiarkind"]};
	Relations.Add(new DataRelation("FK_dichiar_dichiarkind_iddichiarkind",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{istanza_pas.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_istanza_pas_iscrizionedefaultview_idiscrizione_from",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idiscrizione"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idiscrizione"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_pas_istanza_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg-",cPar,cChild,false));

	#endregion

}
}
}
