
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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontlezionestud_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_rendicontlezionestud_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontlezionestud 		=> (MetaTable)Tables["rendicontlezionestud"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontlezionestud_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontlezionestud_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontlezionestud_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontlezionestud_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("geo_city_title", typeof(string));
	tregistrystudentiview.defineColumn("geo_nation_title", typeof(string));
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("maritalstatus_description", typeof(string));
	tregistrystudentiview.defineColumn("registry_active", typeof(string));
	tregistrystudentiview.defineColumn("registry_annotation", typeof(string));
	tregistrystudentiview.defineColumn("registry_authorization_free", typeof(string));
	tregistrystudentiview.defineColumn("registry_badgecode", typeof(string));
	tregistrystudentiview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistrystudentiview.defineColumn("registry_ccp", typeof(string));
	tregistrystudentiview.defineColumn("registry_cf", typeof(string));
	tregistrystudentiview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistrystudentiview.defineColumn("registry_cu", typeof(string),false);
	tregistrystudentiview.defineColumn("registry_email_fe", typeof(string));
	tregistrystudentiview.defineColumn("registry_extension", typeof(string));
	tregistrystudentiview.defineColumn("registry_extmatricula", typeof(string));
	tregistrystudentiview.defineColumn("registry_flag_pa", typeof(string));
	tregistrystudentiview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistrystudentiview.defineColumn("registry_foreigncf", typeof(string));
	tregistrystudentiview.defineColumn("registry_forename", typeof(string));
	tregistrystudentiview.defineColumn("registry_gender", typeof(string));
	tregistrystudentiview.defineColumn("registry_idcategory", typeof(string));
	tregistrystudentiview.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistrystudentiview.defineColumn("registry_idexternal", typeof(int));
	tregistrystudentiview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistrystudentiview.defineColumn("registry_idregistrykind", typeof(int));
	tregistrystudentiview.defineColumn("registry_ipa_fe", typeof(string));
	tregistrystudentiview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistrystudentiview.defineColumn("registry_location", typeof(string));
	tregistrystudentiview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistrystudentiview.defineColumn("registry_lu", typeof(string),false);
	tregistrystudentiview.defineColumn("registry_maritalsurname", typeof(string));
	tregistrystudentiview.defineColumn("registry_multi_cf", typeof(string));
	tregistrystudentiview.defineColumn("registry_p_iva", typeof(string));
	tregistrystudentiview.defineColumn("registry_pec_fe", typeof(string));
	tregistrystudentiview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistrystudentiview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistrystudentiview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistrystudentiview.defineColumn("registry_studenti_authinps", typeof(string));
	tregistrystudentiview.defineColumn("registry_studenti_ct", typeof(DateTime),false);
	tregistrystudentiview.defineColumn("registry_studenti_cu", typeof(string),false);
	tregistrystudentiview.defineColumn("registry_studenti_idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("registry_studenti_idstuddirittokind", typeof(int));
	tregistrystudentiview.defineColumn("registry_studenti_idstudprenotkind", typeof(int),false);
	tregistrystudentiview.defineColumn("registry_studenti_lt", typeof(DateTime),false);
	tregistrystudentiview.defineColumn("registry_studenti_lu", typeof(string),false);
	tregistrystudentiview.defineColumn("registry_surname", typeof(string));
	tregistrystudentiview.defineColumn("registry_toredirect", typeof(int));
	tregistrystudentiview.defineColumn("registry_txt", typeof(string));
	tregistrystudentiview.defineColumn("registryclass_description", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	tregistrystudentiview.defineColumn("residence_description", typeof(string));
	tregistrystudentiview.defineColumn("studdirittokind_title", typeof(string));
	tregistrystudentiview.defineColumn("studprenotkind_title", typeof(string));
	tregistrystudentiview.defineColumn("title", typeof(string),false);
	tregistrystudentiview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// RENDICONTLEZIONESTUD /////////////////////////////////
	var trendicontlezionestud= new MetaTable("rendicontlezionestud");
	trendicontlezionestud.defineColumn("aa", typeof(string),false);
	trendicontlezionestud.defineColumn("assente", typeof(string),false);
	trendicontlezionestud.defineColumn("ct", typeof(DateTime),false);
	trendicontlezionestud.defineColumn("cu", typeof(string),false);
	trendicontlezionestud.defineColumn("idaffidamento", typeof(int),false);
	trendicontlezionestud.defineColumn("idattivform", typeof(int),false);
	trendicontlezionestud.defineColumn("idaula", typeof(int),false);
	trendicontlezionestud.defineColumn("idcanale", typeof(int),false);
	trendicontlezionestud.defineColumn("idcorsostudio", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprog", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidproganno", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogcurr", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogori", typeof(int),false);
	trendicontlezionestud.defineColumn("iddidprogporzanno", typeof(int),false);
	trendicontlezionestud.defineColumn("idedificio", typeof(int),false);
	trendicontlezionestud.defineColumn("idlezione", typeof(int),false);
	trendicontlezionestud.defineColumn("idreg_docenti", typeof(int),false);
	trendicontlezionestud.defineColumn("idreg_studenti", typeof(int),false);
	trendicontlezionestud.defineColumn("idsede", typeof(int),false);
	trendicontlezionestud.defineColumn("lt", typeof(DateTime),false);
	trendicontlezionestud.defineColumn("lu", typeof(string),false);
	trendicontlezionestud.defineColumn("notadisciplinare", typeof(string));
	trendicontlezionestud.defineColumn("ritardo", typeof(DateTime));
	trendicontlezionestud.defineColumn("ritardogiustifica", typeof(string));
	Tables.Add(trendicontlezionestud);
	trendicontlezionestud.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idreg_studenti", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrystudentiview.Columns["idreg"]};
	var cChild = new []{rendicontlezionestud.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_rendicontlezionestud_registrystudentiview_idreg_studenti",cPar,cChild,false));

	#endregion

}
}
}
