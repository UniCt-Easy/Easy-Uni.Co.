
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestariposi_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestariposi_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestastatuskind 		=> (MetaTable)Tables["ptarichiestastatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptadichiarazioneassenzapermessidefaultview 		=> (MetaTable)Tables["ptadichiarazioneassenzapermessidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycongiuntodefaultview 		=> (MetaTable)Tables["registrycongiuntodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestariposi 		=> (MetaTable)Tables["ptarichiestariposi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestariposi_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestariposi_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestariposi_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestariposi_default.xsd";

	#region create DataTables
	//////////////////// PTARICHIESTASTATUSKIND /////////////////////////////////
	var tptarichiestastatuskind= new MetaTable("ptarichiestastatuskind");
	tptarichiestastatuskind.defineColumn("idptarichiestastatuskind", typeof(int),false);
	tptarichiestastatuskind.defineColumn("title", typeof(string));
	Tables.Add(tptarichiestastatuskind);
	tptarichiestastatuskind.defineKey("idptarichiestastatuskind");

	//////////////////// PTADICHIARAZIONEASSENZAPERMESSIDEFAULTVIEW /////////////////////////////////
	var tptadichiarazioneassenzapermessidefaultview= new MetaTable("ptadichiarazioneassenzapermessidefaultview");
	tptadichiarazioneassenzapermessidefaultview.defineColumn("dropdown_title", typeof(string),false);
	tptadichiarazioneassenzapermessidefaultview.defineColumn("idptadichiarazioneassenzapermessi", typeof(int),false);
	tptadichiarazioneassenzapermessidefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tptadichiarazioneassenzapermessidefaultview);
	tptadichiarazioneassenzapermessidefaultview.defineKey("idptadichiarazioneassenzapermessi", "idreg");

	//////////////////// REGISTRYCONGIUNTODEFAULTVIEW /////////////////////////////////
	var tregistrycongiuntodefaultview= new MetaTable("registrycongiuntodefaultview");
	tregistrycongiuntodefaultview.defineColumn("congiuntokind_title", typeof(string));
	tregistrycongiuntodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrycongiuntodefaultview.defineColumn("idcongiuntokind", typeof(int));
	tregistrycongiuntodefaultview.defineColumn("idreg", typeof(int),false);
	tregistrycongiuntodefaultview.defineColumn("idreg_parente", typeof(int),false);
	tregistrycongiuntodefaultview.defineColumn("idregistrycongiunto", typeof(int),false);
	tregistrycongiuntodefaultview.defineColumn("registrycongiunto_ct", typeof(DateTime),false);
	tregistrycongiuntodefaultview.defineColumn("registrycongiunto_cu", typeof(string),false);
	tregistrycongiuntodefaultview.defineColumn("registrycongiunto_lt", typeof(DateTime),false);
	tregistrycongiuntodefaultview.defineColumn("registrycongiunto_lu", typeof(string),false);
	tregistrycongiuntodefaultview.defineColumn("registryparente_title", typeof(string));
	Tables.Add(tregistrycongiuntodefaultview);
	tregistrycongiuntodefaultview.defineKey("idreg", "idreg_parente", "idregistrycongiunto");

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

	//////////////////// PTARICHIESTARIPOSI /////////////////////////////////
	var tptarichiestariposi= new MetaTable("ptarichiestariposi");
	tptarichiestariposi.defineColumn("ct", typeof(DateTime),false);
	tptarichiestariposi.defineColumn("cu", typeof(string),false);
	tptarichiestariposi.defineColumn("data", typeof(DateTime));
	tptarichiestariposi.defineColumn("idafferenza", typeof(int));
	tptarichiestariposi.defineColumn("idptadichiarazioneassenzapermessi", typeof(int));
	tptarichiestariposi.defineColumn("idptarichiestariposi", typeof(int),false);
	tptarichiestariposi.defineColumn("idptarichiestastatuskind", typeof(int));
	tptarichiestariposi.defineColumn("idreg", typeof(int),false);
	tptarichiestariposi.defineColumn("idregistrycongiunto", typeof(int));
	tptarichiestariposi.defineColumn("lt", typeof(DateTime),false);
	tptarichiestariposi.defineColumn("lu", typeof(string),false);
	tptarichiestariposi.defineColumn("orario", typeof(string));
	tptarichiestariposi.defineColumn("protanno", typeof(int));
	tptarichiestariposi.defineColumn("protnumero", typeof(int));
	tptarichiestariposi.defineColumn("start", typeof(DateTime));
	tptarichiestariposi.defineColumn("stop", typeof(DateTime));
	Tables.Add(tptarichiestariposi);
	tptarichiestariposi.defineKey("idptarichiestariposi", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{ptarichiestastatuskind.Columns["idptarichiestastatuskind"]};
	var cChild = new []{ptarichiestariposi.Columns["idptarichiestastatuskind"]};
	Relations.Add(new DataRelation("FK_ptarichiestariposi_ptarichiestastatuskind_idptarichiestastatuskind",cPar,cChild,false));

	cPar = new []{ptadichiarazioneassenzapermessidefaultview.Columns["idptadichiarazioneassenzapermessi"]};
	cChild = new []{ptarichiestariposi.Columns["idptadichiarazioneassenzapermessi"]};
	Relations.Add(new DataRelation("FK_ptarichiestariposi_ptadichiarazioneassenzapermessidefaultview_idptadichiarazioneassenzapermessi",cPar,cChild,false));

	cPar = new []{registrycongiuntodefaultview.Columns["idregistrycongiunto"]};
	cChild = new []{ptarichiestariposi.Columns["idregistrycongiunto"]};
	Relations.Add(new DataRelation("FK_ptarichiestariposi_registrycongiuntodefaultview_idregistrycongiunto",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{ptarichiestariposi.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_ptarichiestariposi_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{ptarichiestariposi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ptarichiestariposi_registryamministrativiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
