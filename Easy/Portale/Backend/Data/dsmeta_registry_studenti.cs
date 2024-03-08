
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
[System.Xml.Serialization.XmlRoot("dsmeta_registry_studenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registry_studenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudio 		=> (MetaTable)Tables["corsostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_istituti 		=> (MetaTable)Tables["registry_istituti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istattitolistudio 		=> (MetaTable)Tables["istattitolistudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias9 		=> (MetaTable)Tables["annoaccademico_alias9"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation_alias5 		=> (MetaTable)Tables["geo_nation_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city_alias5 		=> (MetaTable)Tables["geo_city_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias4 		=> (MetaTable)Tables["diniego_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pratica 		=> (MetaTable)Tables["pratica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias8 		=> (MetaTable)Tables["didprog_alias8"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable importcontrattistipendiview 		=> (MetaTable)Tables["importcontrattistipendiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione_alias6 		=> (MetaTable)Tables["iscrizione_alias6"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias3 		=> (MetaTable)Tables["statuskind_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias8 		=> (MetaTable)Tables["annoaccademico_alias8"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias3 		=> (MetaTable)Tables["istanza_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_pas 		=> (MetaTable)Tables["istanza_pas"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias3 		=> (MetaTable)Tables["diniego_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_alias3 		=> (MetaTable)Tables["nullaosta_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_imm_alias3 		=> (MetaTable)Tables["nullaosta_imm_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzadichiar_alias2 		=> (MetaTable)Tables["istanzadichiar_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias7 		=> (MetaTable)Tables["istanza_alias7"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias2 		=> (MetaTable)Tables["statuskind_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias7 		=> (MetaTable)Tables["didprog_alias7"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias7 		=> (MetaTable)Tables["annoaccademico_alias7"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias2 		=> (MetaTable)Tables["istanza_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori_alias2 		=> (MetaTable)Tables["didprogori_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr_alias2 		=> (MetaTable)Tables["didprogcurr_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_imm_alias2 		=> (MetaTable)Tables["istanza_imm_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias1 		=> (MetaTable)Tables["diniego_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_alias1 		=> (MetaTable)Tables["nullaosta_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_imm_alias1 		=> (MetaTable)Tables["nullaosta_imm_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzadichiar_alias1 		=> (MetaTable)Tables["istanzadichiar_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias6 		=> (MetaTable)Tables["istanza_alias6"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind_alias1 		=> (MetaTable)Tables["statuskind_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias6 		=> (MetaTable)Tables["didprog_alias6"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias6 		=> (MetaTable)Tables["annoaccademico_alias6"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias1 		=> (MetaTable)Tables["istanza_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori_alias1 		=> (MetaTable)Tables["didprogori_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr_alias1 		=> (MetaTable)Tables["didprogcurr_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_imm_alias1 		=> (MetaTable)Tables["istanza_imm_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable diniego_alias2 		=> (MetaTable)Tables["diniego_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzadichiar 		=> (MetaTable)Tables["istanzadichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_alias14 		=> (MetaTable)Tables["istanza_alias14"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_imm 		=> (MetaTable)Tables["nullaosta_imm"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable statuskind 		=> (MetaTable)Tables["statuskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias5 		=> (MetaTable)Tables["didprog_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias5 		=> (MetaTable)Tables["annoaccademico_alias5"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza 		=> (MetaTable)Tables["istanza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanza_imm 		=> (MetaTable)Tables["istanza_imm"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias1 		=> (MetaTable)Tables["sostenimento_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform_alias1 		=> (MetaTable)Tables["pianostudioattivform_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudio_alias1 		=> (MetaTable)Tables["pianostudio_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias4 		=> (MetaTable)Tables["annoaccademico_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione_alias4 		=> (MetaTable)Tables["iscrizione_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias4 		=> (MetaTable)Tables["sostenimento_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias4 		=> (MetaTable)Tables["didprog_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias3 		=> (MetaTable)Tables["annoaccademico_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione_alias3 		=> (MetaTable)Tables["iscrizione_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias3 		=> (MetaTable)Tables["sostenimento_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias3 		=> (MetaTable)Tables["didprog_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias2 		=> (MetaTable)Tables["annoaccademico_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione_alias2 		=> (MetaTable)Tables["iscrizione_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento_alias2 		=> (MetaTable)Tables["sostenimento_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog_alias2 		=> (MetaTable)Tables["didprog_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione_alias1 		=> (MetaTable)Tables["iscrizione_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable decadenza 		=> (MetaTable)Tables["decadenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizioneanno 		=> (MetaTable)Tables["iscrizioneanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimento 		=> (MetaTable)Tables["sostenimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivform 		=> (MetaTable)Tables["pianostudioattivform"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudio 		=> (MetaTable)Tables["pianostudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizione 		=> (MetaTable)Tables["iscrizione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsiscresito 		=> (MetaTable)Tables["bandodsiscresito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accreditokind 		=> (MetaTable)Tables["accreditokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsiscr 		=> (MetaTable)Tables["bandodsiscr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studprenotkinddefaultview 		=> (MetaTable)Tables["studprenotkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable studdirittokinddefaultview 		=> (MetaTable)Tables["studdirittokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclasspersoneview 		=> (MetaTable)Tables["registryclasspersoneview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_studenti 		=> (MetaTable)Tables["registry_studenti"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_studenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_studenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_studenti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_studenti.xsd";

	#region create DataTables
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

	//////////////////// REGISTRY_ISTITUTI /////////////////////////////////
	var tregistry_istituti= new MetaTable("registry_istituti");
	tregistry_istituti.defineColumn("codicemiur", typeof(string));
	tregistry_istituti.defineColumn("codiceustat", typeof(string));
	tregistry_istituti.defineColumn("comune", typeof(string));
	tregistry_istituti.defineColumn("ct", typeof(DateTime));
	tregistry_istituti.defineColumn("cu", typeof(string),false);
	tregistry_istituti.defineColumn("idistitutokind", typeof(int),false);
	tregistry_istituti.defineColumn("idistitutoustat", typeof(int));
	tregistry_istituti.defineColumn("idreg", typeof(int),false);
	tregistry_istituti.defineColumn("lt", typeof(DateTime),false);
	tregistry_istituti.defineColumn("lu", typeof(string),false);
	tregistry_istituti.defineColumn("nome", typeof(string));
	tregistry_istituti.defineColumn("sortcode", typeof(int));
	tregistry_istituti.defineColumn("title", typeof(string));
	tregistry_istituti.defineColumn("title_en", typeof(string));
	Tables.Add(tregistry_istituti);
	tregistry_istituti.defineKey("idreg");

	//////////////////// ISTATTITOLISTUDIO /////////////////////////////////
	var tistattitolistudio= new MetaTable("istattitolistudio");
	tistattitolistudio.defineColumn("idistattitolistudio", typeof(int),false);
	tistattitolistudio.defineColumn("titolo", typeof(string),false);
	Tables.Add(tistattitolistudio);
	tistattitolistudio.defineKey("idistattitolistudio");

	//////////////////// ANNOACCADEMICO_ALIAS9 /////////////////////////////////
	var tannoaccademico_alias9= new MetaTable("annoaccademico_alias9");
	tannoaccademico_alias9.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias9.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias9);
	tannoaccademico_alias9.defineKey("aa");

	//////////////////// TITOLOSTUDIO /////////////////////////////////
	var ttitolostudio= new MetaTable("titolostudio");
	ttitolostudio.defineColumn("aa", typeof(string),false);
	ttitolostudio.defineColumn("conseguito", typeof(string),false);
	ttitolostudio.defineColumn("ct", typeof(DateTime));
	ttitolostudio.defineColumn("cu", typeof(string));
	ttitolostudio.defineColumn("data", typeof(DateTime),false);
	ttitolostudio.defineColumn("giudizio", typeof(string));
	ttitolostudio.defineColumn("idattach", typeof(int));
	ttitolostudio.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudio.defineColumn("idreg", typeof(int),false);
	ttitolostudio.defineColumn("idreg_istituti", typeof(int),false);
	ttitolostudio.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudio.defineColumn("lt", typeof(DateTime));
	ttitolostudio.defineColumn("lu", typeof(string));
	ttitolostudio.defineColumn("voto", typeof(int));
	ttitolostudio.defineColumn("votolode", typeof(string));
	ttitolostudio.defineColumn("votosu", typeof(int));
	ttitolostudio.defineColumn("!idistattitolistudio_istattitolistudio_titolo", typeof(string));
	ttitolostudio.defineColumn("!idreg_istituti_registry_istituti_title", typeof(string));
	Tables.Add(ttitolostudio);
	ttitolostudio.defineKey("idreg", "idtitolostudio");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new MetaTable("registryreference");
	tregistryreference.defineColumn("activeweb", typeof(string));
	tregistryreference.defineColumn("ct", typeof(DateTime),false);
	tregistryreference.defineColumn("cu", typeof(string),false);
	tregistryreference.defineColumn("email", typeof(string));
	tregistryreference.defineColumn("faxnumber", typeof(string));
	tregistryreference.defineColumn("flagdefault", typeof(string));
	tregistryreference.defineColumn("idreg", typeof(int),false);
	tregistryreference.defineColumn("idregistryreference", typeof(int),false);
	tregistryreference.defineColumn("iterweb", typeof(int));
	tregistryreference.defineColumn("lt", typeof(DateTime),false);
	tregistryreference.defineColumn("lu", typeof(string),false);
	tregistryreference.defineColumn("mobilenumber", typeof(string));
	tregistryreference.defineColumn("msnnumber", typeof(string));
	tregistryreference.defineColumn("passwordweb", typeof(string));
	tregistryreference.defineColumn("pec", typeof(string));
	tregistryreference.defineColumn("phonenumber", typeof(string));
	tregistryreference.defineColumn("referencename", typeof(string),false);
	tregistryreference.defineColumn("registryreferencerole", typeof(string));
	tregistryreference.defineColumn("rtf", typeof(Byte[]));
	tregistryreference.defineColumn("saltweb", typeof(string));
	tregistryreference.defineColumn("skypenumber", typeof(string));
	tregistryreference.defineColumn("txt", typeof(string));
	tregistryreference.defineColumn("userweb", typeof(string));
	tregistryreference.defineColumn("website", typeof(string));
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// GEO_NATION_ALIAS5 /////////////////////////////////
	var tgeo_nation_alias5= new MetaTable("geo_nation_alias5");
	tgeo_nation_alias5.defineColumn("idnation", typeof(int),false);
	tgeo_nation_alias5.defineColumn("title", typeof(string));
	tgeo_nation_alias5.ExtendedProperties["TableForReading"]="geo_nation";
	Tables.Add(tgeo_nation_alias5);
	tgeo_nation_alias5.defineKey("idnation");

	//////////////////// GEO_CITY_ALIAS5 /////////////////////////////////
	var tgeo_city_alias5= new MetaTable("geo_city_alias5");
	tgeo_city_alias5.defineColumn("idcity", typeof(int),false);
	tgeo_city_alias5.defineColumn("title", typeof(string));
	tgeo_city_alias5.ExtendedProperties["TableForReading"]="geo_city";
	Tables.Add(tgeo_city_alias5);
	tgeo_city_alias5.defineKey("idcity");

	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new MetaTable("address");
	taddress.defineColumn("active", typeof(string));
	taddress.defineColumn("description", typeof(string),false);
	taddress.defineColumn("idaddress", typeof(int),false);
	Tables.Add(taddress);
	taddress.defineKey("idaddress");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new MetaTable("registryaddress");
	tregistryaddress.defineColumn("active", typeof(string));
	tregistryaddress.defineColumn("address", typeof(string));
	tregistryaddress.defineColumn("annotations", typeof(string));
	tregistryaddress.defineColumn("cap", typeof(string));
	tregistryaddress.defineColumn("ct", typeof(DateTime));
	tregistryaddress.defineColumn("cu", typeof(string));
	tregistryaddress.defineColumn("flagforeign", typeof(string));
	tregistryaddress.defineColumn("idaddresskind", typeof(int),false);
	tregistryaddress.defineColumn("idcity", typeof(int));
	tregistryaddress.defineColumn("idnation", typeof(int));
	tregistryaddress.defineColumn("idreg", typeof(int),false);
	tregistryaddress.defineColumn("location", typeof(string));
	tregistryaddress.defineColumn("lt", typeof(DateTime));
	tregistryaddress.defineColumn("lu", typeof(string));
	tregistryaddress.defineColumn("officename", typeof(string));
	tregistryaddress.defineColumn("recipientagency", typeof(string));
	tregistryaddress.defineColumn("start", typeof(DateTime),false);
	tregistryaddress.defineColumn("stop", typeof(DateTime));
	tregistryaddress.defineColumn("!idaddresskind_address_description", typeof(string));
	tregistryaddress.defineColumn("!idcity_geo_city_title", typeof(string));
	tregistryaddress.defineColumn("!idnation_geo_nation_title", typeof(string));
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idaddresskind", "idreg", "start");

	//////////////////// DINIEGO_ALIAS4 /////////////////////////////////
	var tdiniego_alias4= new MetaTable("diniego_alias4");
	tdiniego_alias4.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias4.defineColumn("cu", typeof(string),false);
	tdiniego_alias4.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias4.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias4.defineColumn("iddidprog", typeof(int));
	tdiniego_alias4.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias4.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias4.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias4.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias4.defineColumn("idreg", typeof(int),false);
	tdiniego_alias4.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias4.defineColumn("lu", typeof(string),false);
	tdiniego_alias4.defineColumn("protanno", typeof(int));
	tdiniego_alias4.defineColumn("protnumero", typeof(int));
	tdiniego_alias4.ExtendedProperties["TableForReading"]="diniego";
	tdiniego_alias4.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tdiniego_alias4);
	tdiniego_alias4.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// PRATICA /////////////////////////////////
	var tpratica= new MetaTable("pratica");
	tpratica.defineColumn("ct", typeof(DateTime),false);
	tpratica.defineColumn("cu", typeof(string),false);
	tpratica.defineColumn("idcorsostudio", typeof(int),false);
	tpratica.defineColumn("iddichiar", typeof(int));
	tpratica.defineColumn("iddidprog", typeof(int),false);
	tpratica.defineColumn("idiscrizione", typeof(int),false);
	tpratica.defineColumn("idiscrizione_from", typeof(int));
	tpratica.defineColumn("idistanza", typeof(int),false);
	tpratica.defineColumn("idistanzakind", typeof(int),false);
	tpratica.defineColumn("idpratica", typeof(int),false);
	tpratica.defineColumn("idreg", typeof(int),false);
	tpratica.defineColumn("idstatuskind", typeof(int),false);
	tpratica.defineColumn("idtitolostudio", typeof(int));
	tpratica.defineColumn("lt", typeof(DateTime),false);
	tpratica.defineColumn("lu", typeof(string),false);
	tpratica.defineColumn("protanno", typeof(int));
	tpratica.defineColumn("protnumero", typeof(int));
	Tables.Add(tpratica);
	tpratica.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idpratica", "idreg");

	//////////////////// DIDPROG_ALIAS8 /////////////////////////////////
	var tdidprog_alias8= new MetaTable("didprog_alias8");
	tdidprog_alias8.defineColumn("aa", typeof(string),false);
	tdidprog_alias8.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias8.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias8.defineColumn("idsede", typeof(int));
	tdidprog_alias8.defineColumn("title", typeof(string));
	tdidprog_alias8.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias8);
	tdidprog_alias8.defineKey("idcorsostudio", "iddidprog");

	//////////////////// IMPORTCONTRATTISTIPENDIVIEW /////////////////////////////////
	var timportcontrattistipendiview= new MetaTable("importcontrattistipendiview");
	timportcontrattistipendiview.defineColumn("anno", typeof(int),false);
	timportcontrattistipendiview.defineColumn("idcontratto", typeof(int),false);
	timportcontrattistipendiview.defineColumn("idreg", typeof(int),false);
	timportcontrattistipendiview.defineColumn("idstipendioannuo", typeof(int),false);
	Tables.Add(timportcontrattistipendiview);
	timportcontrattistipendiview.defineKey("anno", "idcontratto", "idreg", "idstipendioannuo");

	//////////////////// ISCRIZIONE_ALIAS6 /////////////////////////////////
	var tiscrizione_alias6= new MetaTable("iscrizione_alias6");
	tiscrizione_alias6.defineColumn("aa", typeof(string),false);
	tiscrizione_alias6.defineColumn("anno", typeof(int));
	tiscrizione_alias6.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione_alias6.defineColumn("iddidprog", typeof(int),false);
	tiscrizione_alias6.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione_alias6.defineColumn("idreg", typeof(int),false);
	tiscrizione_alias6.ExtendedProperties["TableForReading"]="iscrizione";
	Tables.Add(tiscrizione_alias6);
	tiscrizione_alias6.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// STATUSKIND_ALIAS3 /////////////////////////////////
	var tstatuskind_alias3= new MetaTable("statuskind_alias3");
	tstatuskind_alias3.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias3.defineColumn("title", typeof(string),false);
	tstatuskind_alias3.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias3);
	tstatuskind_alias3.defineKey("idstatuskind");

	//////////////////// ANNOACCADEMICO_ALIAS8 /////////////////////////////////
	var tannoaccademico_alias8= new MetaTable("annoaccademico_alias8");
	tannoaccademico_alias8.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias8.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias8);
	tannoaccademico_alias8.defineKey("aa");

	//////////////////// ISTANZA_ALIAS3 /////////////////////////////////
	var tistanza_alias3= new MetaTable("istanza_alias3");
	tistanza_alias3.defineColumn("aa", typeof(string),false);
	tistanza_alias3.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias3.defineColumn("cu", typeof(string),false);
	tistanza_alias3.defineColumn("data", typeof(DateTime),false);
	tistanza_alias3.defineColumn("extension", typeof(string));
	tistanza_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias3.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias3.defineColumn("idiscrizione", typeof(int),false);
	tistanza_alias3.defineColumn("idistanza", typeof(int),false);
	tistanza_alias3.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias3.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias3.defineColumn("idstatuskind", typeof(int));
	tistanza_alias3.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias3.defineColumn("lu", typeof(string),false);
	tistanza_alias3.defineColumn("paridistanza", typeof(int));
	tistanza_alias3.defineColumn("protanno", typeof(int),false);
	tistanza_alias3.defineColumn("protnumero", typeof(int),false);
	tistanza_alias3.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	tistanza_alias3.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias3);
	tistanza_alias3.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// ISTANZA_PAS /////////////////////////////////
	var tistanza_pas= new MetaTable("istanza_pas");
	tistanza_pas.defineColumn("ct", typeof(DateTime),false);
	tistanza_pas.defineColumn("cu", typeof(string),false);
	tistanza_pas.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_pas.defineColumn("iddidprog", typeof(int),false);
	tistanza_pas.defineColumn("idiscrizione", typeof(int),false);
	tistanza_pas.defineColumn("idiscrizione_from", typeof(int),false);
	tistanza_pas.defineColumn("idistanza", typeof(int),false);
	tistanza_pas.defineColumn("idistanzakind", typeof(int),false);
	tistanza_pas.defineColumn("idreg", typeof(int),false);
	tistanza_pas.defineColumn("lt", typeof(DateTime),false);
	tistanza_pas.defineColumn("lu", typeof(string),false);
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_aa", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_anno_cognome", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_anno_inquadramento", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_anno_matricola", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_anno_nome", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_anno_ruolo", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_iddidprog_title", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_iddidprog_aa", typeof(string));
	tistanza_pas.defineColumn("!idiscrizione_from_iscrizione_iddidprog_idsede", typeof(int));
	Tables.Add(tistanza_pas);
	tistanza_pas.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idistanza", "idistanzakind", "idreg");

	//////////////////// DINIEGO_ALIAS3 /////////////////////////////////
	var tdiniego_alias3= new MetaTable("diniego_alias3");
	tdiniego_alias3.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("cu", typeof(string),false);
	tdiniego_alias3.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias3.defineColumn("iddidprog", typeof(int));
	tdiniego_alias3.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias3.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias3.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias3.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias3.defineColumn("idreg", typeof(int),false);
	tdiniego_alias3.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias3.defineColumn("lu", typeof(string),false);
	tdiniego_alias3.defineColumn("protanno", typeof(int));
	tdiniego_alias3.defineColumn("protnumero", typeof(int));
	tdiniego_alias3.ExtendedProperties["TableForReading"]="diniego";
	tdiniego_alias3.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tdiniego_alias3);
	tdiniego_alias3.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// NULLAOSTA_ALIAS3 /////////////////////////////////
	var tnullaosta_alias3= new MetaTable("nullaosta_alias3");
	tnullaosta_alias3.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_alias3.defineColumn("cu", typeof(string),false);
	tnullaosta_alias3.defineColumn("data", typeof(DateTime),false);
	tnullaosta_alias3.defineColumn("extension", typeof(string));
	tnullaosta_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_alias3.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_alias3.defineColumn("idiscrizione", typeof(int));
	tnullaosta_alias3.defineColumn("idistanza", typeof(int),false);
	tnullaosta_alias3.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_alias3.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_alias3.defineColumn("idreg", typeof(int),false);
	tnullaosta_alias3.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_alias3.defineColumn("lu", typeof(string),false);
	tnullaosta_alias3.defineColumn("protanno", typeof(int));
	tnullaosta_alias3.defineColumn("protnumero", typeof(int));
	tnullaosta_alias3.ExtendedProperties["TableForReading"]="nullaosta";
	Tables.Add(tnullaosta_alias3);
	tnullaosta_alias3.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// NULLAOSTA_IMM_ALIAS3 /////////////////////////////////
	var tnullaosta_imm_alias3= new MetaTable("nullaosta_imm_alias3");
	tnullaosta_imm_alias3.defineColumn("annoimm", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_imm_alias3.defineColumn("cu", typeof(string),false);
	tnullaosta_imm_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprogcurr", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprogori", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idistanza", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idreg", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_imm_alias3.defineColumn("lu", typeof(string),false);
	tnullaosta_imm_alias3.defineColumn("parttime", typeof(string),false);
	tnullaosta_imm_alias3.ExtendedProperties["TableForReading"]="nullaosta_imm";
	Tables.Add(tnullaosta_imm_alias3);
	tnullaosta_imm_alias3.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// ISTANZADICHIAR_ALIAS2 /////////////////////////////////
	var tistanzadichiar_alias2= new MetaTable("istanzadichiar_alias2");
	tistanzadichiar_alias2.defineColumn("ct", typeof(DateTime),false);
	tistanzadichiar_alias2.defineColumn("cu", typeof(string),false);
	tistanzadichiar_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tistanzadichiar_alias2.defineColumn("iddichiar", typeof(int),false);
	tistanzadichiar_alias2.defineColumn("iddidprog", typeof(int),false);
	tistanzadichiar_alias2.defineColumn("idistanza", typeof(int),false);
	tistanzadichiar_alias2.defineColumn("idistanzakind", typeof(int),false);
	tistanzadichiar_alias2.defineColumn("idreg", typeof(int),false);
	tistanzadichiar_alias2.defineColumn("lt", typeof(DateTime),false);
	tistanzadichiar_alias2.defineColumn("lu", typeof(string),false);
	tistanzadichiar_alias2.ExtendedProperties["TableForReading"]="istanzadichiar";
	Tables.Add(tistanzadichiar_alias2);
	tistanzadichiar_alias2.defineKey("idcorsostudio", "iddichiar", "iddidprog", "idistanza", "idistanzakind", "idreg");

	//////////////////// ISTANZA_ALIAS7 /////////////////////////////////
	var tistanza_alias7= new MetaTable("istanza_alias7");
	tistanza_alias7.defineColumn("aa", typeof(string),false);
	tistanza_alias7.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias7.defineColumn("cu", typeof(string),false);
	tistanza_alias7.defineColumn("data", typeof(DateTime),false);
	tistanza_alias7.defineColumn("extension", typeof(string));
	tistanza_alias7.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias7.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias7.defineColumn("idiscrizione", typeof(int));
	tistanza_alias7.defineColumn("idistanza", typeof(int),false);
	tistanza_alias7.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias7.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias7.defineColumn("idstatuskind", typeof(int));
	tistanza_alias7.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias7.defineColumn("lu", typeof(string),false);
	tistanza_alias7.defineColumn("paridistanza", typeof(int),false);
	tistanza_alias7.defineColumn("protanno", typeof(int),false);
	tistanza_alias7.defineColumn("protnumero", typeof(int),false);
	tistanza_alias7.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias7);
	tistanza_alias7.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti", "paridistanza");

	//////////////////// STATUSKIND_ALIAS2 /////////////////////////////////
	var tstatuskind_alias2= new MetaTable("statuskind_alias2");
	tstatuskind_alias2.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias2.defineColumn("title", typeof(string),false);
	tstatuskind_alias2.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias2);
	tstatuskind_alias2.defineKey("idstatuskind");

	//////////////////// DIDPROG_ALIAS7 /////////////////////////////////
	var tdidprog_alias7= new MetaTable("didprog_alias7");
	tdidprog_alias7.defineColumn("aa", typeof(string),false);
	tdidprog_alias7.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias7.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias7.defineColumn("idsede", typeof(int));
	tdidprog_alias7.defineColumn("title", typeof(string));
	tdidprog_alias7.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias7);
	tdidprog_alias7.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO_ALIAS7 /////////////////////////////////
	var tannoaccademico_alias7= new MetaTable("annoaccademico_alias7");
	tannoaccademico_alias7.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias7.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias7);
	tannoaccademico_alias7.defineKey("aa");

	//////////////////// ISTANZA_ALIAS2 /////////////////////////////////
	var tistanza_alias2= new MetaTable("istanza_alias2");
	tistanza_alias2.defineColumn("aa", typeof(string),false);
	tistanza_alias2.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias2.defineColumn("cu", typeof(string),false);
	tistanza_alias2.defineColumn("data", typeof(DateTime),false);
	tistanza_alias2.defineColumn("extension", typeof(string));
	tistanza_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias2.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias2.defineColumn("idiscrizione", typeof(int));
	tistanza_alias2.defineColumn("idistanza", typeof(int),false);
	tistanza_alias2.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias2.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias2.defineColumn("idstatuskind", typeof(int));
	tistanza_alias2.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias2.defineColumn("lu", typeof(string),false);
	tistanza_alias2.defineColumn("paridistanza", typeof(int));
	tistanza_alias2.defineColumn("protanno", typeof(int),false);
	tistanza_alias2.defineColumn("protnumero", typeof(int),false);
	tistanza_alias2.defineColumn("!iddidprog_didprog_title", typeof(string));
	tistanza_alias2.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tistanza_alias2.defineColumn("!iddidprog_didprog_idsede_title", typeof(string));
	tistanza_alias2.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	tistanza_alias2.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias2);
	tistanza_alias2.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// DIDPROGORI_ALIAS2 /////////////////////////////////
	var tdidprogori_alias2= new MetaTable("didprogori_alias2");
	tdidprogori_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori_alias2.defineColumn("iddidprog", typeof(int),false);
	tdidprogori_alias2.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori_alias2.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori_alias2.defineColumn("title", typeof(string));
	tdidprogori_alias2.ExtendedProperties["TableForReading"]="didprogori";
	Tables.Add(tdidprogori_alias2);
	tdidprogori_alias2.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR_ALIAS2 /////////////////////////////////
	var tdidprogcurr_alias2= new MetaTable("didprogcurr_alias2");
	tdidprogcurr_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr_alias2.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr_alias2.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr_alias2.defineColumn("title", typeof(string));
	tdidprogcurr_alias2.ExtendedProperties["TableForReading"]="didprogcurr";
	Tables.Add(tdidprogcurr_alias2);
	tdidprogcurr_alias2.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// ISTANZA_IMM_ALIAS2 /////////////////////////////////
	var tistanza_imm_alias2= new MetaTable("istanza_imm_alias2");
	tistanza_imm_alias2.defineColumn("ct", typeof(DateTime),false);
	tistanza_imm_alias2.defineColumn("cu", typeof(string));
	tistanza_imm_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_imm_alias2.defineColumn("iddidprog", typeof(int),false);
	tistanza_imm_alias2.defineColumn("iddidprogcurr", typeof(int));
	tistanza_imm_alias2.defineColumn("iddidprogori", typeof(int));
	tistanza_imm_alias2.defineColumn("idistanza", typeof(int),false);
	tistanza_imm_alias2.defineColumn("idistanzakind", typeof(int),false);
	tistanza_imm_alias2.defineColumn("idreg", typeof(int),false);
	tistanza_imm_alias2.defineColumn("lt", typeof(DateTime),false);
	tistanza_imm_alias2.defineColumn("lu", typeof(string),false);
	tistanza_imm_alias2.defineColumn("motivrit", typeof(string));
	tistanza_imm_alias2.defineColumn("parttime", typeof(string));
	tistanza_imm_alias2.defineColumn("pre", typeof(string));
	tistanza_imm_alias2.defineColumn("!iddidprogcurr_didprogcurr_title", typeof(string));
	tistanza_imm_alias2.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tistanza_imm_alias2.ExtendedProperties["TableForReading"]="istanza_imm";
	Tables.Add(tistanza_imm_alias2);
	tistanza_imm_alias2.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg");

	//////////////////// DINIEGO_ALIAS1 /////////////////////////////////
	var tdiniego_alias1= new MetaTable("diniego_alias1");
	tdiniego_alias1.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("cu", typeof(string),false);
	tdiniego_alias1.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdiniego_alias1.defineColumn("iddidprog", typeof(int));
	tdiniego_alias1.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias1.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias1.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias1.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias1.defineColumn("idreg", typeof(int),false);
	tdiniego_alias1.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias1.defineColumn("lu", typeof(string),false);
	tdiniego_alias1.defineColumn("protanno", typeof(int));
	tdiniego_alias1.defineColumn("protnumero", typeof(int));
	tdiniego_alias1.ExtendedProperties["TableForReading"]="diniego";
	tdiniego_alias1.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tdiniego_alias1);
	tdiniego_alias1.defineKey("idcorsostudio", "iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// NULLAOSTA_ALIAS1 /////////////////////////////////
	var tnullaosta_alias1= new MetaTable("nullaosta_alias1");
	tnullaosta_alias1.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_alias1.defineColumn("cu", typeof(string),false);
	tnullaosta_alias1.defineColumn("data", typeof(DateTime),false);
	tnullaosta_alias1.defineColumn("extension", typeof(string));
	tnullaosta_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_alias1.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_alias1.defineColumn("idiscrizione", typeof(int));
	tnullaosta_alias1.defineColumn("idistanza", typeof(int),false);
	tnullaosta_alias1.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_alias1.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_alias1.defineColumn("idreg", typeof(int),false);
	tnullaosta_alias1.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_alias1.defineColumn("lu", typeof(string),false);
	tnullaosta_alias1.defineColumn("protanno", typeof(int));
	tnullaosta_alias1.defineColumn("protnumero", typeof(int));
	tnullaosta_alias1.ExtendedProperties["TableForReading"]="nullaosta";
	Tables.Add(tnullaosta_alias1);
	tnullaosta_alias1.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// NULLAOSTA_IMM_ALIAS1 /////////////////////////////////
	var tnullaosta_imm_alias1= new MetaTable("nullaosta_imm_alias1");
	tnullaosta_imm_alias1.defineColumn("annoimm", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_imm_alias1.defineColumn("cu", typeof(string),false);
	tnullaosta_imm_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("iddidprogori", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("idistanza", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("idreg", typeof(int),false);
	tnullaosta_imm_alias1.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_imm_alias1.defineColumn("lu", typeof(string),false);
	tnullaosta_imm_alias1.defineColumn("parttime", typeof(string),false);
	tnullaosta_imm_alias1.ExtendedProperties["TableForReading"]="nullaosta_imm";
	Tables.Add(tnullaosta_imm_alias1);
	tnullaosta_imm_alias1.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// ISTANZADICHIAR_ALIAS1 /////////////////////////////////
	var tistanzadichiar_alias1= new MetaTable("istanzadichiar_alias1");
	tistanzadichiar_alias1.defineColumn("ct", typeof(DateTime),false);
	tistanzadichiar_alias1.defineColumn("cu", typeof(string),false);
	tistanzadichiar_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tistanzadichiar_alias1.defineColumn("iddichiar", typeof(int),false);
	tistanzadichiar_alias1.defineColumn("iddidprog", typeof(int),false);
	tistanzadichiar_alias1.defineColumn("idistanza", typeof(int),false);
	tistanzadichiar_alias1.defineColumn("idistanzakind", typeof(int),false);
	tistanzadichiar_alias1.defineColumn("idreg", typeof(int),false);
	tistanzadichiar_alias1.defineColumn("lt", typeof(DateTime),false);
	tistanzadichiar_alias1.defineColumn("lu", typeof(string),false);
	tistanzadichiar_alias1.ExtendedProperties["TableForReading"]="istanzadichiar";
	Tables.Add(tistanzadichiar_alias1);
	tistanzadichiar_alias1.defineKey("idcorsostudio", "iddichiar", "iddidprog", "idistanza", "idistanzakind", "idreg");

	//////////////////// ISTANZA_ALIAS6 /////////////////////////////////
	var tistanza_alias6= new MetaTable("istanza_alias6");
	tistanza_alias6.defineColumn("aa", typeof(string),false);
	tistanza_alias6.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias6.defineColumn("cu", typeof(string),false);
	tistanza_alias6.defineColumn("data", typeof(DateTime),false);
	tistanza_alias6.defineColumn("extension", typeof(string));
	tistanza_alias6.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias6.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias6.defineColumn("idiscrizione", typeof(int));
	tistanza_alias6.defineColumn("idistanza", typeof(int),false);
	tistanza_alias6.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias6.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias6.defineColumn("idstatuskind", typeof(int));
	tistanza_alias6.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias6.defineColumn("lu", typeof(string),false);
	tistanza_alias6.defineColumn("paridistanza", typeof(int),false);
	tistanza_alias6.defineColumn("protanno", typeof(int),false);
	tistanza_alias6.defineColumn("protnumero", typeof(int),false);
	tistanza_alias6.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias6);
	tistanza_alias6.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti", "paridistanza");

	//////////////////// STATUSKIND_ALIAS1 /////////////////////////////////
	var tstatuskind_alias1= new MetaTable("statuskind_alias1");
	tstatuskind_alias1.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind_alias1.defineColumn("title", typeof(string),false);
	tstatuskind_alias1.ExtendedProperties["TableForReading"]="statuskind";
	Tables.Add(tstatuskind_alias1);
	tstatuskind_alias1.defineKey("idstatuskind");

	//////////////////// DIDPROG_ALIAS6 /////////////////////////////////
	var tdidprog_alias6= new MetaTable("didprog_alias6");
	tdidprog_alias6.defineColumn("aa", typeof(string),false);
	tdidprog_alias6.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias6.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias6.defineColumn("idsede", typeof(int));
	tdidprog_alias6.defineColumn("title", typeof(string));
	tdidprog_alias6.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias6);
	tdidprog_alias6.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO_ALIAS6 /////////////////////////////////
	var tannoaccademico_alias6= new MetaTable("annoaccademico_alias6");
	tannoaccademico_alias6.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias6.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias6);
	tannoaccademico_alias6.defineKey("aa");

	//////////////////// ISTANZA_ALIAS1 /////////////////////////////////
	var tistanza_alias1= new MetaTable("istanza_alias1");
	tistanza_alias1.defineColumn("aa", typeof(string),false);
	tistanza_alias1.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias1.defineColumn("cu", typeof(string),false);
	tistanza_alias1.defineColumn("data", typeof(DateTime),false);
	tistanza_alias1.defineColumn("extension", typeof(string));
	tistanza_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias1.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias1.defineColumn("idiscrizione", typeof(int));
	tistanza_alias1.defineColumn("idistanza", typeof(int),false);
	tistanza_alias1.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias1.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias1.defineColumn("idstatuskind", typeof(int));
	tistanza_alias1.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias1.defineColumn("lu", typeof(string),false);
	tistanza_alias1.defineColumn("paridistanza", typeof(int));
	tistanza_alias1.defineColumn("protanno", typeof(int),false);
	tistanza_alias1.defineColumn("protnumero", typeof(int),false);
	tistanza_alias1.defineColumn("!iddidprog_didprog_title", typeof(string));
	tistanza_alias1.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tistanza_alias1.defineColumn("!iddidprog_didprog_idsede_title", typeof(string));
	tistanza_alias1.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	tistanza_alias1.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias1);
	tistanza_alias1.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// DIDPROGORI_ALIAS1 /////////////////////////////////
	var tdidprogori_alias1= new MetaTable("didprogori_alias1");
	tdidprogori_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogori_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori_alias1.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori_alias1.defineColumn("title", typeof(string));
	tdidprogori_alias1.ExtendedProperties["TableForReading"]="didprogori";
	Tables.Add(tdidprogori_alias1);
	tdidprogori_alias1.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR_ALIAS1 /////////////////////////////////
	var tdidprogcurr_alias1= new MetaTable("didprogcurr_alias1");
	tdidprogcurr_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr_alias1.defineColumn("title", typeof(string));
	tdidprogcurr_alias1.ExtendedProperties["TableForReading"]="didprogcurr";
	Tables.Add(tdidprogcurr_alias1);
	tdidprogcurr_alias1.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// ISTANZA_IMM_ALIAS1 /////////////////////////////////
	var tistanza_imm_alias1= new MetaTable("istanza_imm_alias1");
	tistanza_imm_alias1.defineColumn("ct", typeof(DateTime),false);
	tistanza_imm_alias1.defineColumn("cu", typeof(string));
	tistanza_imm_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_imm_alias1.defineColumn("iddidprog", typeof(int),false);
	tistanza_imm_alias1.defineColumn("iddidprogcurr", typeof(int));
	tistanza_imm_alias1.defineColumn("iddidprogori", typeof(int));
	tistanza_imm_alias1.defineColumn("idistanza", typeof(int),false);
	tistanza_imm_alias1.defineColumn("idistanzakind", typeof(int),false);
	tistanza_imm_alias1.defineColumn("idreg", typeof(int),false);
	tistanza_imm_alias1.defineColumn("lt", typeof(DateTime),false);
	tistanza_imm_alias1.defineColumn("lu", typeof(string),false);
	tistanza_imm_alias1.defineColumn("motivrit", typeof(string));
	tistanza_imm_alias1.defineColumn("parttime", typeof(string));
	tistanza_imm_alias1.defineColumn("pre", typeof(string));
	tistanza_imm_alias1.defineColumn("!iddidprogcurr_didprogcurr_title", typeof(string));
	tistanza_imm_alias1.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	tistanza_imm_alias1.ExtendedProperties["TableForReading"]="istanza_imm";
	Tables.Add(tistanza_imm_alias1);
	tistanza_imm_alias1.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg");

	//////////////////// DINIEGO_ALIAS2 /////////////////////////////////
	var tdiniego_alias2= new MetaTable("diniego_alias2");
	tdiniego_alias2.defineColumn("ct", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("cu", typeof(string),false);
	tdiniego_alias2.defineColumn("data", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("idcorsostudio", typeof(int));
	tdiniego_alias2.defineColumn("iddidprog", typeof(int));
	tdiniego_alias2.defineColumn("iddiniego", typeof(int),false);
	tdiniego_alias2.defineColumn("idiscrizione", typeof(int));
	tdiniego_alias2.defineColumn("idistanza", typeof(int),false);
	tdiniego_alias2.defineColumn("idistanzakind", typeof(int),false);
	tdiniego_alias2.defineColumn("idreg", typeof(int),false);
	tdiniego_alias2.defineColumn("lt", typeof(DateTime),false);
	tdiniego_alias2.defineColumn("lu", typeof(string),false);
	tdiniego_alias2.defineColumn("protanno", typeof(int));
	tdiniego_alias2.defineColumn("protnumero", typeof(int));
	tdiniego_alias2.ExtendedProperties["TableForReading"]="diniego";
	tdiniego_alias2.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tdiniego_alias2);
	tdiniego_alias2.defineKey("iddiniego", "idistanza", "idistanzakind", "idreg");

	//////////////////// ISTANZADICHIAR /////////////////////////////////
	var tistanzadichiar= new MetaTable("istanzadichiar");
	tistanzadichiar.defineColumn("ct", typeof(DateTime),false);
	tistanzadichiar.defineColumn("cu", typeof(string),false);
	tistanzadichiar.defineColumn("idcorsostudio", typeof(int),false);
	tistanzadichiar.defineColumn("iddichiar", typeof(int),false);
	tistanzadichiar.defineColumn("iddidprog", typeof(int),false);
	tistanzadichiar.defineColumn("idistanza", typeof(int),false);
	tistanzadichiar.defineColumn("idistanzakind", typeof(int),false);
	tistanzadichiar.defineColumn("idreg", typeof(int),false);
	tistanzadichiar.defineColumn("lt", typeof(DateTime),false);
	tistanzadichiar.defineColumn("lu", typeof(string),false);
	Tables.Add(tistanzadichiar);
	tistanzadichiar.defineKey("idcorsostudio", "iddichiar", "iddidprog", "idistanza", "idistanzakind", "idreg");

	//////////////////// ISTANZA_ALIAS14 /////////////////////////////////
	var tistanza_alias14= new MetaTable("istanza_alias14");
	tistanza_alias14.defineColumn("aa", typeof(string),false);
	tistanza_alias14.defineColumn("ct", typeof(DateTime),false);
	tistanza_alias14.defineColumn("cu", typeof(string),false);
	tistanza_alias14.defineColumn("data", typeof(DateTime),false);
	tistanza_alias14.defineColumn("extension", typeof(string));
	tistanza_alias14.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_alias14.defineColumn("iddidprog", typeof(int),false);
	tistanza_alias14.defineColumn("idiscrizione", typeof(int));
	tistanza_alias14.defineColumn("idistanza", typeof(int),false);
	tistanza_alias14.defineColumn("idistanzakind", typeof(int),false);
	tistanza_alias14.defineColumn("idreg_studenti", typeof(int),false);
	tistanza_alias14.defineColumn("idstatuskind", typeof(int));
	tistanza_alias14.defineColumn("lt", typeof(DateTime),false);
	tistanza_alias14.defineColumn("lu", typeof(string),false);
	tistanza_alias14.defineColumn("paridistanza", typeof(int),false);
	tistanza_alias14.defineColumn("protanno", typeof(int),false);
	tistanza_alias14.defineColumn("protnumero", typeof(int),false);
	tistanza_alias14.ExtendedProperties["TableForReading"]="istanza";
	Tables.Add(tistanza_alias14);
	tistanza_alias14.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti", "paridistanza");

	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("ct", typeof(DateTime),false);
	tnullaosta.defineColumn("cu", typeof(string),false);
	tnullaosta.defineColumn("data", typeof(DateTime),false);
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta.defineColumn("iddidprog", typeof(int),false);
	tnullaosta.defineColumn("idiscrizione", typeof(int));
	tnullaosta.defineColumn("idistanza", typeof(int),false);
	tnullaosta.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta.defineColumn("idreg", typeof(int),false);
	tnullaosta.defineColumn("lt", typeof(DateTime),false);
	tnullaosta.defineColumn("lu", typeof(string),false);
	tnullaosta.defineColumn("protanno", typeof(int));
	tnullaosta.defineColumn("protnumero", typeof(int));
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// NULLAOSTA_IMM /////////////////////////////////
	var tnullaosta_imm= new MetaTable("nullaosta_imm");
	tnullaosta_imm.defineColumn("annoimm", typeof(int),false);
	tnullaosta_imm.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_imm.defineColumn("cu", typeof(string),false);
	tnullaosta_imm.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_imm.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_imm.defineColumn("iddidprogcurr", typeof(int),false);
	tnullaosta_imm.defineColumn("iddidprogori", typeof(int),false);
	tnullaosta_imm.defineColumn("idistanza", typeof(int),false);
	tnullaosta_imm.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_imm.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_imm.defineColumn("idreg", typeof(int),false);
	tnullaosta_imm.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_imm.defineColumn("lu", typeof(string),false);
	tnullaosta_imm.defineColumn("parttime", typeof(string),false);
	Tables.Add(tnullaosta_imm);
	tnullaosta_imm.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// STATUSKIND /////////////////////////////////
	var tstatuskind= new MetaTable("statuskind");
	tstatuskind.defineColumn("ct", typeof(DateTime),false);
	tstatuskind.defineColumn("cu", typeof(string),false);
	tstatuskind.defineColumn("delibera", typeof(string),false);
	tstatuskind.defineColumn("idstatuskind", typeof(int),false);
	tstatuskind.defineColumn("istanze", typeof(string),false);
	tstatuskind.defineColumn("istanzedelibera", typeof(string),false);
	tstatuskind.defineColumn("lt", typeof(DateTime),false);
	tstatuskind.defineColumn("lu", typeof(string),false);
	tstatuskind.defineColumn("pratica", typeof(string),false);
	tstatuskind.defineColumn("sortcode", typeof(int),false);
	tstatuskind.defineColumn("title", typeof(string),false);
	Tables.Add(tstatuskind);
	tstatuskind.defineKey("idstatuskind");

	//////////////////// DIDPROG_ALIAS5 /////////////////////////////////
	var tdidprog_alias5= new MetaTable("didprog_alias5");
	tdidprog_alias5.defineColumn("aa", typeof(string),false);
	tdidprog_alias5.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias5.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias5.defineColumn("idsede", typeof(int));
	tdidprog_alias5.defineColumn("title", typeof(string));
	tdidprog_alias5.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias5);
	tdidprog_alias5.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO_ALIAS5 /////////////////////////////////
	var tannoaccademico_alias5= new MetaTable("annoaccademico_alias5");
	tannoaccademico_alias5.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias5.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias5);
	tannoaccademico_alias5.defineKey("aa");

	//////////////////// ISTANZA /////////////////////////////////
	var tistanza= new MetaTable("istanza");
	tistanza.defineColumn("aa", typeof(string),false);
	tistanza.defineColumn("ct", typeof(DateTime),false);
	tistanza.defineColumn("cu", typeof(string),false);
	tistanza.defineColumn("data", typeof(DateTime),false);
	tistanza.defineColumn("extension", typeof(string));
	tistanza.defineColumn("idcorsostudio", typeof(int),false);
	tistanza.defineColumn("iddidprog", typeof(int),false);
	tistanza.defineColumn("idiscrizione", typeof(int));
	tistanza.defineColumn("idistanza", typeof(int),false);
	tistanza.defineColumn("idistanzakind", typeof(int),false);
	tistanza.defineColumn("idreg_studenti", typeof(int),false);
	tistanza.defineColumn("idstatuskind", typeof(int));
	tistanza.defineColumn("lt", typeof(DateTime),false);
	tistanza.defineColumn("lu", typeof(string),false);
	tistanza.defineColumn("paridistanza", typeof(int));
	tistanza.defineColumn("protanno", typeof(int),false);
	tistanza.defineColumn("protnumero", typeof(int),false);
	tistanza.defineColumn("!iddidprog_didprog_title", typeof(string));
	tistanza.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tistanza.defineColumn("!iddidprog_didprog_idsede_title", typeof(string));
	tistanza.defineColumn("!idstatuskind_statuskind_title", typeof(string));
	Tables.Add(tistanza);
	tistanza.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg_studenti");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// ISTANZA_IMM /////////////////////////////////
	var tistanza_imm= new MetaTable("istanza_imm");
	tistanza_imm.defineColumn("ct", typeof(DateTime),false);
	tistanza_imm.defineColumn("cu", typeof(string));
	tistanza_imm.defineColumn("idcorsostudio", typeof(int),false);
	tistanza_imm.defineColumn("iddidprog", typeof(int),false);
	tistanza_imm.defineColumn("iddidprogcurr", typeof(int));
	tistanza_imm.defineColumn("iddidprogori", typeof(int));
	tistanza_imm.defineColumn("idistanza", typeof(int),false);
	tistanza_imm.defineColumn("idistanzakind", typeof(int),false);
	tistanza_imm.defineColumn("idreg", typeof(int),false);
	tistanza_imm.defineColumn("lt", typeof(DateTime),false);
	tistanza_imm.defineColumn("lu", typeof(string),false);
	tistanza_imm.defineColumn("motivrit", typeof(string));
	tistanza_imm.defineColumn("parttime", typeof(string));
	tistanza_imm.defineColumn("pre", typeof(string));
	tistanza_imm.defineColumn("!iddidprogcurr_didprogcurr_title", typeof(string));
	tistanza_imm.defineColumn("!iddidprogori_didprogori_title", typeof(string));
	Tables.Add(tistanza_imm);
	tistanza_imm.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idreg");

	//////////////////// SOSTENIMENTO_ALIAS1 /////////////////////////////////
	var tsostenimento_alias1= new MetaTable("sostenimento_alias1");
	tsostenimento_alias1.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("cu", typeof(string),false);
	tsostenimento_alias1.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("domande", typeof(string));
	tsostenimento_alias1.defineColumn("ects", typeof(int));
	tsostenimento_alias1.defineColumn("giudizio", typeof(string));
	tsostenimento_alias1.defineColumn("idappello", typeof(int));
	tsostenimento_alias1.defineColumn("idattivform", typeof(int));
	tsostenimento_alias1.defineColumn("idcorsostudio", typeof(int));
	tsostenimento_alias1.defineColumn("iddidprog", typeof(int));
	tsostenimento_alias1.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias1.defineColumn("idprova", typeof(int));
	tsostenimento_alias1.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias1.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias1.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias1.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias1.defineColumn("insecod", typeof(string));
	tsostenimento_alias1.defineColumn("insedesc", typeof(string));
	tsostenimento_alias1.defineColumn("livello", typeof(string));
	tsostenimento_alias1.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias1.defineColumn("lu", typeof(string),false);
	tsostenimento_alias1.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias1.defineColumn("protanno", typeof(int));
	tsostenimento_alias1.defineColumn("protnumero", typeof(int));
	tsostenimento_alias1.defineColumn("voto", typeof(decimal));
	tsostenimento_alias1.defineColumn("votolode", typeof(string));
	tsostenimento_alias1.defineColumn("votosu", typeof(int));
	tsostenimento_alias1.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias1);
	tsostenimento_alias1.defineKey("idiscrizione", "idreg", "idsostenimento");

	//////////////////// PIANOSTUDIOATTIVFORM_ALIAS1 /////////////////////////////////
	var tpianostudioattivform_alias1= new MetaTable("pianostudioattivform_alias1");
	tpianostudioattivform_alias1.defineColumn("anno", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("ct", typeof(DateTime),false);
	tpianostudioattivform_alias1.defineColumn("cu", typeof(string),false);
	tpianostudioattivform_alias1.defineColumn("idattivform", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idattivform_scelta", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idcorsostudio", typeof(int));
	tpianostudioattivform_alias1.defineColumn("iddidprog", typeof(int));
	tpianostudioattivform_alias1.defineColumn("idiscrizione", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudioattivform_alias1.defineColumn("idpianostudio", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idpianostudioattivform", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idreg", typeof(int),false);
	tpianostudioattivform_alias1.defineColumn("idsostenimento", typeof(int));
	tpianostudioattivform_alias1.defineColumn("lt", typeof(DateTime),false);
	tpianostudioattivform_alias1.defineColumn("lu", typeof(string),false);
	tpianostudioattivform_alias1.ExtendedProperties["TableForReading"]="pianostudioattivform";
	Tables.Add(tpianostudioattivform_alias1);
	tpianostudioattivform_alias1.defineKey("idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PIANOSTUDIO_ALIAS1 /////////////////////////////////
	var tpianostudio_alias1= new MetaTable("pianostudio_alias1");
	tpianostudio_alias1.defineColumn("aa", typeof(string));
	tpianostudio_alias1.defineColumn("ct", typeof(DateTime),false);
	tpianostudio_alias1.defineColumn("cu", typeof(string),false);
	tpianostudio_alias1.defineColumn("idcorsostudio", typeof(int));
	tpianostudio_alias1.defineColumn("iddidprog", typeof(int));
	tpianostudio_alias1.defineColumn("idiscrizione", typeof(int),false);
	tpianostudio_alias1.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudio_alias1.defineColumn("idpianostudio", typeof(int),false);
	tpianostudio_alias1.defineColumn("idpianostudiostatus", typeof(int));
	tpianostudio_alias1.defineColumn("idreg", typeof(int),false);
	tpianostudio_alias1.defineColumn("lt", typeof(DateTime),false);
	tpianostudio_alias1.defineColumn("lu", typeof(string),false);
	tpianostudio_alias1.ExtendedProperties["TableForReading"]="pianostudio";
	Tables.Add(tpianostudio_alias1);
	tpianostudio_alias1.defineKey("idiscrizione", "idpianostudio", "idreg");

	//////////////////// ANNOACCADEMICO_ALIAS4 /////////////////////////////////
	var tannoaccademico_alias4= new MetaTable("annoaccademico_alias4");
	tannoaccademico_alias4.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias4.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias4);
	tannoaccademico_alias4.defineKey("aa");

	//////////////////// ISCRIZIONE_ALIAS4 /////////////////////////////////
	var tiscrizione_alias4= new MetaTable("iscrizione_alias4");
	tiscrizione_alias4.defineColumn("aa", typeof(string),false);
	tiscrizione_alias4.defineColumn("anno", typeof(int));
	tiscrizione_alias4.defineColumn("ct", typeof(DateTime),false);
	tiscrizione_alias4.defineColumn("cu", typeof(string),false);
	tiscrizione_alias4.defineColumn("data", typeof(DateTime));
	tiscrizione_alias4.defineColumn("idcorsostudio", typeof(int));
	tiscrizione_alias4.defineColumn("iddidprog", typeof(int));
	tiscrizione_alias4.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione_alias4.defineColumn("idreg", typeof(int),false);
	tiscrizione_alias4.defineColumn("lt", typeof(DateTime),false);
	tiscrizione_alias4.defineColumn("lu", typeof(string),false);
	tiscrizione_alias4.defineColumn("matricola", typeof(string));
	tiscrizione_alias4.ExtendedProperties["TableForReading"]="iscrizione";
	Tables.Add(tiscrizione_alias4);
	tiscrizione_alias4.defineKey("idiscrizione", "idreg");

	//////////////////// SOSTENIMENTO_ALIAS4 /////////////////////////////////
	var tsostenimento_alias4= new MetaTable("sostenimento_alias4");
	tsostenimento_alias4.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias4.defineColumn("cu", typeof(string),false);
	tsostenimento_alias4.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias4.defineColumn("domande", typeof(string));
	tsostenimento_alias4.defineColumn("ects", typeof(int));
	tsostenimento_alias4.defineColumn("giudizio", typeof(string));
	tsostenimento_alias4.defineColumn("idappello", typeof(int));
	tsostenimento_alias4.defineColumn("idattivform", typeof(int));
	tsostenimento_alias4.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento_alias4.defineColumn("iddidprog", typeof(int),false);
	tsostenimento_alias4.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias4.defineColumn("idprova", typeof(int),false);
	tsostenimento_alias4.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias4.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias4.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias4.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias4.defineColumn("insecod", typeof(string));
	tsostenimento_alias4.defineColumn("insedesc", typeof(string));
	tsostenimento_alias4.defineColumn("livello", typeof(string));
	tsostenimento_alias4.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias4.defineColumn("lu", typeof(string),false);
	tsostenimento_alias4.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias4.defineColumn("protanno", typeof(int));
	tsostenimento_alias4.defineColumn("protnumero", typeof(int));
	tsostenimento_alias4.defineColumn("voto", typeof(decimal));
	tsostenimento_alias4.defineColumn("votolode", typeof(string));
	tsostenimento_alias4.defineColumn("votosu", typeof(int));
	tsostenimento_alias4.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias4);
	tsostenimento_alias4.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idprova", "idreg", "idsostenimento");

	//////////////////// DIDPROG_ALIAS4 /////////////////////////////////
	var tdidprog_alias4= new MetaTable("didprog_alias4");
	tdidprog_alias4.defineColumn("aa", typeof(string));
	tdidprog_alias4.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias4.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias4.defineColumn("title", typeof(string));
	tdidprog_alias4.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias4);
	tdidprog_alias4.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO_ALIAS3 /////////////////////////////////
	var tannoaccademico_alias3= new MetaTable("annoaccademico_alias3");
	tannoaccademico_alias3.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias3.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias3);
	tannoaccademico_alias3.defineKey("aa");

	//////////////////// ISCRIZIONE_ALIAS3 /////////////////////////////////
	var tiscrizione_alias3= new MetaTable("iscrizione_alias3");
	tiscrizione_alias3.defineColumn("aa", typeof(string),false);
	tiscrizione_alias3.defineColumn("anno", typeof(int));
	tiscrizione_alias3.defineColumn("ct", typeof(DateTime),false);
	tiscrizione_alias3.defineColumn("cu", typeof(string),false);
	tiscrizione_alias3.defineColumn("data", typeof(DateTime));
	tiscrizione_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione_alias3.defineColumn("iddidprog", typeof(int),false);
	tiscrizione_alias3.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione_alias3.defineColumn("idreg", typeof(int),false);
	tiscrizione_alias3.defineColumn("lt", typeof(DateTime),false);
	tiscrizione_alias3.defineColumn("lu", typeof(string),false);
	tiscrizione_alias3.defineColumn("matricola", typeof(string));
	tiscrizione_alias3.defineColumn("!iddidprog_didprog_title", typeof(string));
	tiscrizione_alias3.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tiscrizione_alias3.ExtendedProperties["TableForReading"]="iscrizione";
	Tables.Add(tiscrizione_alias3);
	tiscrizione_alias3.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// SOSTENIMENTO_ALIAS3 /////////////////////////////////
	var tsostenimento_alias3= new MetaTable("sostenimento_alias3");
	tsostenimento_alias3.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias3.defineColumn("cu", typeof(string),false);
	tsostenimento_alias3.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias3.defineColumn("domande", typeof(string));
	tsostenimento_alias3.defineColumn("ects", typeof(int));
	tsostenimento_alias3.defineColumn("giudizio", typeof(string));
	tsostenimento_alias3.defineColumn("idappello", typeof(int));
	tsostenimento_alias3.defineColumn("idattivform", typeof(int));
	tsostenimento_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento_alias3.defineColumn("iddidprog", typeof(int),false);
	tsostenimento_alias3.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias3.defineColumn("idprova", typeof(int),false);
	tsostenimento_alias3.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias3.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias3.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias3.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias3.defineColumn("insecod", typeof(string));
	tsostenimento_alias3.defineColumn("insedesc", typeof(string));
	tsostenimento_alias3.defineColumn("livello", typeof(string));
	tsostenimento_alias3.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias3.defineColumn("lu", typeof(string),false);
	tsostenimento_alias3.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias3.defineColumn("protanno", typeof(int));
	tsostenimento_alias3.defineColumn("protnumero", typeof(int));
	tsostenimento_alias3.defineColumn("voto", typeof(decimal));
	tsostenimento_alias3.defineColumn("votolode", typeof(string));
	tsostenimento_alias3.defineColumn("votosu", typeof(int));
	tsostenimento_alias3.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias3);
	tsostenimento_alias3.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idprova", "idreg", "idsostenimento");

	//////////////////// DIDPROG_ALIAS3 /////////////////////////////////
	var tdidprog_alias3= new MetaTable("didprog_alias3");
	tdidprog_alias3.defineColumn("aa", typeof(string));
	tdidprog_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias3.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias3.defineColumn("title", typeof(string));
	tdidprog_alias3.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias3);
	tdidprog_alias3.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO_ALIAS2 /////////////////////////////////
	var tannoaccademico_alias2= new MetaTable("annoaccademico_alias2");
	tannoaccademico_alias2.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias2.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias2);
	tannoaccademico_alias2.defineKey("aa");

	//////////////////// ISCRIZIONE_ALIAS2 /////////////////////////////////
	var tiscrizione_alias2= new MetaTable("iscrizione_alias2");
	tiscrizione_alias2.defineColumn("aa", typeof(string),false);
	tiscrizione_alias2.defineColumn("anno", typeof(int));
	tiscrizione_alias2.defineColumn("ct", typeof(DateTime),false);
	tiscrizione_alias2.defineColumn("cu", typeof(string),false);
	tiscrizione_alias2.defineColumn("data", typeof(DateTime));
	tiscrizione_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione_alias2.defineColumn("iddidprog", typeof(int),false);
	tiscrizione_alias2.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione_alias2.defineColumn("idreg", typeof(int),false);
	tiscrizione_alias2.defineColumn("lt", typeof(DateTime),false);
	tiscrizione_alias2.defineColumn("lu", typeof(string),false);
	tiscrizione_alias2.defineColumn("matricola", typeof(string));
	tiscrizione_alias2.defineColumn("!iddidprog_didprog_title", typeof(string));
	tiscrizione_alias2.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tiscrizione_alias2.ExtendedProperties["TableForReading"]="iscrizione";
	Tables.Add(tiscrizione_alias2);
	tiscrizione_alias2.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// SOSTENIMENTO_ALIAS2 /////////////////////////////////
	var tsostenimento_alias2= new MetaTable("sostenimento_alias2");
	tsostenimento_alias2.defineColumn("ct", typeof(DateTime),false);
	tsostenimento_alias2.defineColumn("cu", typeof(string),false);
	tsostenimento_alias2.defineColumn("data", typeof(DateTime),false);
	tsostenimento_alias2.defineColumn("domande", typeof(string));
	tsostenimento_alias2.defineColumn("ects", typeof(int));
	tsostenimento_alias2.defineColumn("giudizio", typeof(string));
	tsostenimento_alias2.defineColumn("idappello", typeof(int));
	tsostenimento_alias2.defineColumn("idattivform", typeof(int));
	tsostenimento_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento_alias2.defineColumn("iddidprog", typeof(int),false);
	tsostenimento_alias2.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento_alias2.defineColumn("idprova", typeof(int),false);
	tsostenimento_alias2.defineColumn("idreg", typeof(int),false);
	tsostenimento_alias2.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento_alias2.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento_alias2.defineColumn("idtitolostudio", typeof(int));
	tsostenimento_alias2.defineColumn("insecod", typeof(string));
	tsostenimento_alias2.defineColumn("insedesc", typeof(string));
	tsostenimento_alias2.defineColumn("livello", typeof(string));
	tsostenimento_alias2.defineColumn("lt", typeof(DateTime),false);
	tsostenimento_alias2.defineColumn("lu", typeof(string),false);
	tsostenimento_alias2.defineColumn("paridsostenimento", typeof(int));
	tsostenimento_alias2.defineColumn("protanno", typeof(int));
	tsostenimento_alias2.defineColumn("protnumero", typeof(int));
	tsostenimento_alias2.defineColumn("voto", typeof(decimal));
	tsostenimento_alias2.defineColumn("votolode", typeof(string));
	tsostenimento_alias2.defineColumn("votosu", typeof(int));
	tsostenimento_alias2.ExtendedProperties["TableForReading"]="sostenimento";
	Tables.Add(tsostenimento_alias2);
	tsostenimento_alias2.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idprova", "idreg", "idsostenimento");

	//////////////////// DIDPROG_ALIAS2 /////////////////////////////////
	var tdidprog_alias2= new MetaTable("didprog_alias2");
	tdidprog_alias2.defineColumn("aa", typeof(string));
	tdidprog_alias2.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog_alias2.defineColumn("iddidprog", typeof(int),false);
	tdidprog_alias2.defineColumn("title", typeof(string));
	tdidprog_alias2.ExtendedProperties["TableForReading"]="didprog";
	Tables.Add(tdidprog_alias2);
	tdidprog_alias2.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// ISCRIZIONE_ALIAS1 /////////////////////////////////
	var tiscrizione_alias1= new MetaTable("iscrizione_alias1");
	tiscrizione_alias1.defineColumn("aa", typeof(string),false);
	tiscrizione_alias1.defineColumn("anno", typeof(int));
	tiscrizione_alias1.defineColumn("ct", typeof(DateTime),false);
	tiscrizione_alias1.defineColumn("cu", typeof(string),false);
	tiscrizione_alias1.defineColumn("data", typeof(DateTime));
	tiscrizione_alias1.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione_alias1.defineColumn("iddidprog", typeof(int),false);
	tiscrizione_alias1.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione_alias1.defineColumn("idreg", typeof(int),false);
	tiscrizione_alias1.defineColumn("lt", typeof(DateTime),false);
	tiscrizione_alias1.defineColumn("lu", typeof(string),false);
	tiscrizione_alias1.defineColumn("matricola", typeof(string));
	tiscrizione_alias1.defineColumn("!iddidprog_didprog_title", typeof(string));
	tiscrizione_alias1.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tiscrizione_alias1.ExtendedProperties["TableForReading"]="iscrizione";
	Tables.Add(tiscrizione_alias1);
	tiscrizione_alias1.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// DECADENZA /////////////////////////////////
	var tdecadenza= new MetaTable("decadenza");
	tdecadenza.defineColumn("aa", typeof(string),false);
	tdecadenza.defineColumn("ct", typeof(DateTime),false);
	tdecadenza.defineColumn("cu", typeof(string),false);
	tdecadenza.defineColumn("data", typeof(DateTime),false);
	tdecadenza.defineColumn("iddecadenza", typeof(int),false);
	tdecadenza.defineColumn("idiscrizione", typeof(int),false);
	tdecadenza.defineColumn("idreg_studenti", typeof(int),false);
	tdecadenza.defineColumn("lt", typeof(DateTime),false);
	tdecadenza.defineColumn("lu", typeof(string),false);
	tdecadenza.defineColumn("protanno", typeof(int),false);
	tdecadenza.defineColumn("protnumero", typeof(int),false);
	tdecadenza.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tdecadenza);
	tdecadenza.defineKey("iddecadenza", "idiscrizione", "idreg_studenti");

	//////////////////// ISCRIZIONEANNO /////////////////////////////////
	var tiscrizioneanno= new MetaTable("iscrizioneanno");
	tiscrizioneanno.defineColumn("aa", typeof(string),false);
	tiscrizioneanno.defineColumn("anno", typeof(int),false);
	tiscrizioneanno.defineColumn("annofc", typeof(int));
	tiscrizioneanno.defineColumn("ct", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("cu", typeof(string),false);
	tiscrizioneanno.defineColumn("data", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprog", typeof(int),false);
	tiscrizioneanno.defineColumn("iddidprogori", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizione", typeof(int),false);
	tiscrizioneanno.defineColumn("idiscrizioneanno", typeof(int),false);
	tiscrizioneanno.defineColumn("idreg", typeof(int),false);
	tiscrizioneanno.defineColumn("lt", typeof(DateTime),false);
	tiscrizioneanno.defineColumn("lu", typeof(string),false);
	tiscrizioneanno.defineColumn("protanno", typeof(int));
	tiscrizioneanno.defineColumn("protnumero", typeof(int));
	Tables.Add(tiscrizioneanno);
	tiscrizioneanno.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idiscrizioneanno", "idreg");

	//////////////////// SOSTENIMENTO /////////////////////////////////
	var tsostenimento= new MetaTable("sostenimento");
	tsostenimento.defineColumn("ct", typeof(DateTime),false);
	tsostenimento.defineColumn("cu", typeof(string),false);
	tsostenimento.defineColumn("data", typeof(DateTime),false);
	tsostenimento.defineColumn("domande", typeof(string));
	tsostenimento.defineColumn("ects", typeof(int));
	tsostenimento.defineColumn("giudizio", typeof(string));
	tsostenimento.defineColumn("idappello", typeof(int));
	tsostenimento.defineColumn("idattivform", typeof(int));
	tsostenimento.defineColumn("idcorsostudio", typeof(int),false);
	tsostenimento.defineColumn("iddidprog", typeof(int),false);
	tsostenimento.defineColumn("idiscrizione", typeof(int),false);
	tsostenimento.defineColumn("idprova", typeof(int));
	tsostenimento.defineColumn("idreg", typeof(int),false);
	tsostenimento.defineColumn("idsostenimento", typeof(int),false);
	tsostenimento.defineColumn("idsostenimentoesito", typeof(int),false);
	tsostenimento.defineColumn("idtitolostudio", typeof(int));
	tsostenimento.defineColumn("insecod", typeof(string));
	tsostenimento.defineColumn("insedesc", typeof(string));
	tsostenimento.defineColumn("livello", typeof(string));
	tsostenimento.defineColumn("lt", typeof(DateTime),false);
	tsostenimento.defineColumn("lu", typeof(string),false);
	tsostenimento.defineColumn("paridsostenimento", typeof(int));
	tsostenimento.defineColumn("protanno", typeof(int));
	tsostenimento.defineColumn("protnumero", typeof(int));
	tsostenimento.defineColumn("voto", typeof(decimal));
	tsostenimento.defineColumn("votolode", typeof(string));
	tsostenimento.defineColumn("votosu", typeof(int));
	Tables.Add(tsostenimento);
	tsostenimento.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg", "idsostenimento");

	//////////////////// PIANOSTUDIOATTIVFORM /////////////////////////////////
	var tpianostudioattivform= new MetaTable("pianostudioattivform");
	tpianostudioattivform.defineColumn("anno", typeof(int),false);
	tpianostudioattivform.defineColumn("ct", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("cu", typeof(string),false);
	tpianostudioattivform.defineColumn("idattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idattivform_scelta", typeof(int),false);
	tpianostudioattivform.defineColumn("idcorsostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("iddidprog", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizione", typeof(int),false);
	tpianostudioattivform.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudioattivform.defineColumn("idpianostudio", typeof(int),false);
	tpianostudioattivform.defineColumn("idpianostudioattivform", typeof(int),false);
	tpianostudioattivform.defineColumn("idreg", typeof(int),false);
	tpianostudioattivform.defineColumn("idsostenimento", typeof(int));
	tpianostudioattivform.defineColumn("lt", typeof(DateTime),false);
	tpianostudioattivform.defineColumn("lu", typeof(string),false);
	Tables.Add(tpianostudioattivform);
	tpianostudioattivform.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PIANOSTUDIO /////////////////////////////////
	var tpianostudio= new MetaTable("pianostudio");
	tpianostudio.defineColumn("aa", typeof(string));
	tpianostudio.defineColumn("ct", typeof(DateTime),false);
	tpianostudio.defineColumn("cu", typeof(string),false);
	tpianostudio.defineColumn("idcorsostudio", typeof(int));
	tpianostudio.defineColumn("iddidprog", typeof(int));
	tpianostudio.defineColumn("idiscrizione", typeof(int),false);
	tpianostudio.defineColumn("idiscrizionebmi", typeof(int));
	tpianostudio.defineColumn("idpianostudio", typeof(int),false);
	tpianostudio.defineColumn("idpianostudiostatus", typeof(int));
	tpianostudio.defineColumn("idreg", typeof(int),false);
	tpianostudio.defineColumn("lt", typeof(DateTime),false);
	tpianostudio.defineColumn("lu", typeof(string),false);
	tpianostudio.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tpianostudio);
	tpianostudio.defineKey("idiscrizione", "idpianostudio", "idreg");

	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISCRIZIONE /////////////////////////////////
	var tiscrizione= new MetaTable("iscrizione");
	tiscrizione.defineColumn("aa", typeof(string),false);
	tiscrizione.defineColumn("anno", typeof(int));
	tiscrizione.defineColumn("ct", typeof(DateTime),false);
	tiscrizione.defineColumn("cu", typeof(string),false);
	tiscrizione.defineColumn("data", typeof(DateTime));
	tiscrizione.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizione.defineColumn("iddidprog", typeof(int),false);
	tiscrizione.defineColumn("idiscrizione", typeof(int),false);
	tiscrizione.defineColumn("idreg", typeof(int),false);
	tiscrizione.defineColumn("lt", typeof(DateTime),false);
	tiscrizione.defineColumn("lu", typeof(string),false);
	tiscrizione.defineColumn("matricola", typeof(string));
	tiscrizione.defineColumn("!iddidprog_didprog_title", typeof(string));
	tiscrizione.defineColumn("!iddidprog_didprog_aa", typeof(string));
	tiscrizione.defineColumn("!iddidprog_didprog_idsede_title", typeof(string));
	Tables.Add(tiscrizione);
	tiscrizione.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

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

	//////////////////// STUDPRENOTKINDDEFAULTVIEW /////////////////////////////////
	var tstudprenotkinddefaultview= new MetaTable("studprenotkinddefaultview");
	tstudprenotkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstudprenotkinddefaultview.defineColumn("idstudprenotkind", typeof(int),false);
	tstudprenotkinddefaultview.defineColumn("studprenotkind_active", typeof(string));
	Tables.Add(tstudprenotkinddefaultview);
	tstudprenotkinddefaultview.defineKey("idstudprenotkind");

	//////////////////// STUDDIRITTOKINDDEFAULTVIEW /////////////////////////////////
	var tstuddirittokinddefaultview= new MetaTable("studdirittokinddefaultview");
	tstuddirittokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstuddirittokinddefaultview.defineColumn("idstuddirittokind", typeof(int),false);
	tstuddirittokinddefaultview.defineColumn("studdirittokind_active", typeof(string));
	Tables.Add(tstuddirittokinddefaultview);
	tstuddirittokinddefaultview.defineKey("idstuddirittokind");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new MetaTable("maritalstatus");
	tmaritalstatus.defineColumn("active", typeof(string));
	tmaritalstatus.defineColumn("description", typeof(string),false);
	tmaritalstatus.defineColumn("idmaritalstatus", typeof(string),false);
	Tables.Add(tmaritalstatus);
	tmaritalstatus.defineKey("idmaritalstatus");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("active", typeof(string));
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("idresidence", typeof(int),false);
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRYCLASSPERSONEVIEW /////////////////////////////////
	var tregistryclasspersoneview= new MetaTable("registryclasspersoneview");
	tregistryclasspersoneview.defineColumn("dropdown_title", typeof(string),false);
	tregistryclasspersoneview.defineColumn("idregistryclass", typeof(string),false);
	tregistryclasspersoneview.defineColumn("registryclass_active", typeof(string));
	Tables.Add(tregistryclasspersoneview);
	tregistryclasspersoneview.defineKey("idregistryclass");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
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
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int),false);
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int),false);
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
	tregistry.defineColumn("surname", typeof(string),false);
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

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{titolostudio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_titolostudio_registry_idreg",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{titolostudio.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_titolostudio_registry_alias1_idreg_istituti",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{registry_istituti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_istituti_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{istattitolistudio.Columns["idistattitolistudio"]};
	cChild = new []{titolostudio.Columns["idistattitolistudio"]};
	Relations.Add(new DataRelation("FK_titolostudio_istattitolistudio_idistattitolistudio",cPar,cChild,false));

	cPar = new []{annoaccademico_alias9.Columns["aa"]};
	cChild = new []{titolostudio.Columns["aa"]};
	Relations.Add(new DataRelation("FK_titolostudio_annoaccademico_alias9_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry_idreg",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryaddress_registry_idreg",cPar,cChild,false));

	cPar = new []{geo_nation_alias5.Columns["idnation"]};
	cChild = new []{registryaddress.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_nation_alias5_idnation",cPar,cChild,false));

	cPar = new []{geo_city_alias5.Columns["idcity"]};
	cChild = new []{registryaddress.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registryaddress_geo_city_alias5_idcity",cPar,cChild,false));

	cPar = new []{address.Columns["idaddress"]};
	cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("FK_registryaddress_address_idaddresskind",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{istanza_alias3.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias3_registry_idreg",cPar,cChild,false));

	cPar = new []{istanza_alias3.Columns["idcorsostudio"], istanza_alias3.Columns["iddidprog"], istanza_alias3.Columns["idiscrizione"], istanza_alias3.Columns["idistanza"], istanza_alias3.Columns["idistanzakind"], istanza_alias3.Columns["idreg_studenti"]};
	cChild = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idiscrizione"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_pas_istanza_alias3_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idiscrizione"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	cChild = new []{nullaosta_alias3.Columns["idcorsostudio"], nullaosta_alias3.Columns["iddidprog"], nullaosta_alias3.Columns["idiscrizione"], nullaosta_alias3.Columns["idistanza"], nullaosta_alias3.Columns["idistanzakind"], nullaosta_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_alias3_istanza_pas_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idiscrizione"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	cChild = new []{diniego_alias4.Columns["idcorsostudio"], diniego_alias4.Columns["iddidprog"], diniego_alias4.Columns["idiscrizione"], diniego_alias4.Columns["idistanza"], diniego_alias4.Columns["idistanzakind"], diniego_alias4.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias4_istanza_pas_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_pas.Columns["idcorsostudio"], istanza_pas.Columns["iddidprog"], istanza_pas.Columns["idiscrizione"], istanza_pas.Columns["idistanza"], istanza_pas.Columns["idistanzakind"], istanza_pas.Columns["idreg"]};
	cChild = new []{pratica.Columns["idcorsostudio"], pratica.Columns["iddidprog"], pratica.Columns["idiscrizione"], pratica.Columns["idistanza"], pratica.Columns["idistanzakind"], pratica.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pratica_istanza_pas_idcorsostudio-iddidprog-idiscrizione-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{iscrizione_alias6.Columns["idiscrizione"]};
	cChild = new []{istanza_pas.Columns["idiscrizione_from"]};
	Relations.Add(new DataRelation("FK_istanza_pas_iscrizione_alias6_idiscrizione_from",cPar,cChild,false));

	cPar = new []{didprog_alias8.Columns["iddidprog"]};
	cChild = new []{iscrizione_alias6.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias6_didprog_alias8_iddidprog",cPar,cChild,false));

	cPar = new []{importcontrattistipendiview.Columns["anno"]};
	cChild = new []{iscrizione_alias6.Columns["anno"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias6_importcontrattistipendiview_anno",cPar,cChild,false));

	cPar = new []{statuskind_alias3.Columns["idstatuskind"]};
	cChild = new []{istanza_alias3.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_alias3_statuskind_alias3_idstatuskind",cPar,cChild,false));

	cPar = new []{annoaccademico_alias8.Columns["aa"]};
	cChild = new []{istanza_alias3.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_alias3_annoaccademico_alias8_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{istanza_alias2.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias2_registry_idreg",cPar,cChild,false));

	cPar = new []{istanza_alias2.Columns["idcorsostudio"], istanza_alias2.Columns["iddidprog"], istanza_alias2.Columns["idistanza"], istanza_alias2.Columns["idistanzakind"], istanza_alias2.Columns["idreg_studenti"]};
	cChild = new []{istanza_imm_alias2.Columns["idcorsostudio"], istanza_imm_alias2.Columns["iddidprog"], istanza_imm_alias2.Columns["idistanza"], istanza_imm_alias2.Columns["idistanzakind"], istanza_imm_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias2_istanza_alias2_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias2.Columns["idcorsostudio"], istanza_imm_alias2.Columns["iddidprog"], istanza_imm_alias2.Columns["idistanza"], istanza_imm_alias2.Columns["idistanzakind"], istanza_imm_alias2.Columns["idreg"]};
	cChild = new []{diniego_alias3.Columns["idcorsostudio"], diniego_alias3.Columns["iddidprog"], diniego_alias3.Columns["idistanza"], diniego_alias3.Columns["idistanzakind"], diniego_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias3_istanza_imm_alias2_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias2.Columns["idcorsostudio"], istanza_imm_alias2.Columns["iddidprog"], istanza_imm_alias2.Columns["idistanza"], istanza_imm_alias2.Columns["idistanzakind"], istanza_imm_alias2.Columns["idreg"]};
	cChild = new []{nullaosta_alias3.Columns["idcorsostudio"], nullaosta_alias3.Columns["iddidprog"], nullaosta_alias3.Columns["idistanza"], nullaosta_alias3.Columns["idistanzakind"], nullaosta_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_alias3_istanza_imm_alias2_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{nullaosta_alias3.Columns["idcorsostudio"], nullaosta_alias3.Columns["iddidprog"], nullaosta_alias3.Columns["idistanza"], nullaosta_alias3.Columns["idistanzakind"], nullaosta_alias3.Columns["idnullaosta"], nullaosta_alias3.Columns["idreg"]};
	cChild = new []{nullaosta_imm_alias3.Columns["idcorsostudio"], nullaosta_imm_alias3.Columns["iddidprog"], nullaosta_imm_alias3.Columns["idistanza"], nullaosta_imm_alias3.Columns["idistanzakind"], nullaosta_imm_alias3.Columns["idnullaosta"], nullaosta_imm_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias3_nullaosta_alias3_idcorsostudio-iddidprog-idistanza-idistanzakind-idnullaosta-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias2.Columns["idcorsostudio"], istanza_imm_alias2.Columns["iddidprog"], istanza_imm_alias2.Columns["idistanza"], istanza_imm_alias2.Columns["idistanzakind"], istanza_imm_alias2.Columns["idreg"]};
	cChild = new []{istanzadichiar_alias2.Columns["idcorsostudio"], istanzadichiar_alias2.Columns["iddidprog"], istanzadichiar_alias2.Columns["idistanza"], istanzadichiar_alias2.Columns["idistanzakind"], istanzadichiar_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanzadichiar_alias2_istanza_imm_alias2_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias2.Columns["idcorsostudio"], istanza_imm_alias2.Columns["iddidprog"], istanza_imm_alias2.Columns["idistanza"], istanza_imm_alias2.Columns["idistanzakind"], istanza_imm_alias2.Columns["idreg"]};
	cChild = new []{istanza_alias7.Columns["idcorsostudio"], istanza_alias7.Columns["iddidprog"], istanza_alias7.Columns["paridistanza"], istanza_alias7.Columns["idistanzakind"], istanza_alias7.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias7_istanza_imm_alias2_idcorsostudio-iddidprog-paridistanza-idistanzakind-idreg_studenti",cPar,cChild,false));

	cPar = new []{statuskind_alias2.Columns["idstatuskind"]};
	cChild = new []{istanza_alias2.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_alias2_statuskind_alias2_idstatuskind",cPar,cChild,false));

	cPar = new []{didprog_alias7.Columns["iddidprog"]};
	cChild = new []{istanza_alias2.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_alias2_didprog_alias7_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog_alias7.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_alias7_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico_alias7.Columns["aa"]};
	cChild = new []{istanza_alias2.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_alias2_annoaccademico_alias7_aa",cPar,cChild,false));

	cPar = new []{didprogori_alias2.Columns["iddidprogori"]};
	cChild = new []{istanza_imm_alias2.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias2_didprogori_alias2_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr_alias2.Columns["iddidprogcurr"]};
	cChild = new []{istanza_imm_alias2.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias2_didprogcurr_alias2_iddidprogcurr",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{istanza_alias1.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias1_registry_idreg",cPar,cChild,false));

	cPar = new []{istanza_alias1.Columns["idcorsostudio"], istanza_alias1.Columns["iddidprog"], istanza_alias1.Columns["idistanza"], istanza_alias1.Columns["idistanzakind"], istanza_alias1.Columns["idreg_studenti"]};
	cChild = new []{istanza_imm_alias1.Columns["idcorsostudio"], istanza_imm_alias1.Columns["iddidprog"], istanza_imm_alias1.Columns["idistanza"], istanza_imm_alias1.Columns["idistanzakind"], istanza_imm_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias1_istanza_alias1_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias1.Columns["idcorsostudio"], istanza_imm_alias1.Columns["iddidprog"], istanza_imm_alias1.Columns["idistanza"], istanza_imm_alias1.Columns["idistanzakind"], istanza_imm_alias1.Columns["idreg"]};
	cChild = new []{diniego_alias1.Columns["idcorsostudio"], diniego_alias1.Columns["iddidprog"], diniego_alias1.Columns["idistanza"], diniego_alias1.Columns["idistanzakind"], diniego_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias1_istanza_imm_alias1_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias1.Columns["idcorsostudio"], istanza_imm_alias1.Columns["iddidprog"], istanza_imm_alias1.Columns["idistanza"], istanza_imm_alias1.Columns["idistanzakind"], istanza_imm_alias1.Columns["idreg"]};
	cChild = new []{nullaosta_alias1.Columns["idcorsostudio"], nullaosta_alias1.Columns["iddidprog"], nullaosta_alias1.Columns["idistanza"], nullaosta_alias1.Columns["idistanzakind"], nullaosta_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_alias1_istanza_imm_alias1_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{nullaosta_alias1.Columns["idcorsostudio"], nullaosta_alias1.Columns["iddidprog"], nullaosta_alias1.Columns["idistanza"], nullaosta_alias1.Columns["idistanzakind"], nullaosta_alias1.Columns["idnullaosta"], nullaosta_alias1.Columns["idreg"]};
	cChild = new []{nullaosta_imm_alias1.Columns["idcorsostudio"], nullaosta_imm_alias1.Columns["iddidprog"], nullaosta_imm_alias1.Columns["idistanza"], nullaosta_imm_alias1.Columns["idistanzakind"], nullaosta_imm_alias1.Columns["idnullaosta"], nullaosta_imm_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias1_nullaosta_alias1_idcorsostudio-iddidprog-idistanza-idistanzakind-idnullaosta-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias1.Columns["idcorsostudio"], istanza_imm_alias1.Columns["iddidprog"], istanza_imm_alias1.Columns["idistanza"], istanza_imm_alias1.Columns["idistanzakind"], istanza_imm_alias1.Columns["idreg"]};
	cChild = new []{istanzadichiar_alias1.Columns["idcorsostudio"], istanzadichiar_alias1.Columns["iddidprog"], istanzadichiar_alias1.Columns["idistanza"], istanzadichiar_alias1.Columns["idistanzakind"], istanzadichiar_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanzadichiar_alias1_istanza_imm_alias1_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm_alias1.Columns["idcorsostudio"], istanza_imm_alias1.Columns["iddidprog"], istanza_imm_alias1.Columns["idistanza"], istanza_imm_alias1.Columns["idistanzakind"], istanza_imm_alias1.Columns["idreg"]};
	cChild = new []{istanza_alias6.Columns["idcorsostudio"], istanza_alias6.Columns["iddidprog"], istanza_alias6.Columns["paridistanza"], istanza_alias6.Columns["idistanzakind"], istanza_alias6.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias6_istanza_imm_alias1_idcorsostudio-iddidprog-paridistanza-idistanzakind-idreg_studenti",cPar,cChild,false));

	cPar = new []{statuskind_alias1.Columns["idstatuskind"]};
	cChild = new []{istanza_alias1.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_alias1_statuskind_alias1_idstatuskind",cPar,cChild,false));

	cPar = new []{didprog_alias6.Columns["iddidprog"]};
	cChild = new []{istanza_alias1.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_alias1_didprog_alias6_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog_alias6.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_alias6_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico_alias6.Columns["aa"]};
	cChild = new []{istanza_alias1.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_alias1_annoaccademico_alias6_aa",cPar,cChild,false));

	cPar = new []{didprogori_alias1.Columns["iddidprogori"]};
	cChild = new []{istanza_imm_alias1.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias1_didprogori_alias1_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr_alias1.Columns["iddidprogcurr"]};
	cChild = new []{istanza_imm_alias1.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_istanza_imm_alias1_didprogcurr_alias1_iddidprogcurr",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{istanza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_registry_idreg",cPar,cChild,false));

	cPar = new []{istanza.Columns["idcorsostudio"], istanza.Columns["iddidprog"], istanza.Columns["idistanza"], istanza.Columns["idistanzakind"], istanza.Columns["idreg_studenti"]};
	cChild = new []{istanza_imm.Columns["idcorsostudio"], istanza_imm.Columns["iddidprog"], istanza_imm.Columns["idistanza"], istanza_imm.Columns["idistanzakind"], istanza_imm.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanza_imm_istanza_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm.Columns["idcorsostudio"], istanza_imm.Columns["iddidprog"], istanza_imm.Columns["idistanza"], istanza_imm.Columns["idistanzakind"], istanza_imm.Columns["idreg"]};
	cChild = new []{diniego_alias2.Columns["idcorsostudio"], diniego_alias2.Columns["iddidprog"], diniego_alias2.Columns["idistanza"], diniego_alias2.Columns["idistanzakind"], diniego_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_diniego_alias2_istanza_imm_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm.Columns["idcorsostudio"], istanza_imm.Columns["iddidprog"], istanza_imm.Columns["idistanza"], istanza_imm.Columns["idistanzakind"], istanza_imm.Columns["idreg"]};
	cChild = new []{istanzadichiar.Columns["idcorsostudio"], istanzadichiar.Columns["iddidprog"], istanzadichiar.Columns["idistanza"], istanzadichiar.Columns["idistanzakind"], istanzadichiar.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_istanzadichiar_istanza_imm_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{istanza_imm.Columns["idcorsostudio"], istanza_imm.Columns["iddidprog"], istanza_imm.Columns["idistanza"], istanza_imm.Columns["idistanzakind"], istanza_imm.Columns["idreg"]};
	cChild = new []{istanza_alias14.Columns["idcorsostudio"], istanza_alias14.Columns["iddidprog"], istanza_alias14.Columns["paridistanza"], istanza_alias14.Columns["idistanzakind"], istanza_alias14.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_istanza_alias14_istanza_imm_idcorsostudio-iddidprog-paridistanza-idistanzakind-idreg_studenti",cPar,cChild,false));

	cPar = new []{istanza_imm.Columns["idcorsostudio"], istanza_imm.Columns["iddidprog"], istanza_imm.Columns["idistanza"], istanza_imm.Columns["idistanzakind"], istanza_imm.Columns["idreg"]};
	cChild = new []{nullaosta.Columns["idcorsostudio"], nullaosta.Columns["iddidprog"], nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_istanza_imm_idcorsostudio-iddidprog-idistanza-idistanzakind-idreg",cPar,cChild,false));

	cPar = new []{nullaosta.Columns["idcorsostudio"], nullaosta.Columns["iddidprog"], nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idnullaosta"], nullaosta.Columns["idreg"]};
	cChild = new []{nullaosta_imm.Columns["idcorsostudio"], nullaosta_imm.Columns["iddidprog"], nullaosta_imm.Columns["idistanza"], nullaosta_imm.Columns["idistanzakind"], nullaosta_imm.Columns["idnullaosta"], nullaosta_imm.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_nullaosta_idcorsostudio-iddidprog-idistanza-idistanzakind-idnullaosta-idreg",cPar,cChild,false));

	cPar = new []{statuskind.Columns["idstatuskind"]};
	cChild = new []{istanza.Columns["idstatuskind"]};
	Relations.Add(new DataRelation("FK_istanza_statuskind_idstatuskind",cPar,cChild,false));

	cPar = new []{didprog_alias5.Columns["iddidprog"]};
	cChild = new []{istanza.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_istanza_didprog_alias5_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog_alias5.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_alias5_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico_alias5.Columns["aa"]};
	cChild = new []{istanza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_istanza_annoaccademico_alias5_aa",cPar,cChild,false));

	cPar = new []{didprogori.Columns["iddidprogori"]};
	cChild = new []{istanza_imm.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_istanza_imm_didprogori_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{istanza_imm.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_istanza_imm_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{iscrizione_alias4.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias4_registry_idreg",cPar,cChild,false));

	cPar = new []{iscrizione_alias4.Columns["idiscrizione"], iscrizione_alias4.Columns["idreg"]};
	cChild = new []{sostenimento_alias1.Columns["idiscrizione"], sostenimento_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias1_iscrizione_alias4_idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{iscrizione_alias4.Columns["idiscrizione"], iscrizione_alias4.Columns["idreg"]};
	cChild = new []{pianostudio_alias1.Columns["idiscrizione"], pianostudio_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudio_alias1_iscrizione_alias4_idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{pianostudio_alias1.Columns["idiscrizione"], pianostudio_alias1.Columns["idpianostudio"], pianostudio_alias1.Columns["idreg"]};
	cChild = new []{pianostudioattivform_alias1.Columns["idiscrizione"], pianostudioattivform_alias1.Columns["idpianostudio"], pianostudioattivform_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_alias1_pianostudio_alias1_idiscrizione-idpianostudio-idreg",cPar,cChild,false));

	cPar = new []{annoaccademico_alias4.Columns["aa"]};
	cChild = new []{iscrizione_alias4.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias4_annoaccademico_alias4_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{iscrizione_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias3_registry_idreg",cPar,cChild,false));

	cPar = new []{iscrizione_alias3.Columns["idcorsostudio"], iscrizione_alias3.Columns["iddidprog"], iscrizione_alias3.Columns["idiscrizione"], iscrizione_alias3.Columns["idreg"]};
	cChild = new []{sostenimento_alias4.Columns["idcorsostudio"], sostenimento_alias4.Columns["iddidprog"], sostenimento_alias4.Columns["idiscrizione"], sostenimento_alias4.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias4_iscrizione_alias3_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{didprog_alias4.Columns["iddidprog"]};
	cChild = new []{iscrizione_alias3.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias3_didprog_alias4_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico_alias3.Columns["aa"]};
	cChild = new []{iscrizione_alias3.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias3_annoaccademico_alias3_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{iscrizione_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias2_registry_idreg",cPar,cChild,false));

	cPar = new []{iscrizione_alias2.Columns["idcorsostudio"], iscrizione_alias2.Columns["iddidprog"], iscrizione_alias2.Columns["idiscrizione"], iscrizione_alias2.Columns["idreg"]};
	cChild = new []{sostenimento_alias3.Columns["idcorsostudio"], sostenimento_alias3.Columns["iddidprog"], sostenimento_alias3.Columns["idiscrizione"], sostenimento_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias3_iscrizione_alias2_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{didprog_alias3.Columns["iddidprog"]};
	cChild = new []{iscrizione_alias2.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias2_didprog_alias3_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico_alias2.Columns["aa"]};
	cChild = new []{iscrizione_alias2.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias2_annoaccademico_alias2_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{iscrizione_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias1_registry_idreg",cPar,cChild,false));

	cPar = new []{iscrizione_alias1.Columns["idcorsostudio"], iscrizione_alias1.Columns["iddidprog"], iscrizione_alias1.Columns["idiscrizione"], iscrizione_alias1.Columns["idreg"]};
	cChild = new []{sostenimento_alias2.Columns["idcorsostudio"], sostenimento_alias2.Columns["iddidprog"], sostenimento_alias2.Columns["idiscrizione"], sostenimento_alias2.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_alias2_iscrizione_alias1_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{didprog_alias2.Columns["iddidprog"]};
	cChild = new []{iscrizione_alias1.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias1_didprog_alias2_iddidprog",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{iscrizione_alias1.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_alias1_annoaccademico_alias1_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{iscrizione.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizione_registry_idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"], iscrizione.Columns["aa"]};
	cChild = new []{decadenza.Columns["idiscrizione"], decadenza.Columns["idreg_studenti"], decadenza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_decadenza_iscrizione_idiscrizione-idreg_studenti-aa",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{iscrizioneanno.Columns["idcorsostudio"], iscrizioneanno.Columns["iddidprog"], iscrizioneanno.Columns["idiscrizione"], iscrizioneanno.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizioneanno_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{sostenimento.Columns["idcorsostudio"], sostenimento.Columns["iddidprog"], sostenimento.Columns["idiscrizione"], sostenimento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_sostenimento_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{iscrizione.Columns["idcorsostudio"], iscrizione.Columns["iddidprog"], iscrizione.Columns["idiscrizione"], iscrizione.Columns["idreg"]};
	cChild = new []{pianostudio.Columns["idcorsostudio"], pianostudio.Columns["iddidprog"], pianostudio.Columns["idiscrizione"], pianostudio.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudio_iscrizione_idcorsostudio-iddidprog-idiscrizione-idreg",cPar,cChild,false));

	cPar = new []{pianostudio.Columns["idiscrizione"], pianostudio.Columns["idpianostudio"], pianostudio.Columns["idreg"]};
	cChild = new []{pianostudioattivform.Columns["idiscrizione"], pianostudioattivform.Columns["idpianostudio"], pianostudioattivform.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_pianostudioattivform_pianostudio_idiscrizione-idpianostudio-idreg",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{iscrizione.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_iscrizione_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{iscrizione.Columns["aa"]};
	Relations.Add(new DataRelation("FK_iscrizione_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{bandodsiscr.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_bandodsiscr_registry_idreg_studenti",cPar,cChild,false));

	cPar = new []{bandodsiscr.Columns["idbandods"], bandodsiscr.Columns["idbandodsiscr"], bandodsiscr.Columns["idbandodsservizio"], bandodsiscr.Columns["idiscrizione"], bandodsiscr.Columns["idreg_studenti"]};
	cChild = new []{bandodsiscresito.Columns["idbandods"], bandodsiscresito.Columns["idbandodsiscr"], bandodsiscresito.Columns["idbandodsservizio"], bandodsiscresito.Columns["idiscrizione"], bandodsiscresito.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_bandodsiscresito_bandodsiscr_idbandods-idbandodsiscr-idbandodsservizio-idiscrizione-idreg_studenti",cPar,cChild,false));

	cPar = new []{accreditokind.Columns["idaccreditokind"]};
	cChild = new []{bandodsiscr.Columns["idaccreditokind"]};
	Relations.Add(new DataRelation("FK_bandodsiscr_accreditokind_idaccreditokind",cPar,cChild,false));

	cPar = new []{studprenotkinddefaultview.Columns["idstudprenotkind"]};
	cChild = new []{registry_studenti.Columns["idstudprenotkind"]};
	Relations.Add(new DataRelation("FK_registry_studenti_studprenotkinddefaultview_idstudprenotkind",cPar,cChild,false));

	cPar = new []{studdirittokinddefaultview.Columns["idstuddirittokind"]};
	cChild = new []{registry_studenti.Columns["idstuddirittokind"]};
	Relations.Add(new DataRelation("FK_registry_studenti_studdirittokinddefaultview_idstuddirittokind",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_registry_geo_city_idcity",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_registry_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("FK_registry_maritalstatus_idmaritalstatus",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("FK_registry_residence_residence",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	cPar = new []{registryclasspersoneview.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("FK_registry_registryclasspersoneview_idregistryclass",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_studenti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_studenti_registry_idreg",cPar,cChild,false));

	#endregion

}
}
}
