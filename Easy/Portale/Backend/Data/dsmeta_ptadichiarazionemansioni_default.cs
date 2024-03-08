
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
[System.Xml.Serialization.XmlRoot("dsmeta_ptadichiarazionemansioni_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ptadichiarazionemansioni_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycongiuntodefaultview 		=> (MetaTable)Tables["registrycongiuntodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview_alias1 		=> (MetaTable)Tables["registryamministrativiview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ptadichiarazionemansioni 		=> (MetaTable)Tables["ptadichiarazionemansioni"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ptadichiarazionemansioni_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ptadichiarazionemansioni_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ptadichiarazionemansioni_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ptadichiarazionemansioni_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYCONGIUNTODEFAULTVIEW /////////////////////////////////
	var tregistrycongiuntodefaultview= new MetaTable("registrycongiuntodefaultview");
	tregistrycongiuntodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrycongiuntodefaultview.defineColumn("idreg", typeof(int),false);
	tregistrycongiuntodefaultview.defineColumn("idreg_parente", typeof(int),false);
	tregistrycongiuntodefaultview.defineColumn("idregistrycongiunto", typeof(int),false);
	Tables.Add(tregistrycongiuntodefaultview);
	tregistrycongiuntodefaultview.defineKey("idreg", "idreg_parente", "idregistrycongiunto");

	//////////////////// AFFERENZAAMMVIEW /////////////////////////////////
	var tafferenzaammview= new MetaTable("afferenzaammview");
	tafferenzaammview.defineColumn("dropdown_title", typeof(string),false);
	tafferenzaammview.defineColumn("idafferenza", typeof(int),false);
	tafferenzaammview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tafferenzaammview);
	tafferenzaammview.defineKey("idafferenza", "idreg");

	//////////////////// REGISTRYAMMINISTRATIVIVIEW_ALIAS1 /////////////////////////////////
	var tregistryamministrativiview_alias1= new MetaTable("registryamministrativiview_alias1");
	tregistryamministrativiview_alias1.defineColumn("category_description", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("contrattokind_title", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tregistryamministrativiview_alias1.defineColumn("geo_city_title", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("geo_nation_title", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("idcity", typeof(int));
	tregistryamministrativiview_alias1.defineColumn("idnation", typeof(int));
	tregistryamministrativiview_alias1.defineColumn("idreg", typeof(int),false);
	tregistryamministrativiview_alias1.defineColumn("idtitle", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("maritalstatus_description", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_active", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_amministrativi_ct", typeof(DateTime));
	tregistryamministrativiview_alias1.defineColumn("registry_amministrativi_cu", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_amministrativi_cv", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_amministrativi_idcontrattokind", typeof(int));
	tregistryamministrativiview_alias1.defineColumn("registry_amministrativi_idreg", typeof(int),false);
	tregistryamministrativiview_alias1.defineColumn("registry_amministrativi_lt", typeof(DateTime));
	tregistryamministrativiview_alias1.defineColumn("registry_amministrativi_lu", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_annotation", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_authorization_free", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_badgecode", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_birthdate", typeof(DateTime));
	tregistryamministrativiview_alias1.defineColumn("registry_ccp", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_cf", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_ct", typeof(DateTime),false);
	tregistryamministrativiview_alias1.defineColumn("registry_cu", typeof(string),false);
	tregistryamministrativiview_alias1.defineColumn("registry_email_fe", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_extension", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_extmatricula", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_flag_pa", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_foreigncf", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_forename", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_gender", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_idaccmotivecredit", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_idaccmotivedebit", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_idcategory", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_idexternal", typeof(int));
	tregistryamministrativiview_alias1.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_idregistryclass", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_idregistrykind", typeof(int));
	tregistryamministrativiview_alias1.defineColumn("registry_ipa_fe", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_location", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_lt", typeof(DateTime),false);
	tregistryamministrativiview_alias1.defineColumn("registry_lu", typeof(string),false);
	tregistryamministrativiview_alias1.defineColumn("registry_maritalsurname", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_multi_cf", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_p_iva", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_pec_fe", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_residence", typeof(int),false);
	tregistryamministrativiview_alias1.defineColumn("registry_rtf", typeof(Byte[]));
	tregistryamministrativiview_alias1.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_surname", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registry_title", typeof(string),false);
	tregistryamministrativiview_alias1.defineColumn("registry_toredirect", typeof(int));
	tregistryamministrativiview_alias1.defineColumn("registry_txt", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registryclass_description", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("registrykind_description", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("residence_description", typeof(string));
	tregistryamministrativiview_alias1.defineColumn("title_description", typeof(string));
	tregistryamministrativiview_alias1.ExtendedProperties["TableForReading"]="registryamministrativiview";
	Tables.Add(tregistryamministrativiview_alias1);
	tregistryamministrativiview_alias1.defineKey("idreg");

	//////////////////// REGISTRYAMMINISTRATIVIVIEW /////////////////////////////////
	var tregistryamministrativiview= new MetaTable("registryamministrativiview");
	tregistryamministrativiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryamministrativiview.defineColumn("idreg", typeof(int),false);
	tregistryamministrativiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryamministrativiview);
	tregistryamministrativiview.defineKey("idreg");

	//////////////////// PTADICHIARAZIONEMANSIONI /////////////////////////////////
	var tptadichiarazionemansioni= new MetaTable("ptadichiarazionemansioni");
	tptadichiarazionemansioni.defineColumn("ct", typeof(DateTime),false);
	tptadichiarazionemansioni.defineColumn("cu", typeof(string),false);
	tptadichiarazionemansioni.defineColumn("data", typeof(DateTime));
	tptadichiarazionemansioni.defineColumn("giorni", typeof(int));
	tptadichiarazionemansioni.defineColumn("idafferenza", typeof(int));
	tptadichiarazionemansioni.defineColumn("idptadichiarazionemansioni", typeof(int),false);
	tptadichiarazionemansioni.defineColumn("idreg", typeof(int),false);
	tptadichiarazionemansioni.defineColumn("idreg_resp", typeof(int),false);
	tptadichiarazionemansioni.defineColumn("idregistrycongiunto", typeof(int));
	tptadichiarazionemansioni.defineColumn("lt", typeof(DateTime),false);
	tptadichiarazionemansioni.defineColumn("lu", typeof(string),false);
	tptadichiarazionemansioni.defineColumn("protanno", typeof(int));
	tptadichiarazionemansioni.defineColumn("protnumero", typeof(int));
	Tables.Add(tptadichiarazionemansioni);
	tptadichiarazionemansioni.defineKey("idptadichiarazionemansioni");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrycongiuntodefaultview.Columns["idregistrycongiunto"]};
	var cChild = new []{ptadichiarazionemansioni.Columns["idregistrycongiunto"]};
	Relations.Add(new DataRelation("FK_ptadichiarazionemansioni_registrycongiuntodefaultview_idregistrycongiunto",cPar,cChild,false));

	cPar = new []{registryamministrativiview_alias1.Columns["idreg"]};
	cChild = new []{registrycongiuntodefaultview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrycongiuntodefaultview_registryamministrativiview_alias1_idreg",cPar,cChild,false));

	cPar = new []{afferenzaammview.Columns["idafferenza"]};
	cChild = new []{ptadichiarazionemansioni.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_ptadichiarazionemansioni_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{registryamministrativiview_alias1.Columns["idreg"]};
	cChild = new []{afferenzaammview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_afferenzaammview_registryamministrativiview_alias1_idreg",cPar,cChild,false));

	cPar = new []{registryamministrativiview_alias1.Columns["idreg"]};
	cChild = new []{ptadichiarazionemansioni.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_ptadichiarazionemansioni_registryamministrativiview_alias1_idreg",cPar,cChild,false));

	cPar = new []{registryamministrativiview.Columns["idreg"]};
	cChild = new []{ptadichiarazionemansioni.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_ptadichiarazionemansioni_registryamministrativiview_idreg_resp",cPar,cChild,false));

	#endregion

}
}
}
