
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptarichiestamaternita_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptarichiestamaternita_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestastatuskind 		=> (MetaTable)Tables["ptarichiestastatuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview_alias1 		=> (MetaTable)Tables["registryamministrativiview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptarichiestamaternita 		=> (MetaTable)Tables["ptarichiestamaternita"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptarichiestamaternita_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptarichiestamaternita_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptarichiestamaternita_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptarichiestamaternita_default.xsd";

	#region create DataTables
	//////////////////// PTARICHIESTASTATUSKIND /////////////////////////////////
	var tptarichiestastatuskind= new MetaTable("ptarichiestastatuskind");
	tptarichiestastatuskind.defineColumn("idptarichiestastatuskind", typeof(int),false);
	tptarichiestastatuskind.defineColumn("title", typeof(string));
	Tables.Add(tptarichiestastatuskind);
	tptarichiestastatuskind.defineKey("idptarichiestastatuskind");

	//////////////////// REGISTRYAMMINISTRATIVIVIEW_ALIAS1 /////////////////////////////////
	var tregistryamministrativiview_alias1= new MetaTable("registryamministrativiview_alias1");
	tregistryamministrativiview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tregistryamministrativiview_alias1.defineColumn("idreg", typeof(int),false);
	tregistryamministrativiview_alias1.defineColumn("registry_active", typeof(string));
	tregistryamministrativiview_alias1.ExtendedProperties["TableForReading"]="registryamministrativiview";
	Tables.Add(tregistryamministrativiview_alias1);
	tregistryamministrativiview_alias1.defineKey("idreg");

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

	//////////////////// PTARICHIESTAMATERNITA /////////////////////////////////
	var tptarichiestamaternita= new MetaTable("ptarichiestamaternita");
	tptarichiestamaternita.defineColumn("ct", typeof(DateTime),false);
	tptarichiestamaternita.defineColumn("cu", typeof(string),false);
	tptarichiestamaternita.defineColumn("data", typeof(DateTime));
	tptarichiestamaternita.defineColumn("idafferenza", typeof(int));
	tptarichiestamaternita.defineColumn("idattach", typeof(int));
	tptarichiestamaternita.defineColumn("idptarichiestamaternita", typeof(int),false);
	tptarichiestamaternita.defineColumn("idptarichiestastatuskind", typeof(int));
	tptarichiestamaternita.defineColumn("idreg", typeof(int),false);
	tptarichiestamaternita.defineColumn("idreg_resp", typeof(int));
	tptarichiestamaternita.defineColumn("lt", typeof(DateTime),false);
	tptarichiestamaternita.defineColumn("lu", typeof(string),false);
	tptarichiestamaternita.defineColumn("protanno", typeof(int));
	tptarichiestamaternita.defineColumn("protnumero", typeof(int));
	tptarichiestamaternita.defineColumn("start", typeof(DateTime));
	tptarichiestamaternita.defineColumn("stop", typeof(DateTime));
	Tables.Add(tptarichiestamaternita);
	tptarichiestamaternita.defineKey("idptarichiestamaternita", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{ptarichiestastatuskind.Columns["idptarichiestastatuskind"]};
	var cChild = new []{ptarichiestamaternita.Columns["idptarichiestastatuskind"]};
	Relations.Add(new DataRelation("FK_ptarichiestamaternita_ptarichiestastatuskind_idptarichiestastatuskind",cPar,cChild,false));

	cPar = new []{registryamministrativiview_alias1.Columns["idreg"]};
	cChild = new []{ptarichiestamaternita.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_ptarichiestamaternita_registryamministrativiview_alias1_idreg_resp",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{ptarichiestamaternita.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_ptarichiestamaternita_attach_idattach",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{ptarichiestamaternita.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_ptarichiestamaternita_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{ptarichiestamaternita.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ptarichiestamaternita_registryamministrativiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
