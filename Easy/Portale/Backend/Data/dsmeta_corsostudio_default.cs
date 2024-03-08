
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
[System.Xml.Serialization.XmlRoot("dsmeta_corsostudio_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_corsostudio_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura_alias1 		=> (MetaTable)Tables["struttura_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiostruttura 		=> (MetaTable)Tables["corsostudiostruttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudionorma 		=> (MetaTable)Tables["corsostudionorma"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuolakind 		=> (MetaTable)Tables["classescuolakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuolaarea 		=> (MetaTable)Tables["classescuolaarea"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classescuola 		=> (MetaTable)Tables["classescuola"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudioclassescuola 		=> (MetaTable)Tables["corsostudioclassescuola"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattform 		=> (MetaTable)Tables["tipoattform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppo 		=> (MetaTable)Tables["sasdgruppo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadisc 		=> (MetaTable)Tables["ambitoareadisc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiocaratteristica 		=> (MetaTable)Tables["corsostudiocaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable duratakinddefaultview 		=> (MetaTable)Tables["duratakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiolivellodefaultview 		=> (MetaTable)Tables["corsostudiolivellodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudionormadefaultview 		=> (MetaTable)Tables["corsostudionormadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiokinddefaultview 		=> (MetaTable)Tables["corsostudiokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudio 		=> (MetaTable)Tables["corsostudio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_corsostudio_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_corsostudio_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_corsostudio_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_corsostudio_default.xsd";

	#region create DataTables
	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA_ALIAS1 /////////////////////////////////
	var tstruttura_alias1= new MetaTable("struttura_alias1");
	tstruttura_alias1.defineColumn("codice", typeof(string));
	tstruttura_alias1.defineColumn("codiceipa", typeof(string));
	tstruttura_alias1.defineColumn("ct", typeof(DateTime),false);
	tstruttura_alias1.defineColumn("cu", typeof(string),false);
	tstruttura_alias1.defineColumn("email", typeof(string));
	tstruttura_alias1.defineColumn("fax", typeof(string));
	tstruttura_alias1.defineColumn("idaoo", typeof(int));
	tstruttura_alias1.defineColumn("idreg", typeof(int));
	tstruttura_alias1.defineColumn("idsede", typeof(int),false);
	tstruttura_alias1.defineColumn("idstruttura", typeof(int),false);
	tstruttura_alias1.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura_alias1.defineColumn("idupb", typeof(string));
	tstruttura_alias1.defineColumn("lt", typeof(DateTime),false);
	tstruttura_alias1.defineColumn("lu", typeof(string),false);
	tstruttura_alias1.defineColumn("paridstruttura", typeof(int));
	tstruttura_alias1.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura_alias1.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura_alias1.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura_alias1.defineColumn("pesoproguo", typeof(decimal));
	tstruttura_alias1.defineColumn("telefono", typeof(string));
	tstruttura_alias1.defineColumn("title", typeof(string));
	tstruttura_alias1.defineColumn("title_en", typeof(string));
	tstruttura_alias1.ExtendedProperties["TableForReading"]="struttura";
	Tables.Add(tstruttura_alias1);
	tstruttura_alias1.defineKey("idstruttura");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("codice", typeof(string));
	tstruttura.defineColumn("codiceipa", typeof(string));
	tstruttura.defineColumn("ct", typeof(DateTime),false);
	tstruttura.defineColumn("cu", typeof(string),false);
	tstruttura.defineColumn("email", typeof(string));
	tstruttura.defineColumn("fax", typeof(string));
	tstruttura.defineColumn("idaoo", typeof(int));
	tstruttura.defineColumn("idreg", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string));
	tstruttura.defineColumn("lt", typeof(DateTime),false);
	tstruttura.defineColumn("lu", typeof(string),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura.defineColumn("pesoproguo", typeof(decimal));
	tstruttura.defineColumn("telefono", typeof(string));
	tstruttura.defineColumn("title", typeof(string));
	tstruttura.defineColumn("title_en", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// CORSOSTUDIOSTRUTTURA /////////////////////////////////
	var tcorsostudiostruttura= new MetaTable("corsostudiostruttura");
	tcorsostudiostruttura.defineColumn("ct", typeof(DateTime));
	tcorsostudiostruttura.defineColumn("cu", typeof(string));
	tcorsostudiostruttura.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiostruttura.defineColumn("idstruttura", typeof(int),false);
	tcorsostudiostruttura.defineColumn("lt", typeof(DateTime));
	tcorsostudiostruttura.defineColumn("lu", typeof(string));
	tcorsostudiostruttura.defineColumn("!idstruttura_struttura_title", typeof(string));
	tcorsostudiostruttura.defineColumn("!idstruttura_strutturakind_title", typeof(string));
	tcorsostudiostruttura.defineColumn("!idstruttura_struttura_codice", typeof(string));
	tcorsostudiostruttura.defineColumn("!idstruttura_struttura_alias1_title", typeof(string));
	tcorsostudiostruttura.defineColumn("!idstruttura_struttura_alias1_strutturakind_title", typeof(string));
	Tables.Add(tcorsostudiostruttura);
	tcorsostudiostruttura.defineKey("idcorsostudio", "idstruttura");

	//////////////////// CORSOSTUDIONORMA /////////////////////////////////
	var tcorsostudionorma= new MetaTable("corsostudionorma");
	tcorsostudionorma.defineColumn("idcorsostudionorma", typeof(int),false);
	tcorsostudionorma.defineColumn("title", typeof(string),false);
	Tables.Add(tcorsostudionorma);
	tcorsostudionorma.defineKey("idcorsostudionorma");

	//////////////////// CLASSESCUOLAKIND /////////////////////////////////
	var tclassescuolakind= new MetaTable("classescuolakind");
	tclassescuolakind.defineColumn("idclassescuolakind", typeof(string),false);
	tclassescuolakind.defineColumn("title", typeof(string),false);
	Tables.Add(tclassescuolakind);
	tclassescuolakind.defineKey("idclassescuolakind");

	//////////////////// CLASSESCUOLAAREA /////////////////////////////////
	var tclassescuolaarea= new MetaTable("classescuolaarea");
	tclassescuolaarea.defineColumn("idclassescuolaarea", typeof(int),false);
	tclassescuolaarea.defineColumn("title", typeof(string));
	Tables.Add(tclassescuolaarea);
	tclassescuolaarea.defineKey("idclassescuolaarea");

	//////////////////// CLASSESCUOLA /////////////////////////////////
	var tclassescuola= new MetaTable("classescuola");
	tclassescuola.defineColumn("idclassescuola", typeof(int),false);
	tclassescuola.defineColumn("idclassescuolaarea", typeof(int));
	tclassescuola.defineColumn("idclassescuolakind", typeof(string));
	tclassescuola.defineColumn("idcorsostudionorma", typeof(int));
	tclassescuola.defineColumn("indicecineca", typeof(int));
	tclassescuola.defineColumn("lt", typeof(DateTime),false);
	tclassescuola.defineColumn("lu", typeof(string),false);
	tclassescuola.defineColumn("obbform", typeof(string));
	tclassescuola.defineColumn("prospocc", typeof(string));
	tclassescuola.defineColumn("sigla", typeof(string));
	tclassescuola.defineColumn("title", typeof(string),false);
	Tables.Add(tclassescuola);
	tclassescuola.defineKey("idclassescuola");

	//////////////////// CORSOSTUDIOCLASSESCUOLA /////////////////////////////////
	var tcorsostudioclassescuola= new MetaTable("corsostudioclassescuola");
	tcorsostudioclassescuola.defineColumn("ct", typeof(DateTime),false);
	tcorsostudioclassescuola.defineColumn("cu", typeof(string),false);
	tcorsostudioclassescuola.defineColumn("idclassescuola", typeof(int),false);
	tcorsostudioclassescuola.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudioclassescuola.defineColumn("lt", typeof(DateTime),false);
	tcorsostudioclassescuola.defineColumn("lu", typeof(string),false);
	tcorsostudioclassescuola.defineColumn("!idclassescuola_classescuola_sigla", typeof(string));
	tcorsostudioclassescuola.defineColumn("!idclassescuola_classescuola_title", typeof(string));
	tcorsostudioclassescuola.defineColumn("!idclassescuola_corsostudionorma_title", typeof(string));
	tcorsostudioclassescuola.defineColumn("!idclassescuola_classescuola_indicecineca", typeof(int));
	tcorsostudioclassescuola.defineColumn("!idclassescuola_classescuolakind_title", typeof(string));
	tcorsostudioclassescuola.defineColumn("!idclassescuola_classescuolaarea_title", typeof(string));
	Tables.Add(tcorsostudioclassescuola);
	tcorsostudioclassescuola.defineKey("idclassescuola", "idcorsostudio");

	//////////////////// TIPOATTFORM /////////////////////////////////
	var ttipoattform= new MetaTable("tipoattform");
	ttipoattform.defineColumn("description", typeof(string));
	ttipoattform.defineColumn("idtipoattform", typeof(int),false);
	ttipoattform.defineColumn("title", typeof(string),false);
	Tables.Add(ttipoattform);
	ttipoattform.defineKey("idtipoattform");

	//////////////////// SASDGRUPPO /////////////////////////////////
	var tsasdgruppo= new MetaTable("sasdgruppo");
	tsasdgruppo.defineColumn("idsasdgruppo", typeof(int),false);
	tsasdgruppo.defineColumn("idtipoattform", typeof(int),false);
	tsasdgruppo.defineColumn("title", typeof(string));
	Tables.Add(tsasdgruppo);
	tsasdgruppo.defineKey("idsasdgruppo", "idtipoattform");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// AMBITOAREADISC /////////////////////////////////
	var tambitoareadisc= new MetaTable("ambitoareadisc");
	tambitoareadisc.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadisc.defineColumn("title", typeof(string),false);
	Tables.Add(tambitoareadisc);
	tambitoareadisc.defineKey("idambitoareadisc");

	//////////////////// CORSOSTUDIOCARATTERISTICA /////////////////////////////////
	var tcorsostudiocaratteristica= new MetaTable("corsostudiocaratteristica");
	tcorsostudiocaratteristica.defineColumn("cf", typeof(decimal));
	tcorsostudiocaratteristica.defineColumn("cfmax", typeof(decimal));
	tcorsostudiocaratteristica.defineColumn("cfmin", typeof(decimal));
	tcorsostudiocaratteristica.defineColumn("ct", typeof(DateTime),false);
	tcorsostudiocaratteristica.defineColumn("cu", typeof(string),false);
	tcorsostudiocaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tcorsostudiocaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiocaratteristica.defineColumn("idcorsostudiocaratteristica", typeof(int),false);
	tcorsostudiocaratteristica.defineColumn("idsasd", typeof(int));
	tcorsostudiocaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tcorsostudiocaratteristica.defineColumn("idtipoattform", typeof(int));
	tcorsostudiocaratteristica.defineColumn("lt", typeof(DateTime),false);
	tcorsostudiocaratteristica.defineColumn("lu", typeof(string),false);
	tcorsostudiocaratteristica.defineColumn("obblig", typeof(string),false);
	tcorsostudiocaratteristica.defineColumn("profess", typeof(string),false);
	tcorsostudiocaratteristica.defineColumn("!idambitoareadisc_ambitoareadisc_title", typeof(string));
	tcorsostudiocaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tcorsostudiocaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	tcorsostudiocaratteristica.defineColumn("!idsasdgruppo_sasdgruppo_title", typeof(string));
	tcorsostudiocaratteristica.defineColumn("!idtipoattform_tipoattform_title", typeof(string));
	tcorsostudiocaratteristica.defineColumn("!idtipoattform_tipoattform_description", typeof(string));
	tcorsostudiocaratteristica.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcorsostudiocaratteristica);
	tcorsostudiocaratteristica.defineKey("idcorsostudiocaratteristica");

	//////////////////// DURATAKINDDEFAULTVIEW /////////////////////////////////
	var tduratakinddefaultview= new MetaTable("duratakinddefaultview");
	tduratakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tduratakinddefaultview.defineColumn("duratakind_active", typeof(string));
	tduratakinddefaultview.defineColumn("idduratakind", typeof(int),false);
	Tables.Add(tduratakinddefaultview);
	tduratakinddefaultview.defineKey("idduratakind");

	//////////////////// CORSOSTUDIOLIVELLODEFAULTVIEW /////////////////////////////////
	var tcorsostudiolivellodefaultview= new MetaTable("corsostudiolivellodefaultview");
	tcorsostudiolivellodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiolivellodefaultview.defineColumn("idcorsostudiolivello", typeof(int),false);
	Tables.Add(tcorsostudiolivellodefaultview);
	tcorsostudiolivellodefaultview.defineKey("idcorsostudiolivello");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// CORSOSTUDIONORMADEFAULTVIEW /////////////////////////////////
	var tcorsostudionormadefaultview= new MetaTable("corsostudionormadefaultview");
	tcorsostudionormadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudionormadefaultview.defineColumn("idcorsostudionorma", typeof(int),false);
	Tables.Add(tcorsostudionormadefaultview);
	tcorsostudionormadefaultview.defineKey("idcorsostudionorma");

	//////////////////// CORSOSTUDIOKINDDEFAULTVIEW /////////////////////////////////
	var tcorsostudiokinddefaultview= new MetaTable("corsostudiokinddefaultview");
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_active", typeof(string));
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_ct", typeof(DateTime),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_cu", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_description", typeof(string));
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_lt", typeof(DateTime),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_lu", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_sortcode", typeof(int),false);
	tcorsostudiokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("idcorsostudiokind", typeof(int),false);
	tcorsostudiokinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tcorsostudiokinddefaultview);
	tcorsostudiokinddefaultview.defineKey("idcorsostudiokind");

	//////////////////// CORSOSTUDIO /////////////////////////////////
	var tcorsostudio= new MetaTable("corsostudio");
	tcorsostudio.defineColumn("almalaureasurvey", typeof(string));
	tcorsostudio.defineColumn("annoistituz", typeof(int));
	tcorsostudio.defineColumn("basevoto", typeof(int));
	tcorsostudio.defineColumn("codice", typeof(string));
	tcorsostudio.defineColumn("codicemiur", typeof(string));
	tcorsostudio.defineColumn("codicemiurlungo", typeof(string));
	tcorsostudio.defineColumn("crediti", typeof(int));
	tcorsostudio.defineColumn("ct", typeof(DateTime),false);
	tcorsostudio.defineColumn("cu", typeof(string),false);
	tcorsostudio.defineColumn("durata", typeof(int));
	tcorsostudio.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudio.defineColumn("idcorsostudiokind", typeof(int),false);
	tcorsostudio.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudio.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudio.defineColumn("idduratakind", typeof(int));
	tcorsostudio.defineColumn("idstruttura", typeof(int));
	tcorsostudio.defineColumn("lt", typeof(DateTime),false);
	tcorsostudio.defineColumn("lu", typeof(string),false);
	tcorsostudio.defineColumn("obbform", typeof(string));
	tcorsostudio.defineColumn("sboccocc", typeof(string));
	tcorsostudio.defineColumn("title", typeof(string));
	tcorsostudio.defineColumn("title_en", typeof(string));
	Tables.Add(tcorsostudio);
	tcorsostudio.defineKey("idcorsostudio");

	#endregion


	#region DataRelation creation
	var cPar = new []{corsostudio.Columns["idcorsostudio"]};
	var cChild = new []{corsostudiostruttura.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_corsostudiostruttura_corsostudio_idcorsostudio",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{corsostudiostruttura.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_corsostudiostruttura_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{struttura_alias1.Columns["idstruttura"]};
	cChild = new []{struttura.Columns["paridstruttura"]};
	Relations.Add(new DataRelation("FK_struttura_struttura_alias1_paridstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura_alias1.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_alias1_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{corsostudio.Columns["idcorsostudio"]};
	cChild = new []{corsostudioclassescuola.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_corsostudioclassescuola_corsostudio_idcorsostudio",cPar,cChild,false));

	cPar = new []{classescuola.Columns["idclassescuola"]};
	cChild = new []{corsostudioclassescuola.Columns["idclassescuola"]};
	Relations.Add(new DataRelation("FK_corsostudioclassescuola_classescuola_idclassescuola",cPar,cChild,false));

	cPar = new []{corsostudionorma.Columns["idcorsostudionorma"]};
	cChild = new []{classescuola.Columns["idcorsostudionorma"]};
	Relations.Add(new DataRelation("FK_classescuola_corsostudionorma_idcorsostudionorma",cPar,cChild,false));

	cPar = new []{classescuolakind.Columns["idclassescuolakind"]};
	cChild = new []{classescuola.Columns["idclassescuolakind"]};
	Relations.Add(new DataRelation("FK_classescuola_classescuolakind_idclassescuolakind",cPar,cChild,false));

	cPar = new []{classescuolaarea.Columns["idclassescuolaarea"]};
	cChild = new []{classescuola.Columns["idclassescuolaarea"]};
	Relations.Add(new DataRelation("FK_classescuola_classescuolaarea_idclassescuolaarea",cPar,cChild,false));

	cPar = new []{corsostudio.Columns["idcorsostudio"]};
	cChild = new []{corsostudiocaratteristica.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_corsostudio_idcorsostudio",cPar,cChild,false));

	cPar = new []{tipoattform.Columns["idtipoattform"]};
	cChild = new []{corsostudiocaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_tipoattform_idtipoattform",cPar,cChild,false));

	cPar = new []{sasdgruppo.Columns["idsasdgruppo"]};
	cChild = new []{corsostudiocaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_sasdgruppo_idsasdgruppo",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{corsostudiocaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{ambitoareadisc.Columns["idambitoareadisc"]};
	cChild = new []{corsostudiocaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_ambitoareadisc_idambitoareadisc",cPar,cChild,false));

	cPar = new []{duratakinddefaultview.Columns["idduratakind"]};
	cChild = new []{corsostudio.Columns["idduratakind"]};
	Relations.Add(new DataRelation("FK_corsostudio_duratakinddefaultview_idduratakind",cPar,cChild,false));

	cPar = new []{corsostudiolivellodefaultview.Columns["idcorsostudiolivello"]};
	cChild = new []{corsostudio.Columns["idcorsostudiolivello"]};
	Relations.Add(new DataRelation("FK_corsostudio_corsostudiolivellodefaultview_idcorsostudiolivello",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{corsostudio.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_corsostudio_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{corsostudionormadefaultview.Columns["idcorsostudionorma"]};
	cChild = new []{corsostudio.Columns["idcorsostudionorma"]};
	Relations.Add(new DataRelation("FK_corsostudio_corsostudionormadefaultview_idcorsostudionorma",cPar,cChild,false));

	cPar = new []{corsostudiokinddefaultview.Columns["idcorsostudiokind"]};
	cChild = new []{corsostudio.Columns["idcorsostudiokind"]};
	Relations.Add(new DataRelation("FK_corsostudio_corsostudiokinddefaultview_idcorsostudiokind",cPar,cChild,false));

	#endregion

}
}
}
