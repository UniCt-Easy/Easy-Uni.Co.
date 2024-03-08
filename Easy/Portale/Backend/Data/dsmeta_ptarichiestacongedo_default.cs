
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestacongedo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestacongedo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestastatuskind 		=> (MetaTable)Tables["ptarichiestastatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptadichiarazionepermessidefaultview 		=> (MetaTable)Tables["ptadichiarazionepermessidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestacongedo 		=> (MetaTable)Tables["ptarichiestacongedo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestacongedo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestacongedo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestacongedo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestacongedo_default.xsd";

	#region create DataTables
	//////////////////// PTARICHIESTASTATUSKIND /////////////////////////////////
	var tptarichiestastatuskind= new MetaTable("ptarichiestastatuskind");
	tptarichiestastatuskind.defineColumn("idptarichiestastatuskind", typeof(int),false);
	tptarichiestastatuskind.defineColumn("title", typeof(string));
	Tables.Add(tptarichiestastatuskind);
	tptarichiestastatuskind.defineKey("idptarichiestastatuskind");

	//////////////////// PTADICHIARAZIONEPERMESSIDEFAULTVIEW /////////////////////////////////
	var tptadichiarazionepermessidefaultview= new MetaTable("ptadichiarazionepermessidefaultview");
	tptadichiarazionepermessidefaultview.defineColumn("dropdown_title", typeof(string),false);
	tptadichiarazionepermessidefaultview.defineColumn("idptadichiarazionepermessi", typeof(int),false);
	tptadichiarazionepermessidefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tptadichiarazionepermessidefaultview);
	tptadichiarazionepermessidefaultview.defineKey("idptadichiarazionepermessi", "idreg");

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

	//////////////////// PTARICHIESTACONGEDO /////////////////////////////////
	var tptarichiestacongedo= new MetaTable("ptarichiestacongedo");
	tptarichiestacongedo.defineColumn("ct", typeof(DateTime),false);
	tptarichiestacongedo.defineColumn("cu", typeof(string),false);
	tptarichiestacongedo.defineColumn("data", typeof(DateTime));
	tptarichiestacongedo.defineColumn("idafferenza", typeof(int));
	tptarichiestacongedo.defineColumn("idptadichiarazionepermessi", typeof(int));
	tptarichiestacongedo.defineColumn("idptarichiestacongedo", typeof(int),false);
	tptarichiestacongedo.defineColumn("idptarichiestastatuskind", typeof(int));
	tptarichiestacongedo.defineColumn("idreg", typeof(int),false);
	tptarichiestacongedo.defineColumn("lt", typeof(DateTime),false);
	tptarichiestacongedo.defineColumn("lu", typeof(string),false);
	tptarichiestacongedo.defineColumn("orario", typeof(string));
	tptarichiestacongedo.defineColumn("protanno", typeof(int));
	tptarichiestacongedo.defineColumn("protnumero", typeof(int));
	tptarichiestacongedo.defineColumn("start", typeof(DateTime));
	tptarichiestacongedo.defineColumn("stop", typeof(DateTime));
	Tables.Add(tptarichiestacongedo);
	tptarichiestacongedo.defineKey("idptarichiestacongedo");

	#endregion


	#region DataRelation creation
	var cPar = new []{ptarichiestastatuskind.Columns["idptarichiestastatuskind"]};
	var cChild = new []{ptarichiestacongedo.Columns["idptarichiestastatuskind"]};
	Relations.Add(new DataRelation("FK_ptarichiestacongedo_ptarichiestastatuskind_idptarichiestastatuskind",cPar,cChild,false));

	cPar = new []{ptadichiarazionepermessidefaultview.Columns["idptadichiarazionepermessi"]};
	cChild = new []{ptarichiestacongedo.Columns["idptadichiarazionepermessi"]};
	Relations.Add(new DataRelation("FK_ptarichiestacongedo_ptadichiarazionepermessidefaultview_idptadichiarazionepermessi",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{ptarichiestacongedo.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_ptarichiestacongedo_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{ptarichiestacongedo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ptarichiestacongedo_registryamministrativiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
