
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
[System.Xml.Serialization.XmlRoot("dsmeta_accordoscambiomi_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_accordoscambiomi_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel_alias1 		=> (MetaTable)Tables["cefrlanglevel_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomiporzanno 		=> (MetaTable)Tables["accordoscambiomiporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable torkind 		=> (MetaTable)Tables["torkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istitutiesteri 		=> (MetaTable)Tables["registry_istitutiesteri"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isced2013 		=> (MetaTable)Tables["isced2013"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomidett 		=> (MetaTable)Tables["accordoscambiomidett"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefrlanglevel 		=> (MetaTable)Tables["cefrlanglevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_aziende 		=> (MetaTable)Tables["registry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomidettaz 		=> (MetaTable)Tables["accordoscambiomidettaz"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable programmami 		=> (MetaTable)Tables["programmami"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomi 		=> (MetaTable)Tables["accordoscambiomi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_accordoscambiomi_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_accordoscambiomi_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_accordoscambiomi_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_accordoscambiomi_seg.xsd";

	#region create DataTables
	//////////////////// CEFRLANGLEVEL_ALIAS1 /////////////////////////////////
	var tcefrlanglevel_alias1= new MetaTable("cefrlanglevel_alias1");
	tcefrlanglevel_alias1.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel_alias1.defineColumn("cu", typeof(string),false);
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomi", typeof(int),false);
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomidett", typeof(int),false);
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	tcefrlanglevel_alias1.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel_alias1.defineColumn("idiscrizionebmi", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel_alias1.defineColumn("idnation", typeof(int));
	tcefrlanglevel_alias1.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel_alias1.defineColumn("lu", typeof(string),false);
	tcefrlanglevel_alias1.ExtendedProperties["TableForReading"]="cefrlanglevel";
	Tables.Add(tcefrlanglevel_alias1);
	tcefrlanglevel_alias1.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idcefrlanglevel");

	//////////////////// ACCORDOSCAMBIOMIPORZANNO /////////////////////////////////
	var taccordoscambiomiporzanno= new MetaTable("accordoscambiomiporzanno");
	taccordoscambiomiporzanno.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomiporzanno.defineColumn("cu", typeof(string),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomidett", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomiporzanno", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("iddidprogporzannokind", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("indice", typeof(int));
	taccordoscambiomiporzanno.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomiporzanno.defineColumn("lu", typeof(string),false);
	Tables.Add(taccordoscambiomiporzanno);
	taccordoscambiomiporzanno.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idaccordoscambiomiporzanno", "iddidprogporzannokind");

	//////////////////// TORKIND /////////////////////////////////
	var ttorkind= new MetaTable("torkind");
	ttorkind.defineColumn("description", typeof(string));
	ttorkind.defineColumn("idtorkind", typeof(int),false);
	ttorkind.defineColumn("title", typeof(string),false);
	Tables.Add(ttorkind);
	ttorkind.defineKey("idtorkind");

	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("annotation", typeof(string));
	tregistry_alias1.defineColumn("authorization_free", typeof(string));
	tregistry_alias1.defineColumn("badgecode", typeof(string));
	tregistry_alias1.defineColumn("birthdate", typeof(DateTime));
	tregistry_alias1.defineColumn("ccp", typeof(string));
	tregistry_alias1.defineColumn("cf", typeof(string));
	tregistry_alias1.defineColumn("ct", typeof(DateTime),false);
	tregistry_alias1.defineColumn("cu", typeof(string),false);
	tregistry_alias1.defineColumn("email_fe", typeof(string));
	tregistry_alias1.defineColumn("extension", typeof(string));
	tregistry_alias1.defineColumn("extmatricula", typeof(string));
	tregistry_alias1.defineColumn("flag_pa", typeof(string));
	tregistry_alias1.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry_alias1.defineColumn("foreigncf", typeof(string));
	tregistry_alias1.defineColumn("forename", typeof(string));
	tregistry_alias1.defineColumn("gender", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias1.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias1.defineColumn("idcategory", typeof(string));
	tregistry_alias1.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias1.defineColumn("idcity", typeof(int));
	tregistry_alias1.defineColumn("idexternal", typeof(int));
	tregistry_alias1.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias1.defineColumn("idnation", typeof(int));
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("idregistryclass", typeof(string));
	tregistry_alias1.defineColumn("idregistrykind", typeof(int));
	tregistry_alias1.defineColumn("idtitle", typeof(string));
	tregistry_alias1.defineColumn("ipa_fe", typeof(string));
	tregistry_alias1.defineColumn("ipa_perlapa", typeof(string));
	tregistry_alias1.defineColumn("location", typeof(string));
	tregistry_alias1.defineColumn("lt", typeof(DateTime),false);
	tregistry_alias1.defineColumn("lu", typeof(string),false);
	tregistry_alias1.defineColumn("maritalsurname", typeof(string));
	tregistry_alias1.defineColumn("multi_cf", typeof(string));
	tregistry_alias1.defineColumn("p_iva", typeof(string));
	tregistry_alias1.defineColumn("pec_fe", typeof(string));
	tregistry_alias1.defineColumn("residence", typeof(int),false);
	tregistry_alias1.defineColumn("rtf", typeof(Byte[]));
	tregistry_alias1.defineColumn("sdi_defrifamm", typeof(string));
	tregistry_alias1.defineColumn("sdi_norifamm", typeof(string));
	tregistry_alias1.defineColumn("surname", typeof(string));
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.defineColumn("toredirect", typeof(int));
	tregistry_alias1.defineColumn("txt", typeof(string));
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// REGISTRY_ISTITUTIESTERI /////////////////////////////////
	var tregistry_istitutiesteri= new MetaTable("registry_istitutiesteri");
	tregistry_istitutiesteri.defineColumn("city", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("code", typeof(string));
	tregistry_istitutiesteri.defineColumn("ct", typeof(DateTime),false);
	tregistry_istitutiesteri.defineColumn("cu", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("idnace", typeof(string));
	tregistry_istitutiesteri.defineColumn("idreg", typeof(int),false);
	tregistry_istitutiesteri.defineColumn("institutionalcode", typeof(string));
	tregistry_istitutiesteri.defineColumn("lt", typeof(DateTime),false);
	tregistry_istitutiesteri.defineColumn("lu", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("name", typeof(string),false);
	tregistry_istitutiesteri.defineColumn("referencenumber", typeof(string));
	Tables.Add(tregistry_istitutiesteri);
	tregistry_istitutiesteri.defineKey("idreg");

	//////////////////// ISCED2013 /////////////////////////////////
	var tisced2013= new MetaTable("isced2013");
	tisced2013.defineColumn("detailedfield", typeof(string));
	tisced2013.defineColumn("idisced2013", typeof(int),false);
	Tables.Add(tisced2013);
	tisced2013.defineKey("idisced2013");

	//////////////////// ACCORDOSCAMBIOMIDETT /////////////////////////////////
	var taccordoscambiomidett= new MetaTable("accordoscambiomidett");
	taccordoscambiomidett.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomidett.defineColumn("cu", typeof(string),false);
	taccordoscambiomidett.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomidett.defineColumn("idaccordoscambiomidett", typeof(int),false);
	taccordoscambiomidett.defineColumn("idisced2013", typeof(int),false);
	taccordoscambiomidett.defineColumn("idreg_istitutiesteri", typeof(int),false);
	taccordoscambiomidett.defineColumn("idtorkind", typeof(int));
	taccordoscambiomidett.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomidett.defineColumn("lu", typeof(string),false);
	taccordoscambiomidett.defineColumn("numdocincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numdocoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("numpersincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numpersoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("numstulearincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numstulearoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("numstutraincoming", typeof(int));
	taccordoscambiomidett.defineColumn("numstutraoutgoing", typeof(int));
	taccordoscambiomidett.defineColumn("stipula", typeof(DateTime));
	taccordoscambiomidett.defineColumn("stop", typeof(DateTime));
	taccordoscambiomidett.defineColumn("!idisced2013_isced2013_detailedfield", typeof(string));
	taccordoscambiomidett.defineColumn("!idreg_istitutiesteri_registry_istitutiesteri_title", typeof(string));
	taccordoscambiomidett.defineColumn("!idtorkind_torkind_title", typeof(string));
	taccordoscambiomidett.defineColumn("!idtorkind_torkind_description", typeof(string));
	Tables.Add(taccordoscambiomidett);
	taccordoscambiomidett.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idreg_istitutiesteri");

	//////////////////// CEFRLANGLEVEL /////////////////////////////////
	var tcefrlanglevel= new MetaTable("cefrlanglevel");
	tcefrlanglevel.defineColumn("ct", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("cu", typeof(string),false);
	tcefrlanglevel.defineColumn("idaccordoscambiomi", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidett", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettaz", typeof(int));
	tcefrlanglevel.defineColumn("idaccordoscambiomidettlangkind", typeof(int),false);
	tcefrlanglevel.defineColumn("idcefr_compasc", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_complett", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlinter", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_parlprod", typeof(int));
	tcefrlanglevel.defineColumn("idcefr_scritto", typeof(int));
	tcefrlanglevel.defineColumn("idcefrlanglevel", typeof(int),false);
	tcefrlanglevel.defineColumn("idiscrizionebmi", typeof(int));
	tcefrlanglevel.defineColumn("idlearningagrstud", typeof(int));
	tcefrlanglevel.defineColumn("idlearningagrtrainer", typeof(int));
	tcefrlanglevel.defineColumn("idnation", typeof(int));
	tcefrlanglevel.defineColumn("lt", typeof(DateTime),false);
	tcefrlanglevel.defineColumn("lu", typeof(string),false);
	Tables.Add(tcefrlanglevel);
	tcefrlanglevel.defineKey("idcefrlanglevel");

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

	//////////////////// REGISTRY_AZIENDE /////////////////////////////////
	var tregistry_aziende= new MetaTable("registry_aziende");
	tregistry_aziende.defineColumn("ct", typeof(DateTime),false);
	tregistry_aziende.defineColumn("cu", typeof(string),false);
	tregistry_aziende.defineColumn("idateco", typeof(int));
	tregistry_aziende.defineColumn("idnace", typeof(string));
	tregistry_aziende.defineColumn("idnaturagiur", typeof(int));
	tregistry_aziende.defineColumn("idnumerodip", typeof(int));
	tregistry_aziende.defineColumn("idreg", typeof(int),false);
	tregistry_aziende.defineColumn("lt", typeof(DateTime),false);
	tregistry_aziende.defineColumn("lu", typeof(string),false);
	tregistry_aziende.defineColumn("pic", typeof(string));
	tregistry_aziende.defineColumn("title_en", typeof(string));
	tregistry_aziende.defineColumn("txt_en", typeof(string));
	Tables.Add(tregistry_aziende);
	tregistry_aziende.defineKey("idreg");

	//////////////////// ACCORDOSCAMBIOMIDETTAZ /////////////////////////////////
	var taccordoscambiomidettaz= new MetaTable("accordoscambiomidettaz");
	taccordoscambiomidettaz.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomidettaz.defineColumn("cu", typeof(string),false);
	taccordoscambiomidettaz.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomidettaz.defineColumn("idaccordoscambiomidettaz", typeof(int),false);
	taccordoscambiomidettaz.defineColumn("idreg_aziende", typeof(int),false);
	taccordoscambiomidettaz.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomidettaz.defineColumn("lu", typeof(string),false);
	taccordoscambiomidettaz.defineColumn("numstud", typeof(int));
	taccordoscambiomidettaz.defineColumn("stipula", typeof(DateTime));
	taccordoscambiomidettaz.defineColumn("stop", typeof(DateTime));
	taccordoscambiomidettaz.defineColumn("!idreg_aziende_registry_aziende_title", typeof(string));
	Tables.Add(taccordoscambiomidettaz);
	taccordoscambiomidettaz.defineKey("idaccordoscambiomi", "idaccordoscambiomidettaz", "idreg_aziende");

	//////////////////// PROGRAMMAMI /////////////////////////////////
	var tprogrammami= new MetaTable("programmami");
	tprogrammami.defineColumn("acronimo", typeof(string));
	tprogrammami.defineColumn("idprogrammami", typeof(int),false);
	Tables.Add(tprogrammami);
	tprogrammami.defineKey("idprogrammami");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ACCORDOSCAMBIOMI /////////////////////////////////
	var taccordoscambiomi= new MetaTable("accordoscambiomi");
	taccordoscambiomi.defineColumn("aa_start", typeof(string),false);
	taccordoscambiomi.defineColumn("aa_stop", typeof(string));
	taccordoscambiomi.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomi.defineColumn("cu", typeof(string),false);
	taccordoscambiomi.defineColumn("description", typeof(string));
	taccordoscambiomi.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomi.defineColumn("idprogrammami", typeof(int));
	taccordoscambiomi.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomi.defineColumn("lu", typeof(string),false);
	taccordoscambiomi.defineColumn("title", typeof(string),false);
	Tables.Add(taccordoscambiomi);
	taccordoscambiomi.defineKey("idaccordoscambiomi");

	#endregion


	#region DataRelation creation
	var cPar = new []{accordoscambiomi.Columns["idaccordoscambiomi"]};
	var cChild = new []{accordoscambiomidett.Columns["idaccordoscambiomi"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidett_accordoscambiomi_idaccordoscambiomi",cPar,cChild,false));

	cPar = new []{accordoscambiomidett.Columns["idaccordoscambiomi"], accordoscambiomidett.Columns["idaccordoscambiomidett"]};
	cChild = new []{cefrlanglevel_alias1.Columns["idaccordoscambiomi"], cefrlanglevel_alias1.Columns["idaccordoscambiomidett"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_alias1_accordoscambiomidett_idaccordoscambiomi-idaccordoscambiomidett",cPar,cChild,false));

	cPar = new []{accordoscambiomidett.Columns["idaccordoscambiomi"], accordoscambiomidett.Columns["idaccordoscambiomidett"]};
	cChild = new []{accordoscambiomiporzanno.Columns["idaccordoscambiomi"], accordoscambiomiporzanno.Columns["idaccordoscambiomidett"]};
	Relations.Add(new DataRelation("FK_accordoscambiomiporzanno_accordoscambiomidett_idaccordoscambiomi-idaccordoscambiomidett",cPar,cChild,false));

	cPar = new []{torkind.Columns["idtorkind"]};
	cChild = new []{accordoscambiomidett.Columns["idtorkind"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidett_torkind_idtorkind",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{accordoscambiomidett.Columns["idreg_istitutiesteri"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidett_registry_alias1_idreg_istitutiesteri",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_istitutiesteri.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istitutiesteri_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{isced2013.Columns["idisced2013"]};
	cChild = new []{accordoscambiomidett.Columns["idisced2013"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidett_isced2013_idisced2013",cPar,cChild,false));

	cPar = new []{accordoscambiomi.Columns["idaccordoscambiomi"]};
	cChild = new []{accordoscambiomidettaz.Columns["idaccordoscambiomi"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidettaz_accordoscambiomi_idaccordoscambiomi",cPar,cChild,false));

	cPar = new []{accordoscambiomidettaz.Columns["idaccordoscambiomi"], accordoscambiomidettaz.Columns["idaccordoscambiomidettaz"]};
	cChild = new []{cefrlanglevel.Columns["idaccordoscambiomi"], cefrlanglevel.Columns["idaccordoscambiomidettaz"]};
	Relations.Add(new DataRelation("FK_cefrlanglevel_accordoscambiomidettaz_idaccordoscambiomi-idaccordoscambiomidettaz",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{accordoscambiomidettaz.Columns["idreg_aziende"]};
	Relations.Add(new DataRelation("FK_accordoscambiomidettaz_registry_idreg_aziende",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_aziende.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_aziende_registry_idreg",cPar,cChild,false));

	cPar = new []{programmami.Columns["idprogrammami"]};
	cChild = new []{accordoscambiomi.Columns["idprogrammami"]};
	Relations.Add(new DataRelation("FK_accordoscambiomi_programmami_idprogrammami",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{accordoscambiomi.Columns["aa_stop"]};
	Relations.Add(new DataRelation("FK_accordoscambiomi_annoaccademico_alias1_aa_stop",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{accordoscambiomi.Columns["aa_start"]};
	Relations.Add(new DataRelation("FK_accordoscambiomi_annoaccademico_aa_start",cPar,cChild,false));

	#endregion

}
}
}
