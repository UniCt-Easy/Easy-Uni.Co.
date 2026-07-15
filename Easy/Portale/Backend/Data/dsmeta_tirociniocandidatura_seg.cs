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
[System.Xml.Serialization.XmlRoot("dsmeta_tirociniocandidatura_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_tirociniocandidatura_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioappr 		=> (MetaTable)Tables["tirocinioappr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioinvioazienda 		=> (MetaTable)Tables["tirocinioinvioazienda"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniorelazione 		=> (MetaTable)Tables["tirociniorelazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniodiario 		=> (MetaTable)Tables["tirociniodiario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniostato 		=> (MetaTable)Tables["tirociniostato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoo 		=> (MetaTable)Tables["aoo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioprogetto 		=> (MetaTable)Tables["tirocinioprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniocandidaturakinddefaultview 		=> (MetaTable)Tables["tirociniocandidaturakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniocandidatura 		=> (MetaTable)Tables["tirociniocandidatura"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tirociniocandidatura_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tirociniocandidatura_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tirociniocandidatura_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tirociniocandidatura_seg.xsd";

	#region create DataTables
	//////////////////// TIROCINIOAPPR /////////////////////////////////
	var ttirocinioappr= new MetaTable("tirocinioappr");
	ttirocinioappr.defineColumn("approvazione", typeof(string));
	ttirocinioappr.defineColumn("ct", typeof(DateTime),false);
	ttirocinioappr.defineColumn("cu", typeof(string),false);
	ttirocinioappr.defineColumn("dataora", typeof(DateTime));
	ttirocinioappr.defineColumn("idreg_docenti", typeof(int));
	ttirocinioappr.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioappr.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioappr", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioapprkind", typeof(int));
	ttirocinioappr.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioappr.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioappr.defineColumn("lt", typeof(DateTime),false);
	ttirocinioappr.defineColumn("lu", typeof(string),false);
	Tables.Add(ttirocinioappr);
	ttirocinioappr.defineKey("idreg_referente", "idreg_studenti", "idtirocinioappr", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// TIROCINIOINVIOAZIENDA /////////////////////////////////
	var ttirocinioinvioazienda= new MetaTable("tirocinioinvioazienda");
	ttirocinioinvioazienda.defineColumn("ct", typeof(DateTime),false);
	ttirocinioinvioazienda.defineColumn("cu", typeof(string),false);
	ttirocinioinvioazienda.defineColumn("dataora", typeof(DateTime));
	ttirocinioinvioazienda.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioinvioazienda", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioinvioazienda.defineColumn("lt", typeof(DateTime),false);
	ttirocinioinvioazienda.defineColumn("lu", typeof(string),false);
	Tables.Add(ttirocinioinvioazienda);
	ttirocinioinvioazienda.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioinvioazienda", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// TIROCINIORELAZIONE /////////////////////////////////
	var ttirociniorelazione= new MetaTable("tirociniorelazione");
	ttirociniorelazione.defineColumn("attivitasvolta", typeof(string));
	ttirociniorelazione.defineColumn("autovalutazione", typeof(string));
	ttirociniorelazione.defineColumn("competenze", typeof(string));
	ttirociniorelazione.defineColumn("conclusioni", typeof(string));
	ttirociniorelazione.defineColumn("considerazioni", typeof(string));
	ttirociniorelazione.defineColumn("ct", typeof(DateTime));
	ttirociniorelazione.defineColumn("cu", typeof(string));
	ttirociniorelazione.defineColumn("descrazienda", typeof(string));
	ttirociniorelazione.defineColumn("idreg_referente", typeof(int),false);
	ttirociniorelazione.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirociniorelazione", typeof(int),false);
	ttirociniorelazione.defineColumn("introduzione", typeof(string));
	ttirociniorelazione.defineColumn("lt", typeof(DateTime));
	ttirociniorelazione.defineColumn("lu", typeof(string));
	Tables.Add(ttirociniorelazione);
	ttirociniorelazione.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto", "idtirociniorelazione");

	//////////////////// TIROCINIODIARIO /////////////////////////////////
	var ttirociniodiario= new MetaTable("tirociniodiario");
	ttirociniodiario.defineColumn("ct", typeof(DateTime),false);
	ttirociniodiario.defineColumn("cu", typeof(string),false);
	ttirociniodiario.defineColumn("data", typeof(DateTime));
	ttirociniodiario.defineColumn("description", typeof(string));
	ttirociniodiario.defineColumn("idreg_referente", typeof(int),false);
	ttirociniodiario.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniodiario.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniodiario.defineColumn("idtirociniodiario", typeof(int),false);
	ttirociniodiario.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirociniodiario.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniodiario.defineColumn("lt", typeof(DateTime),false);
	ttirociniodiario.defineColumn("lu", typeof(string),false);
	ttirociniodiario.defineColumn("ore", typeof(int));
	Tables.Add(ttirociniodiario);
	ttirociniodiario.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirociniodiario", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// TIROCINIOSTATO /////////////////////////////////
	var ttirociniostato= new MetaTable("tirociniostato");
	ttirociniostato.defineColumn("active", typeof(string),false);
	ttirociniostato.defineColumn("idtirociniostato", typeof(int),false);
	ttirociniostato.defineColumn("title", typeof(string),false);
	Tables.Add(ttirociniostato);
	ttirociniostato.defineKey("idtirociniostato");

	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idreg", typeof(int),false);
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idreg", "idsede");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// AOO /////////////////////////////////
	var taoo= new MetaTable("aoo");
	taoo.defineColumn("idaoo", typeof(int),false);
	taoo.defineColumn("title", typeof(string),false);
	Tables.Add(taoo);
	taoo.defineKey("idaoo");

	//////////////////// TIROCINIOPROGETTO /////////////////////////////////
	var ttirocinioprogetto= new MetaTable("tirocinioprogetto");
	ttirocinioprogetto.defineColumn("competenze", typeof(string));
	ttirocinioprogetto.defineColumn("ct", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("cu", typeof(string),false);
	ttirocinioprogetto.defineColumn("datafineeffettiva", typeof(DateTime));
	ttirocinioprogetto.defineColumn("datafineprevista", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("datainizioeffettiva", typeof(DateTime));
	ttirocinioprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("dataverbale", typeof(DateTime));
	ttirocinioprogetto.defineColumn("description", typeof(string),false);
	ttirocinioprogetto.defineColumn("description_en", typeof(string));
	ttirocinioprogetto.defineColumn("idaoo", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_docenti", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_referente", typeof(int),false);
	ttirocinioprogetto.defineColumn("idreg_studenti", typeof(int),false);
	ttirocinioprogetto.defineColumn("idsede", typeof(int));
	ttirocinioprogetto.defineColumn("idstruttura", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirocinioprogetto.defineColumn("idtirociniostato", typeof(int),false);
	ttirocinioprogetto.defineColumn("lt", typeof(DateTime),false);
	ttirocinioprogetto.defineColumn("lu", typeof(string),false);
	ttirocinioprogetto.defineColumn("ore", typeof(int),false);
	ttirocinioprogetto.defineColumn("protanno", typeof(int));
	ttirocinioprogetto.defineColumn("protnumero", typeof(int));
	ttirocinioprogetto.defineColumn("tempiaccesso", typeof(string));
	ttirocinioprogetto.defineColumn("title", typeof(string),false);
	ttirocinioprogetto.defineColumn("title_en", typeof(string));
	ttirocinioprogetto.defineColumn("!idaoo_aoo_title", typeof(string));
	ttirocinioprogetto.defineColumn("!idreg_docenti_registry_title", typeof(string));
	ttirocinioprogetto.defineColumn("!idsede_sede_title", typeof(string));
	ttirocinioprogetto.defineColumn("!idstruttura_struttura_title", typeof(string));
	ttirocinioprogetto.defineColumn("!idstruttura_struttura_idstrutturakind_title", typeof(string));
	ttirocinioprogetto.defineColumn("!idtirociniostato_tirociniostato_title", typeof(string));
	Tables.Add(ttirocinioprogetto);
	ttirocinioprogetto.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// TIROCINIOCANDIDATURAKINDDEFAULTVIEW /////////////////////////////////
	var ttirociniocandidaturakinddefaultview= new MetaTable("tirociniocandidaturakinddefaultview");
	ttirociniocandidaturakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttirociniocandidaturakinddefaultview.defineColumn("idtirociniocandidaturakind", typeof(int),false);
	ttirociniocandidaturakinddefaultview.defineColumn("tirociniocandidaturakind_active", typeof(string));
	ttirociniocandidaturakinddefaultview.defineColumn("tirociniocandidaturakind_ct", typeof(DateTime),false);
	ttirociniocandidaturakinddefaultview.defineColumn("tirociniocandidaturakind_cu", typeof(string),false);
	ttirociniocandidaturakinddefaultview.defineColumn("tirociniocandidaturakind_lt", typeof(DateTime),false);
	ttirociniocandidaturakinddefaultview.defineColumn("tirociniocandidaturakind_lu", typeof(string),false);
	ttirociniocandidaturakinddefaultview.defineColumn("tirociniocandidaturakind_sortcode", typeof(int),false);
	ttirociniocandidaturakinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(ttirociniocandidaturakinddefaultview);
	ttirociniocandidaturakinddefaultview.defineKey("idtirociniocandidaturakind");

	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// TIROCINIOCANDIDATURA /////////////////////////////////
	var ttirociniocandidatura= new MetaTable("tirociniocandidatura");
	ttirociniocandidatura.defineColumn("ct", typeof(DateTime),false);
	ttirociniocandidatura.defineColumn("cu", typeof(string),false);
	ttirociniocandidatura.defineColumn("data", typeof(DateTime));
	ttirociniocandidatura.defineColumn("idreg_docenti", typeof(int));
	ttirociniocandidatura.defineColumn("idreg_referente", typeof(int),false);
	ttirociniocandidatura.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniocandidatura.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniocandidatura.defineColumn("idtirociniocandidaturakind", typeof(int),false);
	ttirociniocandidatura.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniocandidatura.defineColumn("lt", typeof(DateTime),false);
	ttirociniocandidatura.defineColumn("lu", typeof(string),false);
	Tables.Add(ttirociniocandidatura);
	ttirociniocandidatura.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioproposto");

	#endregion


	#region DataRelation creation
	var cPar = new []{tirociniocandidatura.Columns["idreg_referente"], tirociniocandidatura.Columns["idreg_studenti"], tirociniocandidatura.Columns["idtirociniocandidatura"], tirociniocandidatura.Columns["idtirocinioproposto"]};
	var cChild = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_tirociniocandidatura_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirocinioappr.Columns["idreg_referente"], tirocinioappr.Columns["idreg_studenti"], tirocinioappr.Columns["idtirociniocandidatura"], tirocinioappr.Columns["idtirocinioprogetto"], tirocinioappr.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioappr_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirocinioinvioazienda.Columns["idreg_referente"], tirocinioinvioazienda.Columns["idreg_studenti"], tirocinioinvioazienda.Columns["idtirociniocandidatura"], tirocinioinvioazienda.Columns["idtirocinioprogetto"], tirocinioinvioazienda.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioinvioazienda_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirociniorelazione.Columns["idreg_referente"], tirociniorelazione.Columns["idreg_studenti"], tirociniorelazione.Columns["idtirociniocandidatura"], tirociniorelazione.Columns["idtirocinioprogetto"], tirociniorelazione.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirociniorelazione_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirociniodiario.Columns["idreg_referente"], tirociniodiario.Columns["idreg_studenti"], tirociniodiario.Columns["idtirociniocandidatura"], tirociniodiario.Columns["idtirocinioprogetto"], tirociniodiario.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirociniodiario_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirociniostato.Columns["idtirociniostato"]};
	cChild = new []{tirocinioprogetto.Columns["idtirociniostato"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_tirociniostato_idtirociniostato",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{tirocinioprogetto.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{tirocinioprogetto.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_sede_idsede",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{tirocinioprogetto.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_registry_idreg_docenti",cPar,cChild,false));

	cPar = new []{aoo.Columns["idaoo"]};
	cChild = new []{tirocinioprogetto.Columns["idaoo"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_aoo_idaoo",cPar,cChild,false));

	cPar = new []{tirociniocandidaturakinddefaultview.Columns["idtirociniocandidaturakind"]};
	cChild = new []{tirociniocandidatura.Columns["idtirociniocandidaturakind"]};
	Relations.Add(new DataRelation("FK_tirociniocandidatura_tirociniocandidaturakinddefaultview_idtirociniocandidaturakind",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{tirociniocandidatura.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_tirociniocandidatura_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{tirociniocandidatura.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_tirociniocandidatura_registrystudentiview_idreg_studenti",cPar,cChild,false));

	#endregion

}
}
}
