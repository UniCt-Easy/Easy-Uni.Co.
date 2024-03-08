
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
[System.Xml.Serialization.XmlRoot("dsmeta_pratica_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_pratica_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview_alias1 		=> (MetaTable)Tables["iscrizionedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

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

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

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

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

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
	var cPar = new []{titolostudio.Columns["idtitolostudio"]};
	var cChild = new []{pratica.Columns["idtitolostudio"]};
	Relations.Add(new DataRelation("FK_pratica_titolostudio_idtitolostudio",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{pratica.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_pratica_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview_alias1.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizionedefaultview_alias1_idiscrizione_from",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{pratica.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_pratica_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{pratica.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_pratica_dichiar_iddichiar",cPar,cChild,false));

	#endregion

}
}
}
