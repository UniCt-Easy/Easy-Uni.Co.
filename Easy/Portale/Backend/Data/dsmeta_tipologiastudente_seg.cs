
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
[System.Xml.Serialization.XmlRoot("dsmeta_tipologiastudente_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tipologiastudente_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakind 		=> (MetaTable)Tables["strutturakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipologiastudentestruttura 		=> (MetaTable)Tables["tipologiastudentestruttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsserviziorequisito 		=> (MetaTable)Tables["bandodsserviziorequisito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsserviziodatepres 		=> (MetaTable)Tables["bandodsserviziodatepres"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsservizioattach 		=> (MetaTable)Tables["bandodsservizioattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_studenti 		=> (MetaTable)Tables["registry_studenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriaesitipos 		=> (MetaTable)Tables["graduatoriaesitipos"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriaesiti 		=> (MetaTable)Tables["graduatoriaesiti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiokinddefaultview 		=> (MetaTable)Tables["corsostudiokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipologiastudente 		=> (MetaTable)Tables["tipologiastudente"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tipologiastudente_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tipologiastudente_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tipologiastudente_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tipologiastudente_seg.xsd";

	#region create DataTables
	//////////////////// STRUTTURAKIND /////////////////////////////////
	var tstrutturakind= new MetaTable("strutturakind");
	tstrutturakind.defineColumn("active", typeof(string),false);
	tstrutturakind.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakind.defineColumn("title", typeof(string),false);
	Tables.Add(tstrutturakind);
	tstrutturakind.defineKey("idstrutturakind");

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
	tstruttura.defineColumn("!idstrutturakind_strutturakind_title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// TIPOLOGIASTUDENTESTRUTTURA /////////////////////////////////
	var ttipologiastudentestruttura= new MetaTable("tipologiastudentestruttura");
	ttipologiastudentestruttura.defineColumn("ct", typeof(DateTime),false);
	ttipologiastudentestruttura.defineColumn("cu", typeof(string),false);
	ttipologiastudentestruttura.defineColumn("idbandods", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("idbandodsservizio", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("idstruttura", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("idtipologiastudente", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("lt", typeof(DateTime),false);
	ttipologiastudentestruttura.defineColumn("lu", typeof(string),false);
	Tables.Add(ttipologiastudentestruttura);
	ttipologiastudentestruttura.defineKey("idbandods", "idbandodsservizio", "idstruttura", "idtipologiastudente");

	//////////////////// BANDODSSERVIZIOREQUISITO /////////////////////////////////
	var tbandodsserviziorequisito= new MetaTable("bandodsserviziorequisito");
	tbandodsserviziorequisito.defineColumn("cfbonus", typeof(decimal));
	tbandodsserviziorequisito.defineColumn("cfbonushp", typeof(decimal));
	tbandodsserviziorequisito.defineColumn("cfconseguiti", typeof(decimal));
	tbandodsserviziorequisito.defineColumn("cfconseguitihp", typeof(decimal));
	tbandodsserviziorequisito.defineColumn("ct", typeof(DateTime),false);
	tbandodsserviziorequisito.defineColumn("cu", typeof(string),false);
	tbandodsserviziorequisito.defineColumn("idbandods", typeof(int),false);
	tbandodsserviziorequisito.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsserviziorequisito.defineColumn("idbandodsserviziorequisito", typeof(int),false);
	tbandodsserviziorequisito.defineColumn("idtipologiastudente", typeof(int),false);
	tbandodsserviziorequisito.defineColumn("lt", typeof(DateTime),false);
	tbandodsserviziorequisito.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandodsserviziorequisito);
	tbandodsserviziorequisito.defineKey("idbandods", "idbandodsservizio", "idbandodsserviziorequisito", "idtipologiastudente");

	//////////////////// BANDODSSERVIZIODATEPRES /////////////////////////////////
	var tbandodsserviziodatepres= new MetaTable("bandodsserviziodatepres");
	tbandodsserviziodatepres.defineColumn("ct", typeof(DateTime));
	tbandodsserviziodatepres.defineColumn("cu", typeof(string));
	tbandodsserviziodatepres.defineColumn("data", typeof(DateTime));
	tbandodsserviziodatepres.defineColumn("idbandods", typeof(int),false);
	tbandodsserviziodatepres.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsserviziodatepres.defineColumn("idbandodsserviziodatepres", typeof(int),false);
	tbandodsserviziodatepres.defineColumn("idtipologiastudente", typeof(int),false);
	tbandodsserviziodatepres.defineColumn("lt", typeof(DateTime));
	tbandodsserviziodatepres.defineColumn("lu", typeof(string));
	Tables.Add(tbandodsserviziodatepres);
	tbandodsserviziodatepres.defineKey("idbandods", "idbandodsservizio", "idbandodsserviziodatepres", "idtipologiastudente");

	//////////////////// BANDODSSERVIZIOATTACH /////////////////////////////////
	var tbandodsservizioattach= new MetaTable("bandodsservizioattach");
	tbandodsservizioattach.defineColumn("ct", typeof(DateTime),false);
	tbandodsservizioattach.defineColumn("cu", typeof(string),false);
	tbandodsservizioattach.defineColumn("idbandods", typeof(int),false);
	tbandodsservizioattach.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsservizioattach.defineColumn("idbandodsservizioattach", typeof(int),false);
	tbandodsservizioattach.defineColumn("idtipologiastudente", typeof(int),false);
	tbandodsservizioattach.defineColumn("lt", typeof(DateTime),false);
	tbandodsservizioattach.defineColumn("lu", typeof(string),false);
	tbandodsservizioattach.defineColumn("title", typeof(string));
	Tables.Add(tbandodsservizioattach);
	tbandodsservizioattach.defineKey("idbandods", "idbandodsservizio", "idbandodsservizioattach", "idtipologiastudente");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("gender", typeof(string));
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("surname", typeof(string));
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRY_STUDENTI /////////////////////////////////
	var tregistry_studenti= new MetaTable("registry_studenti");
	tregistry_studenti.defineColumn("authinps", typeof(string),false);
	tregistry_studenti.defineColumn("ct", typeof(DateTime),false);
	tregistry_studenti.defineColumn("cu", typeof(string),false);
	tregistry_studenti.defineColumn("idreg", typeof(int),false);
	tregistry_studenti.defineColumn("idstuddirittokind", typeof(int));
	tregistry_studenti.defineColumn("idstudprenotkind", typeof(int),false);
	tregistry_studenti.defineColumn("lt", typeof(DateTime),false);
	tregistry_studenti.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistry_studenti);
	tregistry_studenti.defineKey("idreg");

	//////////////////// GRADUATORIAESITIPOS /////////////////////////////////
	var tgraduatoriaesitipos= new MetaTable("graduatoriaesitipos");
	tgraduatoriaesitipos.defineColumn("ct", typeof(DateTime),false);
	tgraduatoriaesitipos.defineColumn("cu", typeof(string),false);
	tgraduatoriaesitipos.defineColumn("idcorsostudio", typeof(int));
	tgraduatoriaesitipos.defineColumn("idgraduatoriaesiti", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idgraduatoriaesitipos", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idreg_studenti", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idtipologiastudente", typeof(int));
	tgraduatoriaesitipos.defineColumn("lt", typeof(DateTime),false);
	tgraduatoriaesitipos.defineColumn("lu", typeof(string),false);
	tgraduatoriaesitipos.defineColumn("pos", typeof(int));
	tgraduatoriaesitipos.defineColumn("punteggio", typeof(decimal));
	tgraduatoriaesitipos.defineColumn("!idreg_studenti_registry_studenti_title", typeof(string));
	tgraduatoriaesitipos.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tgraduatoriaesitipos);
	tgraduatoriaesitipos.defineKey("idgraduatoriaesiti", "idgraduatoriaesitipos");

	//////////////////// GRADUATORIAESITI /////////////////////////////////
	var tgraduatoriaesiti= new MetaTable("graduatoriaesiti");
	tgraduatoriaesiti.defineColumn("ct", typeof(DateTime),false);
	tgraduatoriaesiti.defineColumn("cu", typeof(string),false);
	tgraduatoriaesiti.defineColumn("datachiusura", typeof(DateTime));
	tgraduatoriaesiti.defineColumn("idcorsostudio", typeof(int));
	tgraduatoriaesiti.defineColumn("idgraduatoria", typeof(int));
	tgraduatoriaesiti.defineColumn("idgraduatoriaesiti", typeof(int),false);
	tgraduatoriaesiti.defineColumn("idtipologiastudente", typeof(int),false);
	tgraduatoriaesiti.defineColumn("lt", typeof(DateTime),false);
	tgraduatoriaesiti.defineColumn("lu", typeof(string),false);
	tgraduatoriaesiti.defineColumn("provvisoria", typeof(string),false);
	tgraduatoriaesiti.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tgraduatoriaesiti);
	tgraduatoriaesiti.defineKey("idgraduatoriaesiti", "idtipologiastudente");

	//////////////////// CORSOSTUDIOKINDDEFAULTVIEW /////////////////////////////////
	var tcorsostudiokinddefaultview= new MetaTable("corsostudiokinddefaultview");
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_active", typeof(string));
	tcorsostudiokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("idcorsostudiokind", typeof(int),false);
	Tables.Add(tcorsostudiokinddefaultview);
	tcorsostudiokinddefaultview.defineKey("idcorsostudiokind");

	//////////////////// TIPOLOGIASTUDENTE /////////////////////////////////
	var ttipologiastudente= new MetaTable("tipologiastudente");
	ttipologiastudente.defineColumn("abbreviazione", typeof(string));
	ttipologiastudente.defineColumn("annoiscr", typeof(int));
	ttipologiastudente.defineColumn("ct", typeof(DateTime),false);
	ttipologiastudente.defineColumn("cu", typeof(string),false);
	ttipologiastudente.defineColumn("idbandods", typeof(int),false);
	ttipologiastudente.defineColumn("idbandodsservizio", typeof(int),false);
	ttipologiastudente.defineColumn("idcorsostudiokind", typeof(int));
	ttipologiastudente.defineColumn("idtipologiastudente", typeof(int),false);
	ttipologiastudente.defineColumn("immatricolato", typeof(string));
	ttipologiastudente.defineColumn("iscrittobmi", typeof(string));
	ttipologiastudente.defineColumn("lt", typeof(DateTime),false);
	ttipologiastudente.defineColumn("lu", typeof(string),false);
	ttipologiastudente.defineColumn("passaggio", typeof(string));
	ttipologiastudente.defineColumn("tri", typeof(string));
	Tables.Add(ttipologiastudente);
	ttipologiastudente.defineKey("idbandods", "idbandodsservizio", "idtipologiastudente");

	#endregion


	#region DataRelation creation
	var cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	var cChild = new []{tipologiastudentestruttura.Columns["idbandods"], tipologiastudentestruttura.Columns["idbandodsservizio"], tipologiastudentestruttura.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_tipologiastudentestruttura_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{tipologiastudentestruttura.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_tipologiastudentestruttura_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{strutturakind.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakind_idstrutturakind",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{bandodsserviziorequisito.Columns["idbandods"], bandodsserviziorequisito.Columns["idbandodsservizio"], bandodsserviziorequisito.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_bandodsserviziorequisito_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{bandodsserviziodatepres.Columns["idbandods"], bandodsserviziodatepres.Columns["idbandodsservizio"], bandodsserviziodatepres.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_bandodsserviziodatepres_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{bandodsservizioattach.Columns["idbandods"], bandodsservizioattach.Columns["idbandodsservizio"], bandodsservizioattach.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_bandodsservizioattach_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{graduatoriaesiti.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_graduatoriaesiti_tipologiastudente_idtipologiastudente",cPar,cChild,false));

	cPar = new []{graduatoriaesiti.Columns["idgraduatoriaesiti"], graduatoriaesiti.Columns["idtipologiastudente"]};
	cChild = new []{graduatoriaesitipos.Columns["idgraduatoriaesiti"], graduatoriaesitipos.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_graduatoriaesitipos_graduatoriaesiti_idgraduatoriaesiti-idtipologiastudente",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{graduatoriaesitipos.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_graduatoriaesitipos_registry_idreg_studenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_studenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_studenti_registry_idreg",cPar,cChild,false));

	cPar = new []{corsostudiokinddefaultview.Columns["idcorsostudiokind"]};
	cChild = new []{tipologiastudente.Columns["idcorsostudiokind"]};
	Relations.Add(new DataRelation("FK_tipologiastudente_corsostudiokinddefaultview_idcorsostudiokind",cPar,cChild,false));

	#endregion

}
}
}
