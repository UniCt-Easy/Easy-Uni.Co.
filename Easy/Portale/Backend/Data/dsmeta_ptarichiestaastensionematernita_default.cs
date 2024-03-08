
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestaastensionematernita_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestaastensionematernita_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestastatuskind 		=> (MetaTable)Tables["ptarichiestastatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptadichiarazionemansionidefaultview 		=> (MetaTable)Tables["ptadichiarazionemansionidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestaastensionematernita 		=> (MetaTable)Tables["ptarichiestaastensionematernita"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestaastensionematernita_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestaastensionematernita_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestaastensionematernita_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestaastensionematernita_default.xsd";

	#region create DataTables
	//////////////////// PTARICHIESTASTATUSKIND /////////////////////////////////
	var tptarichiestastatuskind= new MetaTable("ptarichiestastatuskind");
	tptarichiestastatuskind.defineColumn("idptarichiestastatuskind", typeof(int),false);
	tptarichiestastatuskind.defineColumn("title", typeof(string));
	Tables.Add(tptarichiestastatuskind);
	tptarichiestastatuskind.defineKey("idptarichiestastatuskind");

	//////////////////// PTADICHIARAZIONEMANSIONIDEFAULTVIEW /////////////////////////////////
	var tptadichiarazionemansionidefaultview= new MetaTable("ptadichiarazionemansionidefaultview");
	tptadichiarazionemansionidefaultview.defineColumn("dropdown_title", typeof(string),false);
	tptadichiarazionemansionidefaultview.defineColumn("idptadichiarazionemansioni", typeof(int),false);
	Tables.Add(tptadichiarazionemansionidefaultview);
	tptadichiarazionemansionidefaultview.defineKey("idptadichiarazionemansioni");

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

	//////////////////// AFFERENZAAMMVIEW /////////////////////////////////
	var tafferenzaammview= new MetaTable("afferenzaammview");
	tafferenzaammview.defineColumn("afferenza_ct", typeof(DateTime),false);
	tafferenzaammview.defineColumn("afferenza_cu", typeof(string),false);
	tafferenzaammview.defineColumn("afferenza_idmansionekind", typeof(int));
	tafferenzaammview.defineColumn("afferenza_lt", typeof(DateTime),false);
	tafferenzaammview.defineColumn("afferenza_lu", typeof(string),false);
	tafferenzaammview.defineColumn("afferenza_start", typeof(DateTime));
	tafferenzaammview.defineColumn("afferenza_stop", typeof(DateTime));
	tafferenzaammview.defineColumn("dropdown_title", typeof(string),false);
	tafferenzaammview.defineColumn("idafferenza", typeof(int),false);
	tafferenzaammview.defineColumn("idreg", typeof(int),false);
	tafferenzaammview.defineColumn("idstruttura", typeof(int));
	tafferenzaammview.defineColumn("mansionekind_title", typeof(string));
	tafferenzaammview.defineColumn("struttura_paridstruttura", typeof(int));
	tafferenzaammview.defineColumn("struttura_title", typeof(string));
	tafferenzaammview.defineColumn("strutturaparent_title", typeof(string));
	Tables.Add(tafferenzaammview);
	tafferenzaammview.defineKey("idafferenza", "idreg");

	//////////////////// REGISTRYAMMINISTRATIVIVIEW /////////////////////////////////
	var tregistryamministrativiview= new MetaTable("registryamministrativiview");
	tregistryamministrativiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryamministrativiview.defineColumn("idreg", typeof(int),false);
	tregistryamministrativiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryamministrativiview);
	tregistryamministrativiview.defineKey("idreg");

	//////////////////// PTARICHIESTAASTENSIONEMATERNITA /////////////////////////////////
	var tptarichiestaastensionematernita= new MetaTable("ptarichiestaastensionematernita");
	tptarichiestaastensionematernita.defineColumn("ct", typeof(DateTime),false);
	tptarichiestaastensionematernita.defineColumn("cu", typeof(string),false);
	tptarichiestaastensionematernita.defineColumn("data", typeof(DateTime));
	tptarichiestaastensionematernita.defineColumn("dataparto", typeof(DateTime));
	tptarichiestaastensionematernita.defineColumn("idafferenza", typeof(int));
	tptarichiestaastensionematernita.defineColumn("idattach", typeof(int));
	tptarichiestaastensionematernita.defineColumn("idptadichiarazionemansioni", typeof(int));
	tptarichiestaastensionematernita.defineColumn("idptarichiestaastensionematernita", typeof(int),false);
	tptarichiestaastensionematernita.defineColumn("idptarichiestastatuskind", typeof(int));
	tptarichiestaastensionematernita.defineColumn("idreg", typeof(int),false);
	tptarichiestaastensionematernita.defineColumn("lt", typeof(DateTime),false);
	tptarichiestaastensionematernita.defineColumn("lu", typeof(string),false);
	tptarichiestaastensionematernita.defineColumn("protanno", typeof(int));
	tptarichiestaastensionematernita.defineColumn("protnumero", typeof(int));
	Tables.Add(tptarichiestaastensionematernita);
	tptarichiestaastensionematernita.defineKey("idptarichiestaastensionematernita", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{ptarichiestastatuskind.Columns["idptarichiestastatuskind"]};
	var cChild = new []{ptarichiestaastensionematernita.Columns["idptarichiestastatuskind"]};
	Relations.Add(new DataRelation("FK_ptarichiestaastensionematernita_ptarichiestastatuskind_idptarichiestastatuskind",cPar,cChild,false));

	cPar = new []{ptadichiarazionemansionidefaultview.Columns["idptadichiarazionemansioni"]};
	cChild = new []{ptarichiestaastensionematernita.Columns["idptadichiarazionemansioni"]};
	Relations.Add(new DataRelation("FK_ptarichiestaastensionematernita_ptadichiarazionemansionidefaultview_idptadichiarazionemansioni",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{ptarichiestaastensionematernita.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_ptarichiestaastensionematernita_attach_idattach",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{ptarichiestaastensionematernita.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_ptarichiestaastensionematernita_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{ptarichiestaastensionematernita.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ptarichiestaastensionematernita_registryamministrativiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
