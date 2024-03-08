
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptadichiarazionepermessi_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptadichiarazionepermessi_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycongiuntodefaultview 		=> (MetaTable)Tables["registrycongiuntodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptadichiarazionepermessi 		=> (MetaTable)Tables["ptadichiarazionepermessi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptadichiarazionepermessi_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptadichiarazionepermessi_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptadichiarazionepermessi_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptadichiarazionepermessi_default.xsd";

	#region create DataTables
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

	//////////////////// PTADICHIARAZIONEPERMESSI /////////////////////////////////
	var tptadichiarazionepermessi= new MetaTable("ptadichiarazionepermessi");
	tptadichiarazionepermessi.defineColumn("ct", typeof(DateTime),false);
	tptadichiarazionepermessi.defineColumn("cu", typeof(string),false);
	tptadichiarazionepermessi.defineColumn("data", typeof(DateTime));
	tptadichiarazionepermessi.defineColumn("giorni100", typeof(int));
	tptadichiarazionepermessi.defineColumn("giorni30", typeof(int));
	tptadichiarazionepermessi.defineColumn("giornino", typeof(int));
	tptadichiarazionepermessi.defineColumn("idafferenza", typeof(int));
	tptadichiarazionepermessi.defineColumn("idptadichiarazionepermessi", typeof(int),false);
	tptadichiarazionepermessi.defineColumn("idreg", typeof(int),false);
	tptadichiarazionepermessi.defineColumn("idregistrycongiunto", typeof(int));
	tptadichiarazionepermessi.defineColumn("lt", typeof(DateTime),false);
	tptadichiarazionepermessi.defineColumn("lu", typeof(string),false);
	tptadichiarazionepermessi.defineColumn("protanno", typeof(int));
	tptadichiarazionepermessi.defineColumn("protnumero", typeof(int));
	Tables.Add(tptadichiarazionepermessi);
	tptadichiarazionepermessi.defineKey("idptadichiarazionepermessi", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrycongiuntodefaultview.Columns["idregistrycongiunto"]};
	var cChild = new []{ptadichiarazionepermessi.Columns["idregistrycongiunto"]};
	Relations.Add(new DataRelation("FK_ptadichiarazionepermessi_registrycongiuntodefaultview_idregistrycongiunto",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{ptadichiarazionepermessi.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_ptadichiarazionepermessi_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{ptadichiarazionepermessi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ptadichiarazionepermessi_registryamministrativiview_idreg",cPar,cChild,false));

	#endregion

}
}
}
