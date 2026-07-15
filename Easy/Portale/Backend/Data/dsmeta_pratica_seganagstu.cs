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
[System.Xml.Serialization.XmlRoot("dsmeta_pratica_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pratica_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskinddefaultview 		=> (MetaTable)Tables["statuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudiodocentiview 		=> (MetaTable)Tables["titolostudiodocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias1 		=> (MetaTable)Tables["iscrizionedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiaraltre_segview 		=> (MetaTable)Tables["dichiaraltre_segview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pratica_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pratica_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pratica_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pratica_seganagstu.xsd";

	#region create DataTables
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

	//////////////////// TITOLOSTUDIODOCENTIVIEW /////////////////////////////////
	var ttitolostudiodocentiview= new MetaTable("titolostudiodocentiview");
	ttitolostudiodocentiview.defineColumn("aa", typeof(string),false);
	ttitolostudiodocentiview.defineColumn("attach_filename", typeof(string));
	ttitolostudiodocentiview.defineColumn("dropdown_title", typeof(string),false);
	ttitolostudiodocentiview.defineColumn("idattach", typeof(int));
	ttitolostudiodocentiview.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idreg", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idreg_istituti", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudiodocentiview.defineColumn("istattitolistudio_titolo", typeof(string));
	ttitolostudiodocentiview.defineColumn("registryistituti_title", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_conseguito", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_ct", typeof(DateTime));
	ttitolostudiodocentiview.defineColumn("titolostudio_cu", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_data", typeof(DateTime));
	ttitolostudiodocentiview.defineColumn("titolostudio_giudizio", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_lt", typeof(DateTime));
	ttitolostudiodocentiview.defineColumn("titolostudio_lu", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_voto", typeof(int));
	ttitolostudiodocentiview.defineColumn("titolostudio_votolode", typeof(string));
	ttitolostudiodocentiview.defineColumn("titolostudio_votosu", typeof(int));
	Tables.Add(ttitolostudiodocentiview);
	ttitolostudiodocentiview.defineKey("idreg", "idtitolostudio");

	//////////////////// ISCRIZIONEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tiscrizionedefaultview_alias1= new MetaTable("iscrizionedefaultview_alias1");
	tiscrizionedefaultview_alias1.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("anno", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("didprog_aa", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("didprog_idsede", typeof(int));
	tiscrizionedefaultview_alias1.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("iddidprog", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview_alias1.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview_alias1.defineColumn("sede_title", typeof(string));
	tiscrizionedefaultview_alias1.ExtendedProperties["TableForReading"]="iscrizionedefaultview";
	Tables.Add(tiscrizionedefaultview_alias1);
	tiscrizionedefaultview_alias1.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_idsede", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int),false);
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
	tiscrizionedefaultview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// DICHIARALTRE_SEGVIEW /////////////////////////////////
	var tdichiaraltre_segview= new MetaTable("dichiaraltre_segview");
	tdichiaraltre_segview.defineColumn("aa", typeof(string));
	tdichiaraltre_segview.defineColumn("dichiar_altre_ct", typeof(DateTime),false);
	tdichiaraltre_segview.defineColumn("dichiar_altre_cu", typeof(string),false);
	tdichiaraltre_segview.defineColumn("dichiar_altre_iddichiar", typeof(int),false);
	tdichiaraltre_segview.defineColumn("dichiar_altre_iddichiaraltrekind", typeof(int),false);
	tdichiaraltre_segview.defineColumn("dichiar_altre_idreg", typeof(int),false);
	tdichiaraltre_segview.defineColumn("dichiar_altre_lt", typeof(DateTime),false);
	tdichiaraltre_segview.defineColumn("dichiar_altre_lu", typeof(string),false);
	tdichiaraltre_segview.defineColumn("dichiar_ct", typeof(DateTime),false);
	tdichiaraltre_segview.defineColumn("dichiar_cu", typeof(string),false);
	tdichiaraltre_segview.defineColumn("dichiar_date", typeof(DateTime),false);
	tdichiaraltre_segview.defineColumn("dichiar_extension", typeof(string));
	tdichiaraltre_segview.defineColumn("dichiar_iddichiarkind", typeof(int),false);
	tdichiaraltre_segview.defineColumn("dichiar_lt", typeof(DateTime),false);
	tdichiaraltre_segview.defineColumn("dichiar_lu", typeof(string),false);
	tdichiaraltre_segview.defineColumn("dichiar_protanno", typeof(int));
	tdichiaraltre_segview.defineColumn("dichiar_protnumero", typeof(int));
	tdichiaraltre_segview.defineColumn("dichiaraltrekind_title", typeof(string));
	tdichiaraltre_segview.defineColumn("iddichiar", typeof(int),false);
	tdichiaraltre_segview.defineColumn("idreg", typeof(int),false);
	tdichiaraltre_segview.defineColumn("registry_title", typeof(string));
	Tables.Add(tdichiaraltre_segview);
	tdichiaraltre_segview.defineKey("iddichiar", "idreg");

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
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{statuskinddefaultview.Columns["idstatuskind"]};
	var cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskinddefaultview_idstatuskind",cPar,cChild,false));

	cPar = new []{titolostudiodocentiview.Columns["idtitolostudio"]};
	cChild = new []{pratica.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_pratica_titolostudiodocentiview_idtitolostudio",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview_alias1.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizionedefaultview_alias1_idiscrizione_from",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{dichiaraltre_segview.Columns["iddichiar"]};
	cChild = new []{pratica.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_pratica_dichiaraltre_segview_iddichiar",cPar,cChild,false));

	#endregion

}
}
}
