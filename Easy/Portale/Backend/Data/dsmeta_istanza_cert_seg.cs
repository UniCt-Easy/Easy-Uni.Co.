
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
[System.Xml.Serialization.XmlRoot("dsmeta_istanza_cert_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_istanza_cert_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzaattach 		=> (MetaTable)Tables["istanzaattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable certkind 		=> (MetaTable)Tables["certkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_cert 		=> (MetaTable)Tables["istanza_cert"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_istanza_cert_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_istanza_cert_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_istanza_cert_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_istanza_cert_seg.xsd";

	#region create DataTables
	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// ISTANZAATTACH /////////////////////////////////
	var tistanzaattach= new MetaTable("istanzaattach");
	tistanzaattach.defineColumn("ct", typeof(DateTime),false);
	tistanzaattach.defineColumn("cu", typeof(string),false);
	tistanzaattach.defineColumn("idattach", typeof(int),false);
	tistanzaattach.defineColumn("idistanza", typeof(int),false);
	tistanzaattach.defineColumn("idistanzakind", typeof(int),false);
	tistanzaattach.defineColumn("idreg", typeof(int),false);
	tistanzaattach.defineColumn("lt", typeof(DateTime),false);
	tistanzaattach.defineColumn("lu", typeof(string),false);
	tistanzaattach.defineColumn("!idattach_attach_filename", typeof(string));
	tistanzaattach.defineColumn("!idattach_attach_size", typeof(int));
	Tables.Add(tistanzaattach);
	tistanzaattach.defineKey("idattach", "idistanza", "idistanzakind", "idreg");

	//////////////////// CERTKIND /////////////////////////////////
	var tcertkind= new MetaTable("certkind");
	tcertkind.defineColumn("description", typeof(string),false);
	tcertkind.defineColumn("idcertkind", typeof(int),false);
	tcertkind.defineColumn("title", typeof(string),false);
	Tables.Add(tcertkind);
	tcertkind.defineKey("idcertkind");

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
	tistanza.defineColumn("idstatuskind", typeof(int));
	tistanza.defineColumn("lt", typeof(DateTime),false);
	tistanza.defineColumn("lu", typeof(string),false);
	tistanza.defineColumn("paridistanza", typeof(int));
	tistanza.defineColumn("protanno", typeof(int),false);
	tistanza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tistanza);
	tistanza.defineKey("idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_CERT /////////////////////////////////
	var tistanza_cert= new MetaTable("istanza_cert");
	tistanza_cert.defineColumn("ct", typeof(DateTime),false);
	tistanza_cert.defineColumn("cu", typeof(string),false);
	tistanza_cert.defineColumn("idcertkind", typeof(int),false);
	tistanza_cert.defineColumn("idistanza", typeof(int),false);
	tistanza_cert.defineColumn("idistanzakind", typeof(int),false);
	tistanza_cert.defineColumn("idreg", typeof(int),false);
	tistanza_cert.defineColumn("lt", typeof(DateTime),false);
	tistanza_cert.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanza_cert);
	tistanza_cert.defineKey("idistanza", "idistanzakind", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	var cChild = new []{istanzaattach.Columns["idistanza"], istanzaattach.Columns["idistanzakind"], istanzaattach.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanzaattach_istanza_idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{istanzaattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_istanzaattach_attach_idattach",cPar,cChild,false));

	cPar = new []{certkind.Columns["idcertkind"]};
	cChild = new []{istanza_cert.Columns["idcertkind"]};
	Relations.Add(new DataRelation("FK_istanza_cert_certkind_idcertkind",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{istanza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_istanza_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_cert.Columns["idistanza"], istanza_cert.Columns["idistanzakind"], istanza_cert.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_cert_istanza_idistanza-idistanzakind-idreg-",cPar,cChild,false));

	#endregion

}
}
}
