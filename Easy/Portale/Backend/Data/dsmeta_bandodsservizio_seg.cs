
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
[System.Xml.Serialization.XmlRoot("dsmeta_bandodsservizio_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_bandodsservizio_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriaesitipos 		=> (MetaTable)Tables["graduatoriaesitipos"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriaesiti 		=> (MetaTable)Tables["graduatoriaesiti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipologiastudentestruttura 		=> (MetaTable)Tables["tipologiastudentestruttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsserviziodatepres 		=> (MetaTable)Tables["bandodsserviziodatepres"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsservizioattach 		=> (MetaTable)Tables["bandodsservizioattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsserviziorequisito 		=> (MetaTable)Tables["bandodsserviziorequisito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiokind 		=> (MetaTable)Tables["corsostudiokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipologiastudente 		=> (MetaTable)Tables["tipologiastudente"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istattitolistudio 		=> (MetaTable)Tables["istattitolistudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonerodefaultview 		=> (MetaTable)Tables["esonerodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsserviziokind 		=> (MetaTable)Tables["bandodsserviziokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsiscresito 		=> (MetaTable)Tables["bandodsiscresito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accreditokind 		=> (MetaTable)Tables["accreditokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsiscr 		=> (MetaTable)Tables["bandodsiscr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsservizio 		=> (MetaTable)Tables["bandodsservizio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_bandodsservizio_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_bandodsservizio_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_bandodsservizio_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_bandodsservizio_seg.xsd";

	#region create DataTables
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

	//////////////////// CORSOSTUDIOKIND /////////////////////////////////
	var tcorsostudiokind= new MetaTable("corsostudiokind");
	tcorsostudiokind.defineColumn("active", typeof(string),false);
	tcorsostudiokind.defineColumn("idcorsostudiokind", typeof(int),false);
	tcorsostudiokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcorsostudiokind);
	tcorsostudiokind.defineKey("idcorsostudiokind");

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
	ttipologiastudente.defineColumn("!idcorsostudiokind_corsostudiokind_title", typeof(string));
	Tables.Add(ttipologiastudente);
	ttipologiastudente.defineKey("idbandods", "idbandodsservizio", "idtipologiastudente");

	//////////////////// ISTATTITOLISTUDIO /////////////////////////////////
	var tistattitolistudio= new MetaTable("istattitolistudio");
	tistattitolistudio.defineColumn("idistattitolistudio", typeof(int),false);
	tistattitolistudio.defineColumn("titolo", typeof(string),false);
	Tables.Add(tistattitolistudio);
	tistattitolistudio.defineKey("idistattitolistudio");

	//////////////////// ESONERODEFAULTVIEW /////////////////////////////////
	var tesonerodefaultview= new MetaTable("esonerodefaultview");
	tesonerodefaultview.defineColumn("aa", typeof(string),false);
	tesonerodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tesonerodefaultview.defineColumn("idcostoscontodef", typeof(int),false);
	tesonerodefaultview.defineColumn("idesonero", typeof(int),false);
	Tables.Add(tesonerodefaultview);
	tesonerodefaultview.defineKey("idesonero");

	//////////////////// BANDODSSERVIZIOKIND /////////////////////////////////
	var tbandodsserviziokind= new MetaTable("bandodsserviziokind");
	tbandodsserviziokind.defineColumn("active", typeof(string),false);
	tbandodsserviziokind.defineColumn("description", typeof(string));
	tbandodsserviziokind.defineColumn("idbandodsserviziokind", typeof(int),false);
	tbandodsserviziokind.defineColumn("title", typeof(string),false);
	Tables.Add(tbandodsserviziokind);
	tbandodsserviziokind.defineKey("idbandodsserviziokind");

	//////////////////// BANDODSISCRESITO /////////////////////////////////
	var tbandodsiscresito= new MetaTable("bandodsiscresito");
	tbandodsiscresito.defineColumn("ct", typeof(DateTime),false);
	tbandodsiscresito.defineColumn("cu", typeof(string),false);
	tbandodsiscresito.defineColumn("idbandods", typeof(int),false);
	tbandodsiscresito.defineColumn("idbandodsiscr", typeof(int),false);
	tbandodsiscresito.defineColumn("idbandodsiscresito", typeof(int),false);
	tbandodsiscresito.defineColumn("idbandodsiscresitokind", typeof(int));
	tbandodsiscresito.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsiscresito.defineColumn("idiscrizione", typeof(int),false);
	tbandodsiscresito.defineColumn("idreg_studenti", typeof(int),false);
	tbandodsiscresito.defineColumn("lt", typeof(DateTime),false);
	tbandodsiscresito.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandodsiscresito);
	tbandodsiscresito.defineKey("idbandods", "idbandodsiscr", "idbandodsiscresito", "idbandodsservizio", "idiscrizione", "idreg_studenti");

	//////////////////// ACCREDITOKIND /////////////////////////////////
	var taccreditokind= new MetaTable("accreditokind");
	taccreditokind.defineColumn("active", typeof(string),false);
	taccreditokind.defineColumn("idaccreditokind", typeof(int),false);
	taccreditokind.defineColumn("title", typeof(string),false);
	Tables.Add(taccreditokind);
	taccreditokind.defineKey("idaccreditokind");

	//////////////////// BANDODSISCR /////////////////////////////////
	var tbandodsiscr= new MetaTable("bandodsiscr");
	tbandodsiscr.defineColumn("cfbonus", typeof(decimal));
	tbandodsiscr.defineColumn("ct", typeof(DateTime),false);
	tbandodsiscr.defineColumn("cu", typeof(string),false);
	tbandodsiscr.defineColumn("idaccreditokind", typeof(int));
	tbandodsiscr.defineColumn("idbandods", typeof(int),false);
	tbandodsiscr.defineColumn("idbandodsiscr", typeof(int),false);
	tbandodsiscr.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsiscr.defineColumn("idiscrizione", typeof(int),false);
	tbandodsiscr.defineColumn("idreg_studenti", typeof(int),false);
	tbandodsiscr.defineColumn("lt", typeof(DateTime),false);
	tbandodsiscr.defineColumn("lu", typeof(string),false);
	tbandodsiscr.defineColumn("!idaccreditokind_accreditokind_title", typeof(string));
	Tables.Add(tbandodsiscr);
	tbandodsiscr.defineKey("idbandods", "idbandodsiscr", "idbandodsservizio", "idiscrizione", "idreg_studenti");

	//////////////////// BANDODSSERVIZIO /////////////////////////////////
	var tbandodsservizio= new MetaTable("bandodsservizio");
	tbandodsservizio.defineColumn("alloggio", typeof(string));
	tbandodsservizio.defineColumn("borsafuorisede", typeof(decimal));
	tbandodsservizio.defineColumn("borsainsede", typeof(decimal));
	tbandodsservizio.defineColumn("borsapendolari", typeof(decimal));
	tbandodsservizio.defineColumn("contributo", typeof(decimal));
	tbandodsservizio.defineColumn("contributomiimporto", typeof(decimal));
	tbandodsservizio.defineColumn("contributomimesi", typeof(int));
	tbandodsservizio.defineColumn("ct", typeof(DateTime),false);
	tbandodsservizio.defineColumn("cu", typeof(string),false);
	tbandodsservizio.defineColumn("fuoricorso", typeof(string),false);
	tbandodsservizio.defineColumn("idbandods", typeof(int),false);
	tbandodsservizio.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsservizio.defineColumn("idbandodsserviziokind", typeof(int),false);
	tbandodsservizio.defineColumn("idesonero", typeof(int));
	tbandodsservizio.defineColumn("idistattitolistudio_min", typeof(int),false);
	tbandodsservizio.defineColumn("iseemax", typeof(decimal));
	tbandodsservizio.defineColumn("ispemax", typeof(decimal));
	tbandodsservizio.defineColumn("lt", typeof(DateTime),false);
	tbandodsservizio.defineColumn("lu", typeof(string),false);
	tbandodsservizio.defineColumn("maggiorenne", typeof(string));
	tbandodsservizio.defineColumn("mensa", typeof(string));
	tbandodsservizio.defineColumn("parttime", typeof(string));
	tbandodsservizio.defineColumn("primaimmatlivello", typeof(string));
	Tables.Add(tbandodsservizio);
	tbandodsservizio.defineKey("idbandods", "idbandodsservizio");

	#endregion


	#region DataRelation creation
	var cPar = new []{bandodsservizio.Columns["idbandods"], bandodsservizio.Columns["idbandodsservizio"]};
	var cChild = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"]};
	Relations.Add(new DataRelation("FK_tipologiastudente_bandodsservizio_idbandods-idbandodsservizio",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{graduatoriaesiti.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_graduatoriaesiti_tipologiastudente_idtipologiastudente",cPar,cChild,false));

	cPar = new []{graduatoriaesiti.Columns["idgraduatoriaesiti"], graduatoriaesiti.Columns["idtipologiastudente"]};
	cChild = new []{graduatoriaesitipos.Columns["idgraduatoriaesiti"], graduatoriaesitipos.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_graduatoriaesitipos_graduatoriaesiti_idgraduatoriaesiti-idtipologiastudente",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{tipologiastudentestruttura.Columns["idbandods"], tipologiastudentestruttura.Columns["idbandodsservizio"], tipologiastudentestruttura.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_tipologiastudentestruttura_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{bandodsserviziodatepres.Columns["idbandods"], bandodsserviziodatepres.Columns["idbandodsservizio"], bandodsserviziodatepres.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_bandodsserviziodatepres_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{bandodsservizioattach.Columns["idbandods"], bandodsservizioattach.Columns["idbandodsservizio"], bandodsservizioattach.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_bandodsservizioattach_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{tipologiastudente.Columns["idbandods"], tipologiastudente.Columns["idbandodsservizio"], tipologiastudente.Columns["idtipologiastudente"]};
	cChild = new []{bandodsserviziorequisito.Columns["idbandods"], bandodsserviziorequisito.Columns["idbandodsservizio"], bandodsserviziorequisito.Columns["idtipologiastudente"]};
	Relations.Add(new DataRelation("FK_bandodsserviziorequisito_tipologiastudente_idbandods-idbandodsservizio-idtipologiastudente",cPar,cChild,false));

	cPar = new []{corsostudiokind.Columns["idcorsostudiokind"]};
	cChild = new []{tipologiastudente.Columns["idcorsostudiokind"]};
	Relations.Add(new DataRelation("FK_tipologiastudente_corsostudiokind_idcorsostudiokind",cPar,cChild,false));

	cPar = new []{istattitolistudio.Columns["idistattitolistudio"]};
	cChild = new []{bandodsservizio.Columns["idistattitolistudio_min"]};
	Relations.Add(new DataRelation("FK_bandodsservizio_istattitolistudio_idistattitolistudio_min",cPar,cChild,false));

	cPar = new []{esonerodefaultview.Columns["idesonero"]};
	cChild = new []{bandodsservizio.Columns["idesonero"]};
	Relations.Add(new DataRelation("FK_bandodsservizio_esonerodefaultview_idesonero",cPar,cChild,false));

	cPar = new []{bandodsserviziokind.Columns["idbandodsserviziokind"]};
	cChild = new []{bandodsservizio.Columns["idbandodsserviziokind"]};
	Relations.Add(new DataRelation("FK_bandodsservizio_bandodsserviziokind_idbandodsserviziokind",cPar,cChild,false));

	cPar = new []{bandodsservizio.Columns["idbandods"], bandodsservizio.Columns["idbandodsservizio"]};
	cChild = new []{bandodsiscr.Columns["idbandods"], bandodsiscr.Columns["idbandodsservizio"]};
	Relations.Add(new DataRelation("FK_bandodsiscr_bandodsservizio_idbandods-idbandodsservizio",cPar,cChild,false));

	cPar = new []{bandodsiscr.Columns["idbandods"], bandodsiscr.Columns["idbandodsiscr"], bandodsiscr.Columns["idbandodsservizio"], bandodsiscr.Columns["idiscrizione"], bandodsiscr.Columns["idreg_studenti"]};
	cChild = new []{bandodsiscresito.Columns["idbandods"], bandodsiscresito.Columns["idbandodsiscr"], bandodsiscresito.Columns["idbandodsservizio"], bandodsiscresito.Columns["idiscrizione"], bandodsiscresito.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_bandodsiscresito_bandodsiscr_idbandods-idbandodsiscr-idbandodsservizio-idiscrizione-idreg_studenti",cPar,cChild,false));

	cPar = new []{accreditokind.Columns["idaccreditokind"]};
	cChild = new []{bandodsiscr.Columns["idaccreditokind"]};
	Relations.Add(new DataRelation("FK_bandodsiscr_accreditokind_idaccreditokind",cPar,cChild,false));

	#endregion

}
}
}
