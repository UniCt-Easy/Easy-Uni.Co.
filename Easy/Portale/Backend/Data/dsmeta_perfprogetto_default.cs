
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogetto_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogetto_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouomembro 		=> (MetaTable)Tables["perfprogettouomembro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouo 		=> (MetaTable)Tables["perfprogettouo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia 		=> (MetaTable)Tables["perfprogettoobiettivosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitaattach 		=> (MetaTable)Tables["perfprogettoobiettivoattivitaattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivita 		=> (MetaTable)Tables["perfprogettoobiettivoattivita"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivo 		=> (MetaTable)Tables["perfprogettoobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettocostobudgetview 		=> (MetaTable)Tables["perfprogettocostobudgetview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcostoview 		=> (MetaTable)Tables["getcostoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive 		=> (MetaTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettocosto 		=> (MetaTable)Tables["perfprogettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias2 		=> (MetaTable)Tables["registry_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_amministrativi_alias1 		=> (MetaTable)Tables["registry_amministrativi_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_amministrativi 		=> (MetaTable)Tables["registry_amministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoavanzamento 		=> (MetaTable)Tables["perfprogettoavanzamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoattach 		=> (MetaTable)Tables["perfprogettoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogsuddannokinddefaultview 		=> (MetaTable)Tables["didprogsuddannokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettostatusdefaultview 		=> (MetaTable)Tables["perfprogettostatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogetto 		=> (MetaTable)Tables["perfprogetto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogetto_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogetto_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogetto_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogetto_default.xsd";

	#region create DataTables
	//////////////////// PERFPROGETTOUOMEMBRO /////////////////////////////////
	var tperfprogettouomembro= new MetaTable("perfprogettouomembro");
	tperfprogettouomembro.defineColumn("ct", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("cu", typeof(string),false);
	tperfprogettouomembro.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouomembro.defineColumn("idperfprogettouo", typeof(int),false);
	tperfprogettouomembro.defineColumn("idreg", typeof(int),false);
	tperfprogettouomembro.defineColumn("lt", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettouomembro);
	tperfprogettouomembro.defineKey("idperfprogetto", "idperfprogettouo", "idreg");

	//////////////////// PERFPROGETTOUO /////////////////////////////////
	var tperfprogettouo= new MetaTable("perfprogettouo");
	tperfprogettouo.defineColumn("!struttura", typeof(string));
	tperfprogettouo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettouo.defineColumn("cu", typeof(string),false);
	tperfprogettouo.defineColumn("description", typeof(string));
	tperfprogettouo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouo.defineColumn("idperfprogettouo", typeof(int),false);
	tperfprogettouo.defineColumn("lt", typeof(DateTime),false);
	tperfprogettouo.defineColumn("lu", typeof(string),false);
	tperfprogettouo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettouo);
	tperfprogettouo.defineKey("idperfprogetto", "idperfprogettouo");

	//////////////////// PERFPROGETTOOBIETTIVOSOGLIA /////////////////////////////////
	var tperfprogettoobiettivosoglia= new MetaTable("perfprogettoobiettivosoglia");
	tperfprogettoobiettivosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("description", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivosoglia", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("percentuale", typeof(decimal));
	tperfprogettoobiettivosoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfprogettoobiettivosoglia);
	tperfprogettoobiettivosoglia.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivosoglia");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITAATTACH /////////////////////////////////
	var tperfprogettoobiettivoattivitaattach= new MetaTable("perfprogettoobiettivoattivitaattach");
	tperfprogettoobiettivoattivitaattach.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idattach", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettoobiettivoattivitaattach);
	tperfprogettoobiettivoattivitaattach.defineKey("idattach", "idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITA /////////////////////////////////
	var tperfprogettoobiettivoattivita= new MetaTable("perfprogettoobiettivoattivita");
	tperfprogettoobiettivoattivita.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivoattivita.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivita.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivita.defineColumn("datafineeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datainizioeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("description", typeof(string));
	tperfprogettoobiettivoattivita.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idreg", typeof(int));
	tperfprogettoobiettivoattivita.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivita.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivoattivita.defineColumn("paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoobiettivoattivita.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivoattivita);
	tperfprogettoobiettivoattivita.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVO /////////////////////////////////
	var tperfprogettoobiettivo= new MetaTable("perfprogettoobiettivo");
	tperfprogettoobiettivo.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivo.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivo.defineColumn("description", typeof(string));
	tperfprogettoobiettivo.defineColumn("idattach", typeof(int));
	tperfprogettoobiettivo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("lt", typeof(DateTime));
	tperfprogettoobiettivo.defineColumn("lu", typeof(string));
	tperfprogettoobiettivo.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivo);
	tperfprogettoobiettivo.defineKey("idperfprogetto", "idperfprogettoobiettivo");

	//////////////////// PERFPROGETTOCOSTOBUDGETVIEW /////////////////////////////////
	var tperfprogettocostobudgetview= new MetaTable("perfprogettocostobudgetview");
	tperfprogettocostobudgetview.defineColumn("amount", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount2", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount3", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount4", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount5", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("annotation", typeof(string));
	tperfprogettocostobudgetview.defineColumn("ct", typeof(DateTime),false);
	tperfprogettocostobudgetview.defineColumn("cu", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("description", typeof(string));
	tperfprogettocostobudgetview.defineColumn("idacc", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("idaccmotive", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("idcostpartition", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idinv", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idsor1", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idsor2", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idsor3", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idupb", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("lt", typeof(DateTime),false);
	tperfprogettocostobudgetview.defineColumn("lu", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("nvar", typeof(int),false);
	tperfprogettocostobudgetview.defineColumn("prevcassa", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("rownum", typeof(int),false);
	tperfprogettocostobudgetview.defineColumn("underwritingkind", typeof(string));
	tperfprogettocostobudgetview.defineColumn("underwritingkind_desc", typeof(string));
	tperfprogettocostobudgetview.defineColumn("yvar", typeof(int),false);
	tperfprogettocostobudgetview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettocostobudgetview);
	tperfprogettocostobudgetview.defineKey("nvar", "rownum", "yvar");

	//////////////////// GETCOSTOVIEW /////////////////////////////////
	var tgetcostoview= new MetaTable("getcostoview");
	tgetcostoview.defineColumn("accmotive_title", typeof(string));
	tgetcostoview.defineColumn("adate", typeof(DateTime));
	tgetcostoview.defineColumn("amount", typeof(decimal));
	tgetcostoview.defineColumn("cf", typeof(string));
	tgetcostoview.defineColumn("description", typeof(string));
	tgetcostoview.defineColumn("doc", typeof(string));
	tgetcostoview.defineColumn("docdate", typeof(DateTime));
	tgetcostoview.defineColumn("idaccmotive", typeof(string),false);
	tgetcostoview.defineColumn("idexp", typeof(int),false);
	tgetcostoview.defineColumn("idupb", typeof(string),false);
	tgetcostoview.defineColumn("nmov", typeof(int));
	tgetcostoview.defineColumn("p_iva", typeof(string));
	tgetcostoview.defineColumn("payment_adate", typeof(DateTime));
	tgetcostoview.defineColumn("registry_title", typeof(string));
	tgetcostoview.defineColumn("transactiondate", typeof(DateTime));
	tgetcostoview.defineColumn("transmissiondate", typeof(DateTime));
	tgetcostoview.defineColumn("ymov", typeof(int),false);
	tgetcostoview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tgetcostoview);
	tgetcostoview.defineKey("idaccmotive", "idexp", "idupb", "ymov");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("title", typeof(string),false);
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new MetaTable("accmotive");
	taccmotive.defineColumn("active", typeof(string));
	taccmotive.defineColumn("codemotive", typeof(string),false);
	taccmotive.defineColumn("idaccmotive", typeof(string),false);
	taccmotive.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// PERFPROGETTOCOSTO /////////////////////////////////
	var tperfprogettocosto= new MetaTable("perfprogettocosto");
	tperfprogettocosto.defineColumn("budget", typeof(decimal));
	tperfprogettocosto.defineColumn("budgetcurr", typeof(decimal));
	tperfprogettocosto.defineColumn("consuntivo", typeof(decimal));
	tperfprogettocosto.defineColumn("ct", typeof(DateTime),false);
	tperfprogettocosto.defineColumn("cu", typeof(string),false);
	tperfprogettocosto.defineColumn("idaccmotive", typeof(string),false);
	tperfprogettocosto.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettocosto.defineColumn("idperfprogettocosto", typeof(int),false);
	tperfprogettocosto.defineColumn("idupb", typeof(string),false);
	tperfprogettocosto.defineColumn("lt", typeof(DateTime),false);
	tperfprogettocosto.defineColumn("lu", typeof(string),false);
	tperfprogettocosto.defineColumn("year", typeof(int),false);
	tperfprogettocosto.defineColumn("!idaccmotive_accmotive_codemotive", typeof(string));
	tperfprogettocosto.defineColumn("!idaccmotive_accmotive_title", typeof(string));
	tperfprogettocosto.defineColumn("!idupb_upb_title", typeof(string));
	Tables.Add(tperfprogettocosto);
	tperfprogettocosto.defineKey("idaccmotive", "idperfprogetto", "idperfprogettocosto", "idupb", "year");

	//////////////////// REGISTRY_ALIAS2 /////////////////////////////////
	var tregistry_alias2= new MetaTable("registry_alias2");
	tregistry_alias2.defineColumn("active", typeof(string),false);
	tregistry_alias2.defineColumn("annotation", typeof(string));
	tregistry_alias2.defineColumn("authorization_free", typeof(string));
	tregistry_alias2.defineColumn("badgecode", typeof(string));
	tregistry_alias2.defineColumn("birthdate", typeof(DateTime));
	tregistry_alias2.defineColumn("ccp", typeof(string));
	tregistry_alias2.defineColumn("cf", typeof(string));
	tregistry_alias2.defineColumn("ct", typeof(DateTime),false);
	tregistry_alias2.defineColumn("cu", typeof(string),false);
	tregistry_alias2.defineColumn("email_fe", typeof(string));
	tregistry_alias2.defineColumn("extension", typeof(string));
	tregistry_alias2.defineColumn("extmatricula", typeof(string));
	tregistry_alias2.defineColumn("flag_pa", typeof(string));
	tregistry_alias2.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry_alias2.defineColumn("foreigncf", typeof(string));
	tregistry_alias2.defineColumn("forename", typeof(string));
	tregistry_alias2.defineColumn("gender", typeof(string));
	tregistry_alias2.defineColumn("idaccmotivecredit", typeof(string));
	tregistry_alias2.defineColumn("idaccmotivedebit", typeof(string));
	tregistry_alias2.defineColumn("idcategory", typeof(string));
	tregistry_alias2.defineColumn("idcentralizedcategory", typeof(string));
	tregistry_alias2.defineColumn("idcity", typeof(int));
	tregistry_alias2.defineColumn("idexternal", typeof(int));
	tregistry_alias2.defineColumn("idmaritalstatus", typeof(string));
	tregistry_alias2.defineColumn("idnation", typeof(int));
	tregistry_alias2.defineColumn("idreg", typeof(int),false);
	tregistry_alias2.defineColumn("idregistryclass", typeof(string));
	tregistry_alias2.defineColumn("idregistrykind", typeof(int));
	tregistry_alias2.defineColumn("idtitle", typeof(string));
	tregistry_alias2.defineColumn("ipa_fe", typeof(string));
	tregistry_alias2.defineColumn("ipa_perlapa", typeof(string));
	tregistry_alias2.defineColumn("location", typeof(string));
	tregistry_alias2.defineColumn("lt", typeof(DateTime),false);
	tregistry_alias2.defineColumn("lu", typeof(string),false);
	tregistry_alias2.defineColumn("maritalsurname", typeof(string));
	tregistry_alias2.defineColumn("multi_cf", typeof(string));
	tregistry_alias2.defineColumn("p_iva", typeof(string));
	tregistry_alias2.defineColumn("pec_fe", typeof(string));
	tregistry_alias2.defineColumn("residence", typeof(int),false);
	tregistry_alias2.defineColumn("rtf", typeof(Byte[]));
	tregistry_alias2.defineColumn("sdi_defrifamm", typeof(string));
	tregistry_alias2.defineColumn("sdi_norifamm", typeof(string));
	tregistry_alias2.defineColumn("surname", typeof(string));
	tregistry_alias2.defineColumn("title", typeof(string),false);
	tregistry_alias2.defineColumn("toredirect", typeof(int));
	tregistry_alias2.defineColumn("txt", typeof(string));
	tregistry_alias2.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias2);
	tregistry_alias2.defineKey("idreg");

	//////////////////// REGISTRY_AMMINISTRATIVI_ALIAS1 /////////////////////////////////
	var tregistry_amministrativi_alias1= new MetaTable("registry_amministrativi_alias1");
	tregistry_amministrativi_alias1.defineColumn("ct", typeof(DateTime));
	tregistry_amministrativi_alias1.defineColumn("cu", typeof(string));
	tregistry_amministrativi_alias1.defineColumn("cv", typeof(string));
	tregistry_amministrativi_alias1.defineColumn("idcontrattokind", typeof(int));
	tregistry_amministrativi_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_amministrativi_alias1.defineColumn("lt", typeof(DateTime));
	tregistry_amministrativi_alias1.defineColumn("lu", typeof(string));
	tregistry_amministrativi_alias1.ExtendedProperties["TableForReading"]="registry_amministrativi";
	Tables.Add(tregistry_amministrativi_alias1);
	tregistry_amministrativi_alias1.defineKey("idreg");

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

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("idtitle", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

	//////////////////// REGISTRY_AMMINISTRATIVI /////////////////////////////////
	var tregistry_amministrativi= new MetaTable("registry_amministrativi");
	tregistry_amministrativi.defineColumn("ct", typeof(DateTime));
	tregistry_amministrativi.defineColumn("cu", typeof(string));
	tregistry_amministrativi.defineColumn("cv", typeof(string));
	tregistry_amministrativi.defineColumn("idcontrattokind", typeof(int));
	tregistry_amministrativi.defineColumn("idreg", typeof(int),false);
	tregistry_amministrativi.defineColumn("lt", typeof(DateTime));
	tregistry_amministrativi.defineColumn("lu", typeof(string));
	Tables.Add(tregistry_amministrativi);
	tregistry_amministrativi.defineKey("idreg");

	//////////////////// PERFPROGETTOAVANZAMENTO /////////////////////////////////
	var tperfprogettoavanzamento= new MetaTable("perfprogettoavanzamento");
	tperfprogettoavanzamento.defineColumn("avanzamento", typeof(decimal));
	tperfprogettoavanzamento.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoavanzamento.defineColumn("cu", typeof(string),false);
	tperfprogettoavanzamento.defineColumn("data", typeof(DateTime));
	tperfprogettoavanzamento.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoavanzamento.defineColumn("idperfprogettoavanzamento", typeof(int),false);
	tperfprogettoavanzamento.defineColumn("idreg_amministrativi", typeof(int));
	tperfprogettoavanzamento.defineColumn("idreg_amministrativi_ver", typeof(int));
	tperfprogettoavanzamento.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoavanzamento.defineColumn("lu", typeof(string),false);
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_amministrativi_surname", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_amministrativi_forename", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_amministrativi_cf", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_registry_amministrativi_idreg_amministrativi_description", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_amministrativi_surname", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_amministrativi_forename", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_amministrativi_cf", typeof(string));
	tperfprogettoavanzamento.defineColumn("!idreg_amministrativi_ver_registry_amministrativi_idreg_amministrativi_ver_description", typeof(string));
	Tables.Add(tperfprogettoavanzamento);
	tperfprogettoavanzamento.defineKey("idperfprogetto", "idperfprogettoavanzamento");

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

	//////////////////// PERFPROGETTOATTACH /////////////////////////////////
	var tperfprogettoattach= new MetaTable("perfprogettoattach");
	tperfprogettoattach.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoattach.defineColumn("cu", typeof(string),false);
	tperfprogettoattach.defineColumn("idattach", typeof(int));
	tperfprogettoattach.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoattach.defineColumn("idperfprogettoattach", typeof(int),false);
	tperfprogettoattach.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoattach.defineColumn("lu", typeof(string),false);
	tperfprogettoattach.defineColumn("!idattach_attach_filename", typeof(string));
	Tables.Add(tperfprogettoattach);
	tperfprogettoattach.defineKey("idperfprogetto", "idperfprogettoattach");

	//////////////////// DIDPROGSUDDANNOKINDDEFAULTVIEW /////////////////////////////////
	var tdidprogsuddannokinddefaultview= new MetaTable("didprogsuddannokinddefaultview");
	tdidprogsuddannokinddefaultview.defineColumn("didprogsuddannokind_active", typeof(string));
	tdidprogsuddannokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogsuddannokinddefaultview.defineColumn("iddidprogsuddannokind", typeof(int),false);
	Tables.Add(tdidprogsuddannokinddefaultview);
	tdidprogsuddannokinddefaultview.defineKey("iddidprogsuddannokind");

	//////////////////// PERFPROGETTOSTATUSDEFAULTVIEW /////////////////////////////////
	var tperfprogettostatusdefaultview= new MetaTable("perfprogettostatusdefaultview");
	tperfprogettostatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettostatusdefaultview.defineColumn("idperfprogettostatus", typeof(int),false);
	tperfprogettostatusdefaultview.defineColumn("perfprogettostatus_active", typeof(string));
	Tables.Add(tperfprogettostatusdefaultview);
	tperfprogettostatusdefaultview.defineKey("idperfprogettostatus");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// PERFPROGETTO /////////////////////////////////
	var tperfprogetto= new MetaTable("perfprogetto");
	tperfprogetto.defineColumn("benefici", typeof(string));
	tperfprogetto.defineColumn("ct", typeof(DateTime));
	tperfprogetto.defineColumn("cu", typeof(string));
	tperfprogetto.defineColumn("datafineeffettiva", typeof(DateTime));
	tperfprogetto.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogetto.defineColumn("datainizioeffettiva", typeof(DateTime));
	tperfprogetto.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogetto.defineColumn("description", typeof(string));
	tperfprogetto.defineColumn("iddidprogsuddannokind", typeof(int));
	tperfprogetto.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogetto.defineColumn("idperfprogettostatus", typeof(int));
	tperfprogetto.defineColumn("idstruttura", typeof(int),false);
	tperfprogetto.defineColumn("lt", typeof(DateTime));
	tperfprogetto.defineColumn("lu", typeof(string));
	tperfprogetto.defineColumn("note", typeof(string));
	tperfprogetto.defineColumn("risultato", typeof(decimal));
	tperfprogetto.defineColumn("title", typeof(string));
	Tables.Add(tperfprogetto);
	tperfprogetto.defineKey("idperfprogetto");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	var cChild = new []{perfprogettouo.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettouo_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettouo.Columns["idperfprogetto"], perfprogettouo.Columns["idperfprogettouo"]};
	cChild = new []{perfprogettouomembro.Columns["idperfprogetto"], perfprogettouomembro.Columns["idperfprogettouo"]};
	Relations.Add(new DataRelation("FK_perfprogettouomembro_perfprogettouo_idperfprogetto-idperfprogettouo",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoobiettivo.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivo_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogetto"], perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfprogetto"], perfprogettoobiettivosoglia.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfprogettoobiettivo_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogetto"], perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["idperfprogetto"], perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_perfprogettoobiettivo_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita.Columns["idperfprogetto"], perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogetto"], perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogettoobiettivoattivita_idperfprogetto-idperfprogettoobiettivo-idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["paridperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettocosto.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettocosto_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{perfprogettocosto.Columns["idaccmotive"], perfprogettocosto.Columns["idupb"]};
	cChild = new []{perfprogettocostobudgetview.Columns["idaccmotive"], perfprogettocostobudgetview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_perfprogettocostobudgetview_perfprogettocosto_idaccmotive-idupb",cPar,cChild,false));

	cPar = new []{perfprogettocosto.Columns["idaccmotive"], perfprogettocosto.Columns["idupb"]};
	cChild = new []{getcostoview.Columns["idaccmotive"], getcostoview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_getcostoview_perfprogettocosto_idaccmotive-idupb",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfprogettocosto.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfprogettocosto_year_year",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{perfprogettocosto.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_perfprogettocosto_upb_idupb",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{perfprogettocosto.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_perfprogettocosto_accmotive_idaccmotive",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoavanzamento.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoavanzamento_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{perfprogettoavanzamento.Columns["idreg_amministrativi_ver"]};
	Relations.Add(new DataRelation("FK_perfprogettoavanzamento_registry_alias2_idreg_amministrativi_ver",cPar,cChild,false));

	cPar = new []{registry_alias2.Columns["idreg"]};
	cChild = new []{registry_amministrativi_alias1.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_amministrativi_alias1_registry_alias2_idreg",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry_alias2.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_alias2_title_idtitle",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{perfprogettoavanzamento.Columns["idreg_amministrativi"]};
	Relations.Add(new DataRelation("FK_perfprogettoavanzamento_registry_idreg_amministrativi",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_amministrativi.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_amministrativi_registry_idreg",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("FK_registry_title_idtitle",cPar,cChild,false));

	cPar = new []{perfprogetto.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoattach.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoattach_perfprogetto_idperfprogetto",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfprogettoattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfprogettoattach_attach_idattach",cPar,cChild,false));

	cPar = new []{didprogsuddannokinddefaultview.Columns["iddidprogsuddannokind"]};
	cChild = new []{perfprogetto.Columns["iddidprogsuddannokind"]};
	Relations.Add(new DataRelation("FK_perfprogetto_didprogsuddannokinddefaultview_iddidprogsuddannokind",cPar,cChild,false));

	cPar = new []{perfprogettostatusdefaultview.Columns["idperfprogettostatus"]};
	cChild = new []{perfprogetto.Columns["idperfprogettostatus"]};
	Relations.Add(new DataRelation("FK_perfprogetto_perfprogettostatusdefaultview_idperfprogettostatus",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{perfprogetto.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfprogetto_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
