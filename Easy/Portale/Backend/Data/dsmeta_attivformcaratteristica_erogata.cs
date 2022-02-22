
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
[System.Xml.Serialization.XmlRoot("dsmeta_attivformcaratteristica_erogata"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_attivformcaratteristica_erogata: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable orakind 		=> (MetaTable)Tables["orakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristicaora 		=> (MetaTable)Tables["attivformcaratteristicaora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppodefaultview 		=> (MetaTable)Tables["sasdgruppodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadiscdefaultview 		=> (MetaTable)Tables["ambitoareadiscdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformcaratteristica 		=> (MetaTable)Tables["attivformcaratteristica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_attivformcaratteristica_erogata(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_attivformcaratteristica_erogata (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_attivformcaratteristica_erogata";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_attivformcaratteristica_erogata.xsd";

	#region create DataTables
	//////////////////// ORAKIND /////////////////////////////////
	var torakind= new MetaTable("orakind");
	torakind.defineColumn("active", typeof(string));
	torakind.defineColumn("idorakind", typeof(int),false);
	torakind.defineColumn("title", typeof(string));
	Tables.Add(torakind);
	torakind.defineKey("idorakind");

	//////////////////// ATTIVFORMCARATTERISTICAORA /////////////////////////////////
	var tattivformcaratteristicaora= new MetaTable("attivformcaratteristicaora");
	tattivformcaratteristicaora.defineColumn("aa", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("cu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idattivformcaratteristicaora", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristicaora.defineColumn("idorakind", typeof(int));
	tattivformcaratteristicaora.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristicaora.defineColumn("lu", typeof(string),false);
	tattivformcaratteristicaora.defineColumn("ora", typeof(int));
	tattivformcaratteristicaora.defineColumn("!idorakind_orakind_title", typeof(string));
	Tables.Add(tattivformcaratteristicaora);
	tattivformcaratteristicaora.defineKey("aa", "idattivform", "idattivformcaratteristica", "idattivformcaratteristicaora", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("areadidattica_title", typeof(string));
	tsasddefaultview.defineColumn("codice", typeof(string),false);
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idareadidattica", typeof(int));
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	tsasddefaultview.defineColumn("sasd_codice_old", typeof(string));
	tsasddefaultview.defineColumn("sasd_lt", typeof(DateTime));
	tsasddefaultview.defineColumn("sasd_lu", typeof(string));
	tsasddefaultview.defineColumn("sasd_title", typeof(string),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// SASDGRUPPODEFAULTVIEW /////////////////////////////////
	var tsasdgruppodefaultview= new MetaTable("sasdgruppodefaultview");
	tsasdgruppodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasdgruppodefaultview.defineColumn("idsasdgruppo", typeof(int),false);
	tsasdgruppodefaultview.defineColumn("idtipoattform", typeof(int),false);
	Tables.Add(tsasdgruppodefaultview);
	tsasdgruppodefaultview.defineKey("idsasdgruppo");

	//////////////////// AMBITOAREADISCDEFAULTVIEW /////////////////////////////////
	var tambitoareadiscdefaultview= new MetaTable("ambitoareadiscdefaultview");
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_idtipoattform", typeof(int));
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_indicecineca", typeof(int));
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_lt", typeof(DateTime),false);
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_lu", typeof(string));
	tambitoareadiscdefaultview.defineColumn("ambitoareadisc_sortcode", typeof(int));
	tambitoareadiscdefaultview.defineColumn("classescuola_sigla", typeof(string));
	tambitoareadiscdefaultview.defineColumn("classescuola_title", typeof(string));
	tambitoareadiscdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tambitoareadiscdefaultview.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadiscdefaultview.defineColumn("idclassescuola", typeof(int));
	tambitoareadiscdefaultview.defineColumn("tipoattform_description", typeof(string));
	tambitoareadiscdefaultview.defineColumn("tipoattform_title", typeof(string));
	tambitoareadiscdefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tambitoareadiscdefaultview);
	tambitoareadiscdefaultview.defineKey("idambitoareadisc");

	//////////////////// TIPOATTFORM /////////////////////////////////
	var ttipoattform= new MetaTable("tipoattform");
	ttipoattform.defineColumn("idtipoattform", typeof(int),false);
	ttipoattform.defineColumn("title", typeof(string),false);
	Tables.Add(ttipoattform);
	ttipoattform.defineKey("idtipoattform");

	//////////////////// ATTIVFORMCARATTERISTICA /////////////////////////////////
	var tattivformcaratteristica= new MetaTable("attivformcaratteristica");
	tattivformcaratteristica.defineColumn("aa", typeof(string),false);
	tattivformcaratteristica.defineColumn("cf", typeof(decimal));
	tattivformcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("cu", typeof(string),false);
	tattivformcaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tattivformcaratteristica.defineColumn("idattivform", typeof(int),false);
	tattivformcaratteristica.defineColumn("idattivformcaratteristica", typeof(int),false);
	tattivformcaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprog", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidproganno", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogori", typeof(int),false);
	tattivformcaratteristica.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformcaratteristica.defineColumn("idsasd", typeof(int));
	tattivformcaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tattivformcaratteristica.defineColumn("idtipoattform", typeof(int));
	tattivformcaratteristica.defineColumn("json", typeof(string));
	tattivformcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tattivformcaratteristica.defineColumn("lu", typeof(string),false);
	tattivformcaratteristica.defineColumn("profess", typeof(string),false);
	tattivformcaratteristica.defineColumn("title", typeof(string));
	Tables.Add(tattivformcaratteristica);
	tattivformcaratteristica.defineKey("aa", "idattivform", "idattivformcaratteristica", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	#endregion


	#region DataRelation creation
	var cPar = new []{attivformcaratteristica.Columns["aa"], attivformcaratteristica.Columns["idattivform"], attivformcaratteristica.Columns["idattivformcaratteristica"], attivformcaratteristica.Columns["idcorsostudio"], attivformcaratteristica.Columns["iddidprog"], attivformcaratteristica.Columns["iddidproganno"], attivformcaratteristica.Columns["iddidprogcurr"], attivformcaratteristica.Columns["iddidprogori"], attivformcaratteristica.Columns["iddidprogporzanno"]};
	var cChild = new []{attivformcaratteristicaora.Columns["aa"], attivformcaratteristicaora.Columns["idattivform"], attivformcaratteristicaora.Columns["idattivformcaratteristica"], attivformcaratteristicaora.Columns["idcorsostudio"], attivformcaratteristicaora.Columns["iddidprog"], attivformcaratteristicaora.Columns["iddidproganno"], attivformcaratteristicaora.Columns["iddidprogcurr"], attivformcaratteristicaora.Columns["iddidprogori"], attivformcaratteristicaora.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristicaora_attivformcaratteristica_aa-idattivform-idattivformcaratteristica-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori-iddidprogporzanno",cPar,cChild,false));

	cPar = new []{orakind.Columns["idorakind"]};
	cChild = new []{attivformcaratteristicaora.Columns["idorakind"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristicaora_orakind_idorakind",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{attivformcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{sasdgruppodefaultview.Columns["idsasdgruppo"]};
	cChild = new []{attivformcaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_sasdgruppodefaultview_idsasdgruppo",cPar,cChild,false));

	cPar = new []{ambitoareadiscdefaultview.Columns["idambitoareadisc"]};
	cChild = new []{attivformcaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_ambitoareadiscdefaultview_idambitoareadisc",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{attivformcaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_attivformcaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	#endregion

}
}
}
