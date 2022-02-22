
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
[System.Xml.Serialization.XmlRoot("dsmeta_tirocinioprogetto_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tirocinioprogetto_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniorelazione 		=> (MetaTable)Tables["tirociniorelazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioinvioazienda 		=> (MetaTable)Tables["tirocinioinvioazienda"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniodiario 		=> (MetaTable)Tables["tirociniodiario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioapprkind 		=> (MetaTable)Tables["tirocinioapprkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioappr 		=> (MetaTable)Tables["tirocinioappr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniostatodefaultview 		=> (MetaTable)Tables["tirociniostatodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoodefaultview 		=> (MetaTable)Tables["aoodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirocinioprogetto 		=> (MetaTable)Tables["tirocinioprogetto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tirocinioprogetto_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tirocinioprogetto_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tirocinioprogetto_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tirocinioprogetto_seg.xsd";

	#region create DataTables
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

	//////////////////// TIROCINIOAPPRKIND /////////////////////////////////
	var ttirocinioapprkind= new MetaTable("tirocinioapprkind");
	ttirocinioapprkind.defineColumn("active", typeof(string));
	ttirocinioapprkind.defineColumn("ct", typeof(DateTime));
	ttirocinioapprkind.defineColumn("cu", typeof(string));
	ttirocinioapprkind.defineColumn("idtirocinioapprkind", typeof(int),false);
	ttirocinioapprkind.defineColumn("lt", typeof(DateTime));
	ttirocinioapprkind.defineColumn("lu", typeof(string));
	ttirocinioapprkind.defineColumn("sortcode", typeof(int));
	ttirocinioapprkind.defineColumn("title", typeof(string));
	Tables.Add(ttirocinioapprkind);
	ttirocinioapprkind.defineKey("idtirocinioapprkind");

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
	ttirocinioappr.defineColumn("!idtirocinioapprkind_tirocinioapprkind_title", typeof(string));
	Tables.Add(ttirocinioappr);
	ttirocinioappr.defineKey("idreg_referente", "idreg_studenti", "idtirocinioappr", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	//////////////////// TIROCINIOSTATODEFAULTVIEW /////////////////////////////////
	var ttirociniostatodefaultview= new MetaTable("tirociniostatodefaultview");
	ttirociniostatodefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttirociniostatodefaultview.defineColumn("idtirociniostato", typeof(int),false);
	ttirociniostatodefaultview.defineColumn("tirociniostato_active", typeof(string));
	Tables.Add(ttirociniostatodefaultview);
	ttirociniostatodefaultview.defineKey("idtirociniostato");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("idcity", typeof(int));
	tsededefaultview.defineColumn("idnation", typeof(int));
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("idcity", typeof(int));
	tregistrydocentiview.defineColumn("idclassconsorsuale", typeof(int));
	tregistrydocentiview.defineColumn("idnation", typeof(int));
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("idreg_istituti", typeof(int));
	tregistrydocentiview.defineColumn("idregistryclass", typeof(string));
	tregistrydocentiview.defineColumn("idsasd", typeof(int));
	tregistrydocentiview.defineColumn("idstruttura", typeof(int));
	tregistrydocentiview.defineColumn("idtitle", typeof(string));
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	tregistrydocentiview.defineColumn("registry_residence", typeof(int),false);
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// AOODEFAULTVIEW /////////////////////////////////
	var taoodefaultview= new MetaTable("aoodefaultview");
	taoodefaultview.defineColumn("dropdown_title", typeof(string),false);
	taoodefaultview.defineColumn("idaoo", typeof(int),false);
	taoodefaultview.defineColumn("idsede", typeof(int));
	Tables.Add(taoodefaultview);
	taoodefaultview.defineKey("idaoo");

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
	Tables.Add(ttirocinioprogetto);
	ttirocinioprogetto.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto");

	#endregion


	#region DataRelation creation
	var cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	var cChild = new []{tirociniorelazione.Columns["idreg_referente"], tirociniorelazione.Columns["idreg_studenti"], tirociniorelazione.Columns["idtirociniocandidatura"], tirociniorelazione.Columns["idtirocinioprogetto"], tirociniorelazione.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirociniorelazione_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirocinioinvioazienda.Columns["idreg_referente"], tirocinioinvioazienda.Columns["idreg_studenti"], tirocinioinvioazienda.Columns["idtirociniocandidatura"], tirocinioinvioazienda.Columns["idtirocinioprogetto"], tirocinioinvioazienda.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioinvioazienda_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirociniodiario.Columns["idreg_referente"], tirociniodiario.Columns["idreg_studenti"], tirociniodiario.Columns["idtirociniocandidatura"], tirociniodiario.Columns["idtirocinioprogetto"], tirociniodiario.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirociniodiario_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioprogetto.Columns["idreg_referente"], tirocinioprogetto.Columns["idreg_studenti"], tirocinioprogetto.Columns["idtirociniocandidatura"], tirocinioprogetto.Columns["idtirocinioprogetto"], tirocinioprogetto.Columns["idtirocinioproposto"]};
	cChild = new []{tirocinioappr.Columns["idreg_referente"], tirocinioappr.Columns["idreg_studenti"], tirocinioappr.Columns["idtirociniocandidatura"], tirocinioappr.Columns["idtirocinioprogetto"], tirocinioappr.Columns["idtirocinioproposto"]};
	Relations.Add(new DataRelation("FK_tirocinioappr_tirocinioprogetto_idreg_referente-idreg_studenti-idtirociniocandidatura-idtirocinioprogetto-idtirocinioproposto",cPar,cChild,false));

	cPar = new []{tirocinioapprkind.Columns["idtirocinioapprkind"]};
	cChild = new []{tirocinioappr.Columns["idtirocinioapprkind"]};
	Relations.Add(new DataRelation("FK_tirocinioappr_tirocinioapprkind_idtirocinioapprkind",cPar,cChild,false));

	cPar = new []{tirociniostatodefaultview.Columns["idtirociniostato"]};
	cChild = new []{tirocinioprogetto.Columns["idtirociniostato"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_tirociniostatodefaultview_idtirociniostato",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{tirocinioprogetto.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{tirocinioprogetto.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_sededefaultview_idsede",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{tirocinioprogetto.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_registrydocentiview_idreg_docenti",cPar,cChild,false));

	cPar = new []{aoodefaultview.Columns["idaoo"]};
	cChild = new []{tirocinioprogetto.Columns["idaoo"]};
	Relations.Add(new DataRelation("FK_tirocinioprogetto_aoodefaultview_idaoo",cPar,cChild,false));

	#endregion

}
}
}
